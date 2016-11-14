module Master {

    $(() => {

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
                            click: (e) => {
                                e.preventDefault();
                                var tr = $(e.target).closest("tr");
                                var data = $('#grid').data('kendoGrid').dataItem(tr);
                                var d: any;
                                d = data;
                                console.log("Id: " + d.Id);
                                emp.read(d.Id)
                            }
                        },
                        {
                            name: "Delete",
                            click: (e) => {
                                e.preventDefault();
                                var tr = $(e.target).closest("tr");
                                var data = $('#grid').data('kendoGrid').dataItem(tr);
                                var d: any;
                                d = data;
                                console.log("Id: " + d.Id);
                                emp.delete(d.Id)
                            }
                        } // built-in "destroy" command
                    ]
                }
            ]
        });

        $('#btnOpenModel').on('click', () => {

            render({
                titile: 'Create Employee',
                name: "",
                phone: "",
                regDate: kendo.toString(new Date(), "")
            }, 'c');

        });

    }

    function render(e: any, mode: string) {
        var viewModel = kendo.observable({
            titile: e.titile,
            name: e.name,
            email: e.email,
            phone: e.phone,
            regDate: e.regDate,
            id : 0
        });

        var templateContent = $("#employee-template").html();
        var template = kendo.template(templateContent);

        $("#model-content").html(template); //append the result to the page

        $('#model_main').modal('show').appendTo('body');
        kendo.bind($("#model-content"), viewModel);

        $('#btnSave').data(mode)

        $('#btnSave').on('click', () => {
            if (mode === 'c') {
                emp.create();
            } else {
                emp.update();
            }
        });
    }

    var emp = (function () {

        const baseUrl = "http://localhost:11296/api/Employee/";
        function apiConnector(action: string, data: any, method: string) {
 
            var defer = $.Deferred();
            $.ajax({
                url: baseUrl + action,
                data: (method === 'get') ? data : JSON.stringify(data),
                method: method,
                dataType: 'json',
                type:method,
                contentType: "application/json; charset=utf-8",
                success: (e) => { defer.resolve(e) }
            });
            return defer;

        }

        return {
            create: (e?) => {

                swal({
                    title: "Are you sure?",
                    text: "Do you want to create new employee",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes",
                    closeOnConfirm: false
                },
                    function () {
                        var data = {
                            Name: $('#txtName').val(),
                            Email: $('#txtEmail').val(),
                            Phone: $('#txtPhone').val()
                        }
                        apiConnector('Create', data, 'post').done((e) => {
                            console.log(e);
                            var d: any;
                            d = e;
                            if (d.State) {
                                swal("Created!", "", "success");
                                emp.readAll();
                            } else {
                                swal("Created!", "", "error");
                            }
                        });
                    });
            },
            update: (e?) => {

                swal({
                    title: "Are you sure?",
                    text: "Do you want to update employee",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes",
                    closeOnConfirm: false
                },
                    function () {
                        var data = {
                            Name: $('#txtName').val(),
                            Email: $('#txtEmail').val(),
                            Phone: $('#txtPhone').val(),
                            key: $('#hndId').val()
                        }
                        apiConnector('Update', data, 'post').done((e) => {
                            console.log(e);
                            var d: any;
                            d = e;
                            if (d.State) {
                                swal("Updated!", "", "success");
                                emp.readAll();
                            } else {
                                swal("Error!", "", "error");
                            }
                        });
                    });
            },
            delete: (e?) => {

                swal({
                    title: "Are you sure?",
                    text: "Do you want to delete employee",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes",
                    closeOnConfirm: false
                },
                    function () {

                        apiConnector('Delete', { Key: e }, 'delete').done((e) => {
                            console.log(e);
                            var d: any;
                            d = e;
                            if (d.State) {
                                swal("Deleted!", "", "success");
                                emp.readAll();
                            } else {
                                swal("Error!", "", "error");
                            }
                        });

                    });
            },
            read: (e?) => {
                apiConnector('read?key=' + e, null, 'get').done((e) => {
                    var d: any;
                    d = e;
                    render({
                        titile: 'Update Employee',
                        name: d.Content.Name,
                        phone: d.Content.Phone,
                        email: d.Content.Email,
                        regDate: kendo.toString(new Date(), ""),
                        id : d.Content.Id
                    }, 'u');
                    console.log(e);
                });
            },
            readAll: (e?) => {
                apiConnector('read', null, 'get').done((d) => {
                    console.log(d);
                    var x: any;
                    x = d;
                    $("#grid").data("kendoGrid").setDataSource(new kendo.data.DataSource({ data: x.Content }));
                });
            },
            search: (e?) => {
                var data = {}
                apiConnector('', data, 'post').done((e) => {
                    console.log();
                });
            }
        }

    })();

}