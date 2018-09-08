using AutoMapper;
using AutoMapper.Configuration;
using OneTETH.Model.Models;
using OneTETH.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Service.AutomapperConfig
{
    public static class AutomapperConfig
    {
        public static void Configure()
        {
            MapperConfigurationExpression cfg = new MapperConfigurationExpression();

            cfg.CreateMap<EzyMonitorExpHeader, EzyMonitorExpHeaderDTO>();
            cfg.CreateMap<CustomsResponseDetail, CustomsResponseDetailDTO>();
            cfg.CreateMap<EzyInvoiceExpDetail, EzyInvoiceExpDetailDTO>().ForMember(
        dest => dest.StatisticalCode,
        opt => opt.MapFrom(src => src.StatisticalCode.ToString("D3"))
    );
            cfg.CreateMap<EzyInvoiceExpHeader, EzyInvoiceExpHeaderDTO>()            
           .ForMember(dest => dest.DisplayInvoiceDate, opts => opts.MapFrom(src =>
           src.InvoiceDate != null ? Convert.ToDateTime(src.InvoiceDate).ToString("dd/MM/yyyy") : string.Empty));

            cfg.CreateMap<EzyExportPermit, EzyExportPermitDTO>()
          .ForMember(dest => dest.DisplayIssueDate, opts => opts.MapFrom(src =>
          src.IssueDate != null ? Convert.ToDateTime(src.IssueDate).ToString("dd/MM/yyyy") : string.Empty));

            cfg.AllowNullDestinationValues = true;

            Mapper.Initialize(cfg);
        }

    }
}
