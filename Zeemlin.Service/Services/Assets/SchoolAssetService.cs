﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries;
using Zeemlin.Data.IRepositries.Assets;
using Zeemlin.Data.IRepositries.Users;
using Zeemlin.Domain.Entities;
using Zeemlin.Domain.Entities.Assets;
using Zeemlin.Domain.Enums;
using Zeemlin.Service.Commons.Helpers;
using Zeemlin.Service.DTOs.Assets.SchoolAssets;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Assets;

namespace Zeemlin.Service.Services.Assets;

public class SchoolAssetService : ISchoolAssetService
{
    private readonly IMapper _mapper;
    private readonly ISchoolAssetRepository _repository;
    private readonly ISchoolRepository _schoolRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly long _maxSizeInBytes;
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".heic" };

    public SchoolAssetService(
        IMapper mapper,
        ISchoolAssetRepository repository,
        ISchoolRepository schoolRepository,
        IAdminRepository adminRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _maxSizeInBytes = 10 * 1024 * 1024;
        _schoolRepository = schoolRepository;
        _adminRepository = adminRepository;
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
            throw new ZeemlinException(400, "Invalid image format. Only jpg, jpeg, png and heic are allowed.");
        }

    }
    public async Task<bool> DeletePictureAsync(long Id)
    {
        var delete = await _repository.SelectAll()
           .AsNoTracking()
           .Where(u => u.Id == Id)
           .FirstOrDefaultAsync();
        if (delete is null)
            throw new ZeemlinException(404, "Education photo not found");

        await _repository.DeleteAsync(Id);

        return true;
    }

    public async Task<IEnumerable<SchoolAssetForResultDto>> RetrieveAllAsync()
    {
        var assets = await _repository.SelectAll().AsNoTracking().ToListAsync();

        return _mapper.Map<IEnumerable<SchoolAssetForResultDto>>(assets);
    }

    public async Task<SchoolAssetForResultDto> RetrieveByIdAsync(long Id)
    {
        var update = await _repository.SelectAll()
           .AsNoTracking()
           .Where(u => u.Id == Id)
           .FirstOrDefaultAsync();
        if (update is null)
            throw new ZeemlinException(404, "Education photo not found");

        return _mapper.Map<SchoolAssetForResultDto>(update);
    }

    public async Task<SchoolAssetForResultDto> UploadAsync(SchoolAssetForCreationDto dto)
    {
        var IsValidSchoolId = await _schoolRepository
            .SelectAll()
            .Where(h => h.Id == dto.SchoolId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (IsValidSchoolId is null)
            throw new ZeemlinException(404, "Education not found");

        if (IsValidSchoolId.SchoolActivity != SchoolActivity.Active)
            throw new ZeemlinException(403, $"{IsValidSchoolId.Name} is temporarily inactive and cannot upload a photo.");

        var IsValidAdminId = await _adminRepository
           .SelectAll()
           .Where(h => h.Id == dto.AdminId)
           .AsNoTracking()
           .FirstOrDefaultAsync();

        if (IsValidAdminId is null)
            throw new ZeemlinException(404, "Admin not found");

        await ValidateImageAsync(dto.Path);
        var WwwRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "SchoolAssets");
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Path.FileName);
        var fullPath = Path.Combine(WwwRootPath, fileName);

        using (var stream = File.OpenWrite(fullPath))
        {
            await dto.Path.CopyToAsync(stream);
        }

        string resultImage = Path.Combine("SchoolAssets", fileName);

        var mapped = _mapper.Map<SchoolAsset>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.UploadedDate = DateTime.UtcNow;
        mapped.Path = resultImage;
        await _repository.InsertAsync(mapped);

        return _mapper.Map<SchoolAssetForResultDto>(mapped);
    }
}
