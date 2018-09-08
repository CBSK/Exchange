using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneTETH.Model.Models
{
    [Table("EzyInvoiceExpDetail")]
    public class EzyInvoiceExpDetail
    {
        [Column(Order = 0), Key]
        public Guid InvoiceDuuid { get; set; }
        [Column(Order = 1), Key]
        public Guid InvoiceHuuid { get; set; }
        [Column(Order = 2), Key]
        public Guid TxNoUuid { get; set; }
        public string ReferenceNumber { get; set; }
        public int ItemNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string CurrencyCode { get; set; }
        public int InvoiceItemNumber { get; set; }
        public int TariffCode { get; set; }
        public int TariffSequence { get; set; }
        public int StatisticalCode { get; set; }
        public string ExportTariff { get; set; }
        public string PrivilegeCode { get; set; }
        public int? Ahtncode { get; set; }
        public int? NatureofTransaction { get; set; }
        public int? Undgnumber { get; set; }
        //public string ProductCodeCompany { get; set; }
        public string ThaiDescriptionOfGoods { get; set; }
        public string EnglishDescriptionOfGoods { get; set; }
        public string ProductCode { get; set; }
        public string CustomsProductCode { get; set; }
        public string ProductAttribute1 { get; set; }
        public string ProductAttribute2 { get; set; }
        public string ProductYear { get; set; }
        public string BrandName { get; set; }
        public string Remark { get; set; }
        public string OriginCountryCode { get; set; }
        public decimal NetWeight { get; set; }
        public string NetWeightUnitCode { get; set; }
        public decimal Quantity { get; set; }
        public string QuantityUnitCode { get; set; }
        //public decimal RateofExchange { get; set; }
        public decimal UnitPriceForeign { get; set; }
        public decimal UnitPriceBaht { get; set; }
        public decimal InvoiceQuantity { get; set; }
        public string InvoiceQuantityUnitCode { get; set; }
        public decimal InvoiceAmountForeign { get; set; }
        public decimal InvoiceAmountBaht { get; set; }
        public decimal? IncreasedPriceForeign { get; set; }
        public decimal? IncreasedPriceBhat { get; set; }
        public decimal FobvalueForeign { get; set; }
        public decimal FobvalueBhat { get; set; }
        public decimal? FobvalueAssess { get; set; }
        public string ShippingMarks { get; set; }
        public int? PackageAmount { get; set; }
        public string PackageUnitCode { get; set; }
        public string ReImportationCertificate { get; set; }
        public string Boi { get; set; }
        public string Bond { get; set; }
        public string Bis19 { get; set; }
        public string ReExport { get; set; }
        public string Fz { get; set; }
        public string Ieat { get; set; }
        public string Compensation { get; set; }
        public string ReferenceDeclarationNumber { get; set; }
        public int? ReferenceDeclarationLineNumber { get; set; }
        public string Bis19TransferNumber { get; set; }
        public string BoilicenseNumber { get; set; }
        public string PurchaseCountryCode { get; set; }
        public string ImportTaxIncentivesId { get; set; }
        //public decimal? ArgumentativeTariff { get; set; }
        public decimal? ArgumentativeTariffSequence { get; set; }
        public string ArgumentativeExportTariff { get; set; }
        public string OriginCriteria { get; set; }
        public string ArgumentativeReasonCode { get; set; }
        public string CertifiedExporterNumber { get; set; }
        public decimal? GrossWeight { get; set; }
        public string ProcedureCode { get; set; }
        public decimal? ValuationCode { get; set; }
        public decimal? DeductedAmount { get; set; }
        public string ModelNumber { get; set; }
        public int? ModelVersion { get; set; }
        //public string ModelCompTaxNumber { get; set; }
        public string LastEntry { get; set; }
    }
}
