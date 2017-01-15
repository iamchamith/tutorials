﻿$(() => {


    $('#btnClickMe').bind('click', null, sampleRequest);

    $('#btnUploadFile').on('click', function () {

        var data = new FormData();

        var files = $("#fileUpload").get(0).files;

        // Add the uploaded image content to the form data collection
        if (files.length > 0) {
            data.append("UploadedImage", files[0]);
        }

        // Make Ajax request with the contentType = false, and procesDate = false
        var ajaxRequest = $.ajax({
            type: "POST",
            url: "/api/Utility/UploadFile",
            contentType: false,
            processData: false,
            data: data
        });

        ajaxRequest.done(function (xhr, textStatus) {
            // Do other operation
        });
    });
});


function sampleRequest() {

    $.ajax({
        url: '/api/ResponseTypes/PostData?id=2',
        method: 'get',
        success: (e) => {
            alert(JSON.stringify(e));
        },
        error: (e) => {
            HandleError(e);
        }
    });

}

function HandleError(e) {
    alert(e.statusText);
    if (e.status === 500) {
        alert(e.statusText);
    }
    else if (e.status === 404) {
        alert('redert to 404 page');
    }
    else if (e.status === 405) {
        alert('redert to login page');
    }
}
