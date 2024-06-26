﻿using AutoMapper;
using Zeemlin.Domain.Enums;
using Zeemlin.Data.IRepositries;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.DTOs.Group;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Domain.Entities.Users;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.Interfaces.Users;
using Zeemlin.Service.Commons.Extentions;
using Zeemlin.Service.DTOs.TeacherGroups;
using Zeemlin.Service.DTOs.Users.Teachers;
using Zeemlin.Service.DTOs.Assets.TeacherAssets;
using Zeemlin.Service.Commons.Helpers;

namespace Zeemlin.Service.Services.Users;

public class TeacherService : ITeacherService
{
    private readonly IMapper _mapper;
    private readonly ITeacherRepository _repository;
    private readonly IGroupRepository _groupRepository;
    private readonly ISchoolRepository _schoolRepository;

    public TeacherService(
        IMapper mapper,
        ITeacherRepository repository,
        ISchoolRepository schoolRepository,
        IGroupRepository groupRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _schoolRepository = schoolRepository;
        _groupRepository = groupRepository;
    }

    public async Task<TeacherForResultDto> CreateAsync(TeacherForCreationDto dto)
    {
        var TeacherEmailExist = await _repository.SelectAll()
            .Where(t => t.Username.ToLower() == dto.Username.ToLower() 
            || t.Email.ToLower() == dto.Email.ToLower()
            || t.PhoneNumber == dto.PhoneNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (TeacherEmailExist is not null)
            throw new ZeemlinException
                (409, "Teacher is already exist.");

        var hasherResult = PasswordHelper.Hash(dto.Password);
        var mapped = _mapper.Map<Teacher>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.Salt = hasherResult.Salt;
        mapped.Password = hasherResult.Hash;

        var created = await _repository.InsertAsync(mapped);

        return _mapper.Map<TeacherForResultDto>(created);

    }

    public async Task<IEnumerable<TeacherForResultDto>> GetTeachersAsync(long groupId)
    {
        var group = await _groupRepository.SelectAll()
            .Include(g => g.TeacherGroups)
                .ThenInclude(tg => tg.Teacher)
            .Where(g => g.Id == groupId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (group is null)
        {
            throw new ZeemlinException(404, "Group not found");
        }

        return _mapper.Map<IEnumerable<TeacherForResultDto>>(group);
    }

    public async Task<TeacherForResultDto> ModifyAsync(long id, TeacherForUpdateDto dto)
    {
        var Teacher = await _repository
            .SelectAll()
            .Where(t => t.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (Teacher is null)
            throw new ZeemlinException(404, "Teacher is not found.");

        var TeacherEmailExist = await _repository.SelectAll()
            .Where(t => t.Email.ToLower() == dto.Email.ToLower()
            || t.PhoneNumber == dto.PhoneNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();


        if (TeacherEmailExist is not null)
            throw new ZeemlinException(409, "Teacher is already exist.");

        Teacher.UpdatedAt = DateTime.UtcNow;
        var person = _mapper.Map(dto, Teacher);
        await _repository.UpdateAsync(person);

        return _mapper.Map<TeacherForResultDto>(person);

    }

    public async Task<bool> ChangePasswordAsync(string email, TeacherForChangePasswordDto dto)
    {
        var user = await _repository.SelectAll()
            .Where(u => u.Email == email)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null || !PasswordHelper.Verify(dto.OldPassword, user.Salt, user.Password))
            throw new ZeemlinException(404, "User or Password is incorrect");
        else if (dto.NewPassword != dto.ConfirmPassword)
            throw new ZeemlinException(400, "New password and confirm password aren't equal");

        var hash = PasswordHelper.Hash(dto.ConfirmPassword);
        user.Salt = hash.Salt;
        user.Password = hash.Hash;
        var updated = await _repository.UpdateAsync(user);

        return true;
    }

    public async Task<TeacherForResultDto> TeacherAddressUpdate(long id, TeacherAddressForUpdateDto dto)
    {
        var teacher = await _repository
            .SelectAll()
            .Where(t => t.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (teacher is null)
            throw new ZeemlinException(404, "Teacher is not found.");

        var person = _mapper.Map(dto, teacher);
        person.UpdatedAt = DateTime.UtcNow;
        await _repository.UpdateAsync(person);

        return _mapper.Map<TeacherForResultDto>(teacher);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _repository
            .SelectAll()
            .AsNoTracking()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new ZeemlinException(404, "Teacher is not found.");

        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<TeacherForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await _repository.SelectAll().AsNoTracking().ToPagedList(@params).ToListAsync();

        return _mapper.Map<IEnumerable<TeacherForResultDto>>(users);

    }

    public async Task<TeacherForResultDto> RetrieveByIdAsync(long id)
    {
        var query = _repository.SelectAll()
          .Include(t => t.TeacherAsset) // Include TeacherAsset
          .Include(t => t.TeacherGroups) // Include TeacherGroups (eager loading)
          .ThenInclude(tg => tg.Group) // Include Group within TeacherGroup
          .AsNoTracking()
          .Where(t => t.Id == id);

        var user = await query.FirstOrDefaultAsync();

        if (user is null)
            throw new ZeemlinException(404, "Teacher is not found.");

        // Map to TeacherForResultDto
        var teacherDto = _mapper.Map<TeacherForResultDto>(user);
        teacherDto.TeacherAssetForResultDto = user.TeacherAsset != null
          ? _mapper.Map<TeacherAssetForResultDto>(user.TeacherAsset)
          : null;

        // Project TeacherGroups directly (assuming no custom mapping)
        teacherDto.TeacherGroupForResult = user.TeacherGroups.Select(tg => new TeacherGroupForResultDto
        {
            TeacherForResultDto = teacherDto, // Reference the parent teacher
            GroupForResultDto = _mapper.Map<GroupForResultDto>(tg.Group), // Use existing mapping
            Role = tg.Role.ToString()
        }).ToList();

        return teacherDto;
    }

    public async Task<IEnumerable<TeacherSearchResultDto>> SearchByUsernameAsync(string searchTerm, long currentSchoolId)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return Enumerable.Empty<TeacherSearchResultDto>(); // Handle empty search
        }

        var query = _repository.SelectAll()
        .Include(t => t.TeacherAsset)
        .AsNoTracking();

        // Rewrite query to use LIKE for case-insensitive comparison
        query = query.Where(t => t.Username.ToLower() == searchTerm.ToLower());

        // Filter by teachers associated with the current school
        query = query.Where(t => t.TeacherGroups.Any(tg => tg.Group.Course.SchoolId == currentSchoolId));

        var teachers = await query.ToListAsync();

        // Handle case where no teacher is found within the school
        if (!teachers.Any())
        {
            throw new ZeemlinException(404, "Teacher not found in this school."); // Custom exception
        }

        return teachers.Select(t => new TeacherSearchResultDto
        {
            Id = t.Id,
            FirstName = t.FirstName,
            LastName = t.LastName,
            DateOfBirth = t.DateOfBirth, // Include if necessary
            PhoneNumber = t.PhoneNumber,
            Email = t.Email,
            Biography = t.Biography,
            DistrictName = t.DistrictName,
            ScienceType = t.ScienceType.ToString(),
            TeacherAssetForResultDto = t.TeacherAsset != null
            ? new TeacherAssetForResultDto // Map only if TeacherAsset exists
            {
                Id = t.TeacherAsset.Id,
                TeacherId = t.TeacherAsset.TeacherId,
                Path = t.TeacherAsset.Path,
                UploadedDate = t.TeacherAsset.UploadedDate
            }
            : null // Set TeacherAssetForResultDto to null if not found
        });
    }

    public async Task<IEnumerable<FilteredTeacherDTO>> GetFilteredTeachers(
    ScienceType? scienceType = null,
    long schoolId = 0) // Mandatory parameter
    {
        if (schoolId <= 0)
        {
            throw new ArgumentException("School ID must be a positive value.");
        }

        var query = _repository.SelectAll()
            .Include(t => t.TeacherAsset) // Eager loading for TeacherAsset
            .AsNoTracking();

        // Apply filters based on input parameters
        query = query.Where(t => t.TeacherGroups.Any(g => g.Group.Course.SchoolId == schoolId));

        // Filter by scienceType (if provided)
        if (scienceType.HasValue)
        {
            query = query.Where(t => t.ScienceType == scienceType.Value);
        }

        // Map teachers to FilteredTeacherDTO
        var filteredTeachers = await query.Select(teacher => new FilteredTeacherDTO
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            DateOfBirth = teacher.DateOfBirth, // Consider formatting or omitting based on needs
            PhoneNumber = teacher.PhoneNumber,
            Email = teacher.Email,
            DistrictName = teacher.DistrictName,
            ScienceType = teacher.ScienceType.ToString(),
            TeacherAssetForResultDto = teacher.TeacherAsset != null ? new TeacherAssetForResultDto // Map teacher asset if it exists
            {
                Path = teacher.TeacherAsset.Path,
                UploadedDate = teacher.TeacherAsset.UploadedDate
            } : null
        }).ToListAsync();

        return filteredTeachers;
    }


    public async Task<IEnumerable<TeacherForResultDto>> GetTeachersBySchoolAsync(long schoolId)
    {
        if (schoolId <= 0)
        {
            throw new ArgumentException("School ID must be a positive value.");
        }

        var school = await _schoolRepository.SelectAll()
            .Where(s => s.Id == schoolId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (school is null)
        {
            throw new ZeemlinException(404, "School not found");
        }

        var teachers = await _repository.SelectAll()
            .Include(t => t.TeacherAsset) // Eager loading for TeacherAsset
            .Where(t => t.TeacherGroups.Any(tg => tg.Group.Course.SchoolId == schoolId))
            .ToListAsync();

        // Map teachers to TeacherForResultDto and include TeacherAsset data
        return teachers.Select(teacher => new TeacherForResultDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            DateOfBirth = teacher.DateOfBirth,
            PhoneNumber = teacher.PhoneNumber,
            Email = teacher.Email,
            Biography = teacher.Biography,
            DistrictName = teacher.DistrictName,
            ScienceType = teacher.ScienceType.ToString(),
            // Include TeacherAsset data if it exists
            TeacherAssetForResultDto = teacher.TeacherAsset != null
                ? _mapper.Map<TeacherAssetForResultDto>(teacher.TeacherAsset)
                : null,
            TeacherGroupForResult = null // Not included in this update
        }).ToList();
    }

}
