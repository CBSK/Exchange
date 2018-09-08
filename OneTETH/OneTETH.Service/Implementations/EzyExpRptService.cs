using OneTETH.Model.Models;
using OneTETH.Repository.Interfaces;
using OneTETH.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTETH.Service.Implementations
{
    public class EzyExpRptService : IEzyExpRptService
    {
        private IEzyExpRptRepository _ezyExpRptRepository;

        public EzyExpRptService(IEzyExpRptRepository ezyExpRptRepository)
        {
            _ezyExpRptRepository = ezyExpRptRepository;
        }

        public List<CustomsBroker> FilterCustomBroker(string brokerNameKeyword)
        {
            return _ezyExpRptRepository.FilterCustomBroker(brokerNameKeyword);
        }
        public async Task<long> AddEZYReportExportMonitor_WinService(EZYReportExportMonitor_WinService ObjEZYReportExportMonitor_WinService)
        {
            return await _ezyExpRptRepository.AddEZYReportExportMonitor_WinService(ObjEZYReportExportMonitor_WinService);
        }

    }
}
