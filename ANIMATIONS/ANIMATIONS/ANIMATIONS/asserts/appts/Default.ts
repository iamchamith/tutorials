/// <reference path="../dts/kendo.all.d.ts" />
/// <reference path="../dts/jquery.d.ts" />

module Animi {

    $(() => {
        $('#allContent').addClass("animated fadeInDown"); 

        $('#btnSubmit').click(() => {
            $('#frmOne').removeClass("animated wobble"); 
            $('#frmOne').animateCss("wobble"); 
        });
    });
 
}