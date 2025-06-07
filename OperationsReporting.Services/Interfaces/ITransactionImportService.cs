namespace OperationsReporting.Services.Interfaces
{
    public interface ITransactionImportService
    {
        Task ImportTransactionsFromXmlAsync(string xmlFilePath, int merchantId);
    }
}
