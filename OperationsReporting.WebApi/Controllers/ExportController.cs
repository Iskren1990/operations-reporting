using Microsoft.AspNetCore.Mvc;
using OperationsReporting.Services.Interfaces;
using System.Text;

namespace OperationsReporting.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExportController : ControllerBase
    {
        private readonly IExportService _exportService;

        public ExportController(IExportService exportService)
        {
            _exportService = exportService;
        }

        [HttpGet("partners")]
        public async Task<IActionResult> ExportPartners()
        {
            var csv = await _exportService.ExportPartnersCsvAsync();
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "partners.csv");
        }

        [HttpGet("merchants")]
        public async Task<IActionResult> ExportMerchants()
        {
            var csv = await _exportService.ExportMerchantsCsvAsync();
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "merchants.csv");
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> ExportTransactions()
        {
            var csv = await _exportService.ExportTransactionsCsvAsync();
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "transactions.csv");
        }
    }
}
