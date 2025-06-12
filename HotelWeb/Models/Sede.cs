using System;
using System.Collections.Generic;

namespace HotelWeb.Models;

public partial class Sede
{
    public int IdSede { get; set; }

    public string? Pais { get; set; }

    public string? Ciudad { get; set; }

    public int? NroHabitaciones { get; set; }

    public virtual ICollection<Habitacione> Habitaciones { get; set; } = new List<Habitacione>();
}
