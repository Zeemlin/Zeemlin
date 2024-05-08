using Zeemlin.Service.DTOs.Users.Teachers;

namespace Zeemlin.Service.DTOs.Assets.TeacherAwards;

public class TeacherAwardForResultDto
{
    public long Id { get; set; }
    public string Path { get; set; }
    public DateTime UploadedDate { get; set; }
    public long TeacherId { get; set; }
    public TeacherForResultDto Teacher { get; set; }
}
