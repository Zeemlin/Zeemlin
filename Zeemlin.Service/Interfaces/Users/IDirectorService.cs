using Zeemlin.Data.DbContexts;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Users.Directors;

namespace Zeemlin.Service.Interfaces.Users;

public interface IDirectorService
{
    Task<bool> RemoveByIdAsync(long id);
    Task<DirectorForResultDto> RetrieveByIdAsync(long id);
    Task<DirectorForResultDto> CreateAsync(DirectorForCreationDto dto);
    Task<DirectorForResultDto> ModifyAsync(long id, DirectorForUpdateDto dto);
    Task<bool> ChangePasswordAsync(string email, DirectorForChangePasswordDto dto);
    Task<IEnumerable<DirectorForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<IEnumerable<DirectorForResultDto>> RetrieveByUsernameAsync(string search, PaginationParams @params);

}
