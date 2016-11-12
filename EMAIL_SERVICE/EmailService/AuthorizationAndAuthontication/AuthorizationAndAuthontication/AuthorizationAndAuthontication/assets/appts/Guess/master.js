var Guess;
(function (Guess) {
    var base = '';
    var maintainLayout = {
        init: function (e) { },
        initControllers: function (e) {
            $('#btnLogin').on('click', function () { api.login(); });
            $('#btnForgetPassword').on('click', function () { api.forgetPassword(); });
            $('#btnRegister').on('click', function () { api.register(); });
        },
    };
    var api = {
        login: function (e) {
            new apiConnector().callservice(base + 'LoginProcess', { Email: $('txtLoginEmail').val(), Password: $('txtLoginPassword').val() }, webMethod.Post).done(function (e) {
                alert(e);
            });
        },
        register: function () {
            new apiConnector().callservice(base + 'RegisterProcess', { Name: $('#txtName').val(), Email: $('txtRegisterEmail').val(), Password: $('txtRegisterPassword').val() }, webMethod.Post).done(function (e) {
                alert(e);
            });
        },
        forgetPassword: function () {
            new apiConnector().callservice(base + 'ForgertPasswordRequest', { email: $('#txtForgetPasswordEmail').val() }, webMethod.Post).done(function (e) {
                alert(e);
            });
        },
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
