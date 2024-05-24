using Zeemlin.Domain.Entities;

namespace Zeemlin.Data.IRepositries;

public interface ILessonAttendanceRepository : IRepository<LessonAttendance>
{
    Task<ICollection<LessonAttendance>> GetStudentAttendancesByGroup(long groupId, long studentId);
}
