function Person(persons, pagination) {
    return new Vue({
        el: '#Persons',
        data: Object.assign({
            Persons: persons,
            Pagination: pagination,
            Dialog: {
                Info: '',
                CurrPerson: {
                    Id: '',
                    Name: '',
                    Instagram: '',
                    Vk: '',
                    Email: '',
                    TimeStamp: '',
                    TimeSending: ''
                },
                Error: {
                    ConditionBase: '',
                    Name: '',
                    Instagram: '',
                    Vk: '',
                    Email: ''
                },
                Find: {
                    View: false,
                    Name: '',
                    Instagram: '',
                    Vk: '',
                    Email: ''
                }
            }
        }),
        methods: {
            _clearValidDialog: function () {

                this.Dialog.Error.Name = this.Dialog.Error.Instagram = this.Dialog.Error.Vk = this.Dialog.Error.Email = this.Dialog.Error.ConditionBase = null;

                this.$refs.textfield_Name.classList.remove("is-invalid");
                this.$refs.textfield_Instagram.classList.remove("is-invalid");
                this.$refs.textfield_Vk.classList.remove("is-invalid");
                this.$refs.textfield_Email.classList.remove("is-invalid");
            },
            _isValidDialog: function () {

                if (this.Dialog.Error.Name) { this.$refs.textfield_Name.classList.add("is-invalid"); }
                if (this.Dialog.Error.Instagram) { this.$refs.textfield_Instagram.classList.add("is-invalid"); }
                if (this.Dialog.Error.Vk) { this.$refs.textfield_Vk.classList.add("is-invalid"); }
                if (this.Dialog.Error.Email) { this.$refs.textfield_Email.classList.add("is-invalid"); }
            },
            _getPage: function (page) {

                if (this.Dialog.Find.View === false) {
                    this.$http.post('/Person/Page', { Page: page, Size: this.Pagination.Size })
                        .then(response => {
                            this.Persons = response.body.Page.Items;
                            this.Pagination = response.body.Page.Pagination;
                        }, response => {
                            alert('error');
                        });
                } else {
                    this.find(page);
                }
            },
            addPerson: function () {

                this.$http.post('/Person/AddPerson',
                    {
                        Name: this.Dialog.CurrPerson.Name,
                        Instagram: this.Dialog.CurrPerson.Instagram,
                        Vk: this.Dialog.CurrPerson.Vk,
                        Email: this.Dialog.CurrPerson.Email,
                        TimeStamp: new Date().toISOString()
                    })
                    .then(response => {

                        if (response.body.Status.Code === "Error") {

                            if (response.body.Errors.length === 0) {
                                this.Dialog.Error.ConditionBase = response.body.Status.Message;
                            } else {

                                for (var i = 0; i < response.body.Errors.length; i++) {
                                    var mess = response.body.Errors[i].Message;

                                    if (response.body.Errors[i].Code === "Invalid_Instagraml") { this.Dialog.Error.Instagram = mess; continue; }
                                    if (response.body.Errors[i].Code === "Invalid_Email") { this.Dialog.Error.Email = mess; continue; }
                                    if (response.body.Errors[i].Code === "Invalid_Name") { this.Dialog.Error.Name = mess; continue; }
                                    if (response.body.Errors[i].Code === "Invalid_Vk") { this.Dialog.Error.Vk = mess; continue; }
                                    if (response.body.Errors[i].Code === "Сondition_Base") { this.Dialog.Error.ConditionBase = mess; continue; }
                                }
                            }
                                this._isValidDialog();
                        } else {
                            this.$refs.UpdatePersonDialog.close();
                            this._getPage(this.Pagination.Page);
                        }
                    }, response => {
                        alert(response);
                        this.$refs.UpdatePersonDialog.close();
                    });
            },
            addPersonDialog: function () {

                this._clearValidDialog();

                this.Dialog.Info = 'Добавить';
                this.Dialog.CurrPerson = Object.assign({}, {
                    Name: '',
                    Instagram: '',
                    Vk: '',
                    Email: '',
                    TimeStamp: ''
                });

                this.$refs.UpdatePersonDialog.showModal();
            },
            info: function (value) {

                alert(value);
            },
            sendPerson: function (value) {

                this.$http.post('/Person/SendPerson', { Id: value.Id })
                    .then(response => {
                        this._getPage(this.Pagination.Page);
                    }, response => {
                        if (response.status === 401) {
                            location.reload();
                        } else {
                            alert(response);
                        }

                    });
            },
            removePerson: function (value) {

                this.$http.post('/Person/DeletePerson', { Id: this.Dialog.CurrPerson.Id })
                    .then(response => {
                        this._getPage(this.Pagination.Page);

                    }, response => {
                        alert('error');
                    });

                this.$refs.RemovePersonDialog.close();
            },
            removePersonDialog: function (value) {

                this.Dialog.Info = 'Уверены ли вы ? Что хотите удалить </br> ' + value.Name;
                this.Dialog.CurrPerson = Object.assign({}, value);

                this.$refs.RemovePersonDialog.showModal();
            },
            updateAndAddPerson: function () {

                this._clearValidDialog();

                if (this.Dialog.Info === 'Добавить') {
                    this.addPerson();
                }
                if (this.Dialog.Info === 'Изменить') {
                    this.updatePerson();
                }
            },
            updatePersonDialog: function (value) {

                this._clearValidDialog();

                this.Dialog.Info = 'Изменить';
                this.Dialog.CurrPerson = Object.assign({}, value);

                this.$refs.UpdatePersonDialog.showModal();
            },
            updatePerson: function () {

                this.$http.post('/Person/UpdatePerson', this.Dialog.CurrPerson)
                    .then(response => {
                        if (response.body.Status.Code === "Error") {

                            if (response.body.Errors.length === 0) {
                                this.Dialog.Error.ConditionBase = response.body.Status.Message;
                            } else {

                                for (var i = 0; i < response.body.Errors.length; i++) {
                                    var mess = response.body.Errors[i].Message;

                                    if (response.body.Errors[i].Code === "Invalid_Instagraml") { this.Dialog.Error.Instagram = mess; continue; }
                                    if (response.body.Errors[i].Code === "Invalid_Email") { this.Dialog.Error.Email = mess; continue; }
                                    if (response.body.Errors[i].Code === "Invalid_Name") { this.Dialog.Error.Name = mess; continue; }
                                    if (response.body.Errors[i].Code === "Invalid_Vk") { this.Dialog.Error.Vk = mess; continue; }
                                    if (response.body.Errors[i].Code === "Сondition_Base") { this.Dialog.Error.ConditionBase = mess; continue; }
                                }
                            }
                            this._isValidDialog();
                        } else {
                            this._getPage(this.Pagination.Page);
                            this.$refs.UpdatePersonDialog.close();
                        }
                    }, response => {
                        alert(response);
                        this.$refs.UpdatePersonDialog.close();
                    });
            },
            dialogFindView: function (value) {

                if (this.Dialog.Find.View) {
                    this.Pagination.Size = 10;
                    this.Dialog.Find.View = !value;
                    this.clearFindDialog();
                }
                else { this.Dialog.Find.View = !value; }
            },
            find: function (page) {

                this.$http.post('/Person/FindPerson',
                    { instagramFind: this.Dialog.Find, pageRequest: { Page: page, Size: this.Pagination.Size } })
                    .then(response => {
                        this.Persons = response.body.Page.Items;
                        this.Pagination = response.body.Page.Pagination;
                    }, response => {
                        alert('Error');
                    });
            },
            clearFindDialog: function () {

                this.Dialog.Find.Name = this.Dialog.Find.Instagram = this.Dialog.Find.Vk = this.Dialog.Find.Email = '';
                this._getPage(1);
            }
        },
        components: {},
        filters: {
            formatDate: function (value) {
                if (value) {
                    return moment(value).format('DD-MM-YYYY HH:mm:ss');
                }
            },
            formatUrl(value) {
                var url = new URL(value);
                var result = url.pathname;

                if (result === '/')
                    return null;
                else
                    return result.substring(1, result.length);
            }
        },
        directives: {
            'mdl-textfield': {
                // определение директивы
                componentUpdated(el, binding, vnode) {
                    if (!(typeof el.MaterialTextfield === 'undefined')) {
                        if (el.MaterialTextfield.input_.value.length > 0)
                            el.MaterialTextfield.checkDirty();
                        else
                            el.MaterialTextfield.change();
                    }
                }
            }
        }
    });
}
