﻿using System;
using System.Collections.Generic;

namespace HotelWeb.Models;

public partial class Disponibilidade
{
    public int IdDisponibilidad { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<Fecha> Fechas { get; set; } = new List<Fecha>();

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();
}
