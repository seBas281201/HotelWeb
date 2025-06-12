using System;
using System.Collections.Generic;

namespace HotelWeb.Models;

public partial class TipoHabitacione
{
    public int IdTipo { get; set; }

    public string? Categoria { get; set; }

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();
}
