using Zeemlin.Domain.Enums;

namespace Zeemlin.Domain.Entities.Users;

public class Admin : User
{
    public string Username { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public GenderType Gender { get; set; }
    public string PassportSeria { get; set; }
    public long SchoolId { get; set; }
    public School School { get; set; }

}
