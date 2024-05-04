using System.ComponentModel.DataAnnotations;
using Zeemlin.Domain.Enums;

namespace Zeemlin.Service.DTOs.Schools;

public class SchoolForCreationDto
{
    [Required] 
    public EducationType SchoolType { get; set; }
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }
    public long DirectorId { get; set; }

    // Address properties
    [Required]
    public Region Region { get; set; } 

    [Required]
    [MaxLength(50)]
    public string DistrictName { get; set; }

    [Required]
    [MaxLength(50)]
    public string GeneralAddressMFY { get; set; }

    [Required]
    [MaxLength(50)]
    public string StreetName { get; set; }

    // Contact Information
    public string? CallCenter { get; set; }
    public string? EmailCenter { get; set; }
    public string? Website { get; set; }

    // School Activity
    public SchoolActivity SchoolActivity { get; set; }
    public DateTime EndDateOfActivity { get; set; }
}
