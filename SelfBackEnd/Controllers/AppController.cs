using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelfBackEnd.Dtos.Response;
using SelfBackEnd.Models;
using SelfBackEnd.Repositories.Interfaces;

namespace SelfBackEnd.Controllers;

[Route("app")]
[ApiController]
[Authorize]
public class AppController : BaseController
{
    private IBaseRepository<AppVersion> _appVersionRepository;
    public AppController(IBaseRepository<AppVersion> baseRepository) 
    {
        _appVersionRepository = baseRepository; 
    }
    [HttpGet]
    [Route("version")]
    public ActionResult<VersionViewDto> GetCurrentVersion()
    {
        var version = _appVersionRepository.GetAll().OrderByDescending(x => x.CreatedAt).FirstOrDefault();

        if(version == null) return NotFound();
        return Ok(new VersionViewDto
        {
            Id = version.Id,
            Name = version.Name,
            Version = version.Version,
        });
    }
}
