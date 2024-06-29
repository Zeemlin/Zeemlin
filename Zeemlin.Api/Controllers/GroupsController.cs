using Microsoft.AspNetCore.Mvc;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Group;
using Zeemlin.Service.Interfaces;

namespace Zeemlin.Api.Controllers
{
    public class GroupsController : BaseController
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // **POST** api/groups - Creates a new group
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GroupForCreationDto dto)
        => Ok(await this._groupService.CreateAsync(dto));

        // **GET** api/groups - Retrieves all groups with pagination
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await this._groupService.RetrieveAllAsync(@params));

        // **GET** api/groups/{id} - Retrieves a group by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._groupService.RetrieveByIdAsync(id));

        // **DELETE** api/groups/{id} - Deletes a group by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._groupService.RemoveAsync(id));

        // **PUT** api/groups/{id} - Updates a group by its ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] GroupForUpdateDto dto)
        => Ok(await this._groupService.ModifyAsync(id, dto));

        // **GET** api/groups/search-schoolId - Searches groups by school ID and term
        [HttpGet("search-schoolId")]
        public async Task<IActionResult> SearchBySchoolIdAsync(string searchTerm, long schoolId)
        {
            var groups = await _groupService.SearchGroupsBySchoolIdAsync(searchTerm, schoolId);
            return Ok(groups);
        }

        // **GET** api/groups/{schoolId}/groups - Retrieves groups associated with a school
        [HttpGet("{schoolId}/groups")]
        public async Task<IActionResult> RetrieveGroupsBySchoolIdAsync(long schoolId)
        {
            var groups = await _groupService.RetrieveGroupsBySchoolIdAsync(schoolId);
            return Ok(groups);
        }

        // **GET** api/groups/{teacherId}/main - Retrieves groups where the teacher is the main teacher
        [HttpGet("{teacherId}/main")]
        public async Task<IActionResult> GetMainTeacherGroupsAsync(long teacherId)
        {
            // Gets groups where the teacher is associated with the group and the role is MainTeacher
            var groups = await _groupService.GetMainTeacherGroupsAsync(teacherId);
            return Ok(groups);
        }

        // **GET** api/groups/{teacherId}/others - Retrieves groups where the teacher is an assistant teacher
        [HttpGet("{teacherId}/others")]
        public async Task<IActionResult> GetOtherTeacherGroupsAsync(long teacherId)
        {
            // Gets groups where the teacher is associated with the group and the role is not MainTeacher
            var groups = await _groupService.GetOtherTeacherGroupsAsync(teacherId);
            return Ok(groups);
        }

        // **GET** api/groups/course/{courseId} - Retrieves groups associated with a course
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> RetrieveGroupsByCourseIdAsync([FromRoute(Name = "courseId")] long courseId)
        {
            if (courseId <= 0)
            {
                return BadRequest(new ArgumentException("Course ID must be a positive value."));
            }

            var groups = await _groupService.RetrieveGroupsByCourseIdAsync(courseId);
            return Ok(groups);
        }

        // **GET** api/groups/{groupId}/teachers - Retrieves teachers associated with a group
        [HttpGet("{id}/teachers")]
        public async Task<IActionResult> GetTeachersByGroupIdAsync([FromRoute(Name = "id")] long groupId)
        {
            if (groupId <= 0)
            {
                return BadRequest(new ArgumentException("Group ID must be a positive value."));
            }

            var teachers = await _groupService.GetTeachersByGroupIdAsync(groupId);
            return Ok(teachers);
        }

        [HttpGet("{groupId}/rankings")]
        public async Task<IActionResult> GetStudentRankingsInGroupAsync([FromRoute(Name = "groupId")] long groupId)
        {
            if (groupId <= 0)
            {
                return BadRequest(new ArgumentException("Group ID must be a positive value."));
            }

            var studentRankings = await _groupService.GetStudentRankingsInGroup(groupId);
            return Ok(studentRankings);
        }
    }
}
