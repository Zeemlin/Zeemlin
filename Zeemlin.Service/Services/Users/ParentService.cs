﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries.Users;
using Zeemlin.Domain.Entities.Users;
using Zeemlin.Service.Commons.Extentions;
using Zeemlin.Service.Commons.Helpers;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Users.Parents;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Users;

namespace Zeemlin.Service.Services.Users;

public class ParentService : IParentService
{
    private readonly IMapper _mapper;
    private readonly IParentRepository _parentRepository;

    public ParentService(IMapper mapper, IParentRepository parentRepository)
    {
        _mapper = mapper;
        _parentRepository = parentRepository;
    }

    private async Task<bool> IsEmailOrPhoneInUseAsync(string email, string phoneNumber, short houseNumber)
    {
        var existingPhoneNumber = await _parentRepository
            .SelectAll()
            .Where(p => p.PhoneNumber == phoneNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingPhoneNumber is not null)
            throw new ZeemlinException(409, "Phone number already exists");

        var existingEmail = await _parentRepository
            .SelectAll()
            .Where(p => p.Email == email)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingEmail is not null)
            throw new ZeemlinException(409, "Email already exists");

        if (houseNumber <= 0)
            throw new ZeemlinException(400, "House number cannot be less than or equal to zero. \n INVALID_HOUSE_NUMBER");

        return false;
    }


    public async Task<ParentForResultDto> CreateAsync(ParentForCreationDto dto)
    {
        await IsEmailOrPhoneInUseAsync(dto.Email, dto.PhoneNumber, dto.HouseNumber);

        var hasherResult = PasswordHelper.Hash(dto.Password);
        var mapped = _mapper.Map<Parent>(dto);
        mapped.Salt = hasherResult.Salt;
        mapped.Password = hasherResult.Hash;
        mapped.CreatedAt = DateTime.UtcNow;
        var created = await _parentRepository.InsertAsync(mapped);

        return _mapper.Map<ParentForResultDto>(created);
    }

    public async Task<ParentForResultDto> ModifyAsync(long id, ParentForUpdateDto dto)
    {
        var isValidId = await _parentRepository
            .SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (isValidId is null)
            throw new ZeemlinException(404, "Not found");

        var existingPhoneNumber = await _parentRepository
            .SelectAll()
            .Where(p => p.PhoneNumber == dto.PhoneNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingPhoneNumber is not null)
            throw new ZeemlinException(409, "Phone number already exists");

        var existingEmail = await _parentRepository
            .SelectAll()
            .Where(p => p.Email == dto.Email)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingEmail is not null)
            throw new ZeemlinException(409, "Email already exists");

        var modify = _mapper.Map(dto, isValidId);
        modify.UpdatedAt = DateTime.UtcNow;
        await _parentRepository.UpdateAsync(modify);

        return _mapper.Map<ParentForResultDto>(modify);
    }

    public async Task<bool> ChangePasswordAsync(string email, ParentForChangePasswordDto dto)
    {
        var user = await _parentRepository.SelectAll()
            .Where(u => u.Email == email)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null || !PasswordHelper.Verify(dto.OldPassword, user.Salt, user.Password))
            throw new ZeemlinException(404, "User or Password is incorrect");
        else if (dto.NewPassword != dto.ConfirmPassword)
            throw new ZeemlinException(400, "New password and confirm password aren't equal");

        var hash = PasswordHelper.Hash(dto.ConfirmPassword);
        user.Salt = hash.Salt;
        user.Password = hash.Hash;
        var updated = await _parentRepository.UpdateAsync(user);

        return true;
    }

    public async Task<ParentForResultDto> ParentAddressUpdate(long id, ParentAddressForUpdateDto dto)
    {
        var parent = await _parentRepository
            .SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (parent is null)
            throw new ZeemlinException(404, "Parent not found.");

        if (dto.HouseNumber <= 0)
            throw new ZeemlinException(400, "House number cannot be less than or equal to zero. \n INVALID_HOUSE_NUMBER");

        var modify = _mapper.Map(dto, parent);
        modify.UpdatedAt = DateTime.UtcNow;
        await _parentRepository.UpdateAsync(modify);

        return _mapper.Map<ParentForResultDto>(parent);
    }


    public async Task<bool> RemoveAsync(long id)
    {
        var isValidId = await _parentRepository
            .SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (isValidId is null)
            throw new ZeemlinException(404, "Not found");

        await _parentRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<ParentForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var parents = await _parentRepository.SelectAll().AsNoTracking().ToPagedList(@params).ToListAsync();

        return _mapper.Map<IEnumerable<ParentForResultDto>>(parents);
    }

    public async Task<ParentForResultDto> RetrieveByIdAsync(long id)
    {
        var isValidId = await _parentRepository
            .SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (isValidId is null)
            throw new ZeemlinException(404, "Not found");

        return _mapper.Map<ParentForResultDto>(isValidId);
    }
}
