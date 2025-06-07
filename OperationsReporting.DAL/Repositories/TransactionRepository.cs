using Microsoft.EntityFrameworkCore;
using OperationsReporting.DAL.Interfaces;
using OperationsReporting.Models.Entities;

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
    }
}
