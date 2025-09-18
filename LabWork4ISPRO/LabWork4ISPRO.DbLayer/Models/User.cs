﻿using System;
using System.Collections.Generic;

namespace LabWork4ISPRO.DbLayer.Models;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual Role Role { get; set; } = null!;
}
