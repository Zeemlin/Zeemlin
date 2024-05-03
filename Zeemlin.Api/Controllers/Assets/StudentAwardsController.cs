using Microsoft.AspNetCore.Mvc;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Assets.StudentAwards;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Assets;

namespace Zeemlin.Api.Controllers.Assets
{
    public class StudentAwardsController : BaseController
    {
        private readonly IStudentAwardService _studentAwardService;

        public StudentAwardsController(IStudentAwardService studentAwardService)
        {
            _studentAwardService = studentAwardService;
        }

        [HttpGet]
        public async Task<IActionResult> RetrieveAllAsync([FromQuery] PaginationParams @params)
        {
            var awards = await _studentAwardService.RetrieveAllAsync(@params);
            return Ok(awards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetrieveByIdAsync(long id)
        {
            var award = await _studentAwardService.RetrieveByIdAsync(id);
            return Ok(award);
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(StudentAwardForCreationDto dto)
        {
            try
            {
                var createdAward = await _studentAwardService.UploadAsync(dto);
                return Ok(createdAward);
            }
            catch (ZeemlinException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePictureAsync(long id)
            => Ok(await _studentAwardService.DeletePictureAsync(id));
    }
}
