using Zeemlin.Service.DTOs.Users.Students;

namespace Zeemlin.Service.DTOs.Assets.StudentAwards;

public class StudentAwardForResultDto
{
    public long Id { get; set; }
    public string Path { get; set; }
    public DateTime UploadedDate { get; set; }
    public long StudentId { get; set; }
    public StudentForResultDto Student { get; set; }
}
