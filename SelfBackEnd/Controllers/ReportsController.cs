using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SelfBackEnd.Controllers;

[Route("reports")]
[ApiController]
[Authorize]
public class ReportsController : BaseController
{
    [HttpGet]
    [Route("countBy/{collection}/{field}")]
    public ActionResult CountBy([FromRoute] string collection, [FromRoute] string field)
    {
        return Ok();
    }
}
