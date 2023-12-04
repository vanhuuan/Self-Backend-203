using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SelfBackEnd.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string GetUserId()
        {
            var userid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault()?.Value;
            return userid;
        }
    }
}
