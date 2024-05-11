using System.ComponentModel.DataAnnotations;
using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Enums;

namespace Zeemlin.Domain.Entities.Users
{
    public class Director : Auditable
    {
        public string Username { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public GenderType Gender { get; set; }
        public string PassportSeria { get; set; }

        public ICollection<School> Schools { get; set; }

        
    }
}
