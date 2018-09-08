using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneTETH.Model.Models
{
    [Table("EzyInvoiceExpHeader")]
    public class EzyInvoiceExpHeader
    {
        [Column(Order = 0), Key]
        public Guid InvoiceHuuid { get; set; }
        [Column(Order = 1), Key]
        public Guid TxNoUuid { get; set; }
        public string ReferenceNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string TermsofPaymentCode { get; set; }
        public string TradeTerms { get; set; }
        public string SellerStatus { get; set; }
        //public string ConsigneeInfoStatus { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeStreetAndNumber { get; set; }
        public string ConsigneeDistrict { get; set; }
        public string ConsigneeSubProvince { get; set; }
        public string ConsigneeProvince { get; set; }
        public string ConsigneePostcode { get; set; }
        public string ConsigneeCountryCode { get; set; }
        //public string Email { get; set; }
        public string InvoiceCurrencyCode { get; set; }
        public decimal? TotalInvoiceAmount { get; set; }
        //public string ForwardingCharge { get; set; }
        public decimal? ForwardingChargeForeign { get; set; }
        public string FreightCurrencyCode { get; set; }
        public decimal? FreightAmountForeign { get; set; }
        public string InsuranceCurrencyCode { get; set; }
        public decimal? InsuranceAmountForeign { get; set; }
        public string PackingChargeCurrencyCode { get; set; }
        public decimal? PackingChargeAmountForeign { get; set; }
        public string InteriorTransportCurrencyCode { get; set; }
        public decimal? InteriorTransportAmountForeign { get; set; }
        public string LandingChargeCurrencyCode { get; set; }
        public decimal? LandingChargeAmountForeign { get; set; }
        public string OtherChargeCurrencyCode { get; set; }
        public decimal? OtherChargeAmountForeign { get; set; }
        //public string OtherChargeDescription { get; set; }
        public string SelfCertificationRemark { get; set; }
        public string AeosReferenceNumber { get; set; }
    }
}
