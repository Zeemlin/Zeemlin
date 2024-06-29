using Zeemlin.Domain.Entities.Users;
using Zeemlin.Domain.Enums;

namespace Zeemlin.Service.DTOs.StudentScores;

public class StudentScoreForCreationDto
{
    public long StudentId { get; set; }
    public long LessonId { get; set; }
    public AssessmentType AssessmentType { get; set; }
    public DateTime AssessmentDate { get; set; }
    public string? Remark { get; set; }
}
