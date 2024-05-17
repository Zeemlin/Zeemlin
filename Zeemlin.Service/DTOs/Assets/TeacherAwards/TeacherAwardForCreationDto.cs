using Microsoft.AspNetCore.Http;

namespace Zeemlin.Service.DTOs.Assets.TeacherAwards;

public class TeacherAwardForCreationDto
{
    public IFormFile Path { get; set; }
    public long TeacherId { get; set; }
}
