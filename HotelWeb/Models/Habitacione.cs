using System;
using System.Collections.Generic;

namespace HotelWeb.Models;

public partial class Habitacione
{
    public int IdHabitacion { get; set; }

    public int? IdTipo { get; set; }

    public int? IdSede { get; set; }

    public int? IdDisponibilidad { get; set; }

    public virtual Disponibilidade? IdDisponibilidadNavigation { get; set; }

    public virtual Sede? IdSedeNavigation { get; set; }

    public virtual TipoHabitacione? IdTipoNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
