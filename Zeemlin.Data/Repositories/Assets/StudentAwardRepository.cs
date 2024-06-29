using Zeemlin.Data.DbContexts;
using Zeemlin.Data.IRepositries.Assets;
using Zeemlin.Domain.Entities.Assets;

namespace Zeemlin.Data.Repositories.Assets;

public class StudentAwardRepository : Repository<StudentAward>, IStudentAwardRepository
{
    public StudentAwardRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
