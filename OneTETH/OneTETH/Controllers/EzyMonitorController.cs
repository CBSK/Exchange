using OneTETH.Model.Models.DTO;
using OneTETH.Models;
using OneTETH.Service.Interfaces;
using System;
using System.Web.Mvc;

namespace OneTETH.Controllers
{
    [Authorize]
    public class EzyMonitorController : Controller
    {
        private IEZYMonitorExpHeaderService _eZYMonitorExpHeaderService;
        private IEzyInvoiceExpHeaderService _ezyInvoiceExpHeaderService;
        private ICustomsResponseDetailService _customsResponseDetailService;
        private IEzyInvoiceExpDetailService _ezyInvoiceExpDetailService;
        private IEzyExportPermitService _ezyExportPermitService;
        private IFTPFileDataListService _fTPFileDataListService;
        public EzyMonitorController(IEZYMonitorExpHeaderService eZYMonitorExpHeaderService, IEzyInvoiceExpHeaderService ezyInvoiceExpHeaderService, ICustomsResponseDetailService customsResponseDetailService, IEzyInvoiceExpDetailService ezyInvoiceExpDetailService, IEzyExportPermitService ezyExportPermitService, IFTPFileDataListService fTPFileDataListService)
        {
            _eZYMonitorExpHeaderService = eZYMonitorExpHeaderService;
            _ezyInvoiceExpHeaderService = ezyInvoiceExpHeaderService;
            _customsResponseDetailService = customsResponseDetailService;
            _ezyInvoiceExpDetailService = ezyInvoiceExpDetailService;
            _ezyExportPermitService = ezyExportPermitService;
            _fTPFileDataListService = fTPFileDataListService;
        }

        public ActionResult Index()
        {
            var monitorHeader = _eZYMonitorExpHeaderService.GetMonitorExpHeaders();

            return View(monitorHeader);

        }

        public ActionResult PopulateMonitorHeader(InvoiceSearchModel invoiceSearchModel)
        {
            DateTime? from = null;
            DateTime? to = null;
            if (!string.IsNullOrEmpty(invoiceSearchModel.InvoiceFrom))
            {
                from = DateTime.ParseExact(invoiceSearchModel.InvoiceFrom, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                to = DateTime.ParseExact(invoiceSearchModel.InvoiceTo, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            var monitorHeader = _eZYMonitorExpHeaderService.GetMonitorExpHeaders(from, to, invoiceSearchModel.InvoiceNo);

            return PartialView("~/Views/ezymonitor/_ezyMonitorHeader.cshtml", monitorHeader);

        }

        public ActionResult PopulateMonitorDetailAndInvoiceHeader(string Id)
        {
            ViewData["InvoiceHeaders"] = _ezyInvoiceExpHeaderService.GetInvoiceHeaders(new Guid(Id));
            EzyMonitorExpHeaderDTO MoniorHeaderDetail = _eZYMonitorExpHeaderService.GetMonitorHeaderDetail(Guid.Parse(Id));
            ViewData["CustomsDetail"] = _customsResponseDetailService.GetCustomsResponseDetails(MoniorHeaderDetail.DeclarationNumber);
            return PartialView("~/Views/ezymonitor/_documentInformation.cshtml", MoniorHeaderDetail);
        }

        public ActionResult PopulateInvoiceDetail(string Id)
        {
            var InvoiceDetailList = _ezyInvoiceExpDetailService.GetInvoiceHeaderDetailList(Id);
            return PartialView("~/Views/ezymonitor/_ezyInvoiceDetail.cshtml", InvoiceDetailList);
        }

        public ActionResult PopulateInvoiceDetailInfoAndPermit(string Id)
        {
            ViewData["ExportPermits"] = _ezyExportPermitService.GetExportPermit(Id);
            var InvoiceDetailInfo = _ezyInvoiceExpDetailService.GetInvoiceDetailByID(Id);
            return PartialView("~/Views/ezymonitor/_ezyInvoiceDetaiInfo.cshtml", InvoiceDetailInfo);
        }

        public FileResult DownloadXML(int XML_ID)
        {
            FTPFileDataListDTO ftpFile = _fTPFileDataListService.GetFileData(XML_ID);
            return File(ftpFile.FileData, "application/xml", ftpFile.FileName);
        }

        public FileResult DownloadPDF(int PDF_ID)
        {
            FTPFileDataListDTO ftpFile = _fTPFileDataListService.GetFileData(PDF_ID);
            return File(ftpFile.FileData, "application/pdf", ftpFile.FileName);
        }

        public ActionResult Invoice()
        {
            var monitorHeader = _eZYMonitorExpHeaderService.GetMonitorExpHeaders();

            return View(monitorHeader);

        }
    }
}