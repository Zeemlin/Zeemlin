using Zeemlin.Data.DbContexts;
using Zeemlin.Data.IRepositries.Assets;
using Zeemlin.Domain.Entities.Assets;

namespace Zeemlin.Data.Repositories.Assets;

public class TeacherAwardRepository : Repository<TeacherAward>, ITeacherAwardRepository
{
    public TeacherAwardRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
