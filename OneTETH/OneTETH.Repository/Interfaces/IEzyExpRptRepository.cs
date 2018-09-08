using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneTETH.Model.Models;
namespace OneTETH.Repository.Interfaces
{
    public interface IEzyExpRptRepository
    {
        List<CustomsBroker> FilterCustomBroker(string borkerNameKeyword);
        Task<long> AddEZYReportExportMonitor_WinService(EZYReportExportMonitor_WinService ObjEZYReportExportMonitor_WinService);
    }
}
