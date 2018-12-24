function Instagram(persons, pagination) {
    return new Vue({
        el: '#Instagram',
        data: Object.assign({
            Persons: persons,
            Pagination: pagination,
            Dialog: {
                Info: '',
                CurrPerson: {
                    Id: '',
                    FIO: '',
                    URL: '',
                    EndPoint: '',
                    TimeStamp: ''
                }
            }
        }),
        methods: {
            _getPage: function (page) {
                //this.ajaxRequest = true;
                this.$http.post('/Home/Page', { Page: page, Size: this.Pagination.Size })
                    .then(response => {
                        this.Persons = response.body.Items;
                        this.Pagination = response.body.Pagination;

                        //location.reload();
                    }, response => {
                        alert('error');
                    });
            },
            addPerson: function () {
                //this.ajaxRequest = false;

                this.$http.post('/Home/AddPerson',
                    { FIO: this.Dialog.CurrPerson.FIO, URL: this.Dialog.CurrPerson.URL, EndPoint: this.Dialog.CurrPerson.EndPoint, TimeStamp: new Date().toISOString() })
                    .then(response => {

                        //// get status
                        //alert(response.status);

                        //// get status text
                        //alert(response.statusText);

                        //// get 'Expires' header
                        //alert(response.headers.get('Expires'));

                        //// get body data
                        //alert(response.body);
                        this._getPage(this.Pagination.Page);

                        //location.reload();

                    }, response => {
                        alert('error');
                    });
            },
            addPersonDialog: function () {

                this.Dialog.Info = 'Добавить';
                this.Dialog.CurrPerson = Object.assign({}, {
                    FIO: '',
                    URL: '',
                    EndPoint: '',
                    TimeStamp: ''
                });

                this.$refs.UpdatePersonDialog.showModal();
            },
            info: function (value) {
                alert(value);
            },
            removePerson: function (value) {
                this.$http.post('/Home/DeletePerson', { Id: this.Dialog.CurrPerson.Id })
                    .then(response => {
                        //location.reload();
                        this._getPage(this.Pagination.Page);
                    }, response => {
                        alert('error');
                    });

                this.$refs.RemovePersonDialog.close();
            },
            removePersonDialog: function (value) {

                this.Dialog.Info = 'Уверены ли вы ? Что хотите удалить </br> ' + value.FIO;
                this.Dialog.CurrPerson = Object.assign({}, value);

                this.$refs.RemovePersonDialog.showModal();
            },
            updateAndAddPerson: function () {

                if (this.Dialog.Info === 'Добавить') {
                    this.addPerson();
                }
                if (this.Dialog.Info === 'Изменить') {
                    this.updatePerson();
                }

                this.$refs.UpdatePersonDialog.close();
            },
            updatePersonDialog: function (value) {

                this.Dialog.Info = 'Изменить';
                this.Dialog.CurrPerson = Object.assign({}, value);

                this.$refs.UpdatePersonDialog.showModal();
            },
            updatePerson: function () {

                this.$http.post('/Home/UpdatePerson', this.Dialog.CurrPerson)
                    .then(response => {
                        //location.reload();
                        this._getPage(this.Pagination.Page);
                    }, response => {
                        alert('error');
                    });
            }
        },
        components: {},
        filters: {
            formatDate: function (value) {
                if (value) {
                    return moment(value).format('DD-MM-YYYY HH:mm:ss');
                }
            },
            endPointFilter: function (value) {
                if (value) {
                    switch (value) {
                        case 1:
                            return 'Instagram';
                        case 2:
                            return 'VK';
                        case 3:
                            return 'Email';
                        default:
                            return value;
                    }
                }
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

 // Material Design Lite directive

    //Vue.directive('mdl-textfield', {
    //    bind(el, binding, vnode) {},
    //    update(el, binding, vnode) {},
    //    unbind(el, binding, vnode) {},
    //    componentUpdated(el, binding, vnode) {}
    //});

    //Vue.http.options.emulateJSON = true;

    //$(document).ready(function () {})