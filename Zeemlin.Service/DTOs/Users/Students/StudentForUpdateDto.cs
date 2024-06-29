using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using Zeemlin.Domain.Enums;
using Zeemlin.Service.Commons.Attributes;

namespace Zeemlin.Service.DTOs.Users.Students;

public class StudentForUpdateDto
{
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public string FatherName { get; set; }
    public GenderType genderType { get; set; }
    [PhoneNumber]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [Email]
    public string Email { get; set; }
    [Required]
    [StrongPassword]
    public string Password { get; set; }

    // Address
    [Required]
    public Region Region { get; set; }
    [Required]
    public string DistrictName { get; set; }
    [Required]
    public string GeneralAddressMFY { get; set; }
    [Required]
    public string StreetName { get; set; }
    [Required]
    public short HouseNumber { get; set; }
}
