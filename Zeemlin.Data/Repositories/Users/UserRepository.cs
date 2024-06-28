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

    //public async Task<User> ExistsAsync(string email)
    //{
    //    var exists = await _dbContext.SuperAdmins.AnyAsync(u => u.Email == email)
    //                  || await _dbContext.Admins.AnyAsync(u => u.Email == email)
    //                  || await _dbContext.Directors.AnyAsync(u => u.Email == email)
    //                  || await _dbContext.Teachers.AnyAsync(u => u.Email == email)
    //                  || await _dbContext.Parents.AnyAsync(u => u.Email == email)
    //                  || await _dbContext.Students.AnyAsync(u => u.Email == email);


    //    return exists;
    //}
}
