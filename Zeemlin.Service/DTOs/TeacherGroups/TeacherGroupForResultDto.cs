﻿using System.Text.Json.Serialization;
using Zeemlin.Service.DTOs.Group;
using Zeemlin.Service.DTOs.Users.Teachers;

namespace Zeemlin.Service.DTOs.TeacherGroups;

public class TeacherGroupForResultDto
{
    public long Id { get; set; }
    public long TeacherId { get; set; }
    [JsonIgnore]
    public TeacherForResultDto TeacherForResultDto { get; set; }
    public long GroupId { get; set; }
    [JsonIgnore]
    public GroupForResultDto GroupForResultDto { get; set; }
    public string Role { get; set; }
}
