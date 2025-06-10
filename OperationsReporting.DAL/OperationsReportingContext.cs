using Microsoft.EntityFrameworkCore;
using OperationsReporting.DAL.Seed;
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

            modelBuilder.Seed();
        }
    }
}
