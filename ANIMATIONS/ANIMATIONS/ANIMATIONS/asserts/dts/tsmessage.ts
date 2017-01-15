/// <reference path="jquery.d.ts" />
/// <reference path="kendo.all.d.ts" />
/// <reference path="helpers_ts.ts" />
/// <reference path="notifyjs.d.ts" />

module TsMessage {

    export function ShowError(displayMessage: string, eventXhr?) {
        Show(displayMessage, MessageType.Error);
        TownsuiteHelpers.Redirect(eventXhr);
    }

    export function ShowSuccess(displayMessage: string, pos?: string) {
        Show(displayMessage, MessageType.Success, pos);
    }

    export function ShowInformation(displayMessage: string) {
        Show(displayMessage, MessageType.Information);
    }

    export function ShowWarning(displayMessage: string) {
        Show(displayMessage, MessageType.Warning);
    }

    export function Show(displayMessage: string, messagetype: MessageType, pos?: string) {

        if (messagetype == MessageType.Error) {
            $.notify(displayMessage, {
                statis: "danger",
                pos: "bottom-right"
            });
        }
        else if (messagetype == MessageType.Success) {
            $.notify(displayMessage, {
                status: "success",
                pos: pos == null || pos.length === 0 ? "bottom-right" : pos
            });
        }
        else if (messagetype == MessageType.Warning) {
            $.notify(displayMessage, {
                status: "warning",
                pos: "bottom-right"
            });
        }
        else if (messagetype == MessageType.Information) {
            $.notify(displayMessage, {
                status: "info",
                pos: "bottom-right"
            });
        }

    }

    export function Hide() {
        $("#notification").html("");
        $("#notification").hide();
    }

    export function ShowAdmin(error: string, messagetype: MessageType) {
        Show(error, messagetype);
    }

    export function HideAdmin() {
        Hide();
    }

    export enum MessageType {
        Error = 0,
        Success = 1,
        Warning = 2,
        Information = 3
    }


    export function SetTownMessage(theMessage: string, hideHelpLinks: HelpLinks) {
        document.title = theMessage;
        $("#breadcrumb").show();
        $("#breadcrumbli").html(theMessage);
        $("#HelpCenterLink").attr("href", "/helpcenter?HelpCenterType=" + encodeURIComponent(theMessage));
        if (hideHelpLinks == HelpLinks.Hide) {
            $("#HelpCenterLink").hide();
        }
    }

    export enum HelpLinks {
        Hide = 0,
        Show = 1
    }
}