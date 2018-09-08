using OneTETH.Model.Models.DTO;
using OneTETH.Repository.Interfaces;
using OneTETH.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace OneTETH.Service.Implementations
{
    public class EZYMonitorExpHeaderService : IEZYMonitorExpHeaderService
    {
        private IEZYMonitorExpHeaderRepository _eZYMonitorExpHeaderRepository;
        public EZYMonitorExpHeaderService(IEZYMonitorExpHeaderRepository eZYMonitorExpHeaderRepository)
        {
            _eZYMonitorExpHeaderRepository = eZYMonitorExpHeaderRepository;
        }

        public List<EzyMonitorExpHeaderDTO> GetMonitorExpHeaders(DateTime? fromDate = null, DateTime? toDate = null, string invoiceNo = null)
        {
            return _eZYMonitorExpHeaderRepository.GetMonitorExpHeaders(fromDate, toDate, invoiceNo);
        }
        public EzyMonitorExpHeaderDTO GetMonitorHeaderDetail(Guid Id)
        {
            return _eZYMonitorExpHeaderRepository.GetMonitorHeaderDetail(Id);
        }
    }
}
