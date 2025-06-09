using OperationsReporting.Models.DTO;

namespace OperationsReporting.Services.Interfaces
{
    public interface IMerchantService
    {
        Task<PagedResult<MerchantDto>> GetMerchantsAsync(int page, int pageSize);
    }
}
