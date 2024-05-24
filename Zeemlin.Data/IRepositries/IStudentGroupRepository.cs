using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Data.IRepositries;

public interface IStudentGroupRepository : IRepository<StudentGroup>
{
    Task<ICollection<Student>> GetStudentsByGroup(long groupId);
}
