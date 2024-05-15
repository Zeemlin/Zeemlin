using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries;
using Zeemlin.Data.IRepositries.Library;
using Zeemlin.Domain.Entities.Library;
using Zeemlin.Domain.Enums;
using Zeemlin.Service.Commons.Helpers;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Books;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Books;

namespace Zeemlin.Service.Services.Books;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly ISchoolRepository _schoolRepository;
    private readonly string[] _allowedExtensions = { ".pdf", ".epub", ".docx" }; // kitob uchun support qiluvchi extensionlar
    private readonly string[] _allowedImageExtensions = { ".jpg", ".jpeg", ".png" }; // kitob muqovasi uchun rasm yuklanadi, shu rasmni support qiluvchi extensionlar
    private readonly long _maxSizeInBytes;

    public BookService(
        IMapper mapper, 
        IBookRepository bookRepository, 
        ITeacherRepository teacherRepository, 
        ISchoolRepository schoolRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _teacherRepository = teacherRepository;
        _schoolRepository = schoolRepository;
        _maxSizeInBytes = 20 * 1024 * 1024; // kitob 20MBdan oshmasligi kerak
    }

    private async Task ValidateBookAsync(IFormFile file)
    {
        if (file.Length > _maxSizeInBytes)
        {
            throw new ZeemlinException(400, "Book size exceeds maximum allowed size.");
        }

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (!_allowedExtensions.Contains(extension))
        {
            throw new ZeemlinException(400, "Invalid image format. Only pdf, epub and docx  are allowed.");
        }

    }

    private async Task ValidatePhotoAsync(IFormFile file)
    {
        if (file == null || file.Length == 0) // Check if photo is uploaded
        {
            return; // No photo uploaded, skip validation
        }

        if (file.Length > 5 * 1024 * 1024) // Adjust max size for photos as needed (here, 5MB)
        {
            throw new ZeemlinException(400, "Book photo size exceeds maximum allowed size.");
        }

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (!_allowedImageExtensions.Contains(extension))
        {
            throw new ZeemlinException(400, "Invalid book photo format. Only jpg, jpeg and png are allowed.");
        }
    }

    public async Task<BookForResultDto> AddAsync(BookForCreationDto dto)
    {
        var school = await _schoolRepository.SelectAll()
          .Include(s => s.Books)
          .Where(s => s.Id == dto.SchoolId)
          .AsNoTracking()
          .FirstOrDefaultAsync(); ;

        if (school is null)
            throw new ZeemlinException(404, "School not found");

        if (school.SchoolActivity != SchoolActivity.Active)
            throw new ZeemlinException(403, $"{school.Name} is temporarily inactive and cannot upload a book.");

        var teacher = await _teacherRepository.SelectAll()
            .Where(s => s.Id == dto.TeacherId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (teacher is null)
            throw new ZeemlinException(404, "Teacher not found");

        await ValidateBookAsync(dto.PdfUrl);
        await ValidatePhotoAsync(dto.BookPhotoUrl);

        var WwwRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Books");
        var pdffile = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.PdfUrl.FileName);
        var photofile = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.BookPhotoUrl.FileName);
        var fullPath = Path.Combine(WwwRootPath, pdffile, photofile);

        using (var stream = File.OpenWrite(fullPath))
        {
            await dto.PdfUrl.CopyToAsync(stream);
            await dto.BookPhotoUrl.CopyToAsync(stream);
        }

        string resultImage = Path.Combine("Books", photofile, pdffile);

        var mapped = _mapper.Map<Book>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.UploadDate = DateTime.UtcNow;
        mapped.BookPhotoUrl = resultImage;
        mapped.Size = dto.PdfUrl.Length;
        mapped.ContentType = dto.PdfUrl.ContentType;
        // await _bookRepository.InsertAsync(mapped);
        throw new NotImplementedException();
    }

    public Task<BookForResultDto> ModifyAsync(long id, BookForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<BookForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
