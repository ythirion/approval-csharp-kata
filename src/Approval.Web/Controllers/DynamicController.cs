using Approval.Shared.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<DynamicPerson>> GetDynamicData()
            => Ok(await Task.FromResult(DataBuilder.Montana()));
    }
}
