using Microsoft.EntityFrameworkCore;
using OperationsReporting.DAL.Interfaces;
using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly OperationsReportingContext _context;

        public MerchantRepository(OperationsReportingContext context)
        {
            _context = context;
        }

        public async Task<List<Merchant>> GetAllAsync()
        {
            return await _context.Merchants.ToListAsync();
        }
    }
}
