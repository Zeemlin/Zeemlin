using Zeemlin.Service.DTOs.Logins;

namespace Zeemlin.Service.Interfaces;

public interface IAuthService
{
    Task<LoginResultDto> AuthenticateAsync(LoginDto login);
}
