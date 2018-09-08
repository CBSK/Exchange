using OneTETH.Model.Models;
using OneTETH.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository.Interfaces
{
    public interface IEzyInvoiceExpHeaderRepository
    {
        List<EzyInvoiceExpHeader> GetInvoiceHeaders(Guid txNoUUID);
        //List<EzyInvoiceExpHeaderDTO> GetInvoiceHeaders_DTO(Guid txNoUUID);
    }
}
