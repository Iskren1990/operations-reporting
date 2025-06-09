using OperationsReporting.Models.Enums;

namespace OperationsReporting.Models.DTO
{
    public class TransactionDto
    {
        public int Id { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public required TransactionType TransactionType { get; set; }
        
        public required decimal Amount { get; set; }
        
        public required string Currency { get; set; }
        
        public required string SenderIban { get; set; }
        
        public required string ReceiverIban { get; set; }
        
        public required TransactionStatus Status { get; set; }
        
        public required string ExternalId { get; set; }
    }
}
