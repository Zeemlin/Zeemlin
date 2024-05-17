using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Books;

namespace Zeemlin.Service.Interfaces.Books;

public interface IBookService
{
    Task<bool> RemoveAsync(long id);
    Task<BookForResultDto> RetrieveByIdAsync(long id);
    Task<BookForResultDto> AddAsync(BookForCreationDto dto);
    Task<BookForResultDto> ModifyAsync(long id, BookForUpdateDto dto);
    Task<IEnumerable<BookForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
