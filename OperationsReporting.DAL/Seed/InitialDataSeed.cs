using Microsoft.EntityFrameworkCore;
using OperationsReporting.Models.Entities;

namespace OperationsReporting.DAL.Seed
{
    internal static class InitialDataSeed
    {
        internal static void Seed(this ModelBuilder modelBuilder)
        {
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
