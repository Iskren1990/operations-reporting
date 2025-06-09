using OperationsReporting.Models.DTO;

namespace OperationsReporting.Services.Interfaces
{
    public interface IPartnerService
    {
        Task<PagedResult<PartnerDto>> GetPartnersAsync(int page, int pageSize);
    }
}
