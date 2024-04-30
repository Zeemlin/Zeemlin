using Zeemlin.Domain.Enums;
using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Data.DbContexts.Seeds.Users
{
    public class TeacherSeedData
    {
        public static IEnumerable<Teacher> GetTeachers()
        {
            yield return new Teacher
            {
                Id = 1,
                CreatedAt = DateTime.UtcNow,
                Username = "johnny",
                FirstName = "John",
                LastName = "Smith",
                DateOfBirth = "1985.5.15",
                PhoneNumber = "+998900000001",
                Email = "johnsmith@school.com",
                Password = "hashed_password",
                Biography = "Experienced teacher in mathematics.",
                ScienceType = ScienceType.Mathematics,
                genderType = GenderType.Male,
                Region = Region.Tashkent,
                DistrictName = "Mirzo Ulug'bek",
                GeneralAddressMFY = "Main Street",
                StreetName = "Oak Avenue",
                HouseNumber = 12
            };

            yield return new Teacher
            {
                Id = 2,
                CreatedAt = DateTime.UtcNow,
                Username = "janedoe",
                FirstName = "Jane",
                LastName = "Doe",
                DateOfBirth = "1988.8.25",
                PhoneNumber = "+998900000002",
                Email = "janedoe@school.com",
                Password = "hashed_password",
                Biography = "Passionate teacher specializing in history.",
                ScienceType = ScienceType.History,
                genderType = GenderType.Female,
                Region = Region.Andijan,
                DistrictName = "Andijan City",
                GeneralAddressMFY = "Downtown",
                StreetName = "Maple Street",
                HouseNumber = 20
            };

            yield return new Teacher
            {
                Id = 3,
                CreatedAt = DateTime.UtcNow,
                Username = "michaelj",
                FirstName = "Michael",
                LastName = "Johnson",
                DateOfBirth = "1980.1.10",
                PhoneNumber = "+998900000003",
                Email = "michaeljohnson@school.com",
                Password = "hashed_password",
                Biography = "Dedicated teacher with expertise in geography.",
                ScienceType = ScienceType.Geography,
                genderType = GenderType.Male,
                Region = Region.Fergana,
                DistrictName = "Fergana City",
                GeneralAddressMFY = "Central Avenue",
                StreetName = "Pine Street",
                HouseNumber = 8
            };

            yield return new Teacher
            {
                Id = 4,
                CreatedAt = DateTime.UtcNow,
                Username = "umid.y",
                FirstName = "Umid",
                LastName = "Yo'ldoshev",
                DateOfBirth = "1980.1.1",
                PhoneNumber = "+998901234567",
                Email = "umid.yoldoshev@school1.com",
                Password = "hashed_password",
                Biography = "Experienced Mathematics teacher with 10+ years of experience.",
                ScienceType = ScienceType.Mathematics,
                genderType = GenderType.Male,
                Region = Region.Samarkand,
                DistrictName = "Samarkand City",
                GeneralAddressMFY = "Broadway",
                StreetName = "Cedar Street",
                HouseNumber = 15
            };

            yield return new Teacher
            {
                Id = 5,
                CreatedAt = DateTime.UtcNow,
                Username = "sara.b",
                FirstName = "Sara",
                LastName = "Brown",
                DateOfBirth = "1990.2.1",
                PhoneNumber = "+998904567890",
                Email = "sarabrown@school.com",
                Password = "hashed_password",
                Biography = "Enthusiastic teacher with a passion for English language learning.",
                ScienceType = ScienceType.EnglishLanguage,
                genderType = GenderType.Female,
                Region = Region.Namangan,
                DistrictName = "Namangan City",
                GeneralAddressMFY = "Park Avenue",
                StreetName = "Elm Street",
                HouseNumber = 24
            };

            yield return new Teacher
            {
                Id = 6,
                CreatedAt = DateTime.UtcNow,
                Username = "kim.h",
                FirstName = "Kim",
                LastName = "Han",
                DateOfBirth = "1987.12.31",
                PhoneNumber = "+998908901234",
                Email = "kimhan@school.com",
                Password = "hashed_password",
                Biography = "Highly qualified teacher for Korean language courses.",
                ScienceType = ScienceType.KoreanLanguage,
                genderType = GenderType.Female,
                Region = Region.TashkentCity,
                DistrictName = "Yangihayot",
                GeneralAddressMFY = "University District",
                StreetName = "Willow Street",
                HouseNumber = 30
            };

            yield return new Teacher
            {
                Id = 7,
                CreatedAt = DateTime.UtcNow,
                Username = "peter.g",
                FirstName = "Peter",
                LastName = "Garcia",
                DateOfBirth = "1978.9.22",
                PhoneNumber = "+998907890123",
                Email = "petergarcia@school.com",
                Password = "hashed_password",
                Biography = "Experienced teacher for Spanish language courses.",
                ScienceType = ScienceType.KoreanLanguage,
                genderType = GenderType.Male,
                Region = Region.Surxondaryo,
                DistrictName = "Termez",
                GeneralAddressMFY = "Old Town",
                StreetName = "Birch Street",
                HouseNumber = 18
            };

            yield return new Teacher
            {
                Id = 8,
                CreatedAt = DateTime.UtcNow,
                Username = "alexei.v",
                FirstName = "Alexei",
                LastName = "Volkov",
                DateOfBirth = "1982.6.14",
                PhoneNumber = "+998909876543",
                Email = "alexeivolkov@school.com",
                Password = "hashed_password",
                Biography = "Dedicated teacher for Russian language instruction.",
                ScienceType = ScienceType.RussianLanguage,
                genderType = GenderType.Male,
                Region = Region.Navoiy,
                DistrictName = "Navoiy City",
                GeneralAddressMFY = "Industrial District",
                StreetName = "Poplar Street",
                HouseNumber = 42
            };

            yield return new Teacher
            {
                Id = 9,
                CreatedAt = DateTime.UtcNow,
                Username = "fatima.a",
                FirstName = "Fatima",
                LastName = "Abdullayeva",
                DateOfBirth = "1992.3.8",
                PhoneNumber = "+998901239876",
                Email = "fatima.abdullayeva@school.com",
                Password = "hashed_password",
                Biography = "Skilled teacher specializing in Uzbek language and literature.",
                ScienceType = ScienceType.UzbekLanguage,
                genderType = GenderType.Female,
                Region = Region.Kashkadarya,
                DistrictName = "Karshi City",
                GeneralAddressMFY = "City Center",
                StreetName = "Ash Street",
                HouseNumber = 55
            };

            yield return new Teacher
            {
                Id = 10,
                CreatedAt = DateTime.UtcNow,
                Username = "emmanuel.b",
                FirstName = "Emmanuel",
                LastName = "Blanc",
                DateOfBirth = "1989.11.17",
                PhoneNumber = "+998905678901",
                Email = "emmanuelblanc@school.com",
                Password = "hashed_password",
                Biography = "Energetic teacher with a passion for French language and culture.",
                ScienceType = ScienceType.FrenchLanguage,
                genderType = GenderType.Male,
                Region = Region.Jizzakh,
                DistrictName = "Jizzakh City",
                GeneralAddressMFY = "New City",
                StreetName = "Beech Street",
                HouseNumber = 37
            };

            yield return new Teacher
            {
                Id = 11,
                CreatedAt = DateTime.UtcNow,
                Username = "ayesha.k",
                FirstName = "Ayesha",
                LastName = "Khan",
                DateOfBirth = "1995.7.10",
                PhoneNumber = "+998902345678",
                Email = "ayeshakhan@school.com",
                Password = "hashed_password",
                Biography = "Enthusiastic teacher dedicated to Biology education.",
                ScienceType = ScienceType.Biology,
                genderType = GenderType.Female,
                Region = Region.Syrdarya,
                DistrictName = "Gulistan",
                GeneralAddressMFY = "University Area",
                StreetName = "Maple Street",
                HouseNumber = 11
            };

            yield return new Teacher
            {
                Id = 12,
                CreatedAt = DateTime.UtcNow,
                Username = "david.l",
                FirstName = "David",
                LastName = "Lee",
                DateOfBirth = "1983.4.25",
                PhoneNumber = "+9989098765432",
                Email = "davidlee@school.com",
                Password = "hashed_password",
                Biography = "Experienced teacher for Chemistry courses.",
                ScienceType = ScienceType.Chemistry,
                genderType = GenderType.Male,
                Region = Region.Khorezm,
                DistrictName = "Khiva",
                GeneralAddressMFY = "Historic Center",
                StreetName = "Elm Street",
                HouseNumber = 29
            };

            yield return new Teacher
            {
                Id = 13,
                CreatedAt = DateTime.UtcNow,
                Username = "maria.g",
                FirstName = "Maria",
                LastName = "Garcia",
                DateOfBirth = "1990.10.21",
                PhoneNumber = "+9989087654321",
                Email = "mariagarcia@school.com",
                Password = "hashed_password",
                Biography = "Skilled teacher for Physics instruction.",
                ScienceType = ScienceType.Physics,
                genderType = GenderType.Female,
                Region = Region.Kashkadarya,
                DistrictName = "Shahrisabz",
                GeneralAddressMFY = "Old Town",
                StreetName = "Birch Street",
                HouseNumber = 61
            };

            yield return new Teacher
            {
                Id = 14,
                CreatedAt = DateTime.UtcNow,
                Username = "omar.s",
                FirstName = "Omar",
                LastName = "Syed",
                DateOfBirth = "1986.5.12",
                PhoneNumber = "+998906789012",
                Email = "omarsyed@school.com",
                Password = "hashed_password",
                Biography = "Dedicated teacher passionate about World History.",
                ScienceType = ScienceType.History,
                genderType = GenderType.Male,
                Region = Region.Bukhara,
                DistrictName = "Bukhara City",
                GeneralAddressMFY = "City Center",
                StreetName = "Ash Street",
                HouseNumber = 74
            };

            yield return new Teacher
            {
                Id = 15,
                CreatedAt = DateTime.UtcNow,
                Username = "malika.a",
                FirstName = "Malika",
                LastName = "Azizova",
                DateOfBirth = "2000.2.29",
                PhoneNumber = "+998901239876",
                Email = "malika.azizova@school4.com",
                Password = "hashed_password",
                Biography = "Skilled Uzbek language teacher passionate about preserving cultural heritage.",
                ScienceType = ScienceType.UzbekLanguage,
                genderType = GenderType.Female,
                Region = Region.Namangan,
                DistrictName = "Namangan City",
                GeneralAddressMFY = "North Street",
                StreetName = "Maple Avenue",
                HouseNumber = 28
            };

            yield return new Teacher
            {
                Id = 16,
                CreatedAt = DateTime.UtcNow,
                Username = "emmap",
                FirstName = "Emma",
                LastName = "Perez",
                DateOfBirth = "1994.6.29",
                PhoneNumber = "+998900000016",
                Email = "emmaperez@school.com",
                Password = "hashed_password",
                Biography = "Experienced teacher specializing in geography.",
                ScienceType = ScienceType.Geography,
                genderType = GenderType.Female,
                Region = Region.Bukhara,
                DistrictName = "Bukhara City",
                GeneralAddressMFY = "West Street",
                StreetName = "Elm Street",
                HouseNumber = 5
            };

            yield return new Teacher
            {
                Id = 17,
                CreatedAt = DateTime.UtcNow,
                Username = "lucas.n",
                FirstName = "Lucas",
                LastName = "Nguyen",
                DateOfBirth = "1992.8.16",
                PhoneNumber = "+998900000017",
                Email = "lucasnguyen@school.com",
                Password = "hashed_password",
                Biography = "Passionate teacher with expertise in biology.",
                ScienceType = ScienceType.Biology,
                genderType = GenderType.Male,
                Region = Region.Khorezm,
                DistrictName = "Khiva",
                GeneralAddressMFY = "South Street",
                StreetName = "Willow Avenue",
                HouseNumber = 10
            };

            yield return new Teacher
            {
                Id = 18,
                CreatedAt = DateTime.UtcNow,
                Username = "lily.g",
                FirstName = "Lily",
                LastName = "Gonzalez",
                DateOfBirth = "1993.10.4",
                PhoneNumber = "+998900000018",
                Email = "lilygonzalez@school.com",
                Password = "hashed_password",
                Biography = "Dedicated teacher with a passion for music.",
                ScienceType = ScienceType.Music,
                genderType = GenderType.Female,
                Region = Region.TashkentCity,
                DistrictName = "Chilonzor",
                GeneralAddressMFY = "East Street",
                StreetName = "Poplar Avenue",
                HouseNumber = 20
            };

            yield return new Teacher
            {
                Id = 19,
                CreatedAt = DateTime.UtcNow,
                Username = "jackson.a",
                FirstName = "Jackson",
                LastName = "Adams",
                DateOfBirth = "1993.10.4",
                PhoneNumber = "+998900000019",
                Email = "jacksonadams@school.com",
                Password = "hashed_password",
                Biography = "Experienced mathematics teacher.",
                ScienceType = ScienceType.Mathematics,
                genderType = GenderType.Male,
                Region = Region.Andijan,
                DistrictName = "Andijan City",
                GeneralAddressMFY = "Central Street",
                StreetName = "Birch Avenue",
                HouseNumber = 36
            };

            yield return new Teacher
            {
                Id = 20,
                CreatedAt = DateTime.UtcNow,
                Username = "elena.p",
                FirstName = "Elena",
                LastName = "Petrova",
                DateOfBirth = "1975.12.24",
                PhoneNumber = "+998903456789",
                Email = "elenapetrova@school.com",
                Password = "hashed_password",
                Biography = "Experienced teacher with a strong background in Literature.",
                ScienceType = ScienceType.HistoryOfUzbekistan,
                genderType = GenderType.Female,
                Region = Region.Surxondaryo,
                DistrictName = "Denau",
                GeneralAddressMFY = "Central District",
                StreetName = "Oak Avenue",
                HouseNumber = 9
            };

            yield return new Teacher
            {
                Id = 21,
                CreatedAt = DateTime.UtcNow,
                Username = "ibrahim.a",
                FirstName = "Ibrahim",
                LastName = "Aliyev",
                DateOfBirth = "1988.3.3",
                PhoneNumber = "+9989098765431",
                Email = "ibrahimaliyev@school.com",
                Password = "hashed_password",
                Biography = "Enthusiastic teacher specializing in Information Technology.",
                ScienceType = ScienceType.InformationTechnology,
                genderType = GenderType.Male,
                Region = Region.Namangan,
                DistrictName = "Namangan City",
                GeneralAddressMFY = "Eastern District",
                StreetName = "Willow Street",
                HouseNumber = 46
            };

            yield return new Teacher
            {
                Id = 22,
                CreatedAt = DateTime.UtcNow,
                Username = "dilshod.r",
                FirstName = "Dilshod",
                LastName = "Rakhmatov",
                DateOfBirth = "1991.8.19",
                PhoneNumber = "+9989087654320",
                Email = "dilshodrakhmatov@school.com",
                Password = "hashed_password",
                Biography = "Dedicated teacher passionate about teaching Algebra.",
                ScienceType = ScienceType.Mathematics, // Assuming Algebra falls under Mathematics
                genderType = GenderType.Male,
                Region = Region.Fergana,
                DistrictName = "Fergana City",
                GeneralAddressMFY = "Western District",
                StreetName = "Maple Street",
                HouseNumber = 23
            };

            yield return new Teacher
            {
                Id = 23,
                CreatedAt = DateTime.UtcNow,
                Username = "chloe.w",
                FirstName = "Chloe",
                LastName = "Wang",
                DateOfBirth = "1994.1.7",
                PhoneNumber = "+9989078901234",
                Email = "chloewang@school.com",
                Password = "hashed_password",
                Biography = "Skilled teacher for Russin language courses.",
                ScienceType = ScienceType.RussianLanguage,
                genderType = GenderType.Female,
                Region = Region.Tashkent,
                DistrictName = "Uchteppa",
                GeneralAddressMFY = "University District",
                StreetName = "Birch Street",
                HouseNumber = 82
            };

            yield return new Teacher
            {
                Id = 24,
                CreatedAt = DateTime.UtcNow,
                Username = "ali.m",
                FirstName = "Ali",
                LastName = "Mohammed",
                DateOfBirth = "1982.9.14",
                PhoneNumber = "+9989067890123",
                Email = "alimohammed@school.com",
                Password = "hashed_password",
                Biography = "Experienced teacher with a strong background in Islamic Studies.",
                ScienceType = ScienceType.Music,
                genderType = GenderType.Male,
                Region = Region.Samarkand,
                DistrictName = "Samarkand City",
                GeneralAddressMFY = "Old City",
                StreetName = "Ash Street",
                HouseNumber = 100
            };

            yield return new Teacher
            {
                Id = 25,
                CreatedAt = DateTime.UtcNow,
                Username = "harper.t",
                FirstName = "Harper",
                LastName = "Thompson",
                DateOfBirth = "1993.10.4",
                PhoneNumber = "+998900000025",
                Email = "harperthompson@school.com",
                Password = "hashed_password",
                Biography = "Passionate teacher specializing in information technology.",
                ScienceType = ScienceType.InformationTechnology,
                genderType = GenderType.Female,
                Region = Region.Samarkand,
                DistrictName = "Samarkand City",
                GeneralAddressMFY = "East Street",
                StreetName = "Cedar Avenue",
                HouseNumber = 42
            };

        }
    }
}
