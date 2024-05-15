using Zeemlin.Domain.Enums;

namespace Zeemlin.Domain.Entities.Users
{
    public class Director : User
    {
        public string Username { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string PhoneNumber { get; set; }
        public GenderType Gender { get; set; }
        public string PassportSeria { get; set; }

        public ICollection<School> Schools { get; set; }

        
    }
}
