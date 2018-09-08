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
    public class EzyInvoiceExpHeaderService: IEzyInvoiceExpHeaderService
    {
        private IEzyInvoiceExpHeaderRepository _ezyInvoiceExpHeaderRepository;
        public EzyInvoiceExpHeaderService(IEzyInvoiceExpHeaderRepository ezyInvoiceExpHeaderRepository)
        {
            _ezyInvoiceExpHeaderRepository = ezyInvoiceExpHeaderRepository;
        }


        public List<EzyInvoiceExpHeaderDTO> GetInvoiceHeaders(Guid txNoUUID)
        {
            var invoiceHeaders = _ezyInvoiceExpHeaderRepository.GetInvoiceHeaders(txNoUUID);
            List<EzyInvoiceExpHeaderDTO> invoiceHeadersModel = Mapper.Map<List<EzyInvoiceExpHeader>, List<EzyInvoiceExpHeaderDTO>>(invoiceHeaders);
            return invoiceHeadersModel;
        }
    }
}
