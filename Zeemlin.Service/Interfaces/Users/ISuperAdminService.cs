using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Users.SuperAdmins;

namespace Zeemlin.Service.Interfaces.Users;

public interface ISuperAdminService
{
    Task<bool> RemoveAsync(long id);
    Task<SuperAdminForResultDto> RetrieveByIdAsync(long id);
    Task<SuperAdminForResultDto> CreateAsync(SuperAdminForCreationDto dto);
    Task<SuperAdminForResultDto> ModifyAsync(long id, SuperAdminForUpdateDto dto);
    Task<bool> ChangePasswordAsync(string email, SuperAdminForChangePasswordDto dto);
    Task<IEnumerable<SuperAdminForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
