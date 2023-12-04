using SelfBackEnd.Dtos.Request;

namespace SelfBackEnd.Services.Interfaces;

public interface IAuthenticateService
{
    public string Login(LoginRequestDto dto);

    public bool Register(RegisterRequestDto dto);

    public string GenerateAccessToken(string uid);

    public string GenerateRefreshToken(string uid);
}
