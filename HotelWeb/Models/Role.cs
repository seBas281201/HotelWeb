﻿using System;
using System.Collections.Generic;

namespace HotelWeb.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
