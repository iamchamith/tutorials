var Master;
(function (Master) {
    $(function () {
        initPage();
        emp.readAll();
    });
    function initPage() {
        $("#grid").kendoGrid({
            selectable: "multiple cell",
            allowCopy: true,
            columns: [
                { field: "Id" },
                { field: "Name" },
                { field: "Email" },
                { field: "Phone" },
                {
                    width: 250,
                    title: "Actions",
                    command: [
                        {
                            name: "details",
                            click: function (e) {
                                e.preventDefault();
                                var tr = $(e.target).closest("tr");
                                var data = $('#grid').data('kendoGrid').dataItem(tr);
                                var d;
                                d = data;
                                console.log("Id: " + d.Id);
                                emp.read(d.Id);
                            }
                        },
                        {
                            name: "Delete",
                            click: function (e) {
                                e.preventDefault();
                                var tr = $(e.target).closest("tr");
                                var data = $('#grid').data('kendoGrid').dataItem(tr);
                                var d;
                                d = data;
                                console.log("Id: " + d.Id);
                                emp.delete(d.Id);
                            }
                        } // built-in "destroy" command
                    ]
                }
            ]
        });
        $('#btnOpenModel').on('click', function () {
            render({
                titile: 'Create Employee',
                name: "",
                phone: "",
                regDate: kendo.toString(new Date(), "")
            }, 'c');
        });
    }
    function render(e, mode) {
        var viewModel = kendo.observable({
            titile: e.titile,
            name: e.name,
            email: e.email,
            phone: e.phone,
            regDate: e.regDate,
            id: 0
        });
        var templateContent = $("#employee-template").html();
        var template = kendo.template(templateContent);
        $("#model-content").html(template); //append the result to the page
        $('#model_main').modal('show').appendTo('body');
        kendo.bind($("#model-content"), viewModel);
        $('#btnSave').data(mode);
        $('#btnSave').on('click', function () {
            if (mode === 'c') {
                emp.create();
            }
            else {
                emp.update();
            }
        });
    }
    var emp = (function () {
        var baseUrl = "http://localhost:11296/api/Employee/";
        function apiConnector(action, data, method) {
            var defer = $.Deferred();
            $.ajax({
                url: baseUrl + action,
                data: (method === 'get') ? data : JSON.stringify(data),
                method: method,
                dataType: 'json',
                type: method,
                contentType: "application/json; charset=utf-8",
                success: function (e) { defer.resolve(e); }
            });
            return defer;
        }
        return {
            create: function (e) {
                swal({
                    title: "Are you sure?",
                    text: "Do you want to create new employee",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes",
                    closeOnConfirm: false
                }, function () {
                    var data = {
                        Name: $('#txtName').val(),
                        Email: $('#txtEmail').val(),
                        Phone: $('#txtPhone').val()
                    };
                    apiConnector('Create', data, 'post').done(function (e) {
                        console.log(e);
                        var d;
                        d = e;
                        if (d.State) {
                            swal("Created!", "", "success");
                            emp.readAll();
                        }
                        else {
                            swal("Created!", "", "error");
                        }
                    });
                });
            },
            update: function (e) {
                swal({
                    title: "Are you sure?",
                    text: "Do you want to update employee",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes",
                    closeOnConfirm: false
                }, function () {
                    var data = {
                        Name: $('#txtName').val(),
                        Email: $('#txtEmail').val(),
                        Phone: $('#txtPhone').val(),
                        key: $('#hndId').val()
                    };
                    apiConnector('Update', data, 'post').done(function (e) {
                        console.log(e);
                        var d;
                        d = e;
                        if (d.State) {
                            swal("Updated!", "", "success");
                            emp.readAll();
                        }
                        else {
                            swal("Error!", "", "error");
                        }
                    });
                });
            },
            delete: function (e) {
                swal({
                    title: "Are you sure?",
                    text: "Do you want to delete employee",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes",
                    closeOnConfirm: false
                }, function () {
                    apiConnector('Delete', { Key: e }, 'delete').done(function (e) {
                        console.log(e);
                        var d;
                        d = e;
                        if (d.State) {
                            swal("Deleted!", "", "success");
                            emp.readAll();
                        }
                        else {
                            swal("Error!", "", "error");
                        }
                    });
                });
            },
            read: function (e) {
                apiConnector('read?key=' + e, null, 'get').done(function (e) {
                    var d;
                    d = e;
                    render({
                        titile: 'Update Employee',
                        name: d.Content.Name,
                        phone: d.Content.Phone,
                        email: d.Content.Email,
                        regDate: kendo.toString(new Date(), ""),
                        id: d.Content.Id
                    }, 'u');
                    console.log(e);
                });
            },
            readAll: function (e) {
                apiConnector('read', null, 'get').done(function (d) {
                    console.log(d);
                    var x;
                    x = d;
                    $("#grid").data("kendoGrid").setDataSource(new kendo.data.DataSource({ data: x.Content }));
                });
            },
            search: function (e) {
                var data = {};
                apiConnector('', data, 'post').done(function (e) {
                    console.log();
                });
            }
        };
    })();
})(Master || (Master = {}));
