using OperationsReporting.Models.Entities;

namespace OperationsReporting.Models.DTO
{
    public class MerchantDto
    {
        public long Id { get; set; }
        
        public required string Name { get; set; }
        
        public DateTime BoardingDate { get; set; }
        
        public required string Url { get; set; }
        
        public required string Country { get; set; }
        
        public required string AddressMain { get; set; }
        
        public string? AddressSecondary { get; set; }

        public long PartnerId { get; set; }

        public List<TransactionDto> Transactions { get; set; } = [];
    }
}
