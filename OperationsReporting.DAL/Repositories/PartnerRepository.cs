using OperationsReporting.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using OperationsReporting.Models.Entities;
using OperationsReporting.Models.DTO;

namespace OperationsReporting.DAL.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly OperationsReportingContext _context;

        public PartnerRepository(OperationsReportingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Partner>> GetAllAsync()
        {
            return await _context.Partners.ToListAsync();
        }

        public async Task<PagedResult<Partner>> GetPartnersAsync(int page, int pageSize)
        {
            var totalCount = await _context.Partners.CountAsync();

            var items = await _context.Partners
                .Include(p => p.Merchants)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Partner>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Items = items
            };
        }
    }
}
