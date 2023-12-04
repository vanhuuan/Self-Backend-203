using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SelfBackEnd.Context;
using SelfBackEnd.Dtos.Request;
using SelfBackEnd.Dtos.Response;
using SelfBackEnd.Repositories.Interfaces;
using SelfBackEnd.Services.Interfaces;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace SelfBackEnd.Controllers;

[Route("auth")]
[ApiController]
public class AuthenController : BaseController
{
    private readonly ILogger _logger;
    private readonly IAuthenticateService _authenticateService;
    private readonly IUserService _userService;

    public AuthenController(ILogger<AuthenController> logger, IAuthenticateService authenticateService, IUserService userService)
    {
        _logger = logger;
        _authenticateService = authenticateService;
        _userService = userService;
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public ActionResult<LoginResponseDto> Login([FromBody] LoginRequestDto dto)
    {
        ActionResult response = Unauthorized();
        var valid = _authenticateService.Login(dto);

        if (!valid.IsNullOrEmpty())
        {
            var user = _userService.GetUserById(valid);
            var accessTokenString = _authenticateService.GenerateAccessToken(user.UserId);
            var refreshTokenString = _authenticateService.GenerateRefreshToken(user.UserId);

            response = Ok(new LoginResponseDto()
            {
                RefreshToken = refreshTokenString,
                Token = accessTokenString
            });
        }

        return response;
    }

    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public ActionResult Register([FromBody] RegisterRequestDto dto)
    {
        var valid = _authenticateService.Register(dto);
        if (valid)
        {
            return Ok();
        }
        return BadRequest();
    }
}
