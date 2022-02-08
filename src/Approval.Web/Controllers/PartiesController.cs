using Approval.Shared.ReadModels;
using Approval.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartiesController : Controller
    {
        private readonly IndividualPartyService _individualPartyService;

        public PartiesController(IndividualPartyService individualPartyService)
            => _individualPartyService = individualPartyService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndividualParty>>> GetIndividualParties()
            => Ok(await _individualPartyService.GetAllIndividualPartiesAsync());
    }
}
