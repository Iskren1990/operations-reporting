using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL.Interfaces
{
    public interface IPartnerRepository
    {
        Task<List<Partner>> GetAllAsync();
    }
}
