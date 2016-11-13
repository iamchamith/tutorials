/// <reference path="../typescript/kendo.all.d.ts" />
/// <reference path="../typescript/jquery.d.ts" />
var Master;
(function (Master) {
    $(function () {
        init.initControllers();
    });
    var init = {
        initControllers: function () {
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
    };
    var emp = (function () {
        var baseurl = "";
        function apiConnector(action, e, method) {
            var defer = $.Deferred();
            $.ajax(baseurl + action, { data: e, method: method, success: function (e) { defer.resolve(e); } });
            return defer;
        }
        return {
            readEmployees: function (e) {
                var data = {};
                apiConnector('Select', data, 'post').done(function () {
                    console.log(e);
                });
            },
            updateEmployee: function (e) {
                var data = {};
                apiConnector('Update', data, 'post').done(function () {
                    console.log(e);
                });
            },
            deleteEmployee: function (e) {
                var data = {};
                apiConnector('Delete', data, 'post').done(function () {
                    console.log(e);
                });
            },
            readEmployee: function (e) {
                var data = {};
                apiConnector('Select', data, 'post').done(function () {
                    console.log(e);
                });
            },
            createEmpoyee: function (e) {
                var data = {};
                apiConnector('Create', data, 'post').done(function () {
                    console.log(e);
                });
            },
            renderEmployeeModelTemplate: function () { }
        };
    })();
})(Master || (Master = {}));
//# sourceMappingURL=master.js.map