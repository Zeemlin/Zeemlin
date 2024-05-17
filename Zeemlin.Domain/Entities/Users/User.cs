using Zeemlin.Domain.Commons;

namespace Zeemlin.Domain.Entities.Users;

public abstract class User : Auditable
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }

}
