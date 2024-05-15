namespace Zeemlin.Service.DTOs.Books;

public class BookForUpdateDto
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string? Description { get; set; }
    public string Subject { get; set; }
    public DateTime UploadDate { get; set; }
    public string Language { get; set; }

    public long SchoolId { get; set; }
    public long TeacherId { get; set; }
}
