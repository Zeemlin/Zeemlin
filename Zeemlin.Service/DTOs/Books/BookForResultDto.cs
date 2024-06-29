namespace Zeemlin.Service.DTOs.Books;

public class BookForResultDto
{
    public long Id { get; set; }
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

    public string BookPhotoUrl { get; set; }
    public string PdfUrl { get; set; }
}
