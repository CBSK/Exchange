function getContactPerson() {
    displayLoader();
    var params = $.extend({}, doAjax_params_default);

    params['url'] = '/Account/_ContactPersons';
    params['data'] = {};
    params['successCallbackFunction'] = bindContactPersonHtml;
    params['errorCallBackFunction'] = hideLoader;
    //params['contentType'] = "application/x-www-form-urlencoded; charset=UTF-8";
    params['dataType'] = 'html';
    params['requestType'] = "GET";
    doAjax(params);
}

function bindContactPersonHtml(data) {
    $("#ContactPersons").html(data);
    if ($("#hdnIsDeclarationEnable").val() == true) {
        $("button").hide();
    }
    hideLoader();
}

function saveContactPerson() {

    var params = $.extend({}, doAjax_params_default);

    params['url'] = '/Account/AddModule';
    params['data'] = { model: model };
    params['successCallbackFunction'] = OpenNextTab;
    params['beforeSendCallbackFunction'] = displayLoader;
    params['errorCallBackFunction'] = hideLoader;
    //params['contentType'] = "application/x-www-form-urlencoded; charset=UTF-8";
    params['dataType'] = 'json';
    params['requestType'] = "POST";
    doAjax(params);
}

function successContact() {
    showMessage("Contact updated Sucessfully", "success");
    OpenNextTab();
}

function BindDesignation() {
    $(".jqDesignation").each(function () {
        var id = $(this).find("input:first").attr("id");
        //console.log("id==>" + id);
        $("#" + id).ejDropDownList({
            dataSource: ej.DataManager({
                url: "/Account/BindDesignation",
                adaptor: new ej.UrlAdaptor()
            }),
            fields: {
                text: "Text",
                value: "Value"
            }
        });
    }); 
}

function BindCountryCode() {
    $(".jqCountryCode").each(function () {
        var id = $(this).find("input:first").attr("id");
        $("#" + id).ejDropDownList({
            dataSource: ej.DataManager({
                url: "/Account/BindCountryCode",
                adaptor: new ej.UrlAdaptor()
            }),
            fields: {
                text: "DisplayText",
                value: "CountryID"
            }
        });
    });
}


$(document).ready(function () {
    BindDesignation();
    BindCountryCode();

    $(".billSameAs").on("click", function () {
        if ($(this).is(":checked")) {
            $(".billFullName").val($("#FullName").val());
            $(".billEmail").val($("#Email").val());
            //$("#billMobileCountryCode").val($("#MobileCountryID").val());
            $('#billMobileCountryCode').ejDropDownList({
                value: $("#MobileCountryID").val()
            });

            $(".billMobileNo").val($("#MobileNo").val());
        } else {
            $(".billFullName").val("");
            $(".billEmail").val("");
            $(".billMobileNo").val("");
            $('#billMobileCountryCode').ejDropDownList({
                value: ""
            });
        }
    });

    $(".opSameAs").on("click", function () {
        if ($(this).is(":checked")) {
            $(".opFullName").val($("#FullName").val());
            $(".opEmail").val($("#Email").val());
            $('#opMobileCountryCode').ejDropDownList({
                value: $("#MobileCountryID").val()
            });
            $(".opMobileNo").val($("#MobileNo").val());
        } else {
            $(".opFullName").val("");
            $(".opEmail").val("");
            $('#opMobileCountryCode').ejDropDownList({
                value: ""
            });
            $(".opMobileNo").val("");
        }
    });
});