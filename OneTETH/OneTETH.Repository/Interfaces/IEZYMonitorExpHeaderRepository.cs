using OneTETH.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository.Interfaces
{
    public interface IEZYMonitorExpHeaderRepository
    {
        List<EzyMonitorExpHeaderDTO> GetMonitorExpHeaders(DateTime? fromDate = null, DateTime? toDate = null, string invoiceNo = null);
        EzyMonitorExpHeaderDTO GetMonitorHeaderDetail(Guid Id);
    }
}
