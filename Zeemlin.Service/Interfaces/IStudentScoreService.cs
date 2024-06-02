using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.StudentScores;

namespace Zeemlin.Service.Interfaces;

public interface IStudentScoreService
{
    Task<bool> RemoveAsync(long id);
    Task<StudentScoreForResultDto> RetrieveByIdAsync(long id);
    Task<StudentScoreForResultDto> CreateAsync(StudentScoreForCreationDto dto);
    Task<StudentScoreForResultDto> ModifyAsync(long id, StudentScoreForUpdateDto dto);
    Task<IEnumerable<StudentScoreForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
