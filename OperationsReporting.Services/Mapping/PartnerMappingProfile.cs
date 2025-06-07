using AutoMapper;
using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Entities;

namespace OperationsReporting.Services.Mapping
{
    public class PartnerMappingProfile : Profile
    {
        public PartnerMappingProfile()
        {
            CreateMap<Partner, PartnerExportDto>();
        }
    }
}
