﻿//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Zeemlin.Data.IRepositries.Users;
//using Zeemlin.Domain.Entities.Users;
//using Zeemlin.Service.DTOs.Logins;
//using Zeemlin.Service.Exceptions;
//using Zeemlin.Service.Interfaces;

//namespace Zeemlin.Service.Services;

//public class AuthService : IAuthService
//{
//    private readonly IUserRepository _userRepository;
//    private readonly IConfiguration _configuration;

//    public AuthService(IConfiguration configuration, IUserRepository userRepository)
//    {

//        _configuration = configuration;
//        _userRepository = userRepository;
//    }


//    public async Task<LoginResultDto> AuthenticateAsync(LoginDto login)
//    {
//        var user = await _userRepository.ExistsAsync(login.Email);
//        if (user == null)
//            throw new ZeemlinException(400, "Email or Password is incorrect");

//        return new LoginResultDto
//        {
//            Token = GenerateToken(user)
//        };

//    }

//    private string GenerateToken(User user)
//    {
//        var tokenHandler = new JwtSecurityTokenHandler();
//        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
//        var tokenDescriptor = new SecurityTokenDescriptor
//        {
//            Subject = new ClaimsIdentity(new Claim[]
//            {
//                new Claim("Id",user.Id.ToString()),
//                new Claim(ClaimTypes.Email, user.Email),
//            }),
//            Audience = _configuration["JWT:Audience"],
//            Issuer = _configuration["JWT:Issuer"],
//            IssuedAt = DateTime.UtcNow,
//            Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JWT:Expire"])),
//            SigningCredentials = new SigningCredentials(
//                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
//        };

//        var token = tokenHandler.CreateToken(tokenDescriptor);
//        return tokenHandler.WriteToken(token);
//    }
//}
