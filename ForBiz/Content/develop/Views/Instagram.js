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
                    Fio: '',
                    Url: '',
                    EndPoint: '',
                    TimeStamp: ''
                }
            },
            DialogFind:
            {
                View: false,
                Fio: '',
                Url: '',
                EndPoint: 0
            }
        }),
        methods: {
            _getPage: function (page) {

                if (this.DialogFind.View === false) {
                    this.$http.post('/Home/Page', { Page: page, Size: this.Pagination.Size })
                        .then(response => {
                            this.Persons = response.body.Page.Items;
                            this.Pagination = response.body.Page.Pagination;
                        }, response => {
                            alert('error');
                        });
                } else {
                    var t = 1;
                }

                
            },
            addPerson: function () {
                this.$http.post('/Home/AddPerson',
                    { Fio: this.Dialog.CurrPerson.Fio, Url: this.Dialog.CurrPerson.Url, EndPoint: this.Dialog.CurrPerson.EndPoint, TimeStamp: new Date().toISOString() })
                    .then(response => {
                        this._getPage(this.Pagination.Page);

                    }, response => {
                        alert('error');
                    });
            },
            addPersonDialog: function () {

                this.Dialog.Info = 'Добавить';
                this.Dialog.CurrPerson = Object.assign({}, {
                    Fio: '',
                    Url: '',
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
                        this._getPage(this.Pagination.Page);

                    }, response => {
                        alert('error');
                    });

                this.$refs.RemovePersonDialog.close();
            },
            removePersonDialog: function (value) {

                this.Dialog.Info = 'Уверены ли вы ? Что хотите удалить </br> ' + value.Fio;
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
                        this._getPage(this.Pagination.Page);

                    }, response => {
                        alert('error');
                    });
            },
            dialogFindView: function (value) {
                this.DialogFind.View = !value;
            },
            dialogFindClear: function () {
                this.DialogFind.Fio = this.DialogFind.Url = this.DialogFind.EndPoint = '';
                this._getPage(1);
            },
            dialogFind: function () {
                this.$http.post('/Home/FindPerson', this.DialogFind).then(response => {
                    this.Persons = response.body.Page.Items;
                    this.Pagination = response.body.Page.Pagination;
                }, response => {
                    alert('Error');
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