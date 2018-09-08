//$(document).ready(function () { name(); });
$(document).ready(function () {
    if ($("#hdnIsDeclarationEnable").val() == "true") {
        $("#tabContents").ejTab({ selectedItemIndex: 6 });
        $("button").hide();
    }
    $('#aDeclaration').click(function (event) {

        checkDeclarationTab();
        event.preventDefault();
        return false;
    });

    checkOTPVerified();
})

function checkDeclarationTab() {
    var params = $.extend({}, doAjax_params_default);
    params['url'] = $_IsDeclarationEnable;
    //params['data'] = { OTPNumber: $("#OTPNo").val() };
    params['successCallbackFunction'] = DeclarationClick;
    params['dataType'] = 'json';
    params['requestType'] = "POST";
    doAjax(params);

    //if (!$('[name="user"]').is(':checked') && $(event.target).attr('href') == '#step-2') {

    //	}
    
}
function verifyOTP() {
    var params = $.extend({}, doAjax_params_default);
    params['url'] = $_VerifyOtp;
    params['data'] = { OTPNumber: $("#OTPNo").val() };
    params['successCallbackFunction'] = enableTabs;
    params['dataType'] = 'json';
    params['requestType'] = "POST";
    doAjax(params);
}
function DeclarationClick(event) {
    console.log(event)

    //alert("Declaration Click")
    if (event == true) {
        $("#tabContents").ejTab({ selectedItemIndex: 5 });
    }
    else if (event == false) {

        showMessage("Please fill complete information!!", "danger");
        return false;
    }

    //var params = $.extend({}, doAjax_params_default);
    //params['url'] = $_VerifyOtp;
    //params['data'] = { OTPNumber: $("#OTPNo").val() };
    //params['successCallbackFunction'] = enableTabs;
    //params['dataType'] = 'json';
    //params['requestType'] = "POST";
    //doAjax(params);
}
function enableTabs(e) {
    if (e.Status) {
        $("#tabContents").ejTab({ enabledItemIndex: [0, 1, 2, 3, 4, 5, 6, 7] });
        showMessage(e.Message, "success");
        $("#IsOTPVerified").val(true);
        $("#divOTP").hide();
    } else {
        showMessage(e.Message, "danger");
    }
}

function UserRegister(e) {
    if (e.Status) {
        showMessage("User Registered Sucessfully", "success");
        window.location.href = $_Registration;
    }
}

function name() {
    showMessage("User Registered Sucessfully", "success");
}

function OnSucessEmailverification(e) {
    if (e.Status) {
        showMessage(e.Message, "danger");
        EnableDisableControls(false);
    } else {
        showMessage(e.Message, "success");
        EnableDisableControls(true);
    }
}
function ValidateEmailAddress() {
    var email = $("#Email").val();
    if (email != "" && email != null && $("#Email").valid()) {
        var params = $.extend({}, doAjax_params_default);

        params['url'] = $_ValidateEmailAddress;
        params['data'] = { EmailAddress: email };
        params['successCallbackFunction'] = OnSucessEmailverification;
        params['contentType'] = "application/x-www-form-urlencoded; charset=UTF-8";
        params['dataType'] = 'json';
        params['requestType'] = "POST";
        doAjax(params);
    } else {
        EnableDisableControls(false);
    }
}

