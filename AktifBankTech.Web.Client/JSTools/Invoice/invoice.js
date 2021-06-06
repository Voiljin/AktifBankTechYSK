function EditInvoiceStatusUpdateModal(id) {
    $('#surveyStatusUpdateBtn').attr('onclick', "PayInvoice('" + id + "')");
}

function PayInvoice(id) {
    var url = $('.pageWrapper').attr('payInvoiceUrl');

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
                AlertBox("Fatura ödeme işlemi başarıyla gerçekleşti", "success");

                var baseURL = $('.pageWrapper').attr('filterUrl');
                var subsId = $('.pageWrapper').attr('subsId');
                baseURL += "?subscriptionId=" + subsId;
                GetPartialPage(baseURL, "#newsDataContent .table-responsive");
            }
            $('#modalInvoiceStatus').modal('hide');
        },
        function (error) { });
}

function InvoicePageListPaging() {
    var status = document.getElementById("statusSelectItem").value;
    var subsId = $('.pageWrapper').attr('subsId');
    var url = $('.pageWrapper').attr('filterUrl');

    var _data = {
        "subscriptionId": subsId,
        "status": status
    };

    AjaxServerCall(_data, url,
        function (success) {
            $("#newsDataContent .table-responsive").html(success);
            ConfigureIE();
        },
        function (error) { });
}