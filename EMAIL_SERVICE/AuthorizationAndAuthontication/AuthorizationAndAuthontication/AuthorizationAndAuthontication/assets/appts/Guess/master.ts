module Guess {

    const base = '';
    var maintainLayout = {

        init: (e?) => { },
        initControllers: (e?) => {

            $('#btnLogin').on('click', () => { api.login(); });
            $('#btnForgetPassword').on('click', () => { api.forgetPassword(); });
            $('#btnRegister').on('click', () => { api.register(); });
        },
    }
    var api = {
        login: (e?) => {
            new apiConnector().callservice(base + 'LoginProcess', { Email: $('txtLoginEmail').val(), Password: $('txtLoginPassword').val() }, webMethod.Post).done((e) => {
                alert(e);
            });
        },
        register: () => {
            new apiConnector().callservice(base + 'RegisterProcess', { Name: $('#txtName').val(), Email: $('txtRegisterEmail').val(), Password: $('txtRegisterPassword').val() }, webMethod.Post).done((e) => {
                alert(e);
            });
        },
        forgetPassword: () => {
            new apiConnector().callservice(base + 'ForgertPasswordRequest', { email: $('#txtForgetPasswordEmail').val() }, webMethod.Post).done((e) => {
                alert(e);
            });
        },
    }

    export enum webMethod {
        Get = 0,
        Post = 1
    }

    export class apiConnector {

        callservice(url: string, data: any, method: webMethod): JQueryDeferred<any> {
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
        }
    }
}