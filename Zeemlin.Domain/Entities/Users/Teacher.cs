using Zeemlin.Domain.Enums;
using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Entities.Assets;

namespace Zeemlin.Domain.Entities.Users;

public class Teacher : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Biography { get; set; }

    // Address
    public Region Region { get; set; }
    public string DistrictName { get; set; }
    public string GeneralAddressMFY { get; set; }
    public string StreetName { get; set; }
    public short HouseNumber { get; set; }
    public ScienceType ScienceType { get; set; }
    public GenderType genderType { get; set; }

    public long? TeacherAssetId { get; set; }
    public TeacherAsset? TeacherAsset { get; set; }


    public ICollection<TeacherAward> TeacherAwards { get; set; }
    public ICollection<TeacherGroup> TeacherGroups { get; set; }
}
