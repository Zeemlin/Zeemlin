using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Users.Directors;
using Zeemlin.Service.Interfaces.Users;

namespace Zeemlin.Api.Controllers.Users;

public class DirectorsController : BaseController
{
    private readonly IDirectorService _directorService;

    public DirectorsController(IDirectorService directorService)
    {
        _directorService = directorService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] DirectorForCreationDto dto)
        => Ok(await _directorService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _directorService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _directorService.RetrieveByIdAsync(id));

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _directorService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] DirectorForUpdateDto dto)
        => Ok(await _directorService.ModifyAsync(id, dto));

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync([Required] string email, [FromForm] DirectorForChangePasswordDto dto)
            => Ok(await _directorService.ChangePasswordAsync(email, dto));

    [HttpGet("username")]
    public async Task<IActionResult> SearchAdminsTerm(string director, PaginationParams @params)
    {
        return Ok(await _directorService.RetrieveByUsernameAsync(director, @params));
    }
}
