using Zeemlin.Service.DTOs.Assets.SchoolLogoAssets;

namespace Zeemlin.Service.DTOs.Schools;

public class SchoolForResultDto
{
    public long Id { get; set; }
    public string SchoolType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long DirectorId { get; set; }
    

    // Address properties
    public string Region { get; set; } 
    public string DistrictName { get; set; }
    public string GeneralAddressMFY { get; set; }
    public string StreetName { get; set; }

    // Contact Information
    public string? CallCenter { get; set; }
    public string? EmailCenter { get; set; }
    public string? Website { get; set; }

    // School Activity
    public string SchoolActivity { get; set; }
    public string EndDateOfActivity { get; set; }
    public SchoolLogoAssetForResultDto SchoolLogoAsset { get; set; }
}
