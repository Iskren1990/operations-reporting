using OperationsReporting.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly OperationsReportingContext _context;

        public PartnerRepository(OperationsReportingContext context)
        {
            _context = context;
        }

        public async Task<List<Partner>> GetAllAsync()
        {
            return await _context.Partners.ToListAsync();
        }
    }
}
