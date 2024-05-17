using System.ComponentModel.DataAnnotations;
using Zeemlin.Service.Commons.Attributes;

namespace Zeemlin.Service.DTOs.Users.Teachers;

public class TeacherForChangePasswordDto
{
    [Required(ErrorMessage = "Old password must not be null or empty!")]
    public string OldPassword { get; set; }

    [Required(ErrorMessage = "New password must not be null or empty!")]
    [StrongPassword]
    public string NewPassword { get; set; }

    [Required(ErrorMessage = "Confirming password must not be null or empty!")]
    [StrongPassword]
    public string ConfirmPassword { get; set; }
}
