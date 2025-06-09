using Microsoft.AspNetCore.Mvc;
using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Filters;
using OperationsReporting.Services.Interfaces;

namespace OperationsReporting.WebApi.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
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

            var result = await _transactionService.ImportTransactionsFromXmlAsync(tempFilePath, merchantId);

            System.IO.File.Delete(tempFilePath);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<TransactionDto>>> GetTransactions([FromQuery] TransactionFilter filter, int page = 1, int pageSize = 20)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 20;

            var result = await _transactionService.GetTransactionsAsync(filter, page, pageSize);

            return Ok(result);
        }
    }
}
