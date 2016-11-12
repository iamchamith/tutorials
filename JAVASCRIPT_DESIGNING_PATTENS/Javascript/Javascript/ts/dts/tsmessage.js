/// <reference path="jquery.d.ts" />
/// <reference path="kendo.all.d.ts" />
/// <reference path="helpers_ts.ts" />
/// <reference path="notifyjs.d.ts" />
var TsMessage;
(function (TsMessage) {
    function ShowError(displayMessage, eventXhr) {
        Show(displayMessage, MessageType.Error);
        TownsuiteHelpers.Redirect(eventXhr);
    }
    TsMessage.ShowError = ShowError;
    function ShowSuccess(displayMessage, pos) {
        Show(displayMessage, MessageType.Success, pos);
    }
    TsMessage.ShowSuccess = ShowSuccess;
    function ShowInformation(displayMessage) {
        Show(displayMessage, MessageType.Information);
    }
    TsMessage.ShowInformation = ShowInformation;
    function ShowWarning(displayMessage) {
        Show(displayMessage, MessageType.Warning);
    }
    TsMessage.ShowWarning = ShowWarning;
    function Show(displayMessage, messagetype, pos) {
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
    TsMessage.Show = Show;
    function Hide() {
        $("#notification").html("");
        $("#notification").hide();
    }
    TsMessage.Hide = Hide;
    function ShowAdmin(error, messagetype) {
        Show(error, messagetype);
    }
    TsMessage.ShowAdmin = ShowAdmin;
    function HideAdmin() {
        Hide();
    }
    TsMessage.HideAdmin = HideAdmin;
    (function (MessageType) {
        MessageType[MessageType["Error"] = 0] = "Error";
        MessageType[MessageType["Success"] = 1] = "Success";
        MessageType[MessageType["Warning"] = 2] = "Warning";
        MessageType[MessageType["Information"] = 3] = "Information";
    })(TsMessage.MessageType || (TsMessage.MessageType = {}));
    var MessageType = TsMessage.MessageType;
    function SetTownMessage(theMessage, hideHelpLinks) {
        document.title = theMessage;
        $("#breadcrumb").show();
        $("#breadcrumbli").html(theMessage);
        $("#HelpCenterLink").attr("href", "/helpcenter?HelpCenterType=" + encodeURIComponent(theMessage));
        if (hideHelpLinks == HelpLinks.Hide) {
            $("#HelpCenterLink").hide();
        }
    }
    TsMessage.SetTownMessage = SetTownMessage;
    (function (HelpLinks) {
        HelpLinks[HelpLinks["Hide"] = 0] = "Hide";
        HelpLinks[HelpLinks["Show"] = 1] = "Show";
    })(TsMessage.HelpLinks || (TsMessage.HelpLinks = {}));
    var HelpLinks = TsMessage.HelpLinks;
})(TsMessage || (TsMessage = {}));
//# sourceMappingURL=tsmessage.js.map