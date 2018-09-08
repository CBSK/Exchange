using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models
{
    public class ReportModel
    {
        //public Int64 RowNo { get; set; }
        public string BrokerTaxNumber { get; set; }
        public string ConsigneeName { get; set; }
        public string PurchaseCountryCode { get; set; }
        public string DestinationCountryCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string DeclarationNumber { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Status { get; set; }
        public Int32 ItemNumber { get; set; }
        public string ProductCode { get; set; }
        public string EnglishDescriptionOfGoods { get; set; }
        public string ThaiDescriptionOfGoods { get; set; }
        public decimal Quantity { get; set; }
        public string TradeTerms { get; set; }
        public string LoadPortAreaName { get; set; }
        public decimal InvoiceAmountBaht { get; set; }
        public decimal BahtAmountTenPercent { get; set; }
        public decimal BahtAmountOnePercent { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal FOBValueBhat { get; set; }
        public Int32 TariffCode { get; set; }
        public Int32 ReleasePort { get; set; }
        public string AreaName { get; set; }
        public Int32 StatisticalCode { get; set; }
        public string Compensation { get; set; }
        public Int32 LoadPort { get; set; }
        public string PermitNumber { get; set; }
        public string OriginCountryCode { get; set; }
        public Guid InvoiceHUUID { get; set; }
        public Guid InvoiceDUUID { get; set; }
        public string ModeOfTransport { get; set; }
        public string CustomsBrokerName { get; set; }
        public string AuditDateTime { get; set; }
        public decimal Ratio { get; set; }
        public decimal FrtCCY { get; set; }
        public decimal InsCCY { get; set; }

    }
}
