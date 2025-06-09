using System.ComponentModel.DataAnnotations;

namespace OperationsReporting.Models.Entities
{
    public class Merchant
    {
        public long Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public DateTime BoardingDate { get; set; }

        [Required]
        public required string Url { get; set; }

        [Required]
        public required string Country { get; set; }

        [Required]
        public required string AddressMain { get; set; }

        public string? AddressSecondary { get; set; }

        public long PartnerId { get; set; }

        public Partner Partner { get; set; } = null!;

        public List<Transaction> Transactions { get; set; } = [];
    }
}