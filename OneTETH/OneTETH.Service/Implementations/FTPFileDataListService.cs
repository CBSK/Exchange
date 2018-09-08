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
    public class FTPFileDataListService: IFTPFileDataListService
    {
        private IFTPFileDataListRepository _fTPFileDataListRepository;
        public FTPFileDataListService(IFTPFileDataListRepository fTPFileDataListRepository)
        {
            _fTPFileDataListRepository = fTPFileDataListRepository;
        }

        public FTPFileDataListDTO GetFileData(int Id)
        {
            var ftpFileData = _fTPFileDataListRepository.GetFileData(Id);
            FTPFileDataListDTO ftpFileDataModel = Mapper.Map<FTPFileDataList, FTPFileDataListDTO>(ftpFileData);
            return ftpFileDataModel;
        }
    }
}
