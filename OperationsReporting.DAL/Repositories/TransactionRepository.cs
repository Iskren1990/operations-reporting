using Microsoft.EntityFrameworkCore;
using OperationsReporting.DAL.Interfaces;
using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Entities;
using OperationsReporting.Models.Filters;

namespace OperationsReporting.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly OperationsReportingContext _context;

        public TransactionRepository(OperationsReportingContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<ImportResultDto<string>> BulkInsertIfNotExistsAsync(List<Transaction> transactions)
        {
            if (transactions == null || transactions.Count == 0)
                return new ImportResultDto<string> { Total = 0, Inserted = 0, SkippedIds = [] };

            var externalIds = transactions.Select(t => t.ExternalId).ToList();

            var existingIds = await _context.Transactions
                .Where(t => externalIds.Contains(t.ExternalId))
                .Select(t => t.ExternalId)
                .ToListAsync();

            var newTransactions = transactions
                .Where(t => !existingIds.Contains(t.ExternalId))
                .ToList();

            if (newTransactions.Count > 0)
            {
                await _context.Transactions.AddRangeAsync(newTransactions);
                await _context.SaveChangesAsync();
            }

            var notInsertedIds = transactions
                .Where(t => existingIds.Contains(t.ExternalId))
                .Select(t => t.ExternalId)
                .ToList();

            return new ImportResultDto<string>
            {
                Total = transactions.Count,
                Inserted = newTransactions.Count,
                SkippedIds = notInsertedIds
            };
        }

        public async Task<(List<Transaction> Transactions, int TotalCount)> GetFilteredTransactionsAsync(TransactionFilter filter, int page, int pageSize)
        {
            IQueryable<Transaction> query = _context.Transactions.AsNoTracking();

            if (filter.DateFrom.HasValue)
                query = query.Where(t => t.DateCreated >= filter.DateFrom.Value);

            if (filter.DateTo.HasValue)
                query = query.Where(t => t.DateCreated <= filter.DateTo.Value);

            if (filter.MinAmount.HasValue)
                query = query.Where(t => t.Amount >= filter.MinAmount.Value);

            if (filter.MaxAmount.HasValue)
                query = query.Where(t => t.Amount <= filter.MaxAmount.Value);

            if (filter.TransactionType.HasValue)
                query = query.Where(t => t.TransactionType == filter.TransactionType.Value);

            if (filter.Status.HasValue)
                query = query.Where(t => t.Status == filter.Status.Value);

            var totalCount = await query.CountAsync();

            var transactions = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (transactions, totalCount);
        }
    }
}
