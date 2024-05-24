using Zeemlin.Data.DbContexts;
using Zeemlin.Data.IRepositries;
using Zeemlin.Domain.Entities;

namespace Zeemlin.Data.Repositories;

public class StudentScoreRepository : Repository<StudentScore>, IStudentScoreRepository
{
    public StudentScoreRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
