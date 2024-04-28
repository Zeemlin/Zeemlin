using Microsoft.AspNetCore.Mvc;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Events.EventRegistrations;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Events.EventsRegistrations;

namespace Zeemlin.Api.Controllers.Events;

public class EventRegistrationsController : BaseController
{
    private readonly IEventRegistrationService _eventRegistration;

    public EventRegistrationsController(IEventRegistrationService eventRegistration)
    {
        _eventRegistration = eventRegistration;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] EventRegistrationCreationDto dto)
      => Ok(await _eventRegistration.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
      => Ok(await _eventRegistration.GetAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
      => Ok(await _eventRegistration.GetByIdAsync(id));

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
      => Ok(await _eventRegistration.DeleteAsync(id));
    [HttpGet("{EventId}-participants")]
    public async Task<IActionResult> GetByEventIdAsync(long eventId, PaginationParams @params)
    {
        try
        {
            var registrations = await _eventRegistration.GetByEventIdAsync(eventId, @params);
            return Ok(registrations);
        }
        catch (ZeemlinException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpGet("{eventId}/search-by-code")]
    public async Task<IActionResult> SearchByCodeAsync(long eventId, string code)
    {
        if (string.IsNullOrEmpty(code))
        {
            return BadRequest(new { message = "Registration code cannot be null or empty." });
        }

        try
        {
            var registration = await _eventRegistration.SearchByCodeAsync(code, eventId);
            return Ok(registration);
        }
        catch (ZeemlinException ex)
        {
            if (ex.StatusCode == 404)
            {
                return NotFound(new { message = ex.Message });
            }
            else
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

}
