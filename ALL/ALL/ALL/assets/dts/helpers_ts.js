/// <reference path="jquery.d.ts" />
/// <reference path="jquery.fitvids.d.ts" />
/// <reference path="moment.d.ts"/>
var TownsuiteHelpers;
(function (TownsuiteHelpers) {
    var t;
    // Helper functions to redirect to login page
    function Redirect(e) {
        if (e.status == 302) {
            document.location.href = "/login";
        }
        else if (e.status == 301) {
            document.location.href = "/noaccess";
        }
        else if (e.status == 503) {
            document.location.href = "/login?Maintenance=true";
        }
    }
    TownsuiteHelpers.Redirect = Redirect;
    // Helper functions to Encode the URI
    function EncodeURIC(str) {
        return encodeURIComponent(str);
    }
    TownsuiteHelpers.EncodeURIC = EncodeURIC;
    // Helper functions to Decode the URI
    function DecodeURIC(str) {
        return decodeURIComponent(str.toString());
    }
    TownsuiteHelpers.DecodeURIC = DecodeURIC;
    function readCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ')
                c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) {
                return c.substring(nameEQ.length, c.length);
            }
        }
        return null;
    }
    TownsuiteHelpers.readCookie = readCookie;
    function createCookie(name, value, days) {
        //deleteCookie(name, "", -1);
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toUTCString();
        }
        else
            var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }
    TownsuiteHelpers.createCookie = createCookie;
    function deleteCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toUTCString();
        }
        else
            var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }
    TownsuiteHelpers.deleteCookie = deleteCookie;
    function DateUtc(DateVal) {
        var offsetMiliseconds = new Date().getTimezoneOffset() * 60000;
        if (DateVal.length > 10) {
            DateVal = DateVal.replace(/\d+/, function (n) { return parseInt(n) + offsetMiliseconds; });
            return DateVal;
        }
        else {
            var jasondate = new Date(DateVal);
            var convertjson = "/Date(" + jasondate.getTime() + ")/";
            var newdate = new Date(parseInt(convertjson.replace('/Date(', '')));
            convertjson = convertjson.replace(/\d+/, function (n) { return String(parseInt(n) + offsetMiliseconds); });
            return new Date(parseInt(convertjson.replace('/Date(', '')));
        }
    }
    TownsuiteHelpers.DateUtc = DateUtc;
    // Convert json date to javascript date using users local timezone for display
    function javascript_date_from_dotnet_date(value) {
        var utcDate = new Date(parseInt(value.replace('/Date(', '')));
        var localDate = convertUTCDateToLocalDate(utcDate);
        return localDate;
    }
    TownsuiteHelpers.javascript_date_from_dotnet_date = javascript_date_from_dotnet_date;
    // Convert json date to javascript date leaving the date as utc for display
    function javascript_date_from_dotnet_date_utc(value) {
        var utcDate = new Date(parseInt(value.replace('/Date(', '')));
        return utcDate;
    }
    TownsuiteHelpers.javascript_date_from_dotnet_date_utc = javascript_date_from_dotnet_date_utc;
    // Convert json date to javascript date using users local timezone for display
    function javascript_date_from_dotnet_date_local(value) {
        var localDate = new Date(parseInt(value.replace('/Date(', '')));
        var finalDate = convertUTCDateToLocalDate(localDate);
        return finalDate;
    }
    TownsuiteHelpers.javascript_date_from_dotnet_date_local = javascript_date_from_dotnet_date_local;
    function tz_abbreviation() {
        return moment().tz(usertimezone).zoneAbbr();
    }
    TownsuiteHelpers.tz_abbreviation = tz_abbreviation;
    function friendlyDate(date1) {
        return moment(date1).format("dddd MMMM Do YYYY, h:mm:ss a");
    }
    TownsuiteHelpers.friendlyDate = friendlyDate;
    function convertUTCDateToLocalDate(date) {
        var browsersOffset = date.getTimezoneOffset();
        var local = moment.tz(date, usertimezone);
        var offsetInMinutes = local.utcOffset() + browsersOffset;
        var offsetInHours = offsetInMinutes / 60;
        var offsetInMilliseconds = offsetInHours * 3600000;
        var localNormalDate = local.toDate();
        if (offsetInMilliseconds <= 0)
            offsetInMilliseconds = offsetInMilliseconds * -1;
        return new Date(localNormalDate.getTime() - offsetInMilliseconds);
    }
    function date_diff_in_ms(date1, date2) {
        var diffDays = date2.getTime() - date1.getTime();
        return diffDays;
    }
    TownsuiteHelpers.date_diff_in_ms = date_diff_in_ms;
    function date_diff_now_in_ms(date1) {
        var date2 = new Date();
        var diffDays = date2.getTime() - date1.getTime();
        return diffDays;
    }
    TownsuiteHelpers.date_diff_now_in_ms = date_diff_now_in_ms;
    function GetUserTimeZoneID() {
        var timezone = String(new Date());
        return timezone.substring(timezone.lastIndexOf('(') + 1).replace(')', '').trim();
    }
    TownsuiteHelpers.GetUserTimeZoneID = GetUserTimeZoneID;
    function CreateOffset(date) {
        var sign = (date.getTimezoneOffset() > 0) ? "-" : "";
        var offset = Math.abs(date.getTimezoneOffset());
        return parseInt(sign + (offset / 60));
    }
    TownsuiteHelpers.CreateOffset = CreateOffset;
    function isNumeric(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }
    TownsuiteHelpers.isNumeric = isNumeric;
    //Get Query Strings javascript
    // TODO: replace with get_url_param
    function GetQueryStringParams(sParam) {
        var sPageURL = window.location.search.substring(1);
        var sURLVariables = sPageURL.split('&');
        for (var i = 0; i < sURLVariables.length; i++) {
            var sParameterName = sURLVariables[i].split('=');
            if (sParameterName[0] == sParam) {
                return sParameterName[1];
            }
        }
    }
    TownsuiteHelpers.GetQueryStringParams = GetQueryStringParams;
    //Get Query Strings jquery
    function get_url_param(name) {
        var results = new RegExp('[\\?&]' + name + '=([^&#]*)').exec(window.location.href);
        if (!results) {
            return "";
        }
        return results[1].toString();
    }
    TownsuiteHelpers.get_url_param = get_url_param;
    // Encode Html
    function EncodeHtml(html) {
        var encodedHtml = encodeURI(html);
        encodedHtml = encodedHtml.replace(/\//g, "%2F");
        encodedHtml = encodedHtml.replace(/\?/g, "%3F");
        encodedHtml = encodedHtml.replace(/=/g, "%3D");
        encodedHtml = encodedHtml.replace(/&/g, "%26");
        encodedHtml = encodedHtml.replace(/@/g, "%40");
        return encodedHtml;
    }
    TownsuiteHelpers.EncodeHtml = EncodeHtml;
    //Decode HTML
    function DecodedHtml(html) {
        return decodeURI(html);
    }
    TownsuiteHelpers.DecodedHtml = DecodedHtml;
    function UpdateURLParameter(url, param, paramVal) {
        var TheAnchor = null;
        var newAdditionalURL = "";
        var tempArray = url.split("?");
        var baseURL = tempArray[0];
        var additionalURL = tempArray[1];
        var temp = "";
        if (additionalURL) {
            var tmpAnchor = additionalURL.split("#");
            var TheParams = tmpAnchor[0];
            TheAnchor = tmpAnchor[1];
            if (TheAnchor)
                additionalURL = TheParams;
            tempArray = additionalURL.split("&");
            for (var i = 0; i < tempArray.length; i++) {
                if (tempArray[i].split('=')[0] != param) {
                    newAdditionalURL += temp + tempArray[i];
                    temp = "&";
                }
            }
        }
        else {
            var tmpAnchor = baseURL.split("#");
            var TheParams = tmpAnchor[0];
            TheAnchor = tmpAnchor[1];
            if (TheParams)
                baseURL = TheParams;
        }
        if (TheAnchor)
            paramVal += "#" + TheAnchor;
        var rows_txt = temp + "" + param + "=" + paramVal;
        return baseURL + "?" + newAdditionalURL + rows_txt;
    }
    TownsuiteHelpers.UpdateURLParameter = UpdateURLParameter;
    function PageSessionManage(sessionTime, window, document) {
        var timeoutduration = sessionTime * 60 * 1000;
        $(window).load(function () {
            ResetTimer(timeoutduration);
        });
        $(document).mouseup(function () {
            ResetTimer(timeoutduration);
        });
        $(document).ajaxSuccess(function () {
            ResetTimer(timeoutduration);
        });
    }
    TownsuiteHelpers.PageSessionManage = PageSessionManage;
    function ResetTimer(timeoutduration) {
        clearTimeout(t);
        t = setTimeout(function () {
            Logout(window);
        }, timeoutduration);
    }
    TownsuiteHelpers.ResetTimer = ResetTimer;
    function Logout(window) {
        var redirect = encodeURI(window.location.href);
        window.location = '/login?parameter1=sessionexpired&redirect=' + redirect;
        return false;
    }
    TownsuiteHelpers.Logout = Logout;
    function CheckifMobile() {
        if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            return true;
        }
        else {
            return false;
        }
    }
    TownsuiteHelpers.CheckifMobile = CheckifMobile;
    function MasterPageInit() {
        ClearFinancialClache();
    }
    TownsuiteHelpers.MasterPageInit = MasterPageInit;
    function ClearFinancialClache() {
        $("#ClearCache").click(function () {
            $.ajax({
                url: "/clearcacheuser",
                dataType: "json",
                data: { Type: TownsuiteHelpers.EncodeURIC("User") },
                success: function (result) {
                    // notify the DataSource that the operation is complete
                    TsMessage.Show("Financial Data Reloaded", TsMessage.MessageType.Success);
                },
                error: function (xhr, textStatus, errorThrown) {
                    TsMessage.Show(xhr.responseText, TsMessage.MessageType.Error);
                }
            });
        });
    }
    function IsMSIE() {
        var ua = window.navigator.userAgent;
        var msie = ua.indexOf("MSIE");
        var trident = ua.indexOf("Trident");
        if (msie > 0) {
            return true;
        }
        if (trident > 0) {
            return true;
        }
        return false;
    }
    TownsuiteHelpers.IsMSIE = IsMSIE;
    function ChangeTheme(themeName) {
        $.ajax({
            type: "POST",
            url: "/user/updatetheme",
            dataType: "json",
            data: {
                theme: themeName,
            },
            error: function (xhr, textStatus, errorThrown) {
                TsMessage.Show("Error changing theme", TsMessage.MessageType.Error);
            }
        });
    }
    TownsuiteHelpers.ChangeTheme = ChangeTheme;
    function NotificationButton() {
        if (isloggedIn == false) {
            return;
        }
        $.ajax({
            type: "GET",
            url: "/newsfeed/notificationbutton",
            contentType: "application/json; charset=utf-8",
            cache: false,
            dataType: "json",
            success: function onSucc(data) {
                var newsCount = data.News;
                var receiptsCount = data.Receipts;
                var complaintsCount = data.Complaints;
                var othersCount = data.Others;
                var fullCount = data.FullCount;
                if (fullCount != 0) {
                    $("#dashboard_count").html(fullCount);
                    $("#notification_fullcount").html(fullCount);
                    $("#dashboard_count").css("display", "block");
                    $("#notification_fullcount").css("display", "block");
                }
                $("#notification_news").html(newsCount + " new message");
                $("#notification_receipts").html("You have " + receiptsCount + " new emails");
                $("#notification_complaints").html(complaintsCount + " new comments");
                $("#notification_other").html(othersCount);
            }
        });
    }
    TownsuiteHelpers.NotificationButton = NotificationButton;
    function CartCount() {
        if (isloggedIn == false) {
            return;
        }
        // HACK: This is a slow inefficent method but works for now
        // /cartdata is loading way more data then we need to do this
        $.ajax({
            type: "POST",
            url: "/cartdata",
            contentType: "application/json; charset=utf-8",
            data: { filter: 'cartData' },
            cache: false,
            dataType: "json",
            success: function onSucc(data) {
                if (data.length > 0) {
                    var msg = data.length;
                    $("#cart_fullcount").html(msg);
                    $("#cart_fullcount_link").css("display", "block");
                }
                else {
                    $("#cart_fullcount").text("");
                }
            }
        });
    }
    TownsuiteHelpers.CartCount = CartCount;
    function BrowserUpdatePrompt() {
        // Prompt users to upgrade to newer versions of their browser
        var $buoop = {
            vs: { c: 2 },
            reminder: 0
        };
        function $buo_f() {
            var e = document.createElement("script");
            e.src = "//browser-update.org/update.min.js";
            document.body.appendChild(e);
        }
        ;
        try {
            document.addEventListener("DOMContentLoaded", $buo_f, false);
        }
        catch (e) {
            window.attachEvent("onload", $buo_f);
        }
    }
    TownsuiteHelpers.BrowserUpdatePrompt = BrowserUpdatePrompt;
    function Analytics() {
        var analytics = window.analytics = window.analytics || [];
        if (!analytics.initialize)
            if (analytics.invoked)
                window.console && console.error && console.error("Segment snippet included twice.");
            else {
                analytics.invoked = !0;
                analytics.methods = ["trackSubmit", "trackClick", "trackLink", "trackForm", "pageview", "identify", "reset", "group", "track", "ready", "alias", "page", "once", "off", "on"];
                analytics.factory = function (t) { return function () { var e = Array.prototype.slice.call(arguments); e.unshift(t); analytics.push(e); return analytics; }; };
                for (var t = 0; t < analytics.methods.length; t++) {
                    var e = analytics.methods[t];
                    analytics[e] = analytics.factory(e);
                }
                analytics.load = function (t) { var e = document.createElement("script"); e.type = "text/javascript"; e.async = !0; e.src = ("https:" === document.location.protocol ? "https://" : "http://") + "cdn.segment.com/analytics.js/v1/" + t + "/analytics.min.js"; var n = document.getElementsByTagName("script")[0]; n.parentNode.insertBefore(e, n); };
                analytics.SNIPPET_VERSION = "3.1.0";
                analytics.load("j7TrLBXxKF");
                analytics.page();
            }
    }
    TownsuiteHelpers.Analytics = Analytics;
    function contains(haystack, needle) {
        return haystack.indexOf(needle) > -1;
    }
    TownsuiteHelpers.contains = contains;
    function startsWith(str, prefix) {
        return str.indexOf(prefix) === 0;
    }
    TownsuiteHelpers.startsWith = startsWith;
    ;
    function endsWidth(str, suffix) {
        return this.substring(this.length - str.length, this.length) === suffix;
    }
    TownsuiteHelpers.endsWidth = endsWidth;
    ;
    // Word substring, do not cut off in middle of word
    function wordSubString(value, length) {
        //trim the string to the maximum length
        var trimmedString = value.substr(0, length);
        //re-trim if we are in the middle of a word
        trimmedString = trimmedString.substr(0, Math.min(trimmedString.length, trimmedString.lastIndexOf(" ")));
        return trimmedString;
    }
    TownsuiteHelpers.wordSubString = wordSubString;
    function isValidUploadTypes(extension) {
        if (this.extension != ".jpg" && this.extension != ".jpeg" && this.extension != ".gif" && this.extension != ".bmp" &&
            this.extension != ".png" && this.extension != ".JPG" && this.extension != ".JPEG" && this.extension != ".GIF" &&
            this.extension != ".BMP" && this.extension != ".PNG" && this.extension != ".mpg" && this.extension != ".MPG" &&
            this.extension != ".mpeg" && this.extension != ".MPEG" && this.extension != ".wmv" && this.extension != ".WMV" &&
            this.extension != ".mov" && this.extension != ".MOV" && this.extension != ".mp4" && this.extension != ".MP4" &&
            this.extension != ".flv" && this.extension != ".FLV" && this.extension != ".avi" && this.extension != ".AVI" &&
            this.extension != ".pdf" && this.extension != ".PDF" && this.extension != ".doc" && this.extension != ".DOC" &&
            this.extension != ".docx" && this.extension != ".DOCX" && this.extension != ".txt" && this.extension != ".TXT" &&
            this.extension != ".zip" && this.extension != ".zip" && this.extension != ".odt" && this.extension != ".ods" &&
            this.extension != ".xls" && this.extension != ".xls" && this.extension != ".xlsx" && this.extension != ".ppt") {
            return true;
        }
        return false;
    }
    TownsuiteHelpers.isValidUploadTypes = isValidUploadTypes;
    function isValidUploadTypeInComplaints(extension) {
        if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp" ||
            extension == ".png" || extension == ".JPG" || extension == ".JPEG" || extension == ".GIF" ||
            extension == ".BMP" || extension == ".PNG" || extension == ".pdf" || extension == ".PDF" ||
            extension == ".doc" || extension == ".DOC" || extension == ".docx" || extension == ".DOCX" ||
            extension == ".txt" || extension == ".TXT" || extension == ".zip" || extension == ".ZIP" ||
            extension == ".rar" || extension == ".RAR" || extension == ".xls" || extension == ".XLS" ||
            extension == ".xlsx" || extension == ".XLSX" || extension == ".ppt" || extension == ".PPT" ||
            extension == ".pptx" || extension == ".PPTX") {
            return true;
        }
        return false;
    }
    TownsuiteHelpers.isValidUploadTypeInComplaints = isValidUploadTypeInComplaints;
    function padLeft(s, padChar, length) {
        while (s.length < length) {
            s = padChar + s;
        }
        return s;
    }
    TownsuiteHelpers.padLeft = padLeft;
    function isNullOrWhiteSpace(str) {
        if (str == null) {
            return true;
        }
        return str === null || str.match(/^ *$/) !== null;
    }
    TownsuiteHelpers.isNullOrWhiteSpace = isNullOrWhiteSpace;
    $(document).ready(function () {
        $("#supportrequestlink").click(function (event) {
            event.preventDefault();
            swal({
                title: "Need Help?",
                text: "Do you need help with your account or have a technical questions?",
                type: "success",
                showCancelButton: true,
                confirmButtonText: "Account related inquiry",
                cancelButtonText: "Technical or how to",
            }, function (isConfirm) {
                if (isConfirm) {
                    if (complaintsEnabled) {
                        window.location.href = "/issue/new";
                    }
                    else {
                        window.location.href = "/contact";
                    }
                }
                else {
                    window.location.href = "/reporterrors";
                }
            });
        });
    });
})(TownsuiteHelpers || (TownsuiteHelpers = {}));
