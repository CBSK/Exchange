using OneTETH.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository.Interfaces
{
    public interface IEzyInvoiceExpDetailRepository
    {
        List<EzyInvoiceExpDetail> GetInvoiceHeaderDetailList(string id);
        EzyInvoiceExpDetail GetInvoiceDetailByID(string id);
    }
}
