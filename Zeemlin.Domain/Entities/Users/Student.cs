using Zeemlin.Domain.Enums;
using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Entities.Assets;

namespace Zeemlin.Domain.Entities.Users;

public class Student : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string FatherName { get; set; }
    public GenderType genderType { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }

    // Address
    public Region Region { get; set; }
    public string DistrictName { get; set; } 
    public string GeneralAddressMFY { get; set; } 
    public string StreetName { get; set; } 
    public short HouseNumber { get; set; } 


    public string StudentUniqueId { get; set; }


    public ICollection<StudentAward> StudentAwards { get; set; }
    public ICollection<StudentGroup> StudentGroups { get; set; }
    public ICollection<ParentStudent> ParentStudents { get; set; }
    public ICollection<LessonAttendance> LessonAttendances { get; set; }

}
