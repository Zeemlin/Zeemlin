using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Data.IRepositries.Users;

public interface IUserRepository : IRepository<User>
{
    //Task<User> ExistsAsync(string email);
}
