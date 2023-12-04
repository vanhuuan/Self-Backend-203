using BCrypt.Net;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SelfBackEnd.Dtos.Request;
using SelfBackEnd.Migrations;
using SelfBackEnd.Models;
using SelfBackEnd.Repositories.Interfaces;
using SelfBackEnd.Services.Interfaces;
using SelfBackEnd.Setting;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SelfBackEnd.Services;

public class AuthenticateService : IAuthenticateService
{
    private readonly IUserRepository _userRepository;

    private readonly JwtConfig _jwtConfig;
    public AuthenticateService(IUserRepository userRepository, IOptions<JwtConfig> jwtConfig)
    {
        _userRepository = userRepository;
        _jwtConfig = jwtConfig.Value;
    }

    public string GenerateAccessToken(string uid)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Sid, uid),
            new Claim(ClaimTypes.Role, "User"),
        };

        var token = new JwtSecurityToken(_jwtConfig.Issuer,
          _jwtConfig.Issuer,
          claims,
          expires: DateTime.Now.AddDays(_jwtConfig.ValidDays),
          signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken(string uid)
    {
        return "later";
    }

    public string Login(LoginRequestDto dto)
    {
        var user = _userRepository.GetUserByEmail(dto.Email);
        if(BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            return user.Id;
        }
        return null;
    }

    public bool Register(RegisterRequestDto dto)
    {
        var checkExist = _userRepository.GetUserByEmail(dto.Email);
        if(checkExist != null) { return false; }
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        var newUser = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            Password = passwordHash,
            FullName = dto.FullName,
        };

        _userRepository.Insert(newUser);
        _userRepository.Save();
        return true;
    }
}
