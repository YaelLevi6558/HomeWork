﻿using System;
using System.Collections.Generic;

namespace ex2.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Adress { get; set; }

    public string? Phone { get; set; }
    //public virtual Tasks? Tasks { get; set; }
    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}