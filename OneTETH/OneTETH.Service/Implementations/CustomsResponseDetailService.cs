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
    public class CustomsResponseDetailService: ICustomsResponseDetailService
    {
        private ICustomsResponseDetailRepository _customsResponseDetailRepository;
        public CustomsResponseDetailService(ICustomsResponseDetailRepository customsResponseDetailRepository)
        {
            _customsResponseDetailRepository = customsResponseDetailRepository;
        }
        public List<CustomsResponseDetailDTO> GetCustomsResponseDetails(string decNo)
        {
            var customsDetail = _customsResponseDetailRepository.GetCustomsResponseDetails(decNo);
            List<CustomsResponseDetailDTO> customsDetailModel = Mapper.Map<List<CustomsResponseDetail>, List<CustomsResponseDetailDTO>>(customsDetail);
            return customsDetailModel;
        }
    }
}
