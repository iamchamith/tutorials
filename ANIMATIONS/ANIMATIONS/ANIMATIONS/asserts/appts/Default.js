/// <reference path="../dts/kendo.all.d.ts" />
/// <reference path="../dts/jquery.d.ts" />
var Animi;
(function (Animi) {
    $(function () {
        $('#allContent').addClass("animated fadeInDown");
        $('#btnSubmit').click(function () {
            $('#frmOne').removeClass("animated wobble");
            $('#frmOne').animateCss("wobble");
        });
    });
})(Animi || (Animi = {}));
//# sourceMappingURL=Default.js.map