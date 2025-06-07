using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL.Interfaces
{
    public interface IMerchantRepository
    {
        Task<List<Merchant>> GetAllAsync();
    }
}
