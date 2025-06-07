using Microsoft.AspNetCore.Mvc;
using OperationsReporting.Services.Interfaces;

namespace OperationsReporting.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionImportController : ControllerBase
    {
        private readonly ITransactionImportService _importService;

        public TransactionImportController(ITransactionImportService importService)
        {
            _importService = importService;
        }

        [HttpPost("{merchantId}")]
        public async Task<IActionResult> ImportTransactions(int merchantId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is missing");

            var tempFilePath = Path.GetRandomFileName();

            using (var stream = System.IO.File.Create(tempFilePath))
            {
                await file.CopyToAsync(stream);
            }

            await _importService.ImportTransactionsFromXmlAsync(tempFilePath, merchantId);

            System.IO.File.Delete(tempFilePath);

            return Ok("Transactions imported successfully.");
        }
    }
}
