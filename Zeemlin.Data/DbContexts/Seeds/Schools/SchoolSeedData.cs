﻿using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Enums;

namespace Zeemlin.Data.DbContexts.Seeds.Schools;

public class SchoolSeedData
{
    public static IEnumerable<School> GetSchools()
    {
        yield return new School
        {
            Id = 1,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Inter-Nation",
            Description = "Xalqaro standartlarga asoslangan innovatsion ta'lim muassasasi",
            DirectorId = 1,
            Region = Region.TashkentCity,
            DistrictName = "Mirzo Ulug'bek",
            GeneralAddressMFY = "Uch Qahramon MFY",
            StreetName = "Bog'ishamol ko'chasi",
            CallCenter = "+998900000001",
            EmailCenter = "TXM@school.com",
            Website = "TXM.com",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024,10,13)
        };

        yield return new School
        {
            Id = 2,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Cambridge Edu",
            Description = "Ingliz olami",
            DirectorId = 2, 
            Region = Region.Samarkand,
            DistrictName = "Eskishahar",
            GeneralAddressMFY = "Xo'ja Ahror Vali MFY",
            StreetName = "Registon ko'chasi",
            CallCenter = "+998900000002",
            EmailCenter = "STI@school.com",
            Website = "STI.com",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)

        };

        yield return new School
        {
            Id = 3,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Andijon Pedagogika Instituti",
            Description = "Pedagogika sohasida yuqori malakali mutaxassislar tayyorlaydigan oliy ta'lim muassasasi",
            DirectorId = 3,
            Region = Region.Andijan,
            DistrictName = "Shahriston",
            GeneralAddressMFY = "Pedagogika instituti",
            StreetName = "Pedagogika ko'chasi",
            CallCenter = "+998900000003",
            EmailCenter = "API@school.com",
            Website = "API.com",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

        yield return new School
        {
            Id = 4,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Namangan Davlat Universiteti",
            Description = "Oliy ta'lim sohasida yuqori malakali mutaxassislar tayyorlaydigan davlat universiteti",
            DirectorId = 4,
            Region = Region.Namangan,
            DistrictName = "Namangan shahri",
            GeneralAddressMFY = "Universitet",
            StreetName = "Universitet ko'chasi",
            CallCenter = "+998900000004",
            EmailCenter = "NDU@school.com",
            Website = "NDU.com",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

        yield return new School
        {
            Id = 5,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Tashkent Language Training Center",
            Description = "Center providing language training services.",
            DirectorId = 3,
            Region = Region.Tashkent,
            DistrictName = "Yunusabad",
            GeneralAddressMFY = "Language Training Center",
            StreetName = "Language Street",
            CallCenter = "+998900000013",
            EmailCenter = "info@tltraining.com",
            Website = "https://tltraining.com",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

        yield return new School
        {
            Id = 6,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Samarkand Computer Training Center",
            Description = "Center offering computer training courses.",
            DirectorId = 4,
            Region = Region.Samarkand,
            DistrictName = "Samarqand shahri",
            GeneralAddressMFY = "Computer Training Center",
            StreetName = "Computer Street",
            CallCenter = "+998900000014",
            EmailCenter = "info@sctc.uz",
            Website = "https://sctc.uz",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

        yield return new School
        {
            Id = 7,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Navoiy Fitness Training Center",
            Description = "Fitness center offering various training programs.",
            DirectorId = 1,
            Region = Region.Navoiy,
            DistrictName = "Navoiy shahri",
            GeneralAddressMFY = "Fitness Training Center",
            StreetName = "Fitness Street",
            CallCenter = "+998900000015",
            EmailCenter = "info@navfit.com",
            Website = "https://navfit.com",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

        yield return new School
        {
            Id = 8,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Surxondaryo Photography Training Center",
            Description = "Center specializing in photography training.",
            DirectorId = 2,
            Region = Region.Surxondaryo,
            DistrictName = "Termiz shahri",
            GeneralAddressMFY = "Photography Training Center",
            StreetName = "Photography Street",
            CallCenter = "+998900000016",
            EmailCenter = "info@sptc.uz",
            Website = "https://sptc.uz",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

        yield return new School
        {
            Id = 9,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Tashkent Language Training Center",
            Description = "Center providing language training services.",
            DirectorId = 3,
            Region = Region.Tashkent,
            DistrictName = "Yunusabad",
            GeneralAddressMFY = "Yunusabad MFY",
            StreetName = "Mustaqillik Avenue",
            CallCenter = "+998900000017",
            EmailCenter = "info@tltraining.com",
            Website = "https://tltraining.com",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

        yield return new School
        {
            Id = 10,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.InnovationAndTechnology,
            Name = "Samarkand Computer Training Center",
            Description = "Center offering computer training courses.",
            DirectorId = 4,
            Region = Region.Samarkand,
            DistrictName = "Samarqand shahri",
            GeneralAddressMFY = "Samarqand MFY",
            StreetName = "Amir Temur Street",
            CallCenter = "+998900000018",
            EmailCenter = "info@sctc.uz",
            Website = "https://sctc.uz",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

        yield return new School
        {
            Id = 11,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.PersonalDevelopment,
            Name = "Navoiy Fitness Training Center",
            Description = "Fitness center offering various training programs.",
            DirectorId = 1,
            Region = Region.Navoiy,
            DistrictName = "Navoiy shahri",
            GeneralAddressMFY = "Navoiy MFY",
            StreetName = "Olmazor Street",
            CallCenter = "+998900000019",
            EmailCenter = "info@navfit.com",
            Website = "https://navfit.com",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

        yield return new School
        {
            Id = 12,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Surxondaryo Photography Training Center",
            Description = "Center specializing in photography training.",
            DirectorId = 5,
            Region = Region.Surxondaryo,
            DistrictName = "Termiz shahri",
            GeneralAddressMFY = "Termiz MFY",
            StreetName = "Shaxrisabz Street",
            CallCenter = "+998900000020",
            EmailCenter = "info@sptc.uz",
            Website = "https://sptc.uz",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };
        
        yield return new School
        {
            Id = 13,
            CreatedAt = DateTime.UtcNow,
            SchoolType = EducationType.LanguageLearning,
            Name = "Surxondaryo Photography Training Center",
            Description = "Center specializing in photography training.",
            DirectorId = 5,
            Region = Region.Surxondaryo,
            DistrictName = "Termiz shahri",
            GeneralAddressMFY = "Termiz MFY",
            StreetName = "Shaxrisabz Street",
            CallCenter = "+998900000021",
            EmailCenter = "info@sptc.uz",
            Website = "https://sptc.uz",
            SchoolActivity = SchoolActivity.Active,
            EndDateOfActivity = new DateTime(2024, 10, 13)
        };

    }
}

