﻿using AutoMapper;
using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Entities.Users;
using Zeemlin.Domain.Entities.Assets;
using Zeemlin.Domain.Entities.Events;
using Zeemlin.Service.DTOs.Grade;
using Zeemlin.Service.DTOs.Group;
using Zeemlin.Service.DTOs.Homework;
using Zeemlin.Service.DTOs.Lesson;
using Zeemlin.Service.DTOs.StudentGroups;
using Zeemlin.Service.DTOs.Schools;
using Zeemlin.Service.DTOs.TeacherGroups;
using Zeemlin.Service.DTOs.Subjects;
using Zeemlin.Service.DTOs.Courses;
using Zeemlin.Service.DTOs.Assets.HomeworkAssets;
using Zeemlin.Service.DTOs.LessonAttendances;
using Zeemlin.Service.DTOs.Users.SuperAdmins;
using Zeemlin.Service.DTOs.Users.Admins;
using Zeemlin.Service.DTOs.Users.Directors;
using Zeemlin.Service.DTOs.Assets.SchoolAssets;
using Zeemlin.Service.DTOs.Assets.TeacherAssets;
using Zeemlin.Service.DTOs.Assets.SchoolLogoAssets;
using Zeemlin.Service.DTOs.Assets.EventAssets;
using Zeemlin.Service.DTOs.Events;
using Zeemlin.Service.DTOs.Users.Students;
using Zeemlin.Service.DTOs.Users.Teachers;
using Zeemlin.Service.DTOs.Users.Parents;
using Zeemlin.Service.DTOs.ParentStudents;
using Zeemlin.Service.DTOs.Assets.VideoLessonAssets;
using Zeemlin.Service.DTOs.Events.EventRegistrations;
using Zeemlin.Service.DTOs.Assets.StudentAwards;
using Zeemlin.Service.DTOs.StudentScores;

