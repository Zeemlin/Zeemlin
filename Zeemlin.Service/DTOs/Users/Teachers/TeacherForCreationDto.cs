using System.ComponentModel.DataAnnotations;
using Zeemlin.Domain.Enums;
using Zeemlin.Service.Commons.Attributes;

namespace Zeemlin.Service.DTOs.Users.Teachers
{
    public class TeacherForCreationDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [PhoneNumber(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [StrongPassword]
        public string Password { get; set; }
        public string? Biography { get; set; }

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

        [Required]
        public ScienceType ScienceType { get; set; }
        [Required]
        public GenderType genderType { get; set; }

    }
}
