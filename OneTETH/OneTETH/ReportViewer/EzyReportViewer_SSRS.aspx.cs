using Microsoft.Reporting.WebForms;
using OneTETH.Model.Models;
using OneTETH.ReportDataset;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneTETH.ReportViewer
{
    public partial class EzyReportViewer_SSRS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Convert.ToString(Request.UrlReferrer).Contains("EzyExpRpt_SSRS"))
                {
                    Response.Redirect("/ReportViewer/EzyExpRpt_SSRS");
                }
                ReportFilter reportFilter = new ReportFilter();
                reportFilter.StartSubmissionDateStr = Request.QueryString["startdate"];
                reportFilter.EndSubmissionDateStr = Request.QueryString["enddate"];
                reportFilter.BrokerName = Request.QueryString["broker"];
                reportFilter.InvoiceNo = Request.QueryString["invoiceno"];
                reportFilter.DeclarationNo = Request.QueryString["decno"];
                reportFilter.StatusCode = Request.QueryString["statuscode"];
                reportFilter.Compensation = Request.QueryString["compensation"];
                reportFilter.ModeOfTransport = Request.QueryString["modeoftransport"];
                if (!string.IsNullOrEmpty(reportFilter.StartSubmissionDateStr))
                    reportFilter.StartSubmissionDate = DateTime.ParseExact(reportFilter.StartSubmissionDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(reportFilter.EndSubmissionDateStr))
                    reportFilter.EndSubmissionDate = DateTime.ParseExact(reportFilter.EndSubmissionDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                RenderReport(reportFilter);
            }
            if (Page.IsPostBack)
            {
                string contact_args = Request["__EVENTARGUMENT"];

                if (!string.IsNullOrEmpty(contact_args) && contact_args.ToLower() == "excel")
                    this.ExportExcelReport(); //Exporting Excel from ReportViewer
            }
           
        }

        private void RenderReport(ReportFilter reportFilter)
        {
            // EzyExptReportViewer.Reset();
            // EzyExptReportViewer.LocalReport.DataSources.Clear();
            // EzyExptReportViewer.PageCountMode = PageCountMode.Actual;
            //// EzyExptReportViewer.LocalReport.DisplayName = "ezyExpRpt_" + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString();
            // EzyExptReportViewer.LocalReport.EnableExternalImages = true;
            // EzyExptReportViewer.LocalReport.ReportPath = Server.MapPath("~/App_Rpt/rptEZYMonitor.rdlc");
            // EzyExptReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", GetReportDataSet(reportFilter)));

            string RptUsername = Decryptdata(ConfigurationManager.AppSettings["ReportServerUserName"].ToString());
            string RptPassword = Decryptdata(ConfigurationManager.AppSettings["ReportServerPwd"].ToString());

            string urlReportServer = ConfigurationManager.AppSettings["ReportServerUrl"].ToString();
            EzyExptReportViewer.ProcessingMode = ProcessingMode.Remote; // ProcessingMode will be Either Remote or Local
            EzyExptReportViewer.ServerReport.ReportServerUrl = new Uri(urlReportServer); //Set the ReportServer Url
            EzyExptReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportPath"].ToString() + ConfigurationManager.AppSettings["ReportName"].ToString(); ; //Passing the Report Path                

            // pass crendentitilas
            //rptViewer.ServerReport.ReportServerCredentials = 
            //  new ReportServerCredentials("uName", "PassWORD", "doMain");

            IReportServerCredentials nc = new CustomReportCredentials(RptUsername, RptPassword, ConfigurationManager.AppSettings["ReportDomain"].ToString());
            EzyExptReportViewer.ServerReport.ReportServerCredentials = nc;

            EzyExptReportViewer.ShowParameterPrompts = false;
            EzyExptReportViewer.ShowPrintButton = false;


            ReportParameter[] reportParameterCollection = new ReportParameter[9];

            reportParameterCollection[0] = new ReportParameter();
            reportParameterCollection[0].Name = "PStartSubmissionDate";
            reportParameterCollection[0].Values.Add(Convert.ToDateTime(reportFilter.StartSubmissionDate).ToString("yyyy-MM-dd"));


            reportParameterCollection[1] = new ReportParameter();
            reportParameterCollection[1].Name = "PEndSubmissionDate";
            reportParameterCollection[1].Values.Add(Convert.ToDateTime(reportFilter.EndSubmissionDate).ToString("yyyy-MM-dd"));

            reportParameterCollection[2] = new ReportParameter();
            reportParameterCollection[2].Name = "PCustomBrokerName";
            reportParameterCollection[2].Values.Add(reportFilter.BrokerName == null ? string.Empty : reportFilter.BrokerName);


            reportParameterCollection[3] = new ReportParameter();
            reportParameterCollection[3].Name = "PPurchaseCountryCode";
            reportParameterCollection[3].Values.Add(string.Empty);


            reportParameterCollection[4] = new ReportParameter();
            reportParameterCollection[4].Name = "PInvoiceNumber";
            reportParameterCollection[4].Values.Add(reportFilter.InvoiceNo == null ? string.Empty : reportFilter.InvoiceNo);


            reportParameterCollection[5] = new ReportParameter();
            reportParameterCollection[5].Name = "PDeclarationNumber";
            reportParameterCollection[5].Values.Add(reportFilter.DeclarationNo == null ? string.Empty : reportFilter.DeclarationNo);


            reportParameterCollection[6] = new ReportParameter();
            reportParameterCollection[6].Name = "PStatus";
            reportParameterCollection[6].Values.Add(reportFilter.StatusCode == null ? string.Empty : reportFilter.StatusCode);


            reportParameterCollection[7] = new ReportParameter();
            reportParameterCollection[7].Name = "PModeOfTransport";
            reportParameterCollection[7].Values.Add(reportFilter.ModeOfTransport == null ? string.Empty : reportFilter.ModeOfTransport);


            reportParameterCollection[8] = new ReportParameter();
            reportParameterCollection[8].Name = "PCompensation";
            reportParameterCollection[8].Values.Add(reportFilter.Compensation == null ? string.Empty : reportFilter.Compensation);
            

            //pass parmeters to report
            EzyExptReportViewer.ServerReport.SetParameters(reportParameterCollection);//Set Report Parameters
            EzyExptReportViewer.ServerReport.Refresh();

        }

        private DataTable GetReportDataSet(ReportFilter reportFilter)
        {
            var reportDataTable = new ezyMonitorDataSet.SP_EZYExportMonitor_ReportDataTable();
            var da = new ReportDataset.ezyMonitorDataSetTableAdapters.SP_EZYExportMonitor_ReportTableAdapter();
            da.Fill(reportDataTable, reportFilter.StartSubmissionDate, reportFilter.EndSubmissionDate, reportFilter.BrokerName, "", reportFilter.InvoiceNo, reportFilter.DeclarationNo, reportFilter.StatusCode, reportFilter.ModeOfTransport, reportFilter.Compensation);
            return reportDataTable;
        }

        private void ExportExcelReport()
        {
            byte[] bytes = EzyExptReportViewer.ServerReport.Render("EXCELOPENXML");
            this.downloadReport(bytes, "xlsx");
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "Script", "myFun();", true);
        }
        private void downloadReport(byte[] data, string format)
        {
            Stream stream = new MemoryStream(data);

            byte[] buffer = new Byte[10000];
            int length;
            long data_length;
            try
            {

                var date = DateTime.Now;
                data_length = stream.Length;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "ezyExpRpt_" + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString() + "." + format);
                Response.AppendCookie(new HttpCookie("tokenCookie", HiddenField1.Value));
                while (data_length > 0)
                {
                    if (Response.IsClientConnected)
                    {
                        length = stream.Read(buffer, 0, 10000);
                        Response.OutputStream.Write(buffer, 0, length);
                        Response.Flush();
                        buffer = new Byte[10000];
                        data_length = data_length - length;
                    }
                    else
                    {
                        data_length = -1;
                    }
                }
            }
            finally
            {
                if (stream != null) { stream.Close(); }
                Response.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ExportExcelReport();

            ClientScriptManager script = Page.ClientScript;

            //if (!script.IsClientScriptBlockRegistered(this.GetType(), "Alert"))

            //{

            //    script.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('hi')", true);
            //}
        }

        public string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }

    public class CustomReportCredentials : IReportServerCredentials
    {

        // local variable for network credential
        private string strUserName;
        private string strPassWord;
        private string strDomainName;
        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            strUserName = UserName;
            strPassWord = PassWord;
            strDomainName = DomainName;
        }
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            // not use ImpersonationUser
            get { return null; }
        }
        public System.Net.ICredentials NetworkCredentials
        {
            // use NetworkCredentials
            get { return new NetworkCredential(strUserName, strPassWord, strDomainName); }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user,
       out string password, out string authority)
        {
            // Do not use forms credentials to authenticate.
            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }
}