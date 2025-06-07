namespace OperationsReporting.Services.Interfaces
{
    public interface IExportService
    {
        Task<string> ExportPartnersCsvAsync();

        Task<string> ExportMerchantsCsvAsync();

        Task<string> ExportTransactionsCsvAsync();
    }
}