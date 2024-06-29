using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Domain.Entities.Assets;

public class StudentAward : Auditable
{
    public string Path { get; set; }
    public DateTime UploadedDate { get; set; }
    public long StudentId { get; set; }
    public Student Student { get; set; }
}
