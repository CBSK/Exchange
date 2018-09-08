using System.Collections.Generic;
using OneTETH.Model.Models;
using System.Threading.Tasks;

namespace OneTETH.Service.Interfaces
{
    public interface IEzyExpRptService
    {
        List<CustomsBroker> FilterCustomBroker(string brokerNameKeyword);
        Task<long> AddEZYReportExportMonitor_WinService(EZYReportExportMonitor_WinService ObjEZYReportExportMonitor_WinService);
    }
}
