﻿using Microsoft.EntityFrameworkCore;
using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Entities.Assets;
using Zeemlin.Domain.Entities.Events;
using Zeemlin.Domain.Entities.Library;
using Zeemlin.Domain.Entities.Questions;
using Zeemlin.Domain.Entities.Users;
using static Zeemlin.Data.DbContexts.EntityConfigurations.AssetsConfiguration;
using static Zeemlin.Data.DbContexts.EntityConfigurations.SchoolConfiguration;
using static Zeemlin.Data.DbContexts.EntityConfigurations.UserConfiguration;

namespace Zeemlin.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        // Schools
        public DbSet<School> School { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Book> Books { get; set; }

        // Event
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventsRegistration { get; set; }

        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }

        // Assets
        public DbSet<SchoolLogoAsset> SchoolLogoAssets { get; set; }
        public DbSet<SchoolAsset> SchoolAssets { get; set; }
        public DbSet<EventAsset> EventAssets { get; set; }
        public DbSet<TeacherAsset> TeacherAssets { get; set; }
        public DbSet<TeacherAward> TeacherAwards { get; set; }
        public DbSet<StudentAward> StudentAwards { get; set; }
        public DbSet<HomeworkAsset> HomeworkAssets { get; set; }
        public DbSet<QuestionAsset> QuestionAssets { get; set; }

        // Lessons
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonAttendance> LessonAttendances { get; set; }
        public DbSet<LessonTable> LessonsTable { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<VideoLessonAsset> VideoLessons { get; set; }
        public DbSet<StudentScore> StudentScores { get; set; }

        // Groups
        public DbSet<Group> Groups { get; set; }
        public DbSet<Grade> Grades { get; set; }

        // Questions
        public DbSet<Question> Questiones { get; set; } 
        public DbSet<Answer> Answers { get; set; }

        // Many-to-Many Relationships (without navigation properties)
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<TeacherGroup> TeacherGroups { get; set; } 
        public DbSet<ParentStudent> ParentStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Assets
            modelBuilder.ApplyConfiguration(new SchoolLogoAssetConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolAssetConfiguration());
            modelBuilder.ApplyConfiguration(new HomeworkAssetConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherAssetConfiguration());
            modelBuilder.ApplyConfiguration(new EventAssetConfiguration());
            modelBuilder.ApplyConfiguration(new StudentAwardConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherAwardConfiguration());


            // Users
            modelBuilder.ApplyConfiguration(new SuperAdminConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());


            // School
            modelBuilder.ApplyConfiguration(new SchoolConfigurations());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentGroupConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ParentStudentConfiguration());
            modelBuilder.ApplyConfiguration(new HomeworkConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new LessonTableConfiguration());
            modelBuilder.ApplyConfiguration(new LessonAttendanceConfiguration());
            modelBuilder.ApplyConfiguration(new VideoLessonAssetConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new StudentScoreConfiguration());

            // Event
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new EventRegistrationConfiguration());


        }

    }
}
