using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Filters;

namespace OperationsReporting.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<ImportResultDto<string>> ImportTransactionsFromXmlAsync(string xmlFilePath, int merchantId);

        Task<PagedResult<TransactionDto>> GetTransactionsAsync(TransactionFilter filter, int page, int pageSize);
    }
}