function EnableDisableControls(isenable) {
    if (isenable) {
        $("#Password").removeAttr("disabled");
        $("#ConfirmPassword").removeAttr("disabled");
        $("#FullName").removeAttr("disabled");
        $("#Answer").removeAttr("disabled");
        $("#MobileCountryID").ejDropDownList("enable");
        $("#MobileNo").removeAttr("disabled");
        $("#SecurityQuestion").ejDropDownList("enable");
        $("#btnsignup").removeAttr("disabled");
    } else {
        $("#Password").attr("disabled", "disabled");
        $("#ConfirmPassword").attr("disabled", "disables");
        $("#FullName").attr("disabled", "disabled");
        $("#Answer").attr("disabled", "disabled");
        $("#MobileNo").attr("disabled", "disabled");

        $("#MobileCountryID").ejDropDownList("disable");
        $("#SecurityQuestion").ejDropDownList("disable");
        $("#btnsignup").attr("disabled", "disabled");
    }
}
function UserloginSuccess(e) {
    if (e.Status) {
        window.location.href = $_Registration;
        //showMessage(e.Message, "danger");
        //EnableDisableControls(false);
    } else {
        showMessage(e.Message, "danger");
        //showMessage(e.Message, "success");
        //EnableDisableControls(true);
    }
}
function onSucessDocument(e) {
    //console.log(e.ReturnData)
    //$("#DocumentGrid").ejGrid().distroy();
    if ($("#DocumentGrid").data("ejGrid") !== undefined && $("#DocumentGrid").ejGrid("destroy")) {
        $("#DocumentGrid").ejGrid({
            dataSource: e.ReturnData,
            allowTextWrap: true,
            columns: [

                { field: "DocumentName", width: "500" },
                { field: "FileName", template: "<a target='_blank' href='/DownloadDocument/{{:DocTypeMapID}}'>{{:FileName}}</a>" },
                { field: "IsMandatory", width: "100" },
                { headerText: "Upload", template: "<input name=\"fileupload\" onchange=\"validateFile(this);\" type=\"file\" /> <input  value=\"{{:DocTypeMapID}}\" type=\"hidden\" /> " }
            ]
        });
    }
    else {
        $("#DocumentGrid").ejGrid({
            dataSource: e.ReturnData,
            allowTextWrap: true,
            columns: [

                { field: "DocumentName", width: "500" },
                { field: "FileName", template: "<a target='_blank' href='/DownloadDocument/{{:DocTypeMapID}}'>{{:FileName}}</a>" },
                { field: "IsMandatory", width: "100" },
                { headerText: "Upload", template: "<input name=\"fileupload\" onchange=\"validateFile(this);\" type=\"file\" /> <input  value=\"{{:DocTypeMapID}}\" type=\"hidden\" /> " }
            ]
        });
    }
}
function bindDocuments() {
    var params = $.extend({}, doAjax_params_default);
    params['url'] = $_GetRegistrationDocument;
    params['data'] = { orgtype: $('#OganizationType').ejDropDownList("getSelectedValue") };
    params['successCallbackFunction'] = onSucessDocument;
    params['contentType'] = "application/x-www-form-urlencoded; charset=UTF-8";
    params['dataType'] = 'json';
    params['requestType'] = "POST";
    doAjax(params);
}
function validateFile(input) {

    //growlService.growl('Please upload valid file type', 'danger');
    var fileSize = 1024 * 1024 * 5;

    // growlService.growl('File size must be not more than 5 MB', 'danger');
    var url = input.value;
    var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
    if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")

    ) {
        if (input.files[0].size <= fileSize) {
            var filename = input.files[0].name;
            $(input).parent().prev().prev().text(filename);
        }
        else {
            $(input).val("");
            showMessage("File size must be not more that 5 MB", "danger");
        }
        //var reader = new FileReader();

        //console.log(reader)
        //reader.onload = function (e) {
        //    $('#img').attr('src', e.target.result);
        //}

        //reader.readAsDataURL(input.files[0]);
    } else {
        $(input).val("");
        showMessage("Please upload valid file type", "danger");
    }
}

function validateFileupload() {
    var isValidupload = true
    $('#DocumentGrid table input[type="checkbox"]:checked').each(function () {
        if ($($(this).parent().next().find("input")).val() == "" && $($(this).parent().prev()[0].innerHTML).text() == "") {
            isValidupload = false;
            showMessage("PLEASE UPLOAD ALL DOCUMENT TYPES", "danger");
            return isValidupload;
        }
    });
    return isValidupload;
}
var fileType = ['image/jpg', 'image/jpeg', 'image/png', 'image/tif', 'application/pdf'];
function uploaddocu() {

    if (validateFileupload()) {

        // Create FormData object  
        var fileData = new FormData();
        $('#DocumentGrid table input[type="file"]').each(function () {
            if ($(this).val() != "") {
                var files1 = $(this).get(0);
                fileData.append("files", files1.files[0]);
                fileData.append("ids", $(this).next().val());
            }
        });
        fileData.append("org", $('#OganizationType').ejDropDownList("getSelectedValue"));
        $.ajax({
            url: '/Account/UploadDocument',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (result) {
                if (result.Status)
                {
                    showMessage(result.Message, "success");
                    checkDeclarationTab();
                }else
                    showMessage("Error while upload!!", "danger");
            },
            error: function (err) {
                // alert(err.statusText);
            }
        });
    }
}

