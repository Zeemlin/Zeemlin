using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries;
using Zeemlin.Data.IRepositries.Assets;
using Zeemlin.Domain.Entities.Assets;
using Zeemlin.Service.Commons.Extentions;
using Zeemlin.Service.Commons.Helpers;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Assets.TeacherAwards;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Assets;

namespace Zeemlin.Service.Services.Assets;

public class TeacherAwardService : ITeacherAwardService
{
    private readonly IMapper _mapper;
    private readonly ITeacherAwardRepository _repository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly long _maxSizeInBytes;
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".heic" };

    public TeacherAwardService(IMapper mapper,
        ITeacherAwardRepository repository,
        ITeacherRepository teacherRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _maxSizeInBytes = 5 * 1024 * 1024;
        _teacherRepository = teacherRepository;
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
        var delete = await _repository.SelectAll()
           .Where(u => u.Id == Id)
           .AsNoTracking()
           .FirstOrDefaultAsync();
        if (delete is null)
            throw new ZeemlinException(404, "Award not found");

        await _repository.DeleteAsync(Id);

        return true;
    }

    public async Task<IEnumerable<TeacherAwardForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var Awards = await _repository.SelectAll().AsNoTracking().ToPagedList(@params).ToListAsync();

        return _mapper.Map<IEnumerable<TeacherAwardForResultDto>>(Awards);
    }

    public async Task<TeacherAwardForResultDto> RetrieveByIdAsync(long Id)
    {
        var delete = await _repository.SelectAll()
           .Where(u => u.Id == Id)
           .AsNoTracking()
           .FirstOrDefaultAsync();
        if (delete is null)
            throw new ZeemlinException(404, "Award not found");

        return _mapper.Map<TeacherAwardForResultDto>(delete);
    }

    public async Task<TeacherAwardForResultDto> UploadAsync(TeacherAwardForCreationDto dto)
    {
        var isValidTeacherId = await _teacherRepository.SelectAll()
            .Where(t => t.Id == dto.TeacherId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (isValidTeacherId is null)
            throw new ZeemlinException(404, "Teacher not found");

        await ValidateImageAsync(dto.Path);
        var WwwRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "TeacherAwards");
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Path.FileName);
        var fullPath = Path.Combine(WwwRootPath, fileName);

        using (var stream = File.OpenWrite(fullPath))
        {
            await dto.Path.CopyToAsync(stream);
        }

        string resultImage = Path.Combine("TeacherAwards", fileName);

        var mapped = _mapper.Map<TeacherAward>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.UploadedDate = DateTime.UtcNow;
        mapped.Path = resultImage;

        await _repository.InsertAsync(mapped);

        return _mapper.Map<TeacherAwardForResultDto>(mapped);
    }
}
