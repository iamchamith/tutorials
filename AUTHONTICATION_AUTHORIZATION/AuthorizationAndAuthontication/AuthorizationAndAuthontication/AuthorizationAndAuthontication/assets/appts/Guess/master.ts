module Guess {

    const base = '/api/Guest/';
    $(() => {
        maintainLayout.init();

    });
    var maintainLayout = {

        init: (e?) => {
            maintainLayout.initControllers();
            api.readUserRoles();

        },
        initControllers: (e?) => {

            $('#btnLogin').on('click', () => { api.login(); });

            $('#btnForgetPassword').on('click', () => { api.forgetPassword(); });
            $('#btnResendForgetPasswordTokenEmail').on('click', () => { api.resendForgetPasswordTokenToEmail() });

            $('#btnRegister').on('click', () => { api.register(); });
            $('#btnResendEmail').on('click', () => { api.resendRegisterTokenToEmail() });
        
            $('#btnLogOut').on('click', () => { api.logout(); });
            $('#ddUserRole').kendoComboBox({
                dataTextField: "RoleId",
                dataValueField: "RoleId"

            });
        },
    }
    var api = {
        readUserRoles: () => {
            new apiConnector().callservice(base + 'UserRoles', null, webMethod.Get).done((e) => {
                console.log(JSON.stringify(e));
                $('#ddUserRole').data("kendoComboBox").setDataSource(new kendo.data.DataSource({ data: e.content }));
            });

        },
        login: (e?) => {
            new apiConnector().callservice(base + 'LoginProcess', { Email: $('#txtLoginEmail').val(), Password: $('#txtLoginPassword').val() }, webMethod.Post).done((e) => {
                alert(JSON.stringify(e));
            });
        },
        register: () => {
            new apiConnector().callservice(base + 'RegisterProcess', { Name: $('#txtName').val(), Email: $('#txtRegisterEmail').val(), Password: $('#txtRegisterPassword').val(), UserTypeInfo: $('#ddUserRole').data("kendoComboBox").value() }, webMethod.Post).done((e) => {
                alert(JSON.stringify(e));
            });
        },
        forgetPassword: () => {
            new apiConnector().callservice(base + 'ForgertPasswordRequest', { email: $('#txtForgetPasswordEmail').val() }, webMethod.Post).done((e) => {
                alert(JSON.stringify(e));
            });
        },
        resendRegisterTokenToEmail: () => {
            new apiConnector().callservice(base + 'ResendValidateEmailToken', { email: $('#txtRegisterEmail').val() }, webMethod.Post).done((e) => {
                alert(JSON.stringify(e));
            });
        },
        resendForgetPasswordTokenToEmail: () => {
            new apiConnector().callservice(base + 'ResendForgetPasswordToken', { email: $('#txtForgetPasswordEmail').val() }, webMethod.Post).done((e) => {
                alert(JSON.stringify(e));
            });
        },
        logout: () => {
            new apiConnector().callservice(base + 'LogOut', null, webMethod.Post).done((e) => {
                alert(JSON.stringify(e));
            });
        }
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