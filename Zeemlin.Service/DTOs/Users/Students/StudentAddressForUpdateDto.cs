using Zeemlin.Domain.Enums;

namespace Zeemlin.Service.DTOs.Users.Students;

public class StudentAddressForUpdateDto
{
    public Region Region { get; set; }
    public string DistrictName { get; set; }
    public string GeneralAddressMFY { get; set; }
    public string StreetName { get; set; }
    public short HouseNumber { get; set; }
}
