using Microsoft.AspNetCore.Mvc;
using OperationsReporting.Models.DTO;
using OperationsReporting.Services.Interfaces;

namespace OperationsReporting.WebApi.Controllers
{
    [ApiController]
    [Route("api/partners")]
    public class PartnersController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnersController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<PartnerDto>>> GetPartners(int page = 1, int pageSize = 10)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var result = await _partnerService.GetPartnersAsync(page, pageSize);
            return Ok(result);
        }
    }
}
