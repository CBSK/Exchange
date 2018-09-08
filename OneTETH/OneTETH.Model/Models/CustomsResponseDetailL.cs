using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneTETH.Model.Models
{
    [Table("CustomsResponseDetail")]
    public class CustomsResponseDetail
    {
        [Key]
        public Guid CustomsResponseDetailUUID { get; set; }
        public Guid CustomsResponseUUID { get; set; }
        public string MessageType { get; set; }
        public string Status { get; set; }
        public string DeclarationNumber { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalDeposit { get; set; }
        public int? ReleasePort { get; set; }
        public string Message { get; set; }
        public int? ItemNumber { get; set; }
        public string ErrorCode { get; set; }
        public string GoodsTransitionNumber { get; set; }
        public string ContainerNumber { get; set; }
        public int? LoadPort { get; set; }
        public DateTime? AuditDateTime { get; set; }
        public string PaymentType { get; set; }
        public string PaymentNumber { get; set; }
        public string BankTransactionNumber { get; set; }
        public decimal? TotalAmount { get; set; }
        public string DocumentNumber { get; set; }
        public string DeclarationLineNumber { get; set; }
        public string NewVesselName { get; set; }
        public string NewVoyageNumber { get; set; }
        public string ReceivedControlNumber { get; set; }
        public int? PortCode { get; set; }
        public string TaxIncentivesID { get; set; }
        public int? ExportDeclarationNumber { get; set; }
        public string ExportDeclarationLineNumber { get; set; }
        public int? ImportDeclarationNumber { get; set; }
        public string ImportDeclarationLineNumber { get; set; }
        public int? ModelNumber { get; set; }
        public string ModelVersion { get; set; }
        public string CompanyTaxNumber { get; set; }
        public int? CompanyBranch { get; set; }
        public int? InformPort { get; set; }
        public int? InformNumber { get; set; }
        public DateTime? InformDate { get; set; }
        public string InlandDeclarationNumber { get; set; }
        public int? XML_ID { get; set; }
    }
}
