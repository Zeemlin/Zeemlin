using Zeemlin.Service.DTOs.Schools;
using Zeemlin.Service.DTOs.Users.Admins;

namespace Zeemlin.Service.DTOs.Assets.SchoolAssets;

public class SchoolAssetForResultDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Path { get; set; }
    public DateTime UploadedDate { get; set; }
    public long SchoolId { get; set; }
    public SchoolForResultDto School { get; set; }
    public long AdminId { get; set; }
    public AdminForResultDto Admin { get; set; }

}
