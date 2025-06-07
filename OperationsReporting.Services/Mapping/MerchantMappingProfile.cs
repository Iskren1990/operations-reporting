using AutoMapper;
using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Entities;

namespace OperationsReporting.Services.Mapping
{
    public class MerchantMappingProfile: Profile
    {
        public MerchantMappingProfile()
        {
            CreateMap<Merchant, MerchantExportDto>();
        }
    }
}
