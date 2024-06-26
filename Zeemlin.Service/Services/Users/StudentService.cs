﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zeemlin.Data.IRepositries;
using Zeemlin.Domain.Entities.Users;
using Zeemlin.Service.Commons.Helpers;
using Zeemlin.Service.DTOs.Users.Students;
using Zeemlin.Service.Exceptions;
using Zeemlin.Service.Interfaces.Users;

namespace Zeemlin.Service.Services.Users;

public class StudentService : IStudentService
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public StudentService(
        IStudentRepository studentRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _studentRepository = studentRepository;
    }
    private async Task<string> GenerateUniqueStudentId()
    {
        string studentId;
        do
        {
            studentId = GenerateRandomAlphanumericString(8);
        } while (await _studentRepository.ExistsAsync(studentId)); // Check for existence

        return studentId;
    }

    private string GenerateRandomAlphanumericString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public async Task<StudentForResultDto> AddAsync(StudentForCreationDto dto)
    {
        var existingStudentEmail = await _studentRepository
          .SelectAll()
          .Where(e => e.Email.ToLower() == dto.Email.ToLower())
          .AsNoTracking()
          .FirstOrDefaultAsync();

        if (existingStudentEmail is not null)
            throw new ZeemlinException(409, "User is already exist.");

        var existingStudentPhoneNumber = await _studentRepository
          .SelectAll()
          .Where(e => e.PhoneNumber == dto.PhoneNumber)
          .AsNoTracking()
          .FirstOrDefaultAsync();

        if (existingStudentPhoneNumber is not null)
            throw new ZeemlinException(409, "User is already exist.");

        var hasherResult = PasswordHelper.Hash(dto.Password);
        var mappedStudent = _mapper.Map<Student>(dto);
        mappedStudent.StudentUniqueId = await GenerateUniqueStudentId();
        mappedStudent.CreatedAt = DateTime.UtcNow;
        mappedStudent.Salt = hasherResult.Salt;
        mappedStudent.Password = hasherResult.Hash;
        await _studentRepository.InsertAsync(mappedStudent);

        return _mapper.Map<StudentForResultDto>(mappedStudent);
    }


    public async Task<StudentForResultDto> ModifyAsync(long id, StudentForUpdateDto dto)
    {
        var user = await _studentRepository.SelectAll()
        .Where(u => u.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (user is null)
            throw new ZeemlinException(404, "User not found");

        var person = _mapper.Map(dto, user);
        person.UpdatedAt = DateTime.UtcNow;
        await _studentRepository.UpdateAsync(person);

        return _mapper.Map<StudentForResultDto>(person);
    }

    public async Task<bool> ChangePasswordAsync(string email, StudentForChangePasswordDto dto)
    {
        var user = await _studentRepository.SelectAll()
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
        var updated = await _studentRepository.UpdateAsync(user);

        return true;
    }

    public async Task<StudentForResultDto> StudentAddressUpdate(long id, StudentAddressForUpdateDto dto)
    {
        var student = await _studentRepository
            .SelectAll()
            .Where(s => s.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (student is null)
            throw new ZeemlinException(404, "Student not found.");

        var user = _mapper.Map(dto, student);
        user.UpdatedAt = DateTime.UtcNow;
        await _studentRepository.UpdateAsync(user);

        return _mapper.Map<StudentForResultDto>(user);
    }


    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _studentRepository.SelectAll()
            .Where(u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null)
            throw new ZeemlinException(404, "User is not found");

        await _studentRepository.DeleteAsync(id);

        return true;
    }



    public async Task<IEnumerable<StudentForResultDto>> RetrieveAllAsync()
    {
        var users = await _studentRepository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<StudentForResultDto>>(users);
    }

    public async Task<StudentForResultDto> RetrieveByIdAsync(long id)
    {
        var student = await _studentRepository.SelectAll()
            .Where(s => s.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (student is null)
            throw new ZeemlinException(404, "Student not found");

        return _mapper.Map<StudentForResultDto>(student);
    }

    public async Task<IEnumerable<Student>> RetrieveByPhoneNumberAsync(string data)
    {
        var query = _studentRepository.SelectAll().Where(a =>
           a.PhoneNumber.Contains(data));
        return await query.ToListAsync();
    }
}
