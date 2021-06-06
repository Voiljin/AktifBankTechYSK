function CreateSubscriber() {
    var firstName = $('input[name=firstName]').val();
    var lastName = $('input[name=lastName]').val();
    var tcNo = $('input[name=tcno]').val();
    var taxNumber = (document.getElementById("statusSelectItem").value == 1) ? null : $('input[name=taxNumber]').val();
    var type = document.getElementById("statusSelectItem").value;    
    var url = $('#form-personal').attr('insertUrl');

    if (firstName == "" || lastName == "" || tcNo == "" || type == "")
        return false;

    var _data = {
        "FirstName": firstName,
        "LastName": lastName,
        "TCNo": tcNo,
        "TaxNumber": taxNumber,
        "SubscriptionTypeId": type
    };

    $('body').append('<div class="pageLoader"><div class="loadingCircle"></div></div>');
    AjaxServerCall(_data, url,
        function (success) {
            var data = JSON.parse(success);
            if (data.HasError) {
                AlertBox(data.ResultMessage, "danger");
            }
            else {
                AlertBox("Abonelik başarıyla oluşturuldu", "success");

                setTimeout(function () {
                    window.location.reload();
                }, 2000);
            }
            $('.pageLoader').hide();
        },
        function (error) {
            AlertBox(error, "danger");
            $('.pageLoader').hide();
        });
}

function GetSubscriberWithFilter() {
    var type = document.getElementById("statusSelectItem").value;
    var searchKeyword = $('input[name=searchKeyword]').val();
    var url = $('.pageWrapper').attr('filterUrl');

    var _data = {
        "SearchKeyword": searchKeyword,
        "Type": type
    };

    AjaxServerCall(_data, url,
        function (success) {
            $("#newsDataContent .table-responsive").html(success);
        },
        function (error) { });
}

function EditSubscriptionStatusUpdateModal(id) {
    $('#surveyStatusUpdateBtn').attr('onclick', "TurnOffSubscription('" + id + "')");
}

function TurnOffSubscription(id) {
    var url = $('.pageWrapper').attr('turnOfUrl');

    var _data = {
        "Id": id
    };

    AjaxServerCall(_data, url,
        function (success) {
            var data = JSON.parse(success);
            if (data.HasError) {
                AlertBox(data.ResultMessage, "danger");
            }
            else {
                AlertBox("Abonelik kapatma işlemi başarıyla gerçekleşti", "success");

                setTimeout(function () {
                    window.location.reload();
                },2000);
            }
            $('#modalInvoiceStatus').modal('hide');
        },
        function (error) { });
}