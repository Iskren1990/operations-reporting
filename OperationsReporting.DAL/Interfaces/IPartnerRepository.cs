using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL.Interfaces
{
    public interface IPartnerRepository
    {
        Task<List<Partner>> GetAllAsync();

        Task<PagedResult<Partner>> GetPartnersAsync(int page, int pageSize);
    }
}
