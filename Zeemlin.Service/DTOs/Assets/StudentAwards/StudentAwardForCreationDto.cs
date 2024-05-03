using Microsoft.AspNetCore.Http;

namespace Zeemlin.Service.DTOs.Assets.StudentAwards;

public class StudentAwardForCreationDto
{
    public IFormFile Path { get; set; }
    public long StudentId { get; set; }
}
