using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models.DTO
{
    public class EzyMonitorExpHeaderDTO
    {
        public Guid txNoUUID { get; set; }
        public string ReferenceNumber { get; set; }
        public string DocumentType { get; set; }
        public string CompanyTaxNumber { get; set; }
        public string CompanyBranch { get; set; }
        public string CompanyNameThai { get; set; }
        public string CompanyNameEnglish { get; set; }
        public string StreetAndNumber { get; set; }
        public string District { get; set; }
        public string SubProvince { get; set; }
        public string Province { get; set; }
        public string Postcode { get; set; }
        public string BrokerTaxNumber { get; set; }
        public string BrokerBranch { get; set; }
        public string CustomsClearanceIDCard { get; set; }
        public string CustomsClearanceName { get; set; }
        public string ManagerIDCode { get; set; }
        public string ManagerName { get; set; }
        public string ModeOfTransport { get; set; }
        public string ModeOfTransportDesc { get; set; }
        public string CargoTypeCode { get; set; }
        public string VesselName { get; set; }
        public Nullable<System.DateTime> DepartureDate { get; set; }
        public string MasterBillofLading { get; set; }
        public string HouseBillofLanding { get; set; }
        public string ReleasePort { get; set; }
        public string LoadPort { get; set; }
        public string PurchaseCountryCode { get; set; }
        public string DestinationCountryCode { get; set; }
        public string ShippingMarks { get; set; }
        public Nullable<int> TotalPackageAmount { get; set; }
        public string TotalPackageUnitCode { get; set; }
        public Nullable<decimal> TotalNetWeight { get; set; }
        public string NetWeightUnitCode { get; set; }
        public Nullable<decimal> TotalGrossWeight { get; set; }
        public string TotalGrossWeightUnitCode { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<decimal> FOBValueForeign { get; set; }
        public Nullable<decimal> FOBValueBaht { get; set; }
        public Nullable<int> RGSCode { get; set; }
        public Nullable<int> CustomsBankCode { get; set; }
        public Nullable<int> BankCode { get; set; }
        public Nullable<int> BankBranchCode { get; set; }
        public string BankAccountNumber { get; set; }
        public Nullable<decimal> TotalPaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public Nullable<decimal> TotalTax { get; set; }
        public Nullable<decimal> TotalDeposit { get; set; }
        public string CommonAccessReferenceNumber { get; set; }
        public string AssessmentRequestCode { get; set; }
        public string InspectionRequestCode { get; set; }
        public string GuaranteeMethod { get; set; }
        public string GuaranteeType { get; set; }
        public Nullable<int> GuaranteeBankCode { get; set; }
        public Nullable<int> GuaranteeBankBranchCode { get; set; }
        public string GuaranteeBankAccountNumber { get; set; }
        public Nullable<decimal> TotalDepositAmount { get; set; }
        public string ExportTaxIncentivesID { get; set; }
        public string TradingPartnerTaxNumber { get; set; }
        public Nullable<int> CompanyTradingBranch { get; set; }
        public string SubBrokerTaxNumber { get; set; }
        public string DeferredDutyTaxFee { get; set; }
        public Nullable<int> TaxCardBankCode { get; set; }
        public Nullable<int> TaxCardBankBranchCode { get; set; }
        public string TaxCarfAccountNumber { get; set; }
        public Nullable<decimal> TotalTaxCardPayAmount { get; set; }
        public string SenderRegistrationID { get; set; }
        public string DeclarationNumber { get; set; }
        public Nullable<int> PDF_ID { get; set; }
        public Nullable<int> XML_ID { get; set; }
        public string Status { get; set; }
        public string CustomsBrokerName { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string DisplaySubmissionDate { get; set; }
        public string DisplayDepartureDate { get; set; }
    }
   
}
