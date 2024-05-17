﻿using Zeemlin.Service.DTOs.Assets.TeacherAssets;

namespace Zeemlin.Service.DTOs.Users.Teachers;

public class TeacherSearchResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Biography { get; set; }
    public string Region { get; set; }
    public string DistrictName { get; set; }
    public string GeneralAddressMFY { get; set; }
    public string StreetName { get; set; }
    public short HouseNumber { get; set; }
    public string ScienceType { get; set; }
    public string genderType { get; set; }

    public TeacherAssetForResultDto TeacherAssetForResultDto { get; set; }
}
