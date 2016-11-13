/// <reference path="../typescript/kendo.all.d.ts" />
/// <reference path="../typescript/jquery.d.ts" />
module Master {
    $(() => {
        init.initControllers();
    });
    var init = {

        initControllers: () => {

            alert();
            $("#grid").kendoGrid({

                columns: [
                    {
                        field: "ContactTitle",
                        title: "Contact Title"
                    }, {
                        field: "CompanyName",
                        title: "Company Name"
                    }, {
                        field: "Country",
                        width: 150
                    }]
            });

        }

    }

    var emp = (function () {
        var baseurl = "";
        function apiConnector(action: string, e: any, method: string) {
            var defer = $.Deferred();
            $.ajax(baseurl + action, { data: e, method: method, success: (e) => { defer.resolve(e) } });
            return defer;
        }
        return {
            readEmployees: (e?) => {
                var data = {

                };
                apiConnector('Select', data, 'post').done(() => {
                    console.log(e);
                });
            },
            updateEmployee: (e?) => {
                var data = {

                };
                apiConnector('Update', data, 'post').done(() => {
                    console.log(e);
                });
            },
            deleteEmployee: (e?) => {
                var data = {

                };
                apiConnector('Delete', data, 'post').done(() => {
                    console.log(e);
                });
            },
            readEmployee: (e?) => {
                var data = {

                };
                apiConnector('Select', data, 'post').done(() => {
                    console.log(e);
                });
            },
            createEmpoyee: (e?) => {
                var data = {

                };
                apiConnector('Create', data, 'post').done(() => {
                    console.log(e);
                });
            },
            renderEmployeeModelTemplate: () => { }
        }

    })();
 
}