using OperationsReporting.Models.Enums;
using OperationsReporting.Common.Attributes;
using OperationsReporting.Models.CsvMaps;

namespace OperationsReporting.Models.DTO
{
    [CsvMap(typeof(TransactionExportDtoMap))]
    public class TransactionExportDto
    {
        public long Id { get; set; }

        public DateTime DateCreated { get; set; }

        public TransactionType TransactionType { get; set; }

        public required decimal Amount { get; set; }

        public required string Currency { get; set; }

        public required string SenderIban { get; set; }

        public required string ReceiverIban { get; set; }

        public required TransactionStatus Status { get; set; }

        public required string ExternalId { get; set; }

        public long MerchantId { get; set; }
    }
}
