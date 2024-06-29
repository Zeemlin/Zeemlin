using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries;
using Zeemlin.Data.IRepositries.Assets;
using Zeemlin.Domain.Entities.Assets;
using Zeemlin.Service.Commons.Extentions;
using Zeemlin.Service.Commons.Helpers;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Assets.StudentAwards;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Assets;

namespace Zeemlin.Service.Services.Assets;

public class StudentAwardService : IStudentAwardService
{
    private readonly IMapper _mapper;
    private readonly IStudentAwardRepository _studentAwardRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly long _maxSizeInBytes;
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".heic" };

    public StudentAwardService(
        IMapper mapper,
        IStudentRepository studentRepository,
        IStudentAwardRepository studentAwardRepository)
    {
        _mapper = mapper;
        _maxSizeInBytes = 5 * 1024 * 1024;
        _studentRepository = studentRepository;
        _studentAwardRepository = studentAwardRepository;
    }

    private async Task ValidateImageAsync(IFormFile file)
    {
        if (file.Length > _maxSizeInBytes)
        {
            throw new ZeemlinException(400, "Image size exceeds maximum allowed size.");
        }

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (!_allowedExtensions.Contains(extension))
        {
            throw new ZeemlinException(400, "Invalid image format. Only jpg, jpeg, png, and heic are allowed.");
        }

    }

    public async Task<bool> DeletePictureAsync(long Id)
    {
        var delete = await _studentAwardRepository.SelectAll()
           .Where(u => u.Id == Id)
           .AsNoTracking()
           .FirstOrDefaultAsync();
        if (delete is null)
            throw new ZeemlinException(404, "Award not found");

        await _studentAwardRepository.DeleteAsync(Id);

        return true;
    }

    public async Task<IEnumerable<StudentAwardForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var Awards = await _studentAwardRepository.SelectAll().AsNoTracking().ToPagedList(@params).ToListAsync();

        return _mapper.Map<IEnumerable<StudentAwardForResultDto>>(Awards);
    }

    public async Task<StudentAwardForResultDto> RetrieveByIdAsync(long Id)
    {
        var delete = await _studentAwardRepository.SelectAll()
           .Where(u => u.Id == Id)
           .AsNoTracking()
           .FirstOrDefaultAsync();
        if (delete is null)
            throw new ZeemlinException(404, "Award not found");

        return _mapper.Map<StudentAwardForResultDto>(delete);
    }

    public async Task<StudentAwardForResultDto> UploadAsync(StudentAwardForCreationDto dto)
    {
        var IsValidStudentId = await _studentRepository
            .SelectAll()
            .Where(h => h.Id == dto.StudentId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (IsValidStudentId is null)
            throw new ZeemlinException(404, "Student not found");

        await ValidateImageAsync(dto.Path);
        var WwwRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "StudentAwards");
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Path.FileName);
        var fullPath = Path.Combine(WwwRootPath, fileName);

        using (var stream = File.OpenWrite(fullPath))
        {
            await dto.Path.CopyToAsync(stream);
        }

        string resultImage = Path.Combine("StudentAwards", fileName);

        var mapped = _mapper.Map<StudentAward>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.UploadedDate = DateTime.UtcNow;
        mapped.Path = resultImage;
        await _studentAwardRepository.InsertAsync(mapped);

        return _mapper.Map<StudentAwardForResultDto>(mapped);
    }
}
