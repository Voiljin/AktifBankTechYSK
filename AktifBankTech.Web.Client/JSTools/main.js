var baseUrl = "https://localhost:44315/";
var isIE = /*@cc_on!@*/false || !!document.documentMode;

$(document).ajaxError(function (event, jqxhr, settings, exception) {
    if (jqxhr.status == 403) {

        AlertBox("Your session has expired", "danger");

        setTimeout(function () {
            window.location.href = baseUrl + 'UserLogin';
        }, 2000);
        return false;
    }
});

$(document).ready(function () {
    ConfigureIE();
});

function AjaxServerCall(_data, url, success, error) {
    $.ajax({
        url: url,
        type: 'POST',
        data: JSON.stringify(_data),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: success,
        error: error
    });
}

function GetPartialPage(url, targetContentId) {
    $.get(url, function (data) {
        $(targetContentId).html("");
        $(targetContentId).html(data);
    });
}

function AlertBox(messageContent, type) {
    $('#alertWrapper').html("");
    var alertHtml = "<div class='pgn-wrapper' data-position='top-right' style='top: 59px; '><div class='pgn push-on-sidebar-open pgn-flip'><div class='alert alert-" + type + "'><button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>×</span><span class='sr-only'>Close</span></button><span>" + messageContent + "</span></div></div></div>";
    $('#alertWrapper').append(alertHtml);

    setTimeout(function () {
        $('#alertWrapper').html("");
    }, 3500);
}

function ConfigureIE() {
    if (isIE) {
        $(".btn").addClass("js-ie")
        $(".btn-lg .btn").addClass("js-ie")
        $(".btn-group-lg .btn").addClass("js-ie")
        $(".btn i").addClass("js-ie")
        $(".btn").css("display", "");
        $("input[type='file']").addClass('ieFileInput');
    }
};