﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Users.Parents;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Users;

namespace Zeemlin.Api.Controllers.Users;

public class ParentsController : BaseController
{
    private readonly IParentService _parentService;

    public ParentsController(IParentService parentService)
    {
        _parentService = parentService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ParentForCreationDto dto)
    => Ok(await _parentService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _parentService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _parentService.RetrieveByIdAsync(id));

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _parentService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] ParentForUpdateDto dto)
        => Ok(await _parentService.ModifyAsync(id, dto));

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync([Required] string email, [FromForm] ParentForChangePasswordDto dto)
            => Ok(await _parentService.ChangePasswordAsync(email, dto));

    [HttpPut("{id}/address")]
    public async Task<IActionResult> UpdateParentAddressAsync(long id, [FromBody] ParentAddressForUpdateDto dto)
    {
        try
        {
            var updatedParent = await _parentService.ParentAddressUpdate(id, dto);
            return Ok(updatedParent);
        }
        catch (ZeemlinException ex)
        {
            return StatusCode(ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }

}
