using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Group;
using Zeemlin.Service.DTOs.Users.Students;

namespace Zeemlin.Service.Interfaces;

public interface IGroupService
{
    Task<bool> RemoveAsync(long id);
    Task<GroupForResultDto> RetrieveByIdAsync(long id);
    Task<GroupForResultDto> CreateAsync(GroupForCreationDto dto);
    Task<GroupForResultDto> ModifyAsync(long id, GroupForUpdateDto dto);
    Task<ICollection<StudentRankingDto>> GetStudentRankingsInGroup(long groupId);
    Task<IEnumerable<GroupForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<IEnumerable<TeacherForGroupDto>> GetTeachersByGroupIdAsync(long groupId);
    Task<IEnumerable<GroupForResultDto>> GetMainTeacherGroupsAsync(long teacherId);
    Task<IEnumerable<GroupForResultDto>> GetOtherTeacherGroupsAsync(long teacherId);
    Task<IEnumerable<GroupForResultDto>> RetrieveGroupsByCourseIdAsync(long courseId);
    Task<IEnumerable<GroupForResultDto>> RetrieveGroupsBySchoolIdAsync(long schoolId);
    Task<IEnumerable<SearchGroupResultDto>> SearchGroupsBySchoolIdAsync(string searchTerm, long schoolId);

}
