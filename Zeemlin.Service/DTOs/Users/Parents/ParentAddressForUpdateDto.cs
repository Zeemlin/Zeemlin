using Zeemlin.Domain.Enums;

namespace Zeemlin.Service.DTOs.Users.Parents;

public class ParentAddressForUpdateDto
{
    public Region Region { get; set; }
    public string DistrictName { get; set; }
    public string GeneralAddressMFY { get; set; }
    public string StreetName { get; set; }
    public short HouseNumber { get; set; }
}
