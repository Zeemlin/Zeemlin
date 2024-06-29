using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Users.SuperAdmins;
using Zeemlin.Service.Interfaces.Users;

namespace Zeemlin.Api.Controllers.Users;

public class SuperAdminsController : BaseController
{
    private readonly ISuperAdminService _SuperAdminService;

    public SuperAdminsController(ISuperAdminService superAdminService)
    {
        _SuperAdminService = superAdminService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SuperAdminForCreationDto dto)
        => Ok(await _SuperAdminService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(PaginationParams @params)
        => Ok(await _SuperAdminService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _SuperAdminService.RetrieveByIdAsync(id));

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _SuperAdminService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] SuperAdminForUpdateDto dto)
        => Ok(await _SuperAdminService.ModifyAsync(id, dto));

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync([Required] string email, [FromForm] SuperAdminForChangePasswordDto dto)
            => Ok(await _SuperAdminService.ChangePasswordAsync(email, dto));
}
