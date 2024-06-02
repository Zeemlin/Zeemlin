using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.DbContexts;
using Zeemlin.Data.IRepositries.Users;
using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Data.Repositories.Users;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> ExistsAsync(string email)
    {
        throw new NotImplementedException();
    }
}
