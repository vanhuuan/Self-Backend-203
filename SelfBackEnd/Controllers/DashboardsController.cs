using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SelfBackEnd.Controllers;

[Route("dashboards")]
[ApiController]
[Authorize]
public class DashboardsController : BaseController
{
    [HttpGet]
    public ActionResult GetAllDashBoard()
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult SaveDashBoard([FromRoute] string id)
    //public ActionResult SaveDashBoard([FromRoute] string id, [FromBody] SaveDashboardRequest request)
    {
        return Ok();
    }
}
