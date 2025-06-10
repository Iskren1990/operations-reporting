using Microsoft.AspNetCore.Mvc;
using OperationsReporting.Services.Interfaces;
using System.Text;

namespace OperationsReporting.WebApi.Controllers
{
    [ApiController]
    [Route("api/exports")]
    public class ExportController : ControllerBase
    {
        private readonly IExportService _exportService;

        public ExportController(IExportService exportService)
        {
            _exportService = exportService ?? throw new ArgumentNullException(nameof(exportService));
        }

        [HttpGet("partners")]
        public async Task<IActionResult> ExportPartners()
        {
            var csv = await _exportService.ExportPartnersCsvAsync();
            return CsvFile(csv, "partners.csv");
        }

        [HttpGet("merchants")]
        public async Task<IActionResult> ExportMerchants()
        {
            var csv = await _exportService.ExportMerchantsCsvAsync();
            return CsvFile(csv, "merchants.csv");
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> ExportTransactions()
        {
            var csv = await _exportService.ExportTransactionsCsvAsync();
            return CsvFile(csv, "transactions.csv");
        }

        private FileContentResult CsvFile(string fileContents, string fileName)
        {
            return File(Encoding.UTF8.GetBytes(fileContents), "text/csv", fileName);
        }
    }
}
