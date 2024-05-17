using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Assets.TeacherAwards;

namespace Zeemlin.Service.Interfaces.Assets;

public interface ITeacherAwardService
{
    Task<bool> DeletePictureAsync(long Id);
    Task<TeacherAwardForResultDto> RetrieveByIdAsync(long Id);
    Task<TeacherAwardForResultDto> UploadAsync(TeacherAwardForCreationDto dto);
    Task<IEnumerable<TeacherAwardForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
