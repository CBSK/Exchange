using OneTETH.Model.Models;
using OneTETH.Models;
using OneTETH.ReportDataset;
using Syncfusion.EJ.ReportViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.Http;
using System.Web.Mvc;
using OneTETH.Service.Interfaces;
using Syncfusion.JavaScript.Models.ReportViewer;
using System.Threading.Tasks;

namespace OneTETH.Controllers
{
    public class ReportViewerController : Controller
    {
        private IEzyExpRptService _ezyExpRptService;

        public ReportViewerController(IEzyExpRptService ezyExpRptService)
        {
            _ezyExpRptService = ezyExpRptService;
        }
        // GET: ReportViewer
        [System.Web.Http.HttpGet]
        public ActionResult EzyExpRpt()
        {
            ReportFilter reportFilter = new ReportFilter();
            Intialize(reportFilter);
            return View(reportFilter);
            //return View();
        }

        [System.Web.Http.HttpGet]
        public ActionResult EzyExpRpt_SSRS()
        {
            ReportFilter reportFilter = new ReportFilter();
            Intialize(reportFilter);
            return View(reportFilter);
            //return View();
        }

        [System.Web.Http.HttpPost]
        public ActionResult LoadAndFilterReport(ReportFilter reportFilter)
        {
            ValidateModelAndSetReportData(reportFilter);
            return PartialView("_EzyExpRptPartial");
        }

        [System.Web.Http.HttpGet]
        public ActionResult FilterCustomBrokers(AutoCompleteFilter filterData)
        {
            return Json(_ezyExpRptService.FilterCustomBroker(filterData.Where == null ? "" : filterData.Where[0].Value), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public async Task<JsonResult> SaveEmailMe(EZYReportExportMonitor_WinService ObjEZYReportExportMonitor_WinService)
        {
            CultureInfo culture = new CultureInfo("en-GB");

            ObjEZYReportExportMonitor_WinService.PStartSubmissionDate = Convert.ToDateTime(ObjEZYReportExportMonitor_WinService.FileName, culture.DateTimeFormat);
            ObjEZYReportExportMonitor_WinService.PEndSubmissionDate = Convert.ToDateTime(ObjEZYReportExportMonitor_WinService.FilePath, culture.DateTimeFormat);
            ObjEZYReportExportMonitor_WinService.FileName = string.Empty;
            ObjEZYReportExportMonitor_WinService.FilePath = string.Empty;

            var ID = await _ezyExpRptService.AddEZYReportExportMonitor_WinService(ObjEZYReportExportMonitor_WinService);

            if (ID > 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #region private helper methods
        private void Intialize(ReportFilter _reportFilter)
        {
            _reportFilter.StartSubmissionDate = DateTime.UtcNow.AddDays(0);
            _reportFilter.EndSubmissionDate = DateTime.UtcNow;
            ViewBag.Compensation = new List<DropDownElement>() { new DropDownElement { Text = "Yes", Value = "Y" }, new DropDownElement { Text = "No", Value = "N" } };
            ViewBag.ModeOfTransport = new List<DropDownElement>() { new DropDownElement { Text = "1-Maritime", Value = "1" }, new DropDownElement { Text = "2-Rail", Value = "2" }, new DropDownElement { Text = "3-Road", Value = "3" }, new DropDownElement { Text = "4-Air", Value = "4" }, new DropDownElement { Text = "5-Mail", Value = "5" }, new DropDownElement { Text = "7-Pipe or Transmission Line", Value = "7" }, new DropDownElement { Text = "8-Inland Water", Value = "8" }, new DropDownElement { Text = "9-Hand Carry", Value = "9" } };
        }

        private DataTable GetReportDataSet(ReportFilter reportFilter)
        {
            var reportDataTable = new ezyMonitorDataSet.SP_EZYExportMonitor_ReportDataTable();
            var da = new ReportDataset.ezyMonitorDataSetTableAdapters.SP_EZYExportMonitor_ReportTableAdapter();
            da.Fill(reportDataTable, reportFilter.StartSubmissionDate, reportFilter.EndSubmissionDate, reportFilter.BrokerName, "", reportFilter.InvoiceNo, reportFilter.DeclarationNo, reportFilter.StatusCode, reportFilter.ModeOfTransport, reportFilter.Compensation);
            return reportDataTable;
        }

        private void SetReportData(ReportFilter reportFilter)
        {
            var dataToDisplay = GetReportDataSet(reportFilter);
            var prop = new Syncfusion.JavaScript.Models.ReportViewerProperties
            {
                ProcessingMode = Syncfusion.JavaScript.ReportViewerEnums.ProcessingMode.Local,
                DataSources = new List<ReportDataSource>() { new ReportDataSource("DataSet1", dataToDisplay) },
                ReportPath = Request.MapPath(Request.ApplicationPath) + @"App_Rpt\rptEZYMonitor.rdlc",
                ReportServiceUrl = "/api/ReportAPI",
                ReportExport = "onReportExport"
            };
            //var reportViewer = new Syncfusion.JavaScript.ReportViewer("reportviewer", prop);
            ViewBag.ezyExportMonitorReportViewer = prop;
        }

        private void ValidateModelAndSetReportData(ReportFilter reportFilter)
        {
            try
            {
                reportFilter.StartSubmissionDate = DateTime.ParseExact(reportFilter.StartSubmissionDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                reportFilter.EndSubmissionDate = DateTime.ParseExact(reportFilter.EndSubmissionDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (ModelState.IsValid)
                {
                    SetReportData(reportFilter);
                }
                else
                {
                    var errors = new List<string>();
                    ErrorModelBuilder(errors);
                    ViewBag.Errors = errors;
                }
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                ViewBag.Errors = errors;
            }
        }

        private void ErrorModelBuilder(List<string> errors)
        {
            foreach (ModelState modelState in ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
        }
        #endregion
    }

    public class ReportAPIController : ApiController, IReportController
    {
        public object PostReportAction(Dictionary<string, object> jsonResult)
        {
            return ReportHelper.ProcessReport(jsonResult, this);
        }
        [System.Web.Http.ActionName("GetResource")]
        [System.Web.Http.AcceptVerbs("GET")]
        public object GetResource(string key, string resourcetype, bool isPrint)
        {
            return ReportHelper.GetResource(key, resourcetype, isPrint);
        }
        public void OnInitReportOptions(ReportViewerOptions reportOption)
        {
        }
        public void OnReportLoaded(ReportViewerOptions reportOption)
        {
        }

    }
}