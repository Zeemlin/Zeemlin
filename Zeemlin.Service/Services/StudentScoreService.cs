using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries;
using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Enums;
using Zeemlin.Service.Commons.Extentions;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.StudentScores;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces;

namespace Zeemlin.Service.Services;

public class StudentScoreService : IStudentScoreService
{
    private readonly IMapper _mapper;
    private readonly IStudentScoreRepository _studentScoreRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ILessonRepository _lessonRepository;

    public StudentScoreService(
        IMapper mapper,
        IStudentScoreRepository studentScoreRepository,
        IStudentRepository studentRepository,
        ILessonRepository lessonRepository)
    {
        _mapper = mapper;
        _studentScoreRepository = studentScoreRepository;
        _studentRepository = studentRepository;
        _lessonRepository = lessonRepository;
    }

    public async Task<StudentScoreForResultDto> CreateAsync(StudentScoreForCreationDto dto)
    {
        var student = await _studentRepository.SelectAll()
            .Where(s => s.Id == dto.StudentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (student is null)
            throw new ZeemlinException(404, "Student not found");

        var lesson = await _lessonRepository.SelectAll()
            .Where(s => s.Id == dto.LessonId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (lesson is null)
            throw new ZeemlinException(404, "Lesson not found");

        var school = await _lessonRepository.SelectAll()
            .Where(l => l.Id == dto.LessonId)
            .Select(l => l.Group.Course.School)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (school?.SchoolActivity != SchoolActivity.Active)
            throw new ZeemlinException(403, $"{school?.Name} is temporarily inactive.");

        var studentScore = _mapper.Map<StudentScore>(dto);
        studentScore.Score = dto.AssessmentType switch
        {
            AssessmentType.Activity => 1,
            AssessmentType.Classwork => 2,
            AssessmentType.Homework => 3,
            AssessmentType.Test => 4,
            _ => throw new ZeemlinException(400, "Invalid AssessmentType provided")
        };
        studentScore.CreatedAt = DateTime.UtcNow;

        await _studentScoreRepository.InsertAsync(studentScore);

        return _mapper.Map<StudentScoreForResultDto>(studentScore);
    }

    public async Task<StudentScoreForResultDto> ModifyAsync(long id, StudentScoreForUpdateDto dto)
    {
        var studentScore = await _studentScoreRepository.SelectAll()
            .Where(sc => sc.Id == id)
            .FirstOrDefaultAsync();
        if (studentScore is null)
            throw new ZeemlinException(404, "Score not found");

        var student = await _studentRepository.SelectAll()
            .Where(s => s.Id == dto.StudentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (student is null)
            throw new ZeemlinException(404, "Student not found");

        var lesson = await _lessonRepository.SelectAll()
            .Where(s => s.Id == dto.LessonId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (lesson is null)
            throw new ZeemlinException(404, "Lesson not found");

        var school = await _lessonRepository.SelectAll()
            .Where(l => l.Id == dto.LessonId)
            .Select(l => l.Group.Course.School)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (school?.SchoolActivity != SchoolActivity.Active)
            throw new ZeemlinException(403, $"{school?.Name} is temporarily inactive.");

        studentScore = _mapper.Map(dto, studentScore);
        studentScore.Score = dto.AssessmentType switch
        {
            AssessmentType.Activity => 1,
            AssessmentType.Classwork => 2,
            AssessmentType.Homework => 3,
            AssessmentType.Test => 4,
            _ => throw new ZeemlinException(400, "Invalid AssessmentType provided")
        };
        studentScore.UpdatedAt = DateTime.UtcNow;

        await _studentScoreRepository.UpdateAsync(studentScore);

        return _mapper.Map<StudentScoreForResultDto>(studentScore);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var studentScore = await _studentScoreRepository.SelectAll()
            .Where(sc => sc.Id == id)
            .FirstOrDefaultAsync();
        if (studentScore is null)
            throw new ZeemlinException(404, "Score not found");

        await _studentScoreRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<StudentScoreForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var scores = await _studentScoreRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<StudentScoreForResultDto>>(scores);
    }

    public async Task<StudentScoreForResultDto> RetrieveByIdAsync(long id)
    {
        var studentScore = await _studentScoreRepository.SelectAll()
            .Where(sc => sc.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (studentScore is null)
            throw new ZeemlinException(404, "Score not found");

        return _mapper.Map<StudentScoreForResultDto>(studentScore);
    }
}
