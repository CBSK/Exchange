using AutoMapper;
using OneTETH.Model.Models;
using OneTETH.Model.Models.DTO;
using OneTETH.Repository.Interfaces;
using OneTETH.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Service.Implementations
{
    public class EzyExportPermitService: IEzyExportPermitService
    {
        private IEzyExportPermitRepository _ezyExportPermitRepository;
        public EzyExportPermitService(IEzyExportPermitRepository ezyExportPermitRepository)
        {
            _ezyExportPermitRepository = ezyExportPermitRepository;
        }
        public List<EzyExportPermitDTO> GetExportPermit(string InvoiceDUUID)
        {
            var ezyExportPermits = _ezyExportPermitRepository.GetExportPermit(InvoiceDUUID);
            List<EzyExportPermitDTO> ezyExportPermitsModel = Mapper.Map<List<EzyExportPermit>, List<EzyExportPermitDTO>>(ezyExportPermits);
            return ezyExportPermitsModel;
        }
    }
}
