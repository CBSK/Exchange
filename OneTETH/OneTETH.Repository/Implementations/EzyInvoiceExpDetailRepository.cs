using OneTETH.Model.Models;
using OneTETH.Model.Models.DTO;
using OneTETH.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository.Implementations
{
    public class EzyInvoiceExpDetailRepository : IEzyInvoiceExpDetailRepository
    {
        private OneTEDBContext _context;
        public EzyInvoiceExpDetailRepository(OneTEDBContext context)
        {
            _context = context;
        }

        public List<EzyInvoiceExpDetail> GetInvoiceHeaderDetailList(string id)
        {

            List<EzyInvoiceExpDetail> listInvoice = _context.EzyInvoiceExpDetail.Where(x => x.InvoiceHuuid.ToString() == id).ToList();
            return listInvoice;

        }

        public EzyInvoiceExpDetail GetInvoiceDetailByID(string id)
        {

            return _context.EzyInvoiceExpDetail.Where(x => x.InvoiceDuuid.ToString() == id).FirstOrDefault();

        }
    }
}
