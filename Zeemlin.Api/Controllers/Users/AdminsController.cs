using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zeemlin.Data.DbContexts;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Users.Admins;
using Zeemlin.Service.DTOs.Users.Parents;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Users;
using Zeemlin.Service.Services.Users;

namespace Zeemlin.Api.Controllers.Users;

public class AdminsController : BaseController
{
    private readonly IAdminService _adminService;

    public AdminsController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] AdminForCreationDto dto)
        => Ok(await _adminService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _adminService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _adminService.RetrieveByIdAsync(id));

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _adminService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] AdminForUpdateDto dto)
        => Ok(await _adminService.ModifyAsync(id, dto));

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync([Required] string email, [FromForm] AdminForChangePasswordDto dto)
            => Ok(await _adminService.ChangePasswordAsync(email, dto));

    [HttpGet("username")]
    public async Task<IActionResult> SearchAdminsTerm(string admin)
    {
        return Ok(await _adminService.SearchAdmins(admin));
    }

    [HttpGet("schools/{schoolId}/admins")]
    public async Task<IActionResult> RetrieveBySchoolIdAsync(long schoolId, [FromQuery] PaginationParams @params)
    {
        var admins = await _adminService.RetrieveBySchoolIdAsync(schoolId, @params);
        return Ok(admins);
    }

}
