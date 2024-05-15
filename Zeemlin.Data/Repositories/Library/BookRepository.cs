using Zeemlin.Data.DbContexts;
using Zeemlin.Data.IRepositries.Library;
using Zeemlin.Domain.Entities.Library;

namespace Zeemlin.Data.Repositories.Library;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