function tabBeforeActive(e) {
    //console.log(e);
    switch (e.activeIndex) {
        case 3:
            getRegistrationModules();
            break;
        case 4:
            var params = $.extend({}, doAjax_params_default);
            params['url'] = $_GetRegistrationDocument;
            params['data'] = {
                orgtype: $('#OganizationType').ejDropDownList("getSelectedValue"), Regid: $('#hiddenregID').val()
            };
            params['successCallbackFunction'] = onSucessDocument;
            params['contentType'] = "application/x-www-form-urlencoded; charset=UTF-8";
            params['dataType'] = 'json';
            params['requestType'] = "POST";
            doAjax(params);
            break;
        case 5:
            if ($("#CompanyName").val() != "") {
                $("#spancompany").text($("#CompanyName").val());
                $("#spancompany").next().hide();
                $("#spancompany").show();
            }
            else {
                $("#spancompany").hide();
                $("#spancompany").next().show();
            }
            if ($("#CompanyRegisterationNumber").val() != "") {
                $("#spancompanyregno").text($("#CompanyRegisterationNumber").val());
                $("#spancompanyregno").show();
                $("#spancompanyregno").prev().hide();
            }
            else {
                $("#spancompanyregno").hide();
                $("#spancompanyregno").prev().show();
            }
            // $("#divContent").load("~/Template/declaration.html");


            //e.preventDefault();
            var params = $.extend({}, doAjax_params_default);
            params['url'] = $_IsDeclarationEnable;
            //params['data'] = { OTPNumber: $("#OTPNo").val() };
            params['successCallbackFunction'] = DeclarationClick;
            params['dataType'] = 'json';
            params['requestType'] = "POST";

        //if (doAjax_return(params)) {

        //	$("#tabContents").ejTab({ selectedItemIndex: 5 });
        //	return true;
        //	break;
        //}
        //else
        //{
        //	return false;
        //	break;
        //}



        default:
    }
}

function savedeclaration() {
    var params = $.extend({}, doAjax_params_default);
    params['url'] = '/Account/SaveDeclaration';
    params['data'] = { html: $('#divContent').html() };
    params['successCallbackFunction'] = enableReadOnlyMode;
    params['contentType'] = "application/x-www-form-urlencoded; charset=UTF-8";
    params['dataType'] = 'json';
    params['requestType'] = "POST";
    doAjax(params);
}

function enabledisbalButton(id) {
    if ($(id).prop("checked"))
        $("#btnregister").removeAttr("disabled");
    else
        $("#btnregister").attr("disabled", "disabled");
}

function Updateuserinformation(e) {

    if (e.Status)
    {
        showMessage("User information updated successfully", "success");
        if ($("#IsOTPVerified").val()) {
            OpenNextTab($("#btnuserregistration"));
            $("#divOTP").hide();
        }
        else
            showMessage("Please verify OTP", "error");
        
    }
    else
        showMessage("Error while save!!", "danger");

}

function Updatecompanyinformation(e) {

    showMessage("Company information updated successfully", "success"); OpenNextTab($("#btncompanyregistration"));
    getContactPerson();
}

function onChange(args) {

    url = "/common/GetMasters?value=State";
    console.log(url);
    var dataManger = ej.DataManager({
        url: url
    });

    var obj2 = $('#State').data("ejDropDownList");

    obj2.option({
        "dataSource": dataManger,
        "readOnly": false,

        fields: {
            text: "StateName", value: "StateID"
        },
        query: new ej.Query().addParams("id", $('#Country').ejDropDownList("getSelectedValue"))
    });
    var stateId = $("#hidStateId").val();
    console.log(stateId)
    setTimeout(function () {
        obj2.selectItemByValue(stateId);;
    }, 1000);

}

function onChangeCity(args) {

    url = "/common/GetMasters?value=City";
    console.log(url);
    var dataManger = ej.DataManager({
        url: url
    });

    var obj2 = $('#City').data("ejDropDownList");

    obj2.option({
        "dataSource": dataManger,
        "readOnly": false,

        fields: {
            text: "CityName", value: "CityID"
        },
        query: new ej.Query().addParams("id", $('#State').ejDropDownList("getSelectedValue"))
    });
    var cityId = $("#hidCityId").val();

    console.log(cityId)
    setTimeout(function () {
        obj2.selectItemByValue(cityId);;
    }, 1000);
}

function checkOTPVerified() {
    if ($("#IsOTPVerified").val()) {
        $("#tabContents").ejTab({ enabledItemIndex: [0, 1, 2, 3, 4, 5, 6, 7] });
        $("#divOTP").hide();
    } else {
        $("#tabContents").ejTab({ disabledItemIndex: [1, 2, 3, 4, 5, 6, 7] });
    }
}

function enableReadOnlyMode() {
    $("button").hide();
    showMessage("User registered successfully", "success");
    window.location.reload();

}
function OnBeginUserInformation(e) {
    if ($("#IsOTPVerified").val()) {
        return true;
    }
    else {
        
        $("#divOTP").show();
        $("#OTPNo").focus();
        showMessage("Please verify OTP", "error");
        return false;
    }
}