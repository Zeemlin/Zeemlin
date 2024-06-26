﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.DbContexts;
using Zeemlin.Data.IRepositries;
using Zeemlin.Data.Repositories;
using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Enums;
using Zeemlin.Service.DTOs.StudentGroups;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces;

namespace Zeemlin.Service.Services;

public class StudentGroupService : IStudentGroupService
{
    private readonly IMapper _mapper;
    private readonly IStudentGroupRepository _studentGroupRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IGroupRepository _groupRepository;
    public StudentGroupService(
        IMapper mapper,
        IStudentGroupRepository studentGroupRepository,
        IStudentRepository studentRepository,
        IGroupRepository groupRepository)
    {
        _mapper = mapper;
        _studentGroupRepository = studentGroupRepository;
        _studentRepository = studentRepository;
        _groupRepository = groupRepository;
    }

    public async Task<StudentGroupForResultDto> AddAsync(StudentGroupForCreationDto dto)
    {
        var group = await _groupRepository.SelectAll()
            .Where(g => g.Id == dto.GroupId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (group is null)
            throw new ZeemlinException(404, "Group Not Found");

        var school = await _groupRepository.SelectAll()
            .Where(l => l.Id == dto.GroupId)
            .Include(l => l.Course.School)
            .AsNoTracking()
            .Select(l => l.Course.School)
            .FirstOrDefaultAsync();

        if (school?.SchoolActivity != SchoolActivity.Active)
            throw new ZeemlinException(403, $"The {school.Name} is temporarily inactive. Unable to add students to {group.Name}");

        var student = await _studentRepository.SelectAll()
            .Where(s => s.Id == dto.StudentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (student is null)
            throw new ZeemlinException(404, "Student not found");

        var existingStudentGroup = await _studentGroupRepository.SelectAll()
         .Where(s => s.StudentId == dto.StudentId && s.GroupId == dto.GroupId)
         .AsNoTracking()
         .FirstOrDefaultAsync();

        if (existingStudentGroup is not null)
            throw new ZeemlinException(400,"Student already exists in group ");

        var mappedStudentGroup = _mapper.Map<StudentGroup>(dto);
        mappedStudentGroup.CreatedAt = DateTime.UtcNow;
        await _studentGroupRepository.InsertAsync(mappedStudentGroup);

        return _mapper.Map<StudentGroupForResultDto>(mappedStudentGroup);

    }

    public async Task<StudentGroupForResultDto> ModifyAsync(long id, StudentGroupForUpdateDto dto)
    {
        var studentGroup = await _studentGroupRepository.SelectAll()
        .Where(u => u.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (studentGroup is null)
            throw new ZeemlinException(404, "Not found");

        var group = await _groupRepository.SelectAll()
            .Where(g => g.Id == dto.GroupId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (group is null)
            throw new ZeemlinException(404, "Group Not Found");

        var student = await _studentRepository.SelectAll()
            .Where(s => s.Id == dto.StudentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (student is null)
            throw new ZeemlinException(404, "Student not found");

        var existingStudentGroup = await _studentGroupRepository.SelectAll()
         .Where(s => s.StudentId == dto.StudentId && s.GroupId == dto.GroupId)
         .AsNoTracking()
         .FirstOrDefaultAsync();

        if (existingStudentGroup is not null)
            throw new ZeemlinException(400, "Student already exists in group ");

        var mappedStudentGroup = _mapper.Map(dto,studentGroup);
        mappedStudentGroup.UpdatedAt = DateTime.UtcNow;
        await _studentGroupRepository.UpdateAsync(mappedStudentGroup);

        return _mapper.Map<StudentGroupForResultDto>(mappedStudentGroup);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _studentGroupRepository.SelectAll()
            .Where(u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null)
            throw new ZeemlinException(404, "Not found");

        await _studentGroupRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<StudentGroupForResultDto>> RetrieveAllAsync()
    {
        var studentGroups = await _studentGroupRepository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<StudentGroupForResultDto>>(studentGroups);
    }

    public async Task<StudentGroupForResultDto> RetrieveByIdAsync(long id)
    {
        var studentGroup = await _studentGroupRepository.SelectAll()
            .Where(s => s.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (studentGroup is null)
            throw new ZeemlinException(404, "Student not found");

        return _mapper.Map<StudentGroupForResultDto>(studentGroup);
    }
}
