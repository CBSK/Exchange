using OneTETH.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Service.Interfaces
{
    public interface IEzyInvoiceExpHeaderService
    {
        List<EzyInvoiceExpHeaderDTO> GetInvoiceHeaders(Guid txNoUUID);
        //List<EzyInvoiceExpHeaderDTO> GetInvoiceHeaders_DTO(Guid txNoUUID);
    }
}
