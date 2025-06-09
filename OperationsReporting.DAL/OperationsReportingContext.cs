using Microsoft.EntityFrameworkCore;
using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL
{
    public class OperationsReportingContext : DbContext
    {
        public OperationsReportingContext(DbContextOptions<OperationsReportingContext> options)
            : base(options)
        {
        }

        public DbSet<Partner> Partners { get; set; }

        public DbSet<Merchant> Merchants { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partner>()
                .ToTable("partners")
                .HasMany(p => p.Merchants)
                .WithOne(m => m.Partner)
                .HasForeignKey(m => m.PartnerId);

            modelBuilder.Entity<Merchant>()
                .ToTable("merchants")
                .HasMany(m => m.Transactions)
                .WithOne(t => t.Merchant)
                .HasForeignKey(t => t.MerchantId);

            modelBuilder.Entity<Transaction>()
                .ToTable("transactions")
                .HasIndex(t => t.ExternalId)
                .IsUnique();

            modelBuilder.Entity<Partner>().HasData(new Partner
            {
                Id = 1,
                Name = "Test Partner"
            });

            modelBuilder.Entity<Merchant>().HasData(
                new Merchant
                {
                    Id = 1,
                    Name = "Merchant A",
                    BoardingDate = new DateTime(2023, 05, 01, 0, 0, 0, DateTimeKind.Utc),
                    Url = "https://merchant-a.com",
                    Country = "Netherlands",
                    AddressMain = "Main Street 123",
                    AddressSecondary = "Suite 4B",
                    PartnerId = 1
                },
                new Merchant
                {
                    Id = 2,
                    Name = "Merchant B",
                    BoardingDate = new DateTime(2023, 04, 01, 0, 0, 0, DateTimeKind.Utc),
                    Url = "https://merchant-b.com",
                    Country = "Bulgaria",
                    AddressMain = "Secondary Street 45",
                    AddressSecondary = null,
                    PartnerId = 1
                }
            );
        }
    }
}
