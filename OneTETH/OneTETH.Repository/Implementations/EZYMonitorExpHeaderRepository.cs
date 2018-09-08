using OneTETH.Model.Models.DTO;
using OneTETH.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository.Implementations
{
    public class EZYMonitorExpHeaderRepository : IEZYMonitorExpHeaderRepository
    {
        private OneTEDBContext _context;
        public EZYMonitorExpHeaderRepository(OneTEDBContext context)
        {
            _context = context;
        }

        public List<EzyMonitorExpHeaderDTO> GetMonitorExpHeaders(DateTime? fromDate = null, DateTime? toDate = null, string invoiceNo = null)
        {           

            // local time zone offset as TimeSpan object                
            var offsetTime = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Ticks;

            // convert time zone offset to minutes
            var localtime_minutes = TimeSpan.FromTicks(offsetTime).TotalMinutes;

            var mlist = (from monitor in _context.EzyMonitorExpHeader
                         join cdsdt in _context.UdcDetails on new { d = 128, e = monitor.Status } equals new { d = cdsdt.UdcMId, e = cdsdt.UdcDCode } into e1
                         from cdsdt in e1.DefaultIfEmpty()
                         join dt in _context.UdcDetails on new { d = 2, e = monitor.DocumentType } equals new { d = dt.UdcMId, e = dt.UdcDCode } into e2
                         from dt in e2.DefaultIfEmpty()
                         join cbn in _context.CustomsBroker on monitor.BrokerTaxNumber equals cbn.TaxNumber into e3
                         from cbn in e3.DefaultIfEmpty()
                         join eih in _context.EzyInvoiceExpHeader on monitor.txNoUUID equals eih.TxNoUuid into e4
                         from eih in e4.DefaultIfEmpty()
                         where (fromDate == null ? true : (eih.InvoiceDate >= fromDate && eih.InvoiceDate <= toDate)) && (invoiceNo == null ? true : eih.InvoiceNumber.Contains(invoiceNo))
                         && (monitor.isRejected == null || monitor.isRejected == false) 
                         && (monitor.isVoid == null || monitor.isVoid == false)
                         select new
                         {
                             txNoUUID = monitor.txNoUUID,
                             ReferenceNumber = monitor.ReferenceNumber,
                             TradingPartnerTaxNumber = monitor.TradingPartnerTaxNumber,
                             CompanyBranch = monitor.CompanyBranch.Value.ToString(),
                             CustomsBankCode = monitor.CustomsBankCode,
                             CustomsClearanceIDCard = monitor.CustomsClearanceIDCard,
                             CustomsClearanceName = monitor.CustomsClearanceName,
                             DocumentType = dt == null ? monitor.DocumentType : monitor.DocumentType + " - " + dt.UdcDDesc,
                             DepartureDate = monitor.DepartureDate,
                             DeclarationNumber = monitor.DeclarationNumber,
                             XML_ID = monitor.XML_ID,
                             PDF_ID = monitor.PDF_ID,
                             BrokerTaxNumber = monitor.BrokerTaxNumber,
                             CompanyNameEnglish = monitor.CompanyNameEnglish,
                             Status = ((monitor.isCanceled != null && monitor.isCanceled == true) ? "Canceled" : (cdsdt == null ? monitor.Status : monitor.Status + " - " + cdsdt.UdcDDesc)),
                             CustomsBrokerName = cbn == null ? "" : cbn.CustomsBrokerName,
                             SubmissionDate = monitor.SubmissionDate,
                             DestinationCountryCode = monitor.DestinationCountryCode,
                             TotalPackageAmount = monitor.TotalPackageAmount,
                             TotalGrossWeight = monitor.TotalGrossWeight,
                             TotalNetWeight = monitor.TotalNetWeight,
                             VesselName = monitor.VesselName,
                             ManagerName = monitor.ManagerName
                         }
                       ).Distinct().ToList();

            var finallist = mlist.Select(x => new EzyMonitorExpHeaderDTO
            {
                txNoUUID = x.txNoUUID,
                ReferenceNumber = x.ReferenceNumber,
                TradingPartnerTaxNumber = x.TradingPartnerTaxNumber,
                CompanyBranch = x.CompanyBranch,
                CustomsBankCode = x.CustomsBankCode,
                CustomsClearanceIDCard = x.CustomsClearanceIDCard,
                CustomsClearanceName = x.CustomsClearanceName,
                DocumentType = x.DocumentType,
                DepartureDate = x.DepartureDate.Value.Date.AddMinutes(localtime_minutes),
                DeclarationNumber = x.DeclarationNumber,
                XML_ID = x.XML_ID,
                PDF_ID = x.PDF_ID,
                BrokerTaxNumber = x.BrokerTaxNumber,
                CompanyNameEnglish = x.CompanyNameEnglish,
                Status = x.Status,
                CustomsBrokerName = x.CustomsBrokerName,
                SubmissionDate = x.SubmissionDate.Value.Date.AddMinutes(localtime_minutes),
                DestinationCountryCode = x.DestinationCountryCode,
                TotalPackageAmount = x.TotalPackageAmount,
                TotalGrossWeight = x.TotalGrossWeight,
                TotalNetWeight = x.TotalNetWeight,
                VesselName = x.VesselName,
                ManagerName = x.ManagerName,
                DisplayDepartureDate = x.DepartureDate == null ? string.Empty : x.DepartureDate.Value.Date.ToString("dd/MM/yyyy"),
                DisplaySubmissionDate = x.SubmissionDate == null ? string.Empty : x.SubmissionDate.Value.Date.ToString("dd/MM/yyyy")
            }).ToList();

            return finallist;
        }

        public EzyMonitorExpHeaderDTO GetMonitorHeaderDetail(Guid Id)
        {
            var list = (from eh in _context.EzyMonitorExpHeader
                        join c in _context.Country on eh.PurchaseCountryCode equals c.TwoLetterIsoCode into e1
                        from c in e1.DefaultIfEmpty()
                        join c1 in _context.Country on eh.DestinationCountryCode equals c1.TwoLetterIsoCode into e2
                        from c1 in e2.DefaultIfEmpty()
                        join pac in _context.PortAreaCode on new { PortAreaCode = SqlFunctions.StringConvert((double)eh.LoadPort) } equals new { PortAreaCode = SqlFunctions.StringConvert((double)pac.AreaCode) } into e3
                        from pac in e3.DefaultIfEmpty()
                        join pac1 in _context.PortAreaCode on new { PortAreaCode = SqlFunctions.StringConvert((double)eh.ReleasePort) } equals new { PortAreaCode = SqlFunctions.StringConvert((double)pac1.AreaCode) } into e4
                        from pac1 in e4.DefaultIfEmpty()
                        join dt in _context.UdcDetails on new { d = 2, e = eh.DocumentType } equals new { d = dt.UdcMId, e = dt.UdcDCode } into e5
                        from dt in e5.DefaultIfEmpty()
                        join mdt in _context.UdcDetails on new { d = 1, e = eh.ModeOfTransport } equals new { d = mdt.UdcMId, e = mdt.UdcDCode } into e6
                        from mdt in e6.DefaultIfEmpty()
                        join cdsdt in _context.UdcDetails on new { d = 128, e = eh.Status } equals new { d = cdsdt.UdcMId, e = cdsdt.UdcDCode } into e7
                        from cdsdt in e7.DefaultIfEmpty()
                        join cbn in _context.CustomsBroker on eh.BrokerTaxNumber equals cbn.TaxNumber into e8
                        from cbn in e8.DefaultIfEmpty()
                        where eh.txNoUUID == Id
                        select new EzyMonitorExpHeaderDTO
                        {
                            txNoUUID = eh.txNoUUID,
                            ReferenceNumber = eh.ReferenceNumber,
                            TradingPartnerTaxNumber = eh.TradingPartnerTaxNumber,
                            CompanyBranch = SqlFunctions.Replicate("0", 6 - eh.CompanyBranch.Value.ToString().Length) + eh.CompanyBranch,
                            CustomsBankCode = eh.CustomsBankCode,
                            CustomsClearanceIDCard = eh.CustomsClearanceIDCard,
                            CustomsClearanceName = eh.CustomsClearanceName,
                            DepartureDate = eh.DepartureDate,
                            DeclarationNumber = eh.DeclarationNumber,
                            XML_ID = eh.XML_ID,
                            PDF_ID = eh.PDF_ID,
                            BrokerTaxNumber = eh.BrokerTaxNumber,
                            CompanyNameEnglish = eh.CompanyNameEnglish,
                            AssessmentRequestCode = eh.AssessmentRequestCode,
                            DocumentType = dt == null ? eh.DocumentType : eh.DocumentType + " - " + dt.UdcDDesc,
                            ModeOfTransport = eh.ModeOfTransport,
                            ModeOfTransportDesc = mdt == null ? eh.ModeOfTransport : eh.ModeOfTransport + " - " + mdt.UdcDDesc,
                            PurchaseCountryCode = c == null ? eh.PurchaseCountryCode : eh.PurchaseCountryCode + " - " + c.Name,
                            DestinationCountryCode = c1 == null ? eh.DestinationCountryCode : eh.DestinationCountryCode + " - " + c1.Name,
                            ReleasePort = pac == null ? SqlFunctions.StringConvert((double)eh.ReleasePort) : eh.ReleasePort + " - " + pac1.AreaName,
                            LoadPort = pac1 == null ? SqlFunctions.StringConvert((double)eh.LoadPort) : eh.LoadPort + " - " + pac.AreaName,
                            CompanyNameThai = eh.CompanyNameThai,
                            FOBValueBaht = eh.FOBValueBaht,
                            BankAccountNumber = eh.BankAccountNumber,
                            BankBranchCode = eh.BankBranchCode,
                            CompanyTaxNumber = eh.CompanyTaxNumber,
                            CurrencyCode = eh.CurrencyCode,
                            BankCode = eh.BankCode,
                            BrokerBranch = SqlFunctions.Replicate("0", 6 - eh.BrokerBranch.Value.ToString().Length) + eh.BrokerBranch,
                            CargoTypeCode = eh.CargoTypeCode,
                            SubProvince = eh.SubProvince,
                            ExchangeRate = eh.ExchangeRate,
                            FOBValueForeign = eh.FOBValueForeign,
                            PaymentMethod = eh.PaymentMethod,
                            ExportTaxIncentivesID = eh.ExportTaxIncentivesID,
                            SubBrokerTaxNumber = eh.SubBrokerTaxNumber,
                            TotalGrossWeight = eh.TotalGrossWeight,
                            TotalNetWeight = eh.TotalNetWeight,
                            NetWeightUnitCode = eh.NetWeightUnitCode,
                            TotalGrossWeightUnitCode = eh.TotalGrossWeightUnitCode,
                            TotalPackageAmount = eh.TotalPackageAmount,
                            TotalPaymentAmount = eh.TotalPaymentAmount,
                            TotalPackageUnitCode = eh.TotalPackageUnitCode,
                            VesselName = eh.VesselName,
                            CompanyTradingBranch = eh.CompanyTradingBranch,
                            MasterBillofLading = eh.MasterBillofLading,
                            HouseBillofLanding = eh.HouseBillofLanding,
                            Status = ((eh.isCanceled != null && eh.isCanceled == true) ? "Canceled" : (cdsdt == null ? eh.Status : eh.Status + " - " + cdsdt.UdcDDesc)),
                            CustomsBrokerName = cbn == null ? "" : cbn.CustomsBrokerName,
                            ManagerName = eh.ManagerName
                        }
                       ).FirstOrDefault();

            return list;
        }
    }

}
