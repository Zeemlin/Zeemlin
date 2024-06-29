using Microsoft.AspNetCore.Mvc;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Courses;
using Zeemlin.Service.Interfaces;

namespace Zeemlin.Api.Controllers;

public class CoursesController : BaseController
{
    private readonly ICourseServices courseServices;

    public CoursesController(ICourseServices courseServices)
    {
        this.courseServices = courseServices;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CourseForCreationDto dto)
        => Ok(await this.courseServices.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await this.courseServices.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await this.courseServices.RetrieveIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await this.courseServices.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] CourseForUpdateDto dto)
        => Ok(await this.courseServices.ModifyAsync(id, dto));

    [HttpGet("by-school/{schoolId}")]
    public async Task<IActionResult> GetBySchoolAsync([FromRoute(Name = "schoolId")] long schoolId, [FromQuery] PaginationParams @params)
    {
        var courses = await courseServices.RetrieveAllBySchoolIdAsync(schoolId, @params);
        if (!courses.Any())
        {
            return NotFound("Courses not found for this school.");
        }
        return Ok(courses);
    }


}
