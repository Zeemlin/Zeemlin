﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries;
using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Enums;
using Zeemlin.Service.Commons.Extentions;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Courses;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces;

namespace Zeemlin.Service.Services;

public class CourseService : ICourseServices
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;
    private readonly ISchoolRepository _schoolRepository;

    public CourseService(IMapper mapper, ICourseRepository courseRepository, ISchoolRepository schoolRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
        _schoolRepository = schoolRepository;
    }

    public async Task<CourseForResultDto> CreateAsync(CourseForCreationDto dto)
    {
        var IsValidSchoolId = await _schoolRepository.SelectAll()
            .Where(s => s.Id == dto.SchoolId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (IsValidSchoolId is null)
            throw new ZeemlinException(404, "School Not Found");

        if (IsValidSchoolId?.SchoolActivity != SchoolActivity.Active)
        {
            throw new ZeemlinException(403, $"The {IsValidSchoolId.Name} is temporarily inactive. Course cannot be created.");
        }

        var existingCourse = await _courseRepository.SelectAll()
            .AsNoTracking()
            .Where(c => c.Name.ToLower() == dto.Name.ToLower() && c.SchoolId == dto.SchoolId)
            .FirstOrDefaultAsync();

        if (existingCourse is not null)
            throw new ZeemlinException(409, $"Course with the same name already exists in this {IsValidSchoolId.Name}.");

        var mappedCourse = _mapper.Map<Course>(dto);
        mappedCourse.CreatedAt = DateTime.UtcNow;
        await _courseRepository.InsertAsync(mappedCourse);

        return _mapper.Map<CourseForResultDto>(mappedCourse);
    }


    public async Task<CourseForResultDto> ModifyAsync(long id, CourseForUpdateDto dto)
    {
        var IsValidId = await _courseRepository.SelectAll()
            .AsNoTracking()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (IsValidId is null)
            throw new ZeemlinException(404, "Course not found");

        var school = await _schoolRepository.SelectAll()
            .AsNoTracking()
            .Where(s => s.Id == dto.SchoolId)
            .FirstOrDefaultAsync();

        if (school is null)
            throw new ZeemlinException(404, "School Not Found");

        if (school?.SchoolActivity != SchoolActivity.Active)
        {
            throw new ZeemlinException(403, $"The {school.Name} is temporarily inactive.  It is not possible to make changes to the {IsValidId.Name} .");
        }

        var existingCourse = await _courseRepository.SelectAll()
            .AsNoTracking()
            .Where(c => c.Name.ToLower() == dto.Name.ToLower() && c.SchoolId == dto.SchoolId)
            .FirstOrDefaultAsync();

        if (existingCourse is not null)
            throw new ZeemlinException(409, $"Course with the same name already exists in this {school.Name}.");

        var mapped = _mapper.Map(dto, IsValidId);
        mapped.UpdatedAt = DateTime.UtcNow;
        await _courseRepository.UpdateAsync(mapped);

        return _mapper.Map<CourseForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var IsValidId = await _courseRepository.SelectAll()
            .AsNoTracking()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (IsValidId is null)
            throw new ZeemlinException(404, "Course not found");

        await _courseRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<CourseForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var courses = await _courseRepository.SelectAll()
          .Include(c => c.Groups) 
          .AsNoTracking()
          .ToPagedList(@params)
          .ToListAsync();

        var courseDtos = _mapper.Map<IEnumerable<CourseForResultDto>>(courses);
        foreach (var courseDto in courseDtos)
        {
            courseDto.GroupCount = courseDto.GroupForResultDto?.Count ?? 0;
        }

        return courseDtos;
    }

    public async Task<CourseForResultDto> RetrieveIdAsync(long id)
    {
        var course = await _courseRepository.SelectAll()
          .Include(c => c.Groups)
          .Where(u => u.Id == id)
          .AsNoTracking()
          .FirstOrDefaultAsync();

        if (course is null)
            throw new ZeemlinException(404, "Course not found");

        var courseDto = _mapper.Map<CourseForResultDto>(course);
        courseDto.GroupCount = course.Groups?.Count ?? 0; 

        return courseDto;
    }

    public async Task<IEnumerable<CourseForResultDto>> RetrieveAllBySchoolIdAsync(long schoolId, PaginationParams @params)
    {
        var school = await _schoolRepository.SelectAll()
            .AsNoTracking()
            .Where(s => s.Id == schoolId)
            .FirstOrDefaultAsync();

        if (school is null)
            throw new ZeemlinException(404, "School not found");

        var courses = await _courseRepository.SelectAll()
            .Include(c => c.Groups) 
            .Where(c => c.SchoolId == schoolId)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        var courseDtos = _mapper.Map<IEnumerable<CourseForResultDto>>(courses);
        foreach (var courseDto in courseDtos)
        {
            courseDto.GroupCount = await _courseRepository.GetGroupCountAsync(courseDto.Id);
        }

        return courseDtos;
    }


}