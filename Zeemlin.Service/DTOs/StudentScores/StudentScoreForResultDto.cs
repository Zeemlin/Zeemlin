using Zeemlin.Domain.Enums;

namespace Zeemlin.Service.DTOs.StudentScores;

public class StudentScoreForResultDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long LessonId { get; set; }
    public AssessmentType AssessmentType { get; set; }
    public DateTime AssessmentDate { get; set; }
    public int Score { get; set; }
    public string? Remark { get; set; }
}
