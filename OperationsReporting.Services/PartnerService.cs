using AutoMapper;
using OperationsReporting.DAL.Interfaces;
using OperationsReporting.Models.DTO;
using OperationsReporting.Services.Interfaces;

namespace OperationsReporting.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepo;
        private readonly IMapper _mapper;

        public PartnerService(IPartnerRepository partnerRepo, IMapper mapper)
        {
            _partnerRepo = partnerRepo ?? throw new ArgumentNullException(nameof(partnerRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PagedResult<PartnerDto>> GetPartnersAsync(int page, int pageSize)
        {
            var result = await _partnerRepo.GetPartnersAsync(page, pageSize);

            return new PagedResult<PartnerDto>
            {
                Page = result.Page,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                Items = _mapper.Map<List<PartnerDto>>(result.Items)
            };
        }
    }
}
