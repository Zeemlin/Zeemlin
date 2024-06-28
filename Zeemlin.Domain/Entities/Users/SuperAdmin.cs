using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Enums;

namespace Zeemlin.Domain.Entities.Users
{
    public class SuperAdmin : Auditable
    {
        public string Username { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public GenderType Gender { get; set; }
        public string PassportSeria { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

    }
}
