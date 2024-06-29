using Zeemlin.Domain.Enums;
using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Entities.Users;
using Zeemlin.Domain.Entities.Assets;
using Zeemlin.Domain.Entities.Library;

namespace Zeemlin.Domain.Entities;

public class School : Auditable
{
    public EducationType SchoolType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long DirectorId { get; set; }
    public Director Director { get; set; } 

    // Address
    public Region Region { get; set; }
    public string DistrictName { get; set; }
    public string GeneralAddressMFY { get; set; }
    public string StreetName { get; set; }

    // Contact Information
    public string? CallCenter { get; set; }
    public string? EmailCenter { get; set; }
    public string? Website { get; set; }

    // School Logo
    public long? SchoolLogoAssetId { get; set; }
    public SchoolLogoAsset? SchoolLogoAsset { get; set; }

    // School Activity
    public SchoolActivity SchoolActivity { get; set; }
    public DateTime EndDateOfActivity { get; set; }


    public ICollection<Admin> Admins { get; set; }
    public ICollection<SchoolAsset> Asset { get; set; }
    public ICollection<Course> Courses { get; set; }
    public ICollection<Book> Books { get; set; }
}
