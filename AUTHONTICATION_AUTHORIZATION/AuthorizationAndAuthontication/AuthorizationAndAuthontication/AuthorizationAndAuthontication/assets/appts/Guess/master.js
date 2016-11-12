var Guess;
(function (Guess) {
    var base = '/api/Guest/';
    $(function () {
        maintainLayout.init();
    });
    var maintainLayout = {
        init: function (e) {
            maintainLayout.initControllers();
            api.readUserRoles();
        },
        initControllers: function (e) {
            $('#btnLogin').on('click', function () { api.login(); });
            $('#btnForgetPassword').on('click', function () { api.forgetPassword(); });
            $('#btnResendForgetPasswordTokenEmail').on('click', function () { api.resendForgetPasswordTokenToEmail(); });
            $('#btnRegister').on('click', function () { api.register(); });
            $('#btnResendEmail').on('click', function () { api.resendRegisterTokenToEmail(); });
            $('#btnLogOut').on('click', function () { api.logout(); });
            $('#ddUserRole').kendoComboBox({
                dataTextField: "RoleId",
                dataValueField: "RoleId"
            });
        },
    };
    var api = {
        readUserRoles: function () {
            new apiConnector().callservice(base + 'UserRoles', null, webMethod.Get).done(function (e) {
                console.log(JSON.stringify(e));
                $('#ddUserRole').data("kendoComboBox").setDataSource(new kendo.data.DataSource({ data: e.content }));
            });
        },
        login: function (e) {
            new apiConnector().callservice(base + 'LoginProcess', { Email: $('#txtLoginEmail').val(), Password: $('#txtLoginPassword').val() }, webMethod.Post).done(function (e) {
                alert(JSON.stringify(e));
            });
        },
        register: function () {
            new apiConnector().callservice(base + 'RegisterProcess', { Name: $('#txtName').val(), Email: $('#txtRegisterEmail').val(), Password: $('#txtRegisterPassword').val(), UserTypeInfo: $('#ddUserRole').data("kendoComboBox").value() }, webMethod.Post).done(function (e) {
                alert(JSON.stringify(e));
            });
        },
        forgetPassword: function () {
            new apiConnector().callservice(base + 'ForgertPasswordRequest', { email: $('#txtForgetPasswordEmail').val() }, webMethod.Post).done(function (e) {
                alert(JSON.stringify(e));
            });
        },
        resendRegisterTokenToEmail: function () {
            new apiConnector().callservice(base + 'ResendValidateEmailToken', { email: $('#txtRegisterEmail').val() }, webMethod.Post).done(function (e) {
                alert(JSON.stringify(e));
            });
        },
        resendForgetPasswordTokenToEmail: function () {
            new apiConnector().callservice(base + 'ResendForgetPasswordToken', { email: $('#txtForgetPasswordEmail').val() }, webMethod.Post).done(function (e) {
                alert(JSON.stringify(e));
            });
        },
        logout: function () {
            new apiConnector().callservice(base + 'LogOut', null, webMethod.Post).done(function (e) {
                alert(JSON.stringify(e));
            });
        }
    };
    (function (webMethod) {
        webMethod[webMethod["Get"] = 0] = "Get";
        webMethod[webMethod["Post"] = 1] = "Post";
    })(Guess.webMethod || (Guess.webMethod = {}));
    var webMethod = Guess.webMethod;
    var apiConnector = (function () {
        function apiConnector() {
        }
        apiConnector.prototype.callservice = function (url, data, method) {
            var dfd = jQuery.Deferred();
            $.ajax({
                url: url,
                method: (method == webMethod.Get) ? "GET" : "POST",
                contentType: "application/json; charset=utf-8",
                data: (method == webMethod.Get) ? data : JSON.stringify(data),
                dataType: "json",
                cache: false,
                success: function (data) {
                    var value = data;
                    dfd.resolve(value);
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(textStatus);
                    dfd.reject();
                }
            });
            return dfd;
        };
        return apiConnector;
    }());
    Guess.apiConnector = apiConnector;
})(Guess || (Guess = {}));
//# sourceMappingURL=master.js.map