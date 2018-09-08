using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneTETH.Model.Models;
using OneTETH.Repository.Interfaces;

namespace OneTETH.Repository.Implementations
{
    public class EzyExpRptRepository : IEzyExpRptRepository
    {
        private OneTEDBContext _context;

        public EzyExpRptRepository(OneTEDBContext context)
        {
            _context = context;
        }
        public List<CustomsBroker> FilterCustomBroker(string borkerNameKeyword)
        {
            List<CustomsBroker> filteredCustomBroker = _context.CustomsBroker.Where(x => x.CustomsBrokerName.Contains(borkerNameKeyword)).ToList();
            return filteredCustomBroker;
        }
        public async Task<long> AddEZYReportExportMonitor_WinService(EZYReportExportMonitor_WinService ObjEZYReportExportMonitor_WinService)
        {
            try
            {
                if (ObjEZYReportExportMonitor_WinService != null)
                {


                    if (ObjEZYReportExportMonitor_WinService.EZYReportExportMonitorID < 1)
                    {
                        ObjEZYReportExportMonitor_WinService.AddOn = DateTime.Now;
                        _context.Add(ObjEZYReportExportMonitor_WinService);
                    }
                    else
                    {
                        ObjEZYReportExportMonitor_WinService.ModOn = DateTime.Now;
                        _context.Update(ObjEZYReportExportMonitor_WinService);
                    }
                    await _context.SaveChangesAsync();

                }
                return ObjEZYReportExportMonitor_WinService.EZYReportExportMonitorID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
