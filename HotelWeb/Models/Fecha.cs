using System;
using System.Collections.Generic;

namespace HotelWeb.Models;

public partial class Fecha
{
    public int IdFecha { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public DateOnly? FechaSalida { get; set; }

    public int? IdDisponibilidad { get; set; }

    public virtual Disponibilidade? IdDisponibilidadNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
