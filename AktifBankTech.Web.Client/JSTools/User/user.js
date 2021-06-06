function LoginUser() {
    var tc = $('#loginEmail').val();
    var password = $('#loginPassword').val();
    var url = $('#loginBody').attr('loginUrl');

    var _data = {
        "TCNo": tc,
        "Password": password
    };

    $('#loginFormWrapper').append('<div class="generalLoader"><div class="loadingCircle"></div></div>');
    AjaxServerCall(_data, url,
        function (success) {
            var data = JSON.parse(success);
            if (data.HasError) {
                AlertBox(data.ResultMessage, "danger");
            }
            else {
                window.location = $('#loginBody').attr('homeUrl');
            }
            $('.generalLoader').hide();
        },
        function (error) {
            AlertBox(error, "danger");
            $('.generalLoader').hide();
        });
}

function LoginAdmin() {
    var tc = $('#loginEmail').val();
    var password = $('#loginPassword').val();
    var url = $('#loginBody').attr('loginUrl');

    var _data = {
        "TCNo": tc,
        "Password": password
    };

    $('#loginFormWrapper').append('<div class="generalLoader"><div class="loadingCircle"></div></div>');
    AjaxServerCall(_data, url,
        function (success) {
            var data = JSON.parse(success);
            if (data.HasError) {
                AlertBox(data.ResultMessage, "danger");
            }
            else {
                window.location = $('#loginBody').attr('homeUrl');
            }
            $('.generalLoader').hide();
        },
        function (error) {
            AlertBox(error, "danger");
            $('.generalLoader').hide();
        });
}