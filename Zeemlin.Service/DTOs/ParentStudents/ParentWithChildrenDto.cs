namespace Zeemlin.Service.DTOs.ParentStudents;

public class ParentWithChildrenDto
{
    public long ParentId { get; set; }
    // Existing parent information (e.g., Email, PhoneNumber, etc.)
    public IEnumerable<ChildInfoDto> Children { get; set; }
}
