using SelfBackEnd.Context;
using SelfBackEnd.Dtos.Response;
using SelfBackEnd.Repositories.Interfaces;
using SelfBackEnd.Services.Interfaces;

namespace SelfBackEnd.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserViewDto GetUserById(string id)
    {
        var user = _userRepository.GetById(id);
        if(user == null) return null;
        return new UserViewDto(user.Id, user.UserName, user.Email, user.FullName);
    }
}
