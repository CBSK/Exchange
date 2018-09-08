using AutoMapper;
using OneTETH.Model.Models;
using OneTETH.Model.Models.DTO;
using OneTETH.Repository.Interfaces;
using OneTETH.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Service.Implementations
{
    public class EzyInvoiceExpDetailService : IEzyInvoiceExpDetailService
    {
        private IEzyInvoiceExpDetailRepository _ezyInvoiceExpDetailRepository;
        public EzyInvoiceExpDetailService(IEzyInvoiceExpDetailRepository ezyInvoiceExpDetailRepository)
        {
            _ezyInvoiceExpDetailRepository = ezyInvoiceExpDetailRepository;
        }

        public List<EzyInvoiceExpDetailDTO> GetInvoiceHeaderDetailList(string id)
        {

            var invoiceHeadersDetail = _ezyInvoiceExpDetailRepository.GetInvoiceHeaderDetailList(id);
            List<EzyInvoiceExpDetailDTO> invoiceHeadersDetailModel = Mapper.Map<List<EzyInvoiceExpDetail>, List<EzyInvoiceExpDetailDTO>>(invoiceHeadersDetail);
            return invoiceHeadersDetailModel;

        }

        public EzyInvoiceExpDetailDTO GetInvoiceDetailByID(string id)
        {

            var invoiceExpDetail = _ezyInvoiceExpDetailRepository.GetInvoiceDetailByID(id);
            EzyInvoiceExpDetailDTO invoiceExpDetailModel = Mapper.Map<EzyInvoiceExpDetail, EzyInvoiceExpDetailDTO>(invoiceExpDetail);
            return invoiceExpDetailModel;
        }
    }
}
