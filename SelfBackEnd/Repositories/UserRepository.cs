using Microsoft.EntityFrameworkCore;
using SelfBackEnd.Context;
using SelfBackEnd.Models;
using SelfBackEnd.Repositories.Interfaces;

namespace SelfBackEnd.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DashBoardContext context) : base(context)
    {
    }

    public User GetUserByEmail(string email)
    {
        return _dbSet.FirstOrDefault(x => x.Email == email);
    }
}
