using Microsoft.AspNetCore.Mvc;
using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Exceptions;
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
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }

        [HttpPost("{merchantId}")]
        public async Task<IActionResult> ImportTransactions(int merchantId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is missing");

            var tempFilePath = Path.GetRandomFileName();

            try
            {
                using (var stream = System.IO.File.Create(tempFilePath))
                {
                    await file.CopyToAsync(stream);
                }

                var result = await _transactionService.ImportTransactionsFromXmlAsync(tempFilePath, merchantId);

                if (result == null)
                    return BadRequest("Import failed or returned no result.");

                return Ok(result);
            }
            catch (Exception ex) when (ex is System.Xml.XmlException || ex is XmlDeserializationException) 
            {
                return BadRequest("Invalid XML format or serialization error.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                if (System.IO.File.Exists(tempFilePath))
                    System.IO.File.Delete(tempFilePath);
            }
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
