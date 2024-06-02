using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Entities.Users;
using Zeemlin.Domain.Enums;

namespace Zeemlin.Domain.Entities;

public class StudentScore : Auditable
{
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long LessonId { get; set; }
    public Lesson Lesson { get; set; }
    public AssessmentType AssessmentType { get; set; }
    public DateTime AssessmentDate { get; set; }
    public int Score { get; set; }  
    public string? Remark { get; set; }
}
