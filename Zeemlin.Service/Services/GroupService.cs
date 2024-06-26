﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries;
using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Enums;
using Zeemlin.Service.Commons.Extentions;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Group;
using Zeemlin.Service.DTOs.Users.Students;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces;

namespace Zeemlin.Service.Services;

public class GroupService : IGroupService
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly ISchoolRepository _schoolRepository;
    private readonly IStudentGroupRepository _studentGroupRepository;
    private readonly ILessonAttendanceRepository _lessonAttendanceRepository;

    public GroupService(
        IGroupRepository repository,
        IMapper mapper,
        ICourseRepository courseRepository,
        ISchoolRepository schoolRepository,
        IStudentGroupRepository studentGroupRepository,
        ILessonAttendanceRepository lessonAttendanceRepository)
    {
        _mapper = mapper;
        _groupRepository = repository;
        _courseRepository = courseRepository;
        _schoolRepository = schoolRepository;
        _studentGroupRepository = studentGroupRepository;
        _lessonAttendanceRepository = lessonAttendanceRepository;
    }

    public async Task<GroupForResultDto> CreateAsync(GroupForCreationDto dto)
    {
        var course = await _courseRepository.SelectAll()
            .Where(c => c.Id == dto.CourseId)
            .Include(s => s.School)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (course is null)
            throw new ZeemlinException(404, "Course not found");

        if (course?.School?.SchoolActivity != SchoolActivity.Active)
        {
            throw new ZeemlinException(403, $"The {course?.School?.Name} is temporarily inactive. Group cannot be created.");
        }

        var groupName = await _groupRepository.SelectAll()
            .Where(gn => gn.CourseId == dto.CourseId
            && gn.Name.ToLower() == dto.Name.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (groupName is not null)
            throw new ZeemlinException(409, $"Group with same name already exists in this {course.Name}");

        var mappedGroup = _mapper.Map<Group>(dto);
        mappedGroup.CreatedAt = DateTime.UtcNow;
        var createdGroup = await _groupRepository.InsertAsync(mappedGroup);

        return _mapper.Map<GroupForResultDto>(createdGroup);
    }

    public async Task<GroupForResultDto> ModifyAsync(long id, GroupForUpdateDto dto)
    {
        var group = await _groupRepository.SelectAll()
            .AsNoTracking()
            .Where(g => g.Id == id)
            .FirstOrDefaultAsync();

        if (group is null)
            throw new ZeemlinException(404, "Group Not Found");

        var course = await _courseRepository.SelectAll()
            .Where(c => c.Id == dto.CourseId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (course is null)
            throw new ZeemlinException(404, "Course not found");

        if (course?.School?.SchoolActivity != SchoolActivity.Active)
        {
            throw new ZeemlinException(403, $"The {course?.School?.Name} is temporarily inactive. It is not possible to make changes to the {group.Name} group.");
        }

        var groupNameUpdate = await _groupRepository.SelectAll()
            .Where(gn => gn.CourseId == dto.CourseId
            && gn.Name.ToLower() == dto.Name.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (groupNameUpdate is not null)
            throw new ZeemlinException(409, $"Group with same name already exists in this {course.Name}");

        group.UpdatedAt = DateTime.UtcNow;
        var groups = _mapper.Map(dto, group);
        await _groupRepository.UpdateAsync(groups);

        return _mapper.Map<GroupForResultDto>(groups);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var group = await _groupRepository.SelectAll()
            .Where(g => g.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (group is null)
            throw new ZeemlinException(404, "Group Not Found");

        await _groupRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<GroupForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var group = await _groupRepository.SelectAll().AsNoTracking().ToPagedList(@params).ToListAsync();

        return _mapper.Map<IEnumerable<GroupForResultDto>>(group);
    }

    public async Task<GroupForResultDto> RetrieveByIdAsync(long id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Group ID must be a positive value.");
        }

        var group = await _groupRepository.SelectAll()
            .Include(g => g.TeacherGroups)
                .ThenInclude(tg => tg.Teacher)
            .Include(g => g.Course)
            .Include(g => g.StudentGroups)
            .Where(g => g.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (group is null)
            throw new ZeemlinException(404, "Group Not Found");

        var groupDto = _mapper.Map<GroupForResultDto>(group);
        var mainTeacher = group.TeacherGroups.FirstOrDefault(tg => tg.Role == TeacherRole.MainTeacher);

        groupDto.CourseName = group.Course.Name;
        groupDto.TeacherFirstName = mainTeacher?.Teacher?.FirstName;
        groupDto.TeacherLastName = mainTeacher?.Teacher?.LastName;
        groupDto.TotalTeacherCount = group.TeacherGroups.Count();
        groupDto.StudentCount = group.StudentGroups.Count();

        return groupDto;
    }


    // Educationning guruhlarini qidirish uchun method
    public async Task<IEnumerable<SearchGroupResultDto>> SearchGroupsBySchoolIdAsync(string searchTerm, long schoolId)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            throw new ArgumentException("Search term cannot be empty.");
        }

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

        var groups = await _groupRepository.SelectAll()
            .Include(g => g.TeacherGroups)
                .ThenInclude(tg => tg.Teacher)
            .Include(g => g.Course)
            .Include(g => g.StudentGroups)
            .Where(g => g.Name.Contains(searchTerm)
            && g.Course.SchoolId == schoolId)
            .AsNoTracking()
            .ToListAsync();

        var groupDtos = groups.Select(group =>
        {
            var groupDto = new SearchGroupResultDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CourseId = group.CourseId,
                CourseName = group.Course.Name,
                TotalTeacherCount = group.TeacherGroups.Count(),
                StudentCount = group.StudentGroups.Count()
            };

            var mainTeacher = group.TeacherGroups.FirstOrDefault(tg => tg.Role == TeacherRole.MainTeacher);

            groupDto.TeacherFirstName = mainTeacher?.Teacher?.FirstName;
            groupDto.TeacherLastName = mainTeacher?.Teacher?.LastName;

            groupDto.GroupData = group.TeacherGroups.Select(tg => new GroupDataResultDto
            {
                TeacherFirstName = tg.Teacher?.FirstName,
                TeacherLastName = tg.Teacher?.LastName,
                ScienceType = tg.Teacher?.ScienceType.ToString(),
            }).ToList();

            return groupDto;
        }).ToList();

        return groupDtos;
    }

    // Educationning guruhlarini qaytarish uchun
    public async Task<IEnumerable<GroupForResultDto>> RetrieveGroupsBySchoolIdAsync(long schoolId)
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

        var groups = await _groupRepository.SelectAll()
            .Include(g => g.TeacherGroups)
                .ThenInclude(tg => tg.Teacher)
            .Include(g => g.Course)
            .Include(g => g.StudentGroups)
            .Where(g => g.Course.SchoolId == schoolId)
            .AsNoTracking()
            .ToListAsync();

        var groupDtos = groups.Select(group =>
        {
            var groupDto = _mapper.Map<GroupForResultDto>(group);
            var mainTeacher = group.TeacherGroups.FirstOrDefault(tg => tg.Role == TeacherRole.MainTeacher);

            groupDto.TeacherFirstName = mainTeacher?.Teacher?.FirstName;
            groupDto.TeacherLastName = mainTeacher?.Teacher?.LastName;
            groupDto.TotalTeacherCount = group.TeacherGroups.Count();
            groupDto.StudentCount = group.StudentGroups.Count();

            return groupDto;
        }).ToList();

        return groupDtos;
    }

    // Ustoz rahbarlik qiladigan guruhlarni qaytaruvchi method
    public async Task<IEnumerable<GroupForResultDto>> GetMainTeacherGroupsAsync(long teacherId)
    {
        var teacherGroups = await _groupRepository.SelectAll()
            .Include(tg => tg.TeacherGroups) // Eager loading for Group data
            .Where(g => g.TeacherGroups.Any(tg => tg.TeacherId == teacherId && tg.Role == TeacherRole.MainTeacher))
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<GroupForResultDto>>(teacherGroups);
    }

    // Ustoz rahbarlik qilmaydigan guruhlar qaytaruvchi method
    public async Task<IEnumerable<GroupForResultDto>> GetOtherTeacherGroupsAsync(long teacherId)
    {
        var teacherGroups = await _groupRepository.SelectAll()
            .Include(tg => tg.TeacherGroups) // Eager loading for Group data
            .Where(g => g.TeacherGroups.Any(tg => tg.TeacherId == teacherId && tg.Role != TeacherRole.MainTeacher))
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<GroupForResultDto>>(teacherGroups);
    }

    // Shu coursega tegishli bo'lgan guruhlarni qaytaruvchi method
    public async Task<IEnumerable<GroupForResultDto>> RetrieveGroupsByCourseIdAsync(long courseId)
    {
        if (courseId <= 0)
        {
            throw new ArgumentException("Course ID must be a positive value.");
        }

        var groups = await _groupRepository.SelectAll()
          .Include(g => g.TeacherGroups)
            .ThenInclude(tg => tg.Teacher)
          .Include(g => g.Course)
          .Include(g => g.StudentGroups)
          .Where(g => g.CourseId == courseId)
          .AsNoTracking()
          .ToListAsync();

        var groupDtos = groups.Select(group =>
        {
            var groupDto = _mapper.Map<GroupForResultDto>(group);
            var mainTeacher = group.TeacherGroups.FirstOrDefault(tg => tg.Role == TeacherRole.MainTeacher);

            groupDto.TeacherFirstName = mainTeacher?.Teacher?.FirstName;
            groupDto.TeacherLastName = mainTeacher?.Teacher?.LastName;
            groupDto.TotalTeacherCount = group.TeacherGroups.Count();
            groupDto.StudentCount = group.StudentGroups.Count();

            return groupDto;
        }).ToList();

        return groupDtos;
    }

    // Shu guruh uchun dars o'tadigan ustozlarni qaytaruvchi method va dto
    public async Task<IEnumerable<TeacherForGroupDto>> GetTeachersByGroupIdAsync(long groupId)
    {
        if (groupId <= 0)
        {
            throw new ArgumentException("Group ID must be a positive value.");
        }

        var group = await _groupRepository.SelectAll()
            .Include(g => g.TeacherGroups)
              .ThenInclude(tg => tg.Teacher)
                .ThenInclude(t => t.TeacherAsset) // Include TeacherAsset
            .Where(g => g.Id == groupId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (group is null)
        {
            throw new ZeemlinException(404, "Group Not Found");
        }

        var teachers = group.TeacherGroups.Select(tg =>
        {
            var profilePictureUrl = tg.Teacher.TeacherAsset?.Path; // Use null-conditional operator
            return new TeacherForGroupDto
            {
                Id = tg.TeacherId,
                Username = tg.Teacher.Username,
                FirstName = tg.Teacher.FirstName,
                LastName = tg.Teacher.LastName,
                ProfilePictureUrl = profilePictureUrl, // Assign profile picture URL if it exists
                ScienceType = tg.Teacher.ScienceType.ToString(),
            };
        }).ToList();

        return teachers;
    }

    public async Task<ICollection<StudentRankingDto>> GetStudentRankingsInGroup(long groupId)
    {
        var group = await _groupRepository.SelectAll()
            .Where(g => g.Id == groupId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (group == null)
            throw new ZeemlinException(404, "Group Not Found");

        var students = await _studentGroupRepository.GetStudentsByGroup(groupId);

        var studentRankings = new List<StudentRankingDto>();

        foreach (var student in students)
        {
            var attendances = await _lessonAttendanceRepository.GetStudentAttendancesByGroup(groupId, student.Id) ?? new List<LessonAttendance>();

            int attendanceCount = attendances.Count(a =>
                a.LessonAttendanceType == LessonAttendanceType.Yes ||
                a.LessonAttendanceType == LessonAttendanceType.PartiallyPresent ||
                a.LessonAttendanceType == LessonAttendanceType.Online);

            var studentScores = student.StudentScores
                .Where(s => s.Lesson.Group.Id == groupId);

            double averageScore = studentScores.Any()
                ? studentScores.Average(s => s.Score)
                : 0;

            double weightedAverage = 0.7 * attendanceCount + 0.3 * averageScore;

            var studentRanking = new StudentRankingDto
            {
                StudentId = student.Id,
                StudentUniqueId = student.StudentUniqueId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                AttendanceCount = attendanceCount,
                AverageScore = averageScore,
                WeightedAverage = weightedAverage,
            };

            studentRankings.Add(studentRanking);
        }

        studentRankings.Sort((result1, result2) =>
        {
            int weightedComparison = result2.WeightedAverage.CompareTo(result1.WeightedAverage);
            return weightedComparison != 0 ? weightedComparison : result1.FirstName.CompareTo(result2.FirstName);
        });

        return studentRankings;
    }





}
