using CsvHelper.Configuration;
using OperationsReporting.Models.DTO;

namespace OperationsReporting.Models.CsvMaps
{
    public sealed class TransactionExportDtoMap : ClassMap<TransactionExportDto>
    {
        public TransactionExportDtoMap()
        {
            Map(t => t.Id).Name("Transaction ID");
            Map(t => t.DateCreated).Name("Created Date");
            Map(t => t.TransactionType).Name("Type");
            Map(t => t.Amount).Name("Amount");
            Map(t => t.Currency).Name("Currency");
            Map(t => t.SenderIban).Name("Sender IBAN");
            Map(t => t.ReceiverIban).Name("Receiver IBAN");
            Map(t => t.Status).Name("Status");
            Map(t => t.ExternalId).Name("External ID");
            Map(t => t.MerchantId).Name("Merchant ID");
        }
    }
}