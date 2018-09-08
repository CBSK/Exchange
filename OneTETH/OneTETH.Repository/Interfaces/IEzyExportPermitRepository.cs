using OneTETH.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository.Interfaces
{
    public interface IEzyExportPermitRepository
    {
        List<EzyExportPermit> GetExportPermit(string InvoiceDUUID);
    }
}
