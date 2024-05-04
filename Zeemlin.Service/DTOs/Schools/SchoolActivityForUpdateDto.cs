using Zeemlin.Domain.Enums;

namespace Zeemlin.Service.DTOs.Schools;

public class SchoolActivityForUpdateDto
{
    public SchoolActivity SchoolActivity { get; set; }
    public DateTime EndDateOfActivity { get; set; }
}
