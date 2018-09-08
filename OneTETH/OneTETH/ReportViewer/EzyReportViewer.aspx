<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EzyReportViewer.aspx.cs" Inherits="OneTETH.ReportViewer.EzyReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <style type="text/css">
    .repViewerCssClass {      
      height:250px !important;
      width:100% !important;
      overflow-y:auto !important;      
    }
   
</style>
<script type="text/javascript">

    $(document).ready(function () {
        $('#VisibleReportContentEzyExptReportViewer_ctl09').css("position", "absolute").css("display", "inline-block !important");
        //$('#VisibleReportContentEzyExptReportViewer_ctl09');
    })

    function exportToexcel() {

        //disable the button so the user cannot double click 

       //Set the hidden field which gets sent to the sever 
       var token = new Date().getTime();
       $('#<%=HiddenField1.ClientID%>').val(token);
       $("#loadingbuttonExcel").show();
       $("#exportButton").hide();
            //Poll for the cookie every second 
            var setIntervalId = setInterval(function () {
                var tokenCookie = getCookie('tokenCookie');
                if (token == tokenCookie) {
                    CleanUp(setIntervalId);
                }

            }, 1000);

    }

    //Reset the form
    function CleanUp(setIntervalId) {
        clearInterval(setIntervalId);
        setCookie('tokenCookie', '', -1);
        $("#loadingbuttonExcel").hide();
        $("#exportButton").show();
    }

    //From http://www.w3schools.com/js/js_cookies.asp
    function setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + "; " + expires;
    }


    function getCookie(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1);
            if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
        }
        return "";
    }

  

</script>
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
              <div class="row">
                    <div class="col-md-3">
                        <button type="button" style="display:none" id="loadingbuttonExcel" class="btn btn-warning">Please wait...</button>
                        <asp:Button ID="exportButton" OnClientClick="exportToexcel()" class="btn btn-primary" runat="server" Text=" Export To Excel" OnClick="Button1_Click" />
                        </div>
                  </div>
            <rsweb:ReportViewer ID="EzyExptReportViewer" data-scrollcss="" ShowExportControls="false" runat="server" ShowFindControls="false" ShowBackButton="false" AsyncRendering="true" ZoomMode="Percent" Height="250px" Width="100%" CssClass="repViewerCssClass"></rsweb:ReportViewer>
        </div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </form>
    
</body>
</html>