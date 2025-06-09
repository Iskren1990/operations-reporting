using AutoMapper;
using OperationsReporting.DAL.Interfaces;
using OperationsReporting.Models.DTO;
using OperationsReporting.Services.Interfaces;

namespace OperationsReporting.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _merchantRepo;
        private readonly IMapper _mapper;

        public MerchantService(IMerchantRepository merchantRepo, IMapper mapper)
        {
            _merchantRepo = merchantRepo ?? throw new ArgumentNullException(nameof(merchantRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PagedResult<MerchantDto>> GetMerchantsAsync(int page, int pageSize)
        {
            var result = await _merchantRepo.GetMerchantsAsync(page, pageSize);

            return new PagedResult<MerchantDto>
            {
                Page = result.Page,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                Items = _mapper.Map<List<MerchantDto>>(result.Items)
            };
        }
    }
}
