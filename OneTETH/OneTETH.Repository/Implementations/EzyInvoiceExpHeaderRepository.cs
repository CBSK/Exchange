using OneTETH.Model.Models;
using OneTETH.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneTETH.Model.Models.DTO;
namespace OneTETH.Repository.Implementations
{
    public class EzyInvoiceExpHeaderRepository : IEzyInvoiceExpHeaderRepository
    {
        private OneTEDBContext _context;
        public EzyInvoiceExpHeaderRepository(OneTEDBContext context)
        {
            _context = context;
        }
        public List<EzyInvoiceExpHeader> GetInvoiceHeaders(Guid txNoUUID)
        {
            return (from InvoiceHeader in _context.EzyInvoiceExpHeader
                    where InvoiceHeader.TxNoUuid == txNoUUID
                    select InvoiceHeader).ToList();
        }
        public List<EzyInvoiceExpHeaderDTO> GetInvoiceHeaders_DTO(Guid txNoUUID)
        {
            return (from InvoiceHeader in _context.EzyInvoiceExpHeader
                    where InvoiceHeader.TxNoUuid == txNoUUID
                    select new EzyInvoiceExpHeaderDTO
                    {
                        InvoiceHuuid = InvoiceHeader.InvoiceHuuid,
                        TxNoUuid = InvoiceHeader.TxNoUuid,
                        ReferenceNumber = InvoiceHeader.ReferenceNumber,
                        InvoiceNumber = InvoiceHeader.InvoiceNumber,
                        InvoiceDate = InvoiceHeader.InvoiceDate,
                        PurchaseOrderNumber = InvoiceHeader.PurchaseOrderNumber,
                        TermsofPaymentCode = InvoiceHeader.TermsofPaymentCode,
                        TradeTerms = InvoiceHeader.TradeTerms,
                        SellerStatus = InvoiceHeader.SellerStatus,
                        ConsigneeName = InvoiceHeader.ConsigneeName,
                        ConsigneeStreetAndNumber = InvoiceHeader.ConsigneeStreetAndNumber,
                        ConsigneeDistrict = InvoiceHeader.ConsigneeDistrict,
                        ConsigneeSubProvince = InvoiceHeader.ConsigneeSubProvince,
                        ConsigneeProvince = InvoiceHeader.ConsigneeProvince,
                        ConsigneePostcode = InvoiceHeader.ConsigneePostcode,
                        ConsigneeCountryCode = InvoiceHeader.ConsigneeCountryCode,
                        InvoiceCurrencyCode = InvoiceHeader.InvoiceCurrencyCode,
                        TotalInvoiceAmount = InvoiceHeader.TotalInvoiceAmount,
                        ForwardingChargeForeign = InvoiceHeader.ForwardingChargeForeign,
                        FreightCurrencyCode = InvoiceHeader.FreightCurrencyCode,
                        FreightAmountForeign = InvoiceHeader.FreightAmountForeign,
                        InsuranceCurrencyCode = InvoiceHeader.InsuranceCurrencyCode,
                        InsuranceAmountForeign = InvoiceHeader.InsuranceAmountForeign,
                        PackingChargeCurrencyCode = InvoiceHeader.PackingChargeCurrencyCode,
                        PackingChargeAmountForeign = InvoiceHeader.PackingChargeAmountForeign,
                        InteriorTransportCurrencyCode = InvoiceHeader.InteriorTransportCurrencyCode,
                        InteriorTransportAmountForeign = InvoiceHeader.InteriorTransportAmountForeign,
                        LandingChargeCurrencyCode = InvoiceHeader.LandingChargeCurrencyCode,
                        LandingChargeAmountForeign = InvoiceHeader.LandingChargeAmountForeign,
                        OtherChargeCurrencyCode = InvoiceHeader.OtherChargeCurrencyCode,
                        OtherChargeAmountForeign = InvoiceHeader.OtherChargeAmountForeign,
                        SelfCertificationRemark = InvoiceHeader.SelfCertificationRemark,
                        AeosReferenceNumber = InvoiceHeader.AeosReferenceNumber,
                        DisplayInvoiceDate = InvoiceHeader.InvoiceDate == null ? string.Empty : Convert.ToDateTime(InvoiceHeader.InvoiceDate).ToString("dd/MM/yyyy"),
                    }).ToList();


        }

    }
}
