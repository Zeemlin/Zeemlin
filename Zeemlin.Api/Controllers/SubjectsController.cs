using Microsoft.AspNetCore.Mvc;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Subjects;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces;

namespace Zeemlin.Api.Controllers;

public class SubjectsController : BaseController
{
    private readonly ISubjectService _subjectService;

    public SubjectsController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SubjectForCreationDto dto)
        => Ok(await this._subjectService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await this._subjectService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._subjectService.RetrieveByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._subjectService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] SubjectForUpdateDto dto)
        => Ok(await this._subjectService.ModifyAsync(id, dto));

    [HttpGet("lessons/{lessonId}/subjects")]
    public async Task<IActionResult> GetSubjectsByLessonAsync([FromRoute(Name = "lessonId")] long lessonId, [FromQuery] PaginationParams @params)
    {
        try
        {
            var subjects = await _subjectService.RetrieveSubjectsByLessonIdAsync(lessonId, @params);
            if (subjects.Any())
            {
                return Ok(subjects);
            }
            return NotFound("Subjects not found for the specified lesson.");
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
