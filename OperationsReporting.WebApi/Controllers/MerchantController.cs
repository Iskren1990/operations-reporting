using Microsoft.AspNetCore.Mvc;
using OperationsReporting.Models.DTO;
using OperationsReporting.Services.Interfaces;

namespace OperationsReporting.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService _merchantService;

        public MerchantController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<MerchantDto>>> GetMerchants(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var result = await _merchantService.GetMerchantsAsync(page, pageSize);

            return Ok(result);
        }
    }
}
