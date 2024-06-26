﻿using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using Zeemlin.Domain.Enums;
using Zeemlin.Service.Commons.Attributes;

namespace Zeemlin.Service.DTOs.Users.Directors;

public class DirectorForUpdateDto
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAttribute]
    public string Email { get; set; }
    [PhoneNumber]
    public string PhoneNumber { get; set; }
    public GenderType Gender { get; set; }
    [UzbekistanPassport]
    public string PassportSeria { get; set; }
}
