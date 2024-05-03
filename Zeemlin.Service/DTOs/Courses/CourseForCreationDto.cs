namespace Zeemlin.Service.DTOs.Courses;

public class CourseForCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int price { get; set; }
    public long SchoolId { get; set; }
}
