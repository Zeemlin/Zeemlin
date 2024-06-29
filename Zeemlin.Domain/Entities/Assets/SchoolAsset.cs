using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Domain.Entities.Assets;

public class SchoolAsset : Auditable
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Path { get; set; }
    public DateTime UploadedDate { get; set; }
    public long SchoolId { get; set; }
    public School School { get; set; }
    public long AdminId { get; set; }
    public Admin Admin { get; set; }
}
