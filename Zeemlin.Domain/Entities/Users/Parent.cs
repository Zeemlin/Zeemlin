using System.ComponentModel.DataAnnotations;
using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Enums;

namespace Zeemlin.Domain.Entities.Users;

public class Parent : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderType Gender { get; set; }
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


    public ICollection<ParentStudent> ParentStudents { get; set; }
}
