using OperationsReporting.Models.Entities;
using OperationsReporting.Models.Filters;

namespace OperationsReporting.DAL.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync();

        Task BulkInsertIfNotExistsAsync(List<Transaction> transactions);

        Task<(List<Transaction> Transactions, int TotalCount)> GetFilteredTransactionsAsync(TransactionFilter filter, int page, int pageSize);

    }
}
