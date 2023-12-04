using SelfBackEnd.Models;

namespace SelfBackEnd.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    public User GetUserByEmail(string email);
}
