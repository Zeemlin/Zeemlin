﻿using Zeemlin.Domain.Commons;
using Zeemlin.Domain.Entities.Users;

namespace Zeemlin.Domain.Entities;

public class ParentStudent : Auditable
{
    public long ParentId { get; set; }
    public Parent Parent { get; set; }

    public long StudentId { get; set;}
    public Student Student { get; set; }
}