namespace Zeemlin.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Users
        CreateMap<Student, StudentForCreationDto>().ReverseMap();
        CreateMap<Student, StudentForUpdateDto>().ReverseMap();
        CreateMap<Student, StudentForChangePasswordDto>().ReverseMap();
        CreateMap<Student, StudentAddressForUpdateDto>().ReverseMap();
        CreateMap<Student, StudentForResultDto>().ReverseMap();

        CreateMap<Teacher, TeacherForCreationDto>().ReverseMap();
        CreateMap<Teacher, TeacherForUpdateDto>().ReverseMap();
        CreateMap<Teacher, TeacherForChangePasswordDto>().ReverseMap();
        CreateMap<Teacher, TeacherAddressForUpdateDto>().ReverseMap();
        CreateMap<Teacher, TeacherForResultDto>().ReverseMap();
        CreateMap<Teacher, TeacherSearchResultDto>().ReverseMap();
        CreateMap<Teacher, FilteredTeacherDTO>();

        CreateMap<Parent, ParentForCreationDto>().ReverseMap();
        CreateMap<Parent, ParentForUpdateDto>().ReverseMap();
        CreateMap<Parent, ParentAddressForUpdateDto>().ReverseMap();
        CreateMap<Parent, ParentForChangePasswordDto>().ReverseMap();
        CreateMap<Parent, ParentForResultDto>().ReverseMap();

        CreateMap<Admin, AdminForCreationDto>().ReverseMap();
        CreateMap<Admin, AdminForUpdateDto>().ReverseMap();
        CreateMap<Admin, AdminForChangePasswordDto>().ReverseMap();
        CreateMap<Admin, AdminForResultDto>().ReverseMap();


        CreateMap<Director, DirectorForCreationDto>().ReverseMap();
        CreateMap<Director, DirectorForUpdateDto>().ReverseMap();
        CreateMap<Director, DirectorForChangePasswordDto>().ReverseMap();
        CreateMap<Director, DirectorForResultDto>().ReverseMap();

        CreateMap<SuperAdmin, SuperAdminForCreationDto>().ReverseMap();
        CreateMap<SuperAdmin, SuperAdminForUpdateDto>().ReverseMap();
        CreateMap<SuperAdmin, SuperAdminForChangePasswordDto>().ReverseMap();
        CreateMap<SuperAdmin, SuperAdminForResultDto>().ReverseMap();
        #endregion

        #region Schools
        CreateMap<School, SchoolForCreationDto>().ReverseMap();
        CreateMap<School, SchoolForUpdateDto>().ReverseMap();
        CreateMap<School, SchoolActivityForUpdateDto>().ReverseMap();
        CreateMap<School, SchoolForResultDto>().ReverseMap();

        CreateMap<Event, EventForCreationDto>().ReverseMap();
        CreateMap<Event, EventForUpdateDto>().ReverseMap();
        CreateMap<Event, EventForPublicDto>();
        CreateMap<Event, EventForResultDto>().ReverseMap();
        CreateMap<EventStatusUpdateDto, Event>();
        CreateMap<Event, RejectedEventForSuperAdminDto>();
        CreateMap<Event, ApprovedEventForSuperAdminDto>();

        CreateMap<EventRegistration, EventRegistrationCreationDto>().ReverseMap();
        CreateMap<EventRegistration, EventRegistrationResultDto>().ReverseMap();

        CreateMap<Course, CourseForCreationDto>().ReverseMap();
        CreateMap<Course, CourseForUpdateDto>().ReverseMap();
        CreateMap<Course, CourseForResultDto>().ReverseMap();

        CreateMap<Group, GroupForCreationDto>().ReverseMap();
        CreateMap<Group, GroupForUpdateDto>().ReverseMap();
        CreateMap<Group, GroupForResultDto>().ReverseMap();
        CreateMap<Group, SearchGroupResultDto>();

        CreateMap<Homework, HomeworkForCreationDto>().ReverseMap();
        CreateMap<Homework, HomeworkForUpdateDto>().ReverseMap();
        CreateMap<Homework, HomeworkForResultDto>().ReverseMap();

        CreateMap<Grade, GradeForCreationDto>().ReverseMap();
        CreateMap<Grade, GradeForUpdateDto>().ReverseMap();
        CreateMap<Grade, GradeForResultDto>().ReverseMap();

        CreateMap<Subject, SubjectForCreationDto>().ReverseMap();
        CreateMap<Subject, SubjectForUpdateDto>().ReverseMap();
        CreateMap<Subject, SubjectForResultDto>().ReverseMap();

        CreateMap<Lesson, LessonForCreationDto>().ReverseMap();
        CreateMap<Lesson, LessonForUpdateDto>().ReverseMap();
        CreateMap<Lesson, LessonForResultDto>().ReverseMap();

        CreateMap<LessonAttendance, LessonAttendanceForCreationDto>().ReverseMap();
        CreateMap<LessonAttendance, LessonAttendanceForUpdateDto>().ReverseMap();
        CreateMap<LessonAttendance, LessonAttendanceForResultDto>().ReverseMap();
        CreateMap<LessonAttendance, StudentAttendanceReportDto>().ReverseMap();

        CreateMap<StudentScore, StudentScoreForCreationDto>().ReverseMap();
        CreateMap<StudentScore, StudentScoreForUpdateDto>().ReverseMap();
        CreateMap<StudentScore, StudentScoreForResultDto>().ReverseMap();
        #endregion

        #region Relationships
        CreateMap<StudentGroup, StudentGroupForCreationDto>().ReverseMap();
        CreateMap<StudentGroup, StudentGroupForUpdateDto>().ReverseMap();
        CreateMap<StudentGroup, StudentGroupForResultDto>().ReverseMap();

        CreateMap<TeacherGroup, TeacherGroupForCreationDto>().ReverseMap();
        CreateMap<TeacherGroup, TeacherGroupForUpdateDto>().ReverseMap();
        CreateMap<TeacherGroup, TeacherGroupForResultDto>().ReverseMap();

        CreateMap<ParentStudent, ParentStudentForCreationDto>().ReverseMap();
        CreateMap<ParentStudent, ParentStudentForUpdateDto>().ReverseMap();
        CreateMap<ParentStudent, ParentStudentForResultDto>().ReverseMap();
        #endregion

        #region Assets
        CreateMap<SchoolLogoAsset, SchoolLogoAssetForCreationDto>().ReverseMap();
        CreateMap<SchoolLogoAsset, SchoolLogoAssetForResultDto>().ReverseMap();

        CreateMap<SchoolAsset, SchoolAssetForCreationDto>().ReverseMap();
        CreateMap<SchoolAsset, SchoolAssetForResultDto>().ReverseMap();

        CreateMap<TeacherAsset, TeacherAssetForCreationDto>().ReverseMap();
        CreateMap<TeacherAsset, TeacherAssetForUpdateDto>().ReverseMap();
        CreateMap<TeacherAsset, TeacherAssetForResultDto>().ReverseMap();

        CreateMap<HomeworkAsset, HomeworkAssetForCreationDto>().ReverseMap();
        CreateMap<HomeworkAsset, HomeworkAssetForUpdateDto>().ReverseMap();
        CreateMap<HomeworkAsset, HomeworkAssetForResultDto>().ReverseMap();

        CreateMap<EventAsset, EventAssetForCreationDto>().ReverseMap();
        CreateMap<EventAsset, EventAssetForResultDto>().ReverseMap();

        CreateMap<VideoLessonAsset, VideoLessonAssetForCreationDto>().ReverseMap();
        CreateMap<VideoLessonAsset, VideoLessonAssetForUpdateDto>().ReverseMap();
        CreateMap<VideoLessonAsset, VideoLessonAssetForResultDto>().ReverseMap();

        CreateMap<StudentAward, StudentAwardForCreationDto>().ReverseMap();
        CreateMap<StudentAward, StudentAwardForResultDto>().ReverseMap();
        #endregion
    }
}