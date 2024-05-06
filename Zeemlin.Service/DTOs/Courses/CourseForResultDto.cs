using Zeemlin.Service.DTOs.Group;

namespace Zeemlin.Service.DTOs.Courses;

public class CourseForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int price { get; set; }
    public long SchoolId { get; set; }
    public int GroupCount { get; set; }
    public ICollection<GroupForResultDto> GroupForResultDto { get; set; }
}
