﻿using Zeemlin.Domain.Enums;
using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Entities.Users;
using Zeemlin.Domain.Entities.Assets;

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


    public ICollection<SchoolAsset> Asset { get; set; }
    public ICollection<Course> Courses { get; set; }
}
