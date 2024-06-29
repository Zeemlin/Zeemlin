using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.DbContexts;
using Zeemlin.Data.IRepositries;
using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Data.Repositories;

public class StudentGroupRepository : Repository<StudentGroup>, IStudentGroupRepository
{
    public StudentGroupRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ICollection<Student>> GetStudentsByGroup(long groupId)
    {
        return await _dbContext.StudentGroups
            .Include(sg => sg.Student)
            .ThenInclude(s => s.StudentScores)
            .ThenInclude(ss => ss.Lesson)
            .ThenInclude(l => l.Group)
            .Where(sg => sg.GroupId == groupId)
            .Select(sg => sg.Student)
            .ToListAsync();
    }

}
