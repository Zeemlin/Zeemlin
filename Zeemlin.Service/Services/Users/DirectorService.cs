using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries.Users;
using Zeemlin.Domain.Entities.Users;
using Zeemlin.Service.Commons.Extentions;
using Zeemlin.Service.Commons.Helpers;
using Zeemlin.Service.Configurations;
using Zeemlin.Service.DTOs.Schools;
using Zeemlin.Service.DTOs.Users.Directors;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Users;

namespace Zeemlin.Service.Services.Users;

public class DirectorService : IDirectorService
{
    private readonly IMapper _mapper;
    private readonly IDirectorRepository _repository;

    public DirectorService(IMapper mapper, IDirectorRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DirectorForResultDto> CreateAsync(DirectorForCreationDto dto)
    {
        var IsValidUsername = await _repository
           .SelectAll()
           .AsNoTracking()
           .Where(u => u.Username.ToLower() == dto.Username.ToLower())
           .FirstOrDefaultAsync();

        if (IsValidUsername is not null)
            throw new ZeemlinException(409, "Username already exists");

        var IsValidUserEmail = await _repository
            .SelectAll()
            .AsNoTracking()
            .Where(u => u.Email.ToLower() == dto.Email.ToLower())
            .FirstOrDefaultAsync();

        if (IsValidUserEmail is not null)
            throw new ZeemlinException(409, "Email already exists");

        var IsValidUserPhoneNumber = await _repository
            .SelectAll()
            .AsNoTracking()
            .Where(u => u.PhoneNumber == dto.PhoneNumber)
            .FirstOrDefaultAsync();

        if (IsValidUserPhoneNumber is not null)
            throw new ZeemlinException(409, "Phone number already exists");

        var IsValidPassportSeria = await _repository
            .SelectAll()
            .AsNoTracking()
            .Where(u => u.PassportSeria == dto.PassportSeria)
            .FirstOrDefaultAsync();

        if (IsValidPassportSeria is not null)
            throw new ZeemlinException(409, "PassportSeria already exists");

        var mapped = _mapper.Map<Director>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        await _repository.InsertAsync(mapped);

        return _mapper.Map<DirectorForResultDto>(mapped);
    }

    public async Task<DirectorForResultDto> ModifyAsync(long id, DirectorForUpdateDto dto)
    {
        var IsValidId = await _repository
            .SelectAll().AsNoTracking()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (IsValidId is null)
            throw new ZeemlinException(404, "Not Found");

        var IsValidUsername = await _repository
           .SelectAll()
           .AsNoTracking()
           .Where(u => u.Username.ToLower() == dto.Username.ToLower())
           .FirstOrDefaultAsync();

        if (IsValidUsername is not null)
            throw new ZeemlinException(409, "Username already exists");

        var IsValidUserEmail = await _repository
            .SelectAll()
            .AsNoTracking()
            .Where(u => u.Email.ToLower() == dto.Email.ToLower())
            .FirstOrDefaultAsync();

        if (IsValidUserEmail is not null)
            throw new ZeemlinException(409, "Email already exists");

        var IsValidUserPhoneNumber = await _repository
            .SelectAll()
            .AsNoTracking()
            .Where(u => u.PhoneNumber == dto.PhoneNumber)
            .FirstOrDefaultAsync();

        if (IsValidUserPhoneNumber is not null)
            throw new ZeemlinException(409, "Phone number already exists");

        var IsValidPassportSeria = await _repository
            .SelectAll()
            .AsNoTracking()
            .Where(u => u.PassportSeria == dto.PassportSeria)
            .FirstOrDefaultAsync();

        if (IsValidPassportSeria is not null)
            throw new ZeemlinException(409, "PassportSeria already exists");

        var mapped = _mapper.Map(dto, IsValidId);
        mapped.UpdatedAt = DateTime.UtcNow;
        await _repository.UpdateAsync(mapped);

        return _mapper.Map<DirectorForResultDto>(mapped);
    }

    public async Task<bool> ChangePasswordAsync(string email, DirectorForChangePasswordDto dto)
    {
        var user = await _repository.SelectAll()
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
        var updated = await _repository.UpdateAsync(user);

        return true;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var IsValidId = await _repository
            .SelectAll().AsNoTracking()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (IsValidId is null)
            throw new ZeemlinException(404, "Not Found");

        await _repository.DeleteAsync(id); 
        return true;
    }

    public async Task<IEnumerable<DirectorForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var directors = await _repository.SelectAll().AsNoTracking().ToPagedList(@params).ToListAsync();

        return _mapper.Map<IEnumerable<DirectorForResultDto>>(directors);
    }

    public async Task<DirectorForResultDto> RetrieveByIdAsync(long id)
    {
        var director = await _repository.SelectAll()
            .Include(d => d.Schools)
            .ThenInclude(s => s.SchoolLogoAsset) // Include SchoolLogoAsset
            .AsNoTracking()
            .Where(d => d.Id == id)
            .FirstOrDefaultAsync();

        if (director is null)
            throw new ZeemlinException(404, "Not Found");

        var result = _mapper.Map<DirectorForResultDto>(director);
        result.Schools = director.Schools != null
            ? _mapper.Map<ICollection<SchoolForResultDto>>(director.Schools)
            : null;

        return result;
    }

    public async Task<IEnumerable<DirectorForResultDto>> RetrieveByUsernameAsync(string search, PaginationParams @params)
    {
        // Use Include method for eager loading
        var directors = await _repository.SelectAll() // Include the School navigation property
            .Where(a => a.Username.Contains(search))
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        if (!directors.Any()) // Check if any directors found
        {
            throw new ZeemlinException(404, "Not Found");
        }

        var result = _mapper.Map<IEnumerable<DirectorForResultDto>>(directors);

        return result;
    }

}
