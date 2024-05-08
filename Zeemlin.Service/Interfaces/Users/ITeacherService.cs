using Zeemlin.Domain.Enums;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Users.Teachers;

namespace Zeemlin.Service.Interfaces.Users;

public interface ITeacherService
{
    Task<bool> RemoveAsync(long id);
    Task<TeacherForResultDto> RetrieveByIdAsync(long id);
    Task<TeacherForResultDto> CreateAsync(TeacherForCreationDto dto);
    // Shu guruh uchun dars o'tadigan ustozlarni qaytaradi
    Task<IEnumerable<TeacherForResultDto>> GetTeachersAsync(long groupId);
    Task<TeacherForResultDto> ModifyAsync(long id, TeacherForUpdateDto dto);
    // Teacherning address ma'lumotlarini yangilash uchun method
    Task<TeacherForResultDto> TeacherAddressUpdate(long id, TeacherAddressForUpdateDto dto);

    // Maktabdagi barcha ustozlarni qaytarish uchun method
    Task<IEnumerable<TeacherForResultDto>> GetTeachersBySchoolAsync(long schoolId);
    Task<IEnumerable<TeacherForResultDto>> RetrieveAllAsync(PaginationParams @params);

    // Admin uchun: maktabdagi ustozlarni username bo'yicha qidirish
    Task<IEnumerable<TeacherSearchResultDto>> SearchByUsernameAsync(string searchTerm, long currentSchoolId); 
    // Admin uchun: Ustozlarni filtrlab olish, fan bo'yicha
    Task<IEnumerable<FilteredTeacherDTO>> GetFilteredTeachers(ScienceType? scienceType = null, long schoolId = 0);
}
