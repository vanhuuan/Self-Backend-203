using SelfBackEnd.Dtos.Response;

namespace SelfBackEnd.Services.Interfaces;

public interface IUserService
{
    public UserViewDto GetUserById(string id);
}
