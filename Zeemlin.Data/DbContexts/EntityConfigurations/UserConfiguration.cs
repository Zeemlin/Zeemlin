﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zeemlin.Domain.Entities.Assets;
using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Data.DbContexts.EntityConfigurations
{
    public class UserConfiguration
    {
        public class SuperAdminConfiguration : IEntityTypeConfiguration<SuperAdmin>
        {
            public void Configure(EntityTypeBuilder<SuperAdmin> builder)
            {
                //builder.ToTable("SuperAdmins");
                //builder.HasKey(e => e.Id);

                //builder.Property(e => e.Username).IsRequired().HasMaxLength(50);
                //builder.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                //builder.Property(e => e.LastName).IsRequired().HasMaxLength(30);
                //builder.Property(e => e.User.Email).IsRequired().HasMaxLength(50);
                //builder.Property(e => e.User.Password).IsRequired();
                //builder.Property(e => e.User.Salt).IsRequired();
                //builder.Property(e => e.Gender).IsRequired();
                builder.Property(e => e.PassportSeria).IsRequired().HasMaxLength(9);

            }
        }

        public class DirectorConfiguration : IEntityTypeConfiguration<Director>
        {
            public void Configure(EntityTypeBuilder<Director> builder)
            {
                builder.ToTable("Directors");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Username).IsRequired().HasMaxLength(50);
                builder.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                builder.Property(e => e.LastName).IsRequired().HasMaxLength(30);
                builder.Property(e => e.Email).IsRequired().HasMaxLength(50);
                builder.Property(e => e.PhoneNumber).IsRequired();
                builder.Property(e => e.Password).IsRequired();
                builder.Property(e => e.Salt).IsRequired();
                builder.Property(e => e.Gender).IsRequired();
                builder.Property(e => e.PassportSeria).IsRequired().HasMaxLength(9);

                builder.HasMany(e => e.Schools)
                    .WithOne(s => s.Director)
                    .HasForeignKey(s => s.DirectorId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }

        public class AdminConfiguration : IEntityTypeConfiguration<Admin>
        {
            public void Configure(EntityTypeBuilder<Admin> builder)
            {
                builder.ToTable("Admins");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Username).IsRequired().HasMaxLength(50);
                builder.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                builder.Property(e => e.LastName).IsRequired().HasMaxLength(30);
                builder.Property(e => e.Email).IsRequired().HasMaxLength(50);
                builder.Property(e => e.Password).IsRequired();
                builder.Property(e => e.Salt).IsRequired();
                builder.Property(e => e.Gender).IsRequired();
                builder.Property(e => e.PassportSeria).IsRequired().HasMaxLength(9);

            }
        }

        public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
        {
            public void Configure(EntityTypeBuilder<Teacher> builder)
            {
                builder.ToTable("Teachers");
                builder.HasKey(t => t.Id);

                builder.Property(t => t.Username).IsRequired().HasMaxLength(50);
                builder.Property(t => t.FirstName).IsRequired().HasMaxLength(30);
                builder.Property(t => t.LastName).IsRequired().HasMaxLength(30);
                builder.Property(t => t.DateOfBirth).IsRequired();
                builder.Property(t => t.PhoneNumber).IsRequired();
                builder.Property(t => t.Email).IsRequired().HasMaxLength(50);
                builder.Property(t => t.Password).IsRequired();
                builder.Property(t => t.Salt).IsRequired();
                builder.Property(t => t.Biography).HasMaxLength(200);
                builder.Property(t => t.Region).IsRequired();
                builder.Property(t => t.DistrictName).IsRequired().HasMaxLength(50);
                builder.Property(e => e.GeneralAddressMFY).IsRequired().HasMaxLength(50);
                builder.Property(e => e.StreetName).IsRequired().HasMaxLength(100);
                builder.Property(e => e.HouseNumber).IsRequired();
                builder.Property(t => t.ScienceType).IsRequired();
                builder.Property(t => t.genderType).IsRequired();

                builder.HasMany(t => t.TeacherAwards)
                  .WithOne(tg => tg.Teacher)
                  .HasForeignKey(tg => tg.TeacherId)
                  .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(t => t.TeacherGroups)
                  .WithOne(tg => tg.Teacher)
                  .HasForeignKey(tg => tg.TeacherId)
                  .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(t => t.TeacherAsset)
                  .WithOne(a => a.Teacher)
                  .HasForeignKey<TeacherAsset>(a => a.TeacherId)
                  .OnDelete(DeleteBehavior.Cascade); 

                builder.HasMany(t => t.TeacherAwards)
                  .WithOne(tg => tg.Teacher)
                  .HasForeignKey(tg => tg.TeacherId)
                  .OnDelete(DeleteBehavior.Cascade);
            }
        }



        public class ParentConfiguration : IEntityTypeConfiguration<Parent>
        {
            public void Configure(EntityTypeBuilder<Parent> builder)
            {
                builder.ToTable("Parents");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                builder.Property(e => e.LastName).IsRequired().HasMaxLength(30);
                builder.Property(e => e.DateOfBirth).IsRequired();
                builder.Property(e => e.Gender).IsRequired();
                builder.Property(t => t.PhoneNumber).IsRequired();
                builder.Property(e => e.Email).IsRequired().HasMaxLength(255);
                builder.Property(t => t.Password).IsRequired();
                builder.Property(e => e.Salt).IsRequired();
                builder.Property(e => e.Region).IsRequired();
                builder.Property(e => e.DistrictName).IsRequired().HasMaxLength(50);
                builder.Property(e => e.GeneralAddressMFY).IsRequired().HasMaxLength(50);
                builder.Property(e => e.StreetName).IsRequired().HasMaxLength(50);
                builder.Property(e => e.HouseNumber).IsRequired();

                builder.HasMany(p => p.ParentStudents)
                    .WithOne(ps => ps.Parent)
                    .HasForeignKey(ps => ps.ParentId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }

        public class StudentConfiguration : IEntityTypeConfiguration<Student>
        {
            public void Configure(EntityTypeBuilder<Student> builder)
            {
                builder.ToTable("Students");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                builder.Property(e => e.LastName).IsRequired().HasMaxLength(50); 
                builder.Property(e => e.DateOfBirth).IsRequired();
                builder.Property(e => e.FatherName).IsRequired().HasMaxLength(50);
                builder.Property(t => t.genderType).IsRequired();
                builder.Property(e => e.PhoneNumber).IsRequired();
                builder.Property(e => e.Email).IsRequired().HasMaxLength(50);
                builder.Property(e => e.Password).IsRequired();
                builder.Property(e => e.Salt).IsRequired();
                builder.Property(t => t.Region).IsRequired();
                builder.Property(e => e.DistrictName).IsRequired().HasMaxLength(50);
                builder.Property(e => e.GeneralAddressMFY).IsRequired().HasMaxLength(50);
                builder.Property(e => e.StreetName).IsRequired().HasMaxLength(100);
                builder.Property(e => e.HouseNumber).IsRequired();
                builder.Property(e => e.StudentUniqueId);

                builder.HasMany(e => e.StudentAwards)
                    .WithOne(sg => sg.Student)
                    .HasForeignKey(sg => sg.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(e => e.StudentGroups)
                    .WithOne(sg => sg.Student)
                    .HasForeignKey(sg => sg.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(e => e.LessonAttendances)
                    .WithOne(la => la.Student)
                    .HasForeignKey(la => la.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(ps => ps.ParentStudents)
                    .WithOne(s => s.Student)
                    .HasForeignKey(s => s.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(ps => ps.StudentScores)
                    .WithOne(s => s.Student)
                    .HasForeignKey(s => s.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

            }
        }
    }
}
