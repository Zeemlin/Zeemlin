using Microsoft.AspNetCore.Mvc;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Assets.TeacherAwards;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Assets;

namespace Zeemlin.Api.Controllers.Assets;

public class TeacherAwardsController : BaseController
{
    private readonly ITeacherAwardService _service;

    public TeacherAwardsController(ITeacherAwardService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> RetrieveAllAsync([FromQuery] PaginationParams @params)
    {
        var awards = await _service.RetrieveAllAsync(@params);
        return Ok(awards);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetrieveByIdAsync(long id)
    {
        var award = await _service.RetrieveByIdAsync(id);
        return Ok(award);
    }

    [HttpPost]
    public async Task<IActionResult> UploadAsync(TeacherAwardForCreationDto dto)
    {
        try
        {
            var createdAward = await _service.UploadAsync(dto);
            return Ok(createdAward);
        }
        catch (ZeemlinException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePictureAsync(long id)
        => Ok(await _service.DeletePictureAsync(id));
}

