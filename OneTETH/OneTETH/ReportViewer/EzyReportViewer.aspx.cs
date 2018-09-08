using Microsoft.Reporting.WebForms;
using OneTETH.Model.Models;
using OneTETH.ReportDataset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneTETH.ReportViewer
{
    public partial class EzyReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Convert.ToString(Request.UrlReferrer).Contains("EzyExpRpt"))
                {
                    Response.Redirect("/ReportViewer/EzyExpRpt");
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
            EzyExptReportViewer.Reset();
            EzyExptReportViewer.LocalReport.DataSources.Clear();
            EzyExptReportViewer.PageCountMode = PageCountMode.Actual;
           // EzyExptReportViewer.LocalReport.DisplayName = "ezyExpRpt_" + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString();
            EzyExptReportViewer.LocalReport.EnableExternalImages = true;
            EzyExptReportViewer.LocalReport.ReportPath = Server.MapPath("~/App_Rpt/rptEZYMonitor.rdlc");
            EzyExptReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", GetReportDataSet(reportFilter)));
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
            byte[] bytes = EzyExptReportViewer.LocalReport.Render("EXCELOPENXML");
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
    }
}