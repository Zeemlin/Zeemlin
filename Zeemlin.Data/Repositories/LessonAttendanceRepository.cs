using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.DbContexts;
using Zeemlin.Data.IRepositries;
using Zeemlin.Domain.Entities;

namespace Zeemlin.Data.Repositories
{
    public class LessonAttendanceRepository : Repository<LessonAttendance>, ILessonAttendanceRepository
    {
        public LessonAttendanceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<LessonAttendance>> GetStudentAttendancesByGroup(long groupId, long studentId)
        {
            var attendances = await _dbContext.LessonAttendances
                .Where(a => a.Lesson.Group.Id == groupId && a.StudentId == studentId)
                .ToListAsync();

            return attendances;
        }
    }
}
