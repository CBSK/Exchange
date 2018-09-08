using OneTETH.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Service.Interfaces
{
    public interface IEZYMonitorExpHeaderService
    {
        List<EzyMonitorExpHeaderDTO> GetMonitorExpHeaders(DateTime? fromDate = null, DateTime? toDate = null, string invoiceNo = null);
        EzyMonitorExpHeaderDTO GetMonitorHeaderDetail(Guid Id);
    }
}
