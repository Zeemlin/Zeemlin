using System.ComponentModel.DataAnnotations;

namespace Zeemlin.Service.DTOs.Courses;

public class CourseForUpdateDto
{
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public int price { get; set; }
    public long SchoolId { get; set; }
}
