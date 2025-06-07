using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync();
    }
}
