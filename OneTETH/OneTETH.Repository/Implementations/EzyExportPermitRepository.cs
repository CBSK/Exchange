using OneTETH.Model.Models;
using OneTETH.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository.Implementations
{
    public class EzyExportPermitRepository: IEzyExportPermitRepository
    {
        private OneTEDBContext _context;
        public EzyExportPermitRepository(OneTEDBContext context)
        {
            _context = context;
        }

        public List<EzyExportPermit> GetExportPermit(string InvoiceDUUID)
        {
            return (from permit in _context.EzyExportPermit where permit.InvoiceDuuid.ToString() == InvoiceDUUID select permit).ToList();
        }
    }
}
