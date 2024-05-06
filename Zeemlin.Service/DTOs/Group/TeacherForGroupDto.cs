namespace Zeemlin.Service.DTOs.Group;

public class TeacherForGroupDto
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePictureUrl { get; set; } // Assuming profile picture URL is a string
    public string ScienceType { get; set; } // Assuming ScienceType is a string representation of the enum
}
