using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zeemlin.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Organizer = table.Column<string>(type: "text", nullable: false),
                    EventType = table.Column<byte>(type: "smallint", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Format = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    OfficialPage = table.Column<string>(type: "text", nullable: true),
                    CreatedByUsername = table.Column<string>(type: "text", nullable: false),
                    UpdaterId = table.Column<long>(type: "bigint", nullable: true),
                    EventAssetId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<int>(type: "integer", nullable: false),
                    DistrictName = table.Column<string>(type: "text", nullable: false),
                    GeneralAddressMFY = table.Column<string>(type: "text", nullable: false),
                    StreetName = table.Column<string>(type: "text", nullable: false),
                    HouseNumber = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FatherName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    genderType = table.Column<byte>(type: "smallint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Region = table.Column<int>(type: "integer", nullable: false),
                    DistrictName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GeneralAddressMFY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StreetName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HouseNumber = table.Column<short>(type: "smallint", nullable: false),
                    StudentUniqueId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperAdmins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    PassportSeria = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Biography = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Region = table.Column<int>(type: "integer", nullable: false),
                    DistrictName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GeneralAddressMFY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StreetName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HouseNumber = table.Column<short>(type: "smallint", nullable: false),
                    ScienceType = table.Column<byte>(type: "smallint", nullable: false),
                    genderType = table.Column<byte>(type: "smallint", nullable: false),
                    TeacherAssetId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventAssets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRegistrations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RegistrationCode = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventRegistrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentStudents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentStudents_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAwards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAwards_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    PassportSeria = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    SuperAdminId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directors_SuperAdmins_SuperAdminId",
                        column: x => x.SuperAdminId,
                        principalTable: "SuperAdmins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeacherAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAssets_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAwards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAwards_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SchoolType = table.Column<byte>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    DirectorId = table.Column<long>(type: "bigint", nullable: false),
                    Region = table.Column<int>(type: "integer", nullable: false),
                    DistrictName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GeneralAddressMFY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StreetName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CallCenter = table.Column<string>(type: "text", nullable: true),
                    EmailCenter = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SchoolLogoAssetId = table.Column<long>(type: "bigint", nullable: true),
                    SuperAdminId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schools_SuperAdmins_SuperAdminId",
                        column: x => x.SuperAdminId,
                        principalTable: "SuperAdmins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    PassportSeria = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    SuperAdminId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admins_SuperAdmins_SuperAdminId",
                        column: x => x.SuperAdminId,
                        principalTable: "SuperAdmins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    price = table.Column<int>(type: "integer", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolLogoAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolLogoAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolLogoAssets_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    AdminId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolAssets_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolAssets_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    StartDate = table.Column<string>(type: "text", nullable: false),
                    EndDate = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGroups_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    Role = table.Column<byte>(type: "smallint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherGroups_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AssessmentType = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Deadline = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homeworks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonAttendances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LessonAttendanceType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonAttendances_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonAttendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonTables",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    Classroom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonTables_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonTables_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questiones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Difficulty = table.Column<byte>(type: "smallint", nullable: false),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questiones_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoLessonAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoLessonAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoLessonAssets_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HomeworkId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkAssets_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questiones_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAssets_Questiones_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "Gender", "LastName", "PassportSeria", "Password", "PhoneNumber", "SuperAdminId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8635), "olimjon.torayev@director.com", "Olimjon", (byte)1, "To'rayev", "AB123456", "hashed_password", "+998904567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "director1" },
                    { 2L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8642), "nodira.xolmirzayeva@director.com", "Nodira", (byte)2, "Xolmirzayeva", "CD789012", "hashed_password", "+998904567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "director2" },
                    { 3L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8646), "sarvar.qosimov@director.com", "Sarvar", (byte)1, "Qosimov", "EF345678", "hashed_password", "+998904567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "director3" },
                    { 4L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8649), "malika.azizova@director.com", "Malika", (byte)2, "Azizova", "GH567890", "hashed_password", "+998904567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "director4" },
                    { 5L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8652), "islom.karimov@director.com", "Islom", (byte)1, "Karimov", "IJ789012", "hashed_password", "+998904567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "director5" },
                    { 6L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8656), "ikcmwopv@director.com", "mcpw", (byte)1, "cmla", "IJ785212", "hashed_password", "+998904567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "director5" }
                });

            migrationBuilder.InsertData(
                table: "SuperAdmins",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "Gender", "LastName", "PassportSeria", "Password", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8281), "shahnozaodilova@gmail.com", "Shahnoza", (byte)2, "Odilova", "AB123456", "hashed_password", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "superadmin1" },
                    { 2L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8311), "moxi05@gmail.com", "Moxinur", (byte)2, "Zokirova", "CD789012", "hashed_password", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "superadmin2" },
                    { 3L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8315), "akbarov@gmail.com", "Muhammadjon", (byte)1, "Akbarov", "AB123458", "hashed_password", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "superadmin3" },
                    { 4L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8318), "ruxshona0@gmail.com", "Ruxshona", (byte)2, "Nodirova", "CD789013", "hashed_password", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "superadmin4" },
                    { 5L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8321), "kimdir@gmail.com", "Kimdir", (byte)2, "Bilmiman", "CD789014", "hashed_password", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "superadmin4" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Biography", "CreatedAt", "DateOfBirth", "DistrictName", "Email", "FirstName", "GeneralAddressMFY", "HouseNumber", "LastName", "Password", "PhoneNumber", "Region", "ScienceType", "StreetName", "TeacherAssetId", "UpdatedAt", "Username", "genderType" },
                values: new object[,]
                {
                    { 1L, "Experienced teacher in mathematics.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8770), "1985.5.15", "Mirzo Ulug'bek", "johnsmith@school.com", "John", "Main Street", (short)12, "Smith", "hashed_password", "+998900000001", 1, (byte)13, "Oak Avenue", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnny", (byte)1 },
                    { 2L, "Passionate teacher specializing in history.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8780), "1988.8.25", "Andijan City", "janedoe@school.com", "Jane", "Downtown", (short)20, "Doe", "hashed_password", "+998900000002", 3, (byte)4, "Maple Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "janedoe", (byte)2 },
                    { 3L, "Dedicated teacher with expertise in geography.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8784), "1980.1.10", "Fergana City", "michaeljohnson@school.com", "Michael", "Central Avenue", (short)8, "Johnson", "hashed_password", "+998900000003", 5, (byte)19, "Pine Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "michaelj", (byte)1 },
                    { 4L, "Experienced Mathematics teacher with 10+ years of experience.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8789), "1980.1.1", "Samarkand City", "umid.yoldoshev@school1.com", "Umid", "Broadway", (short)15, "Yo'ldoshev", "hashed_password", "+998901234567", 11, (byte)13, "Cedar Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "umid.y", (byte)1 },
                    { 5L, "Enthusiastic teacher with a passion for English language learning.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8793), "1990.2.1", "Namangan City", "sarabrown@school.com", "Sara", "Park Avenue", (short)24, "Brown", "hashed_password", "+998904567890", 4, (byte)11, "Elm Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.b", (byte)2 },
                    { 6L, "Highly qualified teacher for Korean language courses.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8797), "1987.12.31", "Yangihayot", "kimhan@school.com", "Kim", "University District", (short)30, "Han", "hashed_password", "+998908901234", 2, (byte)7, "Willow Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kim.h", (byte)2 },
                    { 7L, "Experienced teacher for Spanish language courses.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8800), "1978.9.22", "Termez", "petergarcia@school.com", "Peter", "Old Town", (short)18, "Garcia", "hashed_password", "+998907890123", 12, (byte)7, "Birch Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter.g", (byte)1 },
                    { 8L, "Dedicated teacher for Russian language instruction.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8811), "1982.6.14", "Navoiy City", "alexeivolkov@school.com", "Alexei", "Industrial District", (short)42, "Volkov", "hashed_password", "+998909876543", 9, (byte)10, "Poplar Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alexei.v", (byte)1 },
                    { 9L, "Skilled teacher specializing in Uzbek language and literature.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8815), "1992.3.8", "Karshi City", "fatima.abdullayeva@school.com", "Fatima", "City Center", (short)55, "Abdullayeva", "hashed_password", "+998901239876", 8, (byte)6, "Ash Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatima.a", (byte)2 },
                    { 10L, "Energetic teacher with a passion for French language and culture.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8819), "1989.11.17", "Jizzakh City", "emmanuelblanc@school.com", "Emmanuel", "New City", (short)37, "Blanc", "hashed_password", "+998905678901", 7, (byte)9, "Beech Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emmanuel.b", (byte)1 },
                    { 11L, "Enthusiastic teacher dedicated to Biology education.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8823), "1995.7.10", "Gulistan", "ayeshakhan@school.com", "Ayesha", "University Area", (short)11, "Khan", "hashed_password", "+998902345678", 13, (byte)17, "Maple Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayesha.k", (byte)2 },
                    { 12L, "Experienced teacher for Chemistry courses.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8827), "1983.4.25", "Khiva", "davidlee@school.com", "David", "Historic Center", (short)29, "Lee", "hashed_password", "+9989098765432", 14, (byte)18, "Elm Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.l", (byte)1 },
                    { 13L, "Skilled teacher for Physics instruction.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8830), "1990.10.21", "Shahrisabz", "mariagarcia@school.com", "Maria", "Old Town", (short)61, "Garcia", "hashed_password", "+9989087654321", 8, (byte)16, "Birch Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.g", (byte)2 },
                    { 14L, "Dedicated teacher passionate about World History.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8834), "1986.5.12", "Bukhara City", "omarsyed@school.com", "Omar", "City Center", (short)74, "Syed", "hashed_password", "+998906789012", 6, (byte)4, "Ash Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.s", (byte)1 },
                    { 15L, "Skilled Uzbek language teacher passionate about preserving cultural heritage.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8837), "2000.2.29", "Namangan City", "malika.azizova@school4.com", "Malika", "North Street", (short)28, "Azizova", "hashed_password", "+998901239876", 4, (byte)6, "Maple Avenue", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "malika.a", (byte)2 },
                    { 16L, "Experienced teacher specializing in geography.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8841), "1994.6.29", "Bukhara City", "emmaperez@school.com", "Emma", "West Street", (short)5, "Perez", "hashed_password", "+998900000016", 6, (byte)19, "Elm Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emmap", (byte)2 },
                    { 17L, "Passionate teacher with expertise in biology.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8844), "1992.8.16", "Khiva", "lucasnguyen@school.com", "Lucas", "South Street", (short)10, "Nguyen", "hashed_password", "+998900000017", 14, (byte)17, "Willow Avenue", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucas.n", (byte)1 },
                    { 18L, "Dedicated teacher with a passion for music.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8849), "1993.10.4", "Chilonzor", "lilygonzalez@school.com", "Lily", "East Street", (short)20, "Gonzalez", "hashed_password", "+998900000018", 2, (byte)2, "Poplar Avenue", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lily.g", (byte)2 },
                    { 19L, "Experienced mathematics teacher.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8852), "1993.10.4", "Andijan City", "jacksonadams@school.com", "Jackson", "Central Street", (short)36, "Adams", "hashed_password", "+998900000019", 3, (byte)13, "Birch Avenue", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jackson.a", (byte)1 },
                    { 20L, "Experienced teacher with a strong background in Literature.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8855), "1975.12.24", "Denau", "elenapetrova@school.com", "Elena", "Central District", (short)9, "Petrova", "hashed_password", "+998903456789", 12, (byte)5, "Oak Avenue", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "elena.p", (byte)2 },
                    { 21L, "Enthusiastic teacher specializing in Information Technology.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8858), "1988.3.3", "Namangan City", "ibrahimaliyev@school.com", "Ibrahim", "Eastern District", (short)46, "Aliyev", "hashed_password", "+9989098765431", 4, (byte)21, "Willow Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ibrahim.a", (byte)1 },
                    { 22L, "Dedicated teacher passionate about teaching Algebra.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8861), "1991.8.19", "Fergana City", "dilshodrakhmatov@school.com", "Dilshod", "Western District", (short)23, "Rakhmatov", "hashed_password", "+9989087654320", 5, (byte)13, "Maple Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dilshod.r", (byte)1 },
                    { 23L, "Skilled teacher for Russin language courses.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8865), "1994.1.7", "Uchteppa", "chloewang@school.com", "Chloe", "University District", (short)82, "Wang", "hashed_password", "+9989078901234", 1, (byte)10, "Birch Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chloe.w", (byte)2 },
                    { 24L, "Experienced teacher with a strong background in Islamic Studies.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8868), "1982.9.14", "Samarkand City", "alimohammed@school.com", "Ali", "Old City", (short)100, "Mohammed", "hashed_password", "+9989067890123", 11, (byte)2, "Ash Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.m", (byte)1 },
                    { 25L, "Passionate teacher specializing in information technology.", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8871), "1993.10.4", "Samarkand City", "harperthompson@school.com", "Harper", "East Street", (short)42, "Thompson", "hashed_password", "+998900000025", 11, (byte)21, "Cedar Avenue", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "harper.t", (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "CallCenter", "CreatedAt", "Description", "DirectorId", "DistrictName", "EmailCenter", "GeneralAddressMFY", "Name", "Region", "SchoolLogoAssetId", "SchoolType", "StreetName", "SuperAdminId", "UpdatedAt", "Website" },
                values: new object[,]
                {
                    { 1L, "+998900000001", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8984), "Xalqaro standartlarga asoslangan innovatsion ta'lim muassasasi", 1L, "Mirzo Ulug'bek", "TXM@school.com", "Uch Qahramon MFY", "Inter-Nation", 2, null, (byte)3, "Bog'ishamol ko'chasi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TXM.com" },
                    { 2L, "+998900000002", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8991), "Ingliz olami", 2L, "Eskishahar", "STI@school.com", "Xo'ja Ahror Vali MFY", "Cambridge Edu", 11, null, (byte)3, "Registon ko'chasi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "STI.com" },
                    { 3L, "+998900000003", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8995), "Pedagogika sohasida yuqori malakali mutaxassislar tayyorlaydigan oliy ta'lim muassasasi", 3L, "Shahriston", "API@school.com", "Pedagogika instituti", "Andijon Pedagogika Instituti", 3, null, (byte)3, "Pedagogika ko'chasi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "API.com" },
                    { 4L, "+998900000004", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8998), "Oliy ta'lim sohasida yuqori malakali mutaxassislar tayyorlaydigan davlat universiteti", 4L, "Namangan shahri", "NDU@school.com", "Universitet", "Namangan Davlat Universiteti", 4, null, (byte)3, "Universitet ko'chasi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NDU.com" },
                    { 5L, "+998900000013", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9001), "Center providing language training services.", 3L, "Yunusabad", "info@tltraining.com", "Language Training Center", "Tashkent Language Training Center", 1, null, (byte)3, "Language Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://tltraining.com" },
                    { 6L, "+998900000014", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9005), "Center offering computer training courses.", 4L, "Samarqand shahri", "info@sctc.uz", "Computer Training Center", "Samarkand Computer Training Center", 11, null, (byte)3, "Computer Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://sctc.uz" },
                    { 7L, "+998900000015", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9008), "Fitness center offering various training programs.", 1L, "Navoiy shahri", "info@navfit.com", "Fitness Training Center", "Navoiy Fitness Training Center", 9, null, (byte)3, "Fitness Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://navfit.com" },
                    { 8L, "+998900000016", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9011), "Center specializing in photography training.", 2L, "Termiz shahri", "info@sptc.uz", "Photography Training Center", "Surxondaryo Photography Training Center", 12, null, (byte)3, "Photography Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://sptc.uz" },
                    { 9L, "+998900000017", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9014), "Center providing language training services.", 3L, "Yunusabad", "info@tltraining.com", "Yunusabad MFY", "Tashkent Language Training Center", 1, null, (byte)3, "Mustaqillik Avenue", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://tltraining.com" },
                    { 10L, "+998900000018", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9017), "Center offering computer training courses.", 4L, "Samarqand shahri", "info@sctc.uz", "Samarqand MFY", "Samarkand Computer Training Center", 11, null, (byte)2, "Amir Temur Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://sctc.uz" },
                    { 11L, "+998900000019", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9020), "Fitness center offering various training programs.", 1L, "Navoiy shahri", "info@navfit.com", "Navoiy MFY", "Navoiy Fitness Training Center", 9, null, (byte)4, "Olmazor Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://navfit.com" },
                    { 12L, "+998900000020", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9023), "Center specializing in photography training.", 5L, "Termiz shahri", "info@sptc.uz", "Termiz MFY", "Surxondaryo Photography Training Center", 12, null, (byte)3, "Shaxrisabz Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://sptc.uz" },
                    { 13L, "+998900000021", new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9026), "Center specializing in photography training.", 5L, "Termiz shahri", "info@sptc.uz", "Termiz MFY", "Surxondaryo Photography Training Center", 12, null, (byte)3, "Shaxrisabz Street", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://sptc.uz" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "Gender", "LastName", "PassportSeria", "Password", "SchoolId", "SuperAdminId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8455), "johndoe@admin1.com", "John", (byte)1, "Doe", "AB123456", "hashed_password", 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school1" },
                    { 2L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8460), "janesmith@admin2.com", "Jane", (byte)2, "Smith", "CD789012", "hashed_password", 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school1" },
                    { 3L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8464), "michaeljohnson@admin1.com", "Michael", (byte)1, "Johnson", "EF345678", "hashed_password", 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school2" },
                    { 4L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8467), "emmadavis@admin2.com", "Emma", (byte)2, "Davis", "GH901234", "hashed_password", 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school2" },
                    { 5L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8470), "williambrown@admin1.com", "William", (byte)1, "Brown", "IJ567890", "hashed_password", 3L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school3" },
                    { 6L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8473), "oliviataylor@admin2.com", "Olivia", (byte)2, "Taylor", "KL123456", "hashed_password", 3L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school3" },
                    { 7L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8476), "davidwilson@admin1.com", "David", (byte)1, "Wilson", "MN789012", "hashed_password", 4L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school4" },
                    { 8L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8479), "sophiamartinez@admin2.com", "Sophia", (byte)2, "Martinez", "OP345678", "hashed_password", 4L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school4" },
                    { 9L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8481), "jamesanderson@admin1.com", "James", (byte)1, "Anderson", "QR901234", "hashed_password", 5L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school5" },
                    { 10L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8485), "avahernandez@admin2.com", "Ava", (byte)2, "Hernandez", "ST567890", "hashed_password", 5L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school5" },
                    { 11L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8488), "benjaminyoung@admin1.com", "Benjamin", (byte)1, "Young", "UV123456", "hashed_password", 6L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school6" },
                    { 12L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8491), "mialopez@admin2.com", "Mia", (byte)2, "Lopez", "WX789012", "hashed_password", 6L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school6" },
                    { 13L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8493), "danielgonzalez@admin1.com", "Daniel", (byte)1, "Gonzalez", "YZ345678", "hashed_password", 7L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school7" },
                    { 14L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8496), "isabellaperez@admin2.com", "Isabella", (byte)2, "Perez", "AB901234", "hashed_password", 7L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school7" },
                    { 15L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8498), "islom.karimov@admin1.com", "Islom", (byte)1, "Karimov", "MN567890", "hashed_password", 8L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school4" },
                    { 17L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8500), "ethanmoore@admin1.com", "Ethan", (byte)1, "Moore", "CD901234", "hashed_password", 9L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school9" },
                    { 19L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8503), "alexanderscott@admin1.com", "Alexander", (byte)1, "Scott", "GH123456", "hashed_password", 10L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school10" },
                    { 20L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8506), "ameliagomez@admin2.com", "Amelia", (byte)2, "Gomez", "IJ789012", "hashed_password", 10L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school10" },
                    { 21L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8509), "henrywright@admin1.com", "Henry", (byte)1, "Wright", "KL345678", "hashed_password", 11L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school11" },
                    { 22L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8511), "sophieflores@admin2.com", "Sophie", (byte)2, "Flores", "MN901234", "hashed_password", 11L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school11" },
                    { 23L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8514), "liamsanchez@admin1.com", "Liam", (byte)1, "Sanchez", "OP567890", "hashed_password", 12L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1_school12" },
                    { 24L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8516), "gracechang@admin2.com", "Grace", (byte)2, "Chang", "QR123456", "hashed_password", 12L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2_school12" },
                    { 25L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(8518), "cmwp@admin2.com", "mps", (byte)2, "cmwp", "QR123456", "hashed_password", 13L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin3_school12" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "SchoolId", "UpdatedAt", "price" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9141), "A comprehensive course covering all aspects of the English language.", "English Language Course", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48651 },
                    { 2L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9147), "A course focusing on various aspects of computer science and programming.", "Computer Science Course", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74586 },
                    { 3L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9150), "A course covering photography techniques, equipment, and artistic aspects.", "Photography Course", 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48651 },
                    { 4L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9152), "A comprehensive course covering various mathematical concepts and techniques.", "Mathematics Course", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48651 },
                    { 5L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9154), "A course exploring the history and development of art from different periods and cultures.", "Art History Course", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54861 },
                    { 6L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9157), "A course covering fundamental principles of physics and their practical applications.", "Physics Course", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48651 },
                    { 7L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9159), "A course exploring music theory, notation, composition, and performance.", "Music Theory Course", 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000 },
                    { 8L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9161), "A course covering the principles of chemistry, including atomic structure, chemical reactions, and bonding.", "Chemistry Course", 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000 },
                    { 9L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9163), "A course studying the Earth's landscapes, environments, and human geography.", "Geography Course", 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 153889 },
                    { 10L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9166), "A course focusing on the French language, covering vocabulary, grammar, and conversation.", "French Language Course", 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 485325 },
                    { 11L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9168), "A course covering algebraic concepts and techniques, including equations, functions, and polynomials.", "Algebra Course", 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 489615 },
                    { 12L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9170), "A course exploring the principles of biology, including cell biology, genetics, and ecology.", "Biology Course", 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98465 },
                    { 13L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9172), "A course focusing on the Russian language, covering vocabulary, grammar, and conversation.", "Russian Language Course", 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84650 },
                    { 14L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9174), "A course exploring classic and contemporary works of English literature.", "English Literature Course", 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000 },
                    { 15L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9176), "A course examining the history and development of art from different cultures and periods.", "History of Art Course", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000 },
                    { 16L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9178), "A course covering fundamental concepts of computer science, programming, and algorithms.", "Computer Science Course", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000 },
                    { 17L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9180), "A course studying the Earth's structure, rocks, minerals, and geological processes.", "Geology Course", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78245 },
                    { 18L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9189), "A course focusing on IT concepts, including hardware, software, networks, and cybersecurity.", "Information Technology Course", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40978 },
                    { 19L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9191), "A course covering principles and techniques of chemical engineering, including unit operations and process design.", "Chemical Engineering Course", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48740 },
                    { 20L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9193), "A course focusing on physical fitness, sports, and exercise physiology.", "Physical Education Course", 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48658 },
                    { 21L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9195), "A course exploring advanced concepts in algebraic geometry, including varieties and schemes.", "Algebraic Geometry Course", 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 755407 },
                    { 22L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9197), "A course studying the Earth's environment, ecosystems, and human impact on nature.", "Environmental Science Course", 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4150 },
                    { 23L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9199), "A course exploring the art and techniques of French cuisine, including cooking methods and recipes.", "French Cuisine Course", 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4568 },
                    { 24L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9201), "A course exploring the art and techniques of French cuisine, including cooking methods and recipes.", "Course", 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86000 },
                    { 25L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9203), "A course exploring the art and techniques of French cuisine, including cooking methods and recipes.", "Course", 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000 }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9340), "A group for beginner English language learners.", "Beginner English Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9344), "A group focusing on Java programming language and application development.", "Java Programming Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9346), "A group for beginners learning basic photography techniques.", "Basic Photography Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 4L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9349), "A group for intermediate level mathematics students.", "Intermediate Mathematics Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 5L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9351), "A group studying Renaissance art and its influences.", "Renaissance Art Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 6L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9354), "A group focusing on advanced topics in physics and theoretical physics.", "Advanced Physics Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 7L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9356), "A group focusing on learning to play musical instruments and ensemble performance.", "Instrumental Music Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 8L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9358), "A group studying organic chemistry and its applications in industry and research.", "Organic Chemistry Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 9L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9360), "A group exploring environmental issues and sustainability.", "Environmental Studies Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 10L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9362), "A group for intermediate French language learners.", "Intermediate French Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, 11L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9364), "A group focusing on advanced algebraic concepts and problem-solving techniques.", "Advanced Algebra Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, 12L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9366), "A group studying the cellular structure, function, and processes.", "Cell Biology Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, 13L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9368), "A group focusing on practicing conversational Russian language skills.", "Russian Language Conversation Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, 14L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9370), "A group studying the works of William Shakespeare and Elizabethan literature.", "Shakespearean Literature Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, 15L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9372), "A group exploring ancient civilizations, cultures, and historical events.", "Ancient History Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, 16L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9374), "A group focusing on advanced algorithms and problem-solving strategies.", "Advanced Algorithms Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, 17L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9376), "A group studying volcanoes, volcanic processes, and volcanic hazards.", "Volcanology Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, 18L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9379), "A group focusing on network security principles, protocols, and practices.", "Network Security Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, 19L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9381), "A group studying chemical engineering process design and optimization.", "Process Design Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, 20L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9382), "A group focusing on team sports and cooperative gameplay.", "Team Sports Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, 11L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9384), "A group studying abstract algebraic structures and their properties.", "Abstract Algebra Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, 12L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9386), "A group focusing on the study of genes, heredity, and genetic variation.", "Genetics Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, 13L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9388), "A group for advanced learners focusing on complex aspects of Russian language and literature.", "Advanced Russian Language Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, 14L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9391), "A group studying modern literary works and contemporary authors.", "Modern Literature Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, 15L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9393), "A group focusing on art and artists from the Renaissance period.", "Renaissance Art Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, 16L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9395), "A group studying machine learning algorithms and applications.", "Machine Learning Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, 17L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9397), "A group studying fossils, ancient life forms, and prehistoric ecosystems.", "Paleontology Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, 18L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9399), "A group focusing on cybersecurity practices, threats, and defenses.", "Cybersecurity Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, 19L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9401), "A group studying optimization techniques for chemical processes.", "Chemical Process Optimization Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30L, 20L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9403), "A group focusing on yoga, meditation, and mindfulness practices.", "Yoga and Meditation Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31L, 21L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9404), "A group focusing on yoga, meditation, and mindfulness practices.", "Yoga and Meditation Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32L, 15L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9406), "A group focusing on yoga, meditation, and mindfulness practices.", "Yoga and Meditation Group", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedAt", "Description", "EndDate", "GroupId", "StartDate", "TeacherId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9514), "An introductory lesson covering basic English grammar concepts.", "10:00", 1L, "9:00", 1L, "Introduction to English Grammar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9519), "A beginner-level lesson introducing fundamental Java programming concepts.", "10:00", 2L, "9:00", 2L, "Introduction to Java Programming", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9522), "An introductory lesson covering basic photography techniques and principles.", "10:00", 3L, "9:00", 3L, "Introduction to Photography", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9524), "A lesson focusing on intermediate-level algebraic concepts and problem-solving techniques.", "10:00", 4L, "9:00", 4L, "Intermediate Mathematics: Algebra", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9526), "A lesson introducing Renaissance art and its historical significance.", "10:00", 5L, "9:00", 5L, "Renaissance Art: Introduction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9530), "An advanced lesson covering quantum mechanics and its applications.", "10:00", 6L, "9:00", 6L, "Advanced Physics: Quantum Mechanics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9533), "A beginner-level lesson introducing piano playing techniques and music theory.", "10:00", 7L, "9:00", 7L, "Instrumental Music: Introduction to Piano", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9535), "An introductory lesson covering basic organic chemistry principles and reactions.", "10:00", 8L, "9:00", 8L, "Organic Chemistry: Introduction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9538), "A lesson exploring ancient civilizations and their contributions to world history.", "10:00", 9L, "9:00", 9L, "World History: Ancient Civilizations", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9541), "An introductory lesson covering basic graphic design principles and software tools.", "10:00", 10L, "9:00", 10L, "Introduction to Graphic Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9543), "A beginner-level lesson introducing basic web development concepts and technologies.", "10:00", 11L, "9:00", 11L, "Introduction to Web Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9545), "A beginner-level lesson introducing basic web development concepts and technologies.", "10:00", 12L, "9:00", 12L, "Introduction to Web Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9548), "A beginner-level lesson introducing basic web development concepts and technologies.", "10:00", 13L, "9:00", 13L, "Introduction to Web Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TeacherGroups",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Role", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9831), 1L, (byte)3, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9838), 2L, (byte)3, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9840), 3L, (byte)3, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9842), 4L, (byte)3, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9844), 5L, (byte)3, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9849), 6L, (byte)3, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9850), 7L, (byte)3, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9852), 8L, (byte)3, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9855), 9L, (byte)3, 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9857), 10L, (byte)3, 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9859), 11L, (byte)3, 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9861), 12L, (byte)3, 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9863), 13L, (byte)3, 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9865), 14L, (byte)3, 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9867), 15L, (byte)3, 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9869), 16L, (byte)3, 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9870), 17L, (byte)3, 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9873), 18L, (byte)3, 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9875), 19L, (byte)3, 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9877), 20L, (byte)3, 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9879), 21L, (byte)3, 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9881), 22L, (byte)3, 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9882), 23L, (byte)3, 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9884), 24L, (byte)3, 21L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9885), 25L, (byte)3, 22L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Homeworks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "LessonId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9657), "23:59:59", "Complete the exercises on basic English grammar concepts covered in the lesson.", 1L, "Practice Exercise 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9663), "23:59:59", "Write a short paragraph applying the grammar rules discussed in class.", 1L, "Writing Assignment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9665), "23:59:59", "Write a Java program that demonstrates the use of variables and different data types.", 2L, "Code Exercise: Variables and Data Types", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9667), "23:59:59", "Solve the programming problems provided and submit your solutions.", 2L, "Problem-solving Exercise", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9669), "23:59:59", "Take photographs applying the composition techniques discussed in class.", 3L, "Photo Composition Project", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9673), "23:59:59", "Edit the provided photographs using editing software and submit your edited versions.", 3L, "Editing Exercise", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9675), "23:59:59", "Solve the algebraic problems provided and submit your solutions.", 4L, "Problem-solving Assignment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9677), "23:59:59", "Practice solving algebraic equations of different types.", 4L, "Algebraic Equations Exercise", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9679), "23:59:59", "Analyze a Renaissance artwork of your choice and write an essay.", 5L, "Art Analysis Project", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9686), "23:59:59", "Reproduce a famous Renaissance artwork using your preferred medium.", 5L, "Artwork Reproduction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9688), "23:59:59", "Reproduce a famous Renaissance artwork using your preferred medium.", 8L, "Artwork Reproduction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2024, 4, 30, 22, 7, 31, 634, DateTimeKind.Utc).AddTicks(9690), "23:59:59", "Reproduce a famous Renaissance artwork using your preferred medium.", 8L, "Artwork Reproduction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_SchoolId",
                table: "Admins",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_SuperAdminId",
                table: "Admins",
                column: "SuperAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SchoolId",
                table: "Courses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_SuperAdminId",
                table: "Directors",
                column: "SuperAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAssets_EventId",
                table: "EventAssets",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventId",
                table: "EventRegistrations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_LessonId",
                table: "Grades",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAssets_HomeworkId",
                table: "HomeworkAssets",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_LessonId",
                table: "Homeworks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAttendances_LessonId",
                table: "LessonAttendances",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAttendances_StudentId",
                table: "LessonAttendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupId",
                table: "Lessons",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTables_LessonId",
                table: "LessonTables",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTables_TeacherId",
                table: "LessonTables",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentStudents_ParentId",
                table: "ParentStudents",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentStudents_StudentId",
                table: "ParentStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAssets_QuestionId",
                table: "QuestionAssets",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questiones_LessonId",
                table: "Questiones",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAssets_AdminId",
                table: "SchoolAssets",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAssets_SchoolId",
                table: "SchoolAssets",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolLogoAssets_SchoolId",
                table: "SchoolLogoAssets",
                column: "SchoolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_DirectorId",
                table: "Schools",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SuperAdminId",
                table: "Schools",
                column: "SuperAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAwards_StudentId",
                table: "StudentAwards",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_GroupId",
                table: "StudentGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_StudentId",
                table: "StudentGroups",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LessonId",
                table: "Subjects",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssets_TeacherId",
                table: "TeacherAssets",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAwards_TeacherId",
                table: "TeacherAwards",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherGroups_GroupId",
                table: "TeacherGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherGroups_TeacherId",
                table: "TeacherGroups",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoLessonAssets_LessonId",
                table: "VideoLessonAssets",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "EventAssets");

            migrationBuilder.DropTable(
                name: "EventRegistrations");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "HomeworkAssets");

            migrationBuilder.DropTable(
                name: "LessonAttendances");

            migrationBuilder.DropTable(
                name: "LessonTables");

            migrationBuilder.DropTable(
                name: "ParentStudents");

            migrationBuilder.DropTable(
                name: "QuestionAssets");

            migrationBuilder.DropTable(
                name: "SchoolAssets");

            migrationBuilder.DropTable(
                name: "SchoolLogoAssets");

            migrationBuilder.DropTable(
                name: "StudentAwards");

            migrationBuilder.DropTable(
                name: "StudentGroups");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "TeacherAssets");

            migrationBuilder.DropTable(
                name: "TeacherAwards");

            migrationBuilder.DropTable(
                name: "TeacherGroups");

            migrationBuilder.DropTable(
                name: "VideoLessonAssets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Questiones");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "SuperAdmins");
        }
    }
}
