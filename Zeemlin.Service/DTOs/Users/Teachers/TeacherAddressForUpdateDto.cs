using Zeemlin.Domain.Enums;

namespace Zeemlin.Service.DTOs.Users.Teachers;

public class TeacherAddressForUpdateDto
{
    public Region Region { get; set; }
    public string DistrictName { get; set; }
    public string GeneralAddressMFY { get; set; }
    public string StreetName { get; set; }
    public short HouseNumber { get; set; }
}
