using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zeemlin.Domain.Entities.Assets;
using Zeemlin.Domain.Entities.Library;

namespace Zeemlin.Data.DbContexts.EntityConfigurations
{
    public class AssetsConfiguration
    {
        public class SchoolLogoAssetConfiguration : IEntityTypeConfiguration<SchoolLogoAsset>
        {
            public void Configure(EntityTypeBuilder<SchoolLogoAsset> builder)
            {
                builder.ToTable("SchoolLogoAssets");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Path).IsRequired();
                builder.Property(e => e.UploadedDate).IsRequired();

                builder.HasOne(e => e.School)
                    .WithMany()
                    .HasForeignKey(e => e.SchoolId);
            }
        }
        public class SchoolAssetConfiguration : IEntityTypeConfiguration<SchoolAsset>
        {
            public void Configure(EntityTypeBuilder<SchoolAsset> builder)
            {
                builder.ToTable("SchoolAssets");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
                builder.Property(e => e.Description).HasMaxLength(1000);
                builder.Property(e => e.Path).IsRequired();
                builder.Property(e => e.UploadedDate).IsRequired();

                builder.HasOne(e => e.School)
                    .WithMany()
                    .HasForeignKey(e => e.SchoolId);
            }
        }

        public class HomeworkAssetConfiguration : IEntityTypeConfiguration<HomeworkAsset>
        {
            public void Configure(EntityTypeBuilder<HomeworkAsset> builder)
            {
                builder.ToTable("HomeworkAssets");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Path).IsRequired();
                builder.Property(e => e.UploadedDate).IsRequired();

                builder.HasOne(e => e.Homework)
                    .WithMany()
                    .HasForeignKey(e => e.HomeworkId);
            }
        }

        public class TeacherAssetConfiguration : IEntityTypeConfiguration<TeacherAsset>
        {
            public void Configure(EntityTypeBuilder<TeacherAsset> builder)
            {
                builder.ToTable("TeacherAssets");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Path).IsRequired();
                builder.Property(e => e.UploadedDate).IsRequired();

                builder.HasOne(e => e.Teacher)
                    .WithMany()
                    .HasForeignKey(e => e.TeacherId);
            }
        }

        public class EventAssetConfiguration : IEntityTypeConfiguration<EventAsset>
        {
            public void Configure(EntityTypeBuilder<EventAsset> builder)
            {
                builder.ToTable("EventAssets");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Path).IsRequired();
                builder.Property(e => e.UploadedDate).IsRequired();

                builder.HasOne(e => e.Event)
                    .WithMany()
                    .HasForeignKey(e => e.EventId);
            }
        }


        public class QuestionAssetConfiguration : IEntityTypeConfiguration<QuestionAsset>
        {
            public void Configure(EntityTypeBuilder<QuestionAsset> builder)
            {
                builder.ToTable("QuestionAssets");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Path).IsRequired();
                builder.Property(e => e.UploadedDate).IsRequired();

                builder.HasOne(e => e.Question)
                    .WithMany()
                    .HasForeignKey(e => e.QuestionId);
            }
        }

        public class VideoLessonAssetConfiguration : IEntityTypeConfiguration<VideoLessonAsset>
        {
            public void Configure(EntityTypeBuilder<VideoLessonAsset> builder)
            {
                builder.ToTable("VideoLessonAssets"); // Set table name
                builder.HasKey(a => a.Id); // Set primary key

                // Define properties with data types and validation (if needed)
                builder.Property(e => e.Title).HasMaxLength(255); // Optional title, limit length
                builder.Property(e => e.Description); // Optional description
                builder.Property(e => e.Path).IsRequired(); // Required path to the video file
                builder.Property(e => e.UploadedDate).IsRequired(); // Required upload date
                builder.Property(e => e.ContentType); // Optional content type (e.g., video/mp4)
                builder.Property(e => e.Size); // Optional size of the video file in bytes

                // Foreign key relationship with Lesson (One-to-Many)
                builder.HasOne(e => e.Lesson)
                    .WithMany(l => l.VideoLessons) // Lesson has many VideoLessonAssets
                    .HasForeignKey(e => e.LessonId);
            }
        }

        public class StudentAwardConfiguration : IEntityTypeConfiguration<StudentAward>
        {
            public void Configure(EntityTypeBuilder<StudentAward> builder)
            {
                builder.ToTable("StudentAwards");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Path).IsRequired();
                builder.Property(e => e.UploadedDate).IsRequired();

                builder.HasOne(e => e.Student)
                    .WithMany(s => s.StudentAwards)
                    .HasForeignKey(e => e.StudentId);
            }
        }

        public class TeacherAwardConfiguration : IEntityTypeConfiguration<TeacherAward>
        {
            public void Configure(EntityTypeBuilder<TeacherAward> builder)
            {
                builder.ToTable("TeacherAwards");
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Path).IsRequired();
                builder.Property(e => e.UploadedDate).IsRequired();

                builder.HasOne(e => e.Teacher)
                    .WithMany(t => t.TeacherAwards)
                    .HasForeignKey(e => e.TeacherId);
            }
        }

        public class BookConfiguration : IEntityTypeConfiguration<Book>
        {
            public void Configure(EntityTypeBuilder<Book> builder)
            {
                builder.ToTable("Books"); 

                builder.HasKey(b => b.Id); 

                builder.Property(b => b.ISBN).IsRequired().HasMaxLength(13); 
                builder.Property(b => b.Title).IsRequired().HasMaxLength(255);
                builder.Property(b => b.Author).IsRequired().HasMaxLength(100);
                builder.Property(b => b.Description).HasMaxLength(1000); 
                builder.Property(b => b.Subject).IsRequired().HasMaxLength(50);
                builder.Property(b => b.UploadDate).IsRequired();
                builder.Property(b => b.Language).IsRequired().HasMaxLength(20);
                builder.Property(b => b.ContentType);
                builder.Property(b => b.Size);

                builder.HasOne(b => b.School)
                  .WithMany(s => s.Books) 
                  .HasForeignKey(b => b.SchoolId);

                builder.Property(b => b.BookPhotoUrl);
                builder.Property(b => b.PdfUrl);
            }
        }
    }
}
