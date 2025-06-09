using OperationsReporting.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OperationsReporting.Models.Entities
{
    public class Transaction
    {
        public long Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public required decimal Amount { get; set; }

        [Required]
        public required string Currency { get; set; }

        [Required]
        public required string SenderIban { get; set; }

        [Required]
        public required string ReceiverIban { get; set; }

        [Required]
        public required TransactionStatus Status { get; set; }

        [Required]
        public required string ExternalId { get; set; }

        public long MerchantId { get; set; }

        public required Merchant Merchant { get; set; }
    }
}