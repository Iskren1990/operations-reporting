using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL.Interfaces
{
    public interface IMerchantRepository
    {
        Task<List<Merchant>> GetAllAsync();

        Task<PagedResult<Merchant>> GetMerchantsAsync(int page, int pageSize);
    }
}
