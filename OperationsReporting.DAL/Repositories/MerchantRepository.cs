using Microsoft.EntityFrameworkCore;
using OperationsReporting.DAL.Interfaces;
using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly OperationsReportingContext _context;

        public MerchantRepository(OperationsReportingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Merchant>> GetAllAsync()
        {
            return await _context.Merchants.ToListAsync();
        }


        public async Task<PagedResult<Merchant>> GetMerchantsAsync(int page, int pageSize)
        {
            var totalCount = await _context.Merchants.CountAsync();

            var items = await _context.Merchants
                .Include(m => m.Partner)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Merchant>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Items = items
            };
        }
    }
}
