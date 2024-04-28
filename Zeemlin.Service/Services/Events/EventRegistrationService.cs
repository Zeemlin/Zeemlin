using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Zeemlin.Data.IRepositries.Events;
using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Entities.Events;
using Zeemlin.Service.Commons.Extentions;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Events.EventRegistrations;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces;
using Zeemlin.Service.Interfaces.Events.EventsRegistrations;


namespace Zeemlin.Service.Services.Events;

public class EventRegistrationService : IEventRegistrationService
{
    private readonly IMapper _mapper;
    private readonly IEventRegistrationRepository _eventRegistrationRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IEmailService _emailService;

    public EventRegistrationService(
        IMapper mapper,
        IEventRegistrationRepository eventRegistrationRepository,
        IEventRepository eventRepository,
        IEmailService emailService)
    {
        _mapper = mapper;
        _eventRegistrationRepository = eventRegistrationRepository;
        _eventRepository = eventRepository;
        _emailService = emailService;
    }

    private string GenerateRegistrationCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public async Task<EventRegistrationResultDto> CreateAsync(EventRegistrationCreationDto dto)
    {
        // Check if event exists
        var existingEvent = await _eventRepository.SelectAll()
            .Where(e => e.Id == dto.EventId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (existingEvent is null)
        {
            throw new ZeemlinException(404, "No such event exists");
        }

        // Check for duplicate registration using email and event ID
        //var existingRegistration = await _eventRegistrationRepository.SelectAll().Where(
        //    r => r.EventId == dto.EventId && r.Email.ToLower() == dto.Email.ToLower())
        //    .AsNoTracking()
        //    .FirstOrDefaultAsync();

        //if (existingRegistration != null)
        //{
        //    throw new ZeemlinException(409, "This email has already registered for this event.");
        //}

        // Generate registration code (replace with your preferred generation logic)

        // Map DTO to entity
        var mapped = _mapper.Map<EventRegistration>(dto);
        mapped.RegistrationCode = GenerateRegistrationCode();

        // Set registration date
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.RegistrationDate = DateTime.UtcNow;

        await _eventRegistrationRepository.InsertAsync(mapped);

        // Send confirmation email in a separate task
        await SendRegistrationConfirmationEmail(mapped, existingEvent);
        // Map entity back to DTO for returning result
        return _mapper.Map<EventRegistrationResultDto>(mapped);
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var deleteParticipant = await _eventRegistrationRepository
            .SelectAll()
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (deleteParticipant is null)
            throw new ZeemlinException(404, "Participant not found");

        await _eventRegistrationRepository .DeleteAsync(id);
        return true;
    }

    public async Task<ICollection<EventRegistrationResultDto>> GetByEventIdAsync(long eventId, PaginationParams @params)
    {
        var deleteParticipant = await _eventRepository
            .SelectAll()
            .Where(e => e.Id == eventId)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();
        if (deleteParticipant is null)
            throw new ZeemlinException(404, "Participant not found");

        return _mapper.Map<ICollection<EventRegistrationResultDto>>(deleteParticipant);
    }

    public async Task<EventRegistrationResultDto> GetByIdAsync(long id)
    {
        var Participant = await _eventRegistrationRepository
            .SelectAll()
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (Participant is null)
            throw new ZeemlinException(404, "Participant not found");

        return _mapper.Map<EventRegistrationResultDto>(Participant);
        throw new NotImplementedException();
    }

    public async Task<EventRegistrationResultDto> SearchByCodeAsync(string code, long EventId)
    {
        if (string.IsNullOrEmpty(code))
        {
            throw new ArgumentException("Registration code cannot be null or empty.");
        }

        var registration = await _eventRegistrationRepository.SelectAll()
            .Where(r => r.RegistrationCode == code &&
            r.EventId == EventId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (registration is null)
        {
            throw new ZeemlinException(404, "Registration not found");
        }

        return _mapper.Map<EventRegistrationResultDto>(registration);
    }

    public async Task<ICollection<EventRegistrationResultDto>> GetAllAsync(PaginationParams @params)
    {
        var Participants = await _eventRegistrationRepository.SelectAll().AsNoTracking().ToPagedList(@params).ToListAsync();

        return _mapper.Map<ICollection<EventRegistrationResultDto>>(Participants);
    }


    private async Task SendRegistrationConfirmationEmail(EventRegistration registration, Event evnt)
    {
        // Prepare the email content
        var recipientEmail = registration.Email;
        var subject = $"Your Registration Confirmation for {evnt.Title}";

        // Craft the email body with registration and event details
        var messageBody = $"<style>p {{ margin-bottom: 10px; }}</style>" +
                      $"<p>Dear {registration.FirstName} {registration.LastName},</p>" +
                      $"<p>Thank you for registering for the event '{evnt.Title}'.</p>" +
                      $"<h3>Event Details:</h3>" +
                      $"<p>- Event Name: {evnt.Title}</p>" +
                      $"<p>- Event Time: {evnt.StartedAt:yyyy-MM-dd HH:mm}</p>" +
                      $"<p>- Event Location: {evnt.Location}</p>" +
                      $"<p>- Your Registration Code: {registration.RegistrationCode}</p>" +
                      $"<p>We look forward to seeing you at the event!</p>";

        // Send the email using the EmailService
        await _emailService.SendMessage(new Message
        {
            To = recipientEmail,
            Subject = subject,
            Body = messageBody
        });
    }



}
