using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Domain.Entities.Library;

public class Book : Auditable
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string? Description { get; set; }
    public string Subject { get; set; }
    public DateTime UploadDate { get; set; }
    public string Language { get; set; }
    public string ContentType { get; set; }
    public long Size { get; set; }

    public long SchoolId { get; set; }
    public School School { get; set; }

    public long TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    // media files
    public string BookPhotoUrl { get; set; }
    public string PdfUrl { get; set; }


}

