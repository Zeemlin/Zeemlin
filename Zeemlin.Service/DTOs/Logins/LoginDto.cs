using System.ComponentModel.DataAnnotations;
using Zeemlin.Service.Commons.Attributes;

namespace Zeemlin.Service.DTOs.Logins;

public class LoginDto
{
    [Required(ErrorMessage = "Elektron pochtani kiriting"), PhoneNumber]
    public string Email { get; set; }

    [Required(ErrorMessage = "Parolni kiriting"), StrongPassword]
    public string Password { get; set; }
}
