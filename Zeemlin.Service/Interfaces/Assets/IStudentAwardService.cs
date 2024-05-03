using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Assets.StudentAwards;

namespace Zeemlin.Service.Interfaces.Assets;

public interface IStudentAwardService
{
    Task<bool> DeletePictureAsync(long Id);
    Task<StudentAwardForResultDto> RetrieveByIdAsync(long Id);
    Task<StudentAwardForResultDto> UploadAsync(StudentAwardForCreationDto dto);
    Task<IEnumerable<StudentAwardForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
