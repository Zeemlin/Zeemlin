﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zeemlin.Service.DTOs.Users.Students;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Users;

namespace Zeemlin.Api.Controllers.Users;

//[Authorize]
public class StudentsController : BaseController
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] StudentForCreationDto dto)
        => Ok(await _studentService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _studentService.RetrieveAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _studentService.RetrieveByIdAsync(id));

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _studentService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] StudentForUpdateDto dto)
        => Ok(await _studentService.ModifyAsync(id, dto));

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync([Required] string email, [FromForm] StudentForChangePasswordDto dto)
            => Ok(await _studentService.ChangePasswordAsync(email, dto));

    [HttpGet("search/{searchTerm}")]
    public async Task<IActionResult> SearchStudentPhoneNumberTerm(string searchTerm)
    {
        return Ok(await _studentService.RetrieveByPhoneNumberAsync(searchTerm));
    }

    [HttpPut("{id}/address")]
    public async Task<IActionResult> UpdateStudentAddressAsync(long id, [FromBody] StudentAddressForUpdateDto dto)
    {
        try
        {
            var updatedStudent = await _studentService.StudentAddressUpdate(id, dto);
            return Ok(updatedStudent);
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
