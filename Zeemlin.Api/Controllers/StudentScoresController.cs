using Microsoft.AspNetCore.Mvc;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.StudentScores;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces;

namespace Zeemlin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentScoresController : BaseController
    {
        private readonly IStudentScoreService _studentScoreService;

        public StudentScoresController(IStudentScoreService studentScoreService)
        {
            _studentScoreService = studentScoreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] StudentScoreForCreationDto dto)
        {
            try
            {
                var result = await _studentScoreService.CreateAsync(dto);
                return Ok(result);
            }
            catch (ZeemlinException ze)
            {
                return StatusCode(ze.StatusCode, ze.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyAsync([FromRoute(Name = "id")] long id, [FromBody] StudentScoreForUpdateDto dto)
        {
            try
            {
                var result = await _studentScoreService.ModifyAsync(id, dto);
                return Ok(result);
            }
            catch (ZeemlinException ze)
            {
                return StatusCode(ze.StatusCode, ze.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        {
            try
            {
                var deleted = await _studentScoreService.RemoveAsync(id);
                if (deleted)
                {
                    return NoContent(); // Resource deleted successfully
                }
                return NotFound(); // Resource not found
            }
            catch (ZeemlinException ze)
            {
                return StatusCode(ze.StatusCode, ze.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            try
            {
                var scores = await _studentScoreService.RetrieveAllAsync(@params);
                return Ok(scores);
            }
            catch (ZeemlinException ze)
            {
                return StatusCode(ze.StatusCode, ze.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
        {
            try
            {
                var score = await _studentScoreService.RetrieveByIdAsync(id);
                return Ok(score);
            }
            catch (ZeemlinException ze)
            {
                return StatusCode(ze.StatusCode, ze.Message);
            }
        }
    }
}
