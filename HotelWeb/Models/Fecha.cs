using System;
using System.Collections.Generic;

namespace HotelWeb.Models;

public partial class Fecha
{
    public int IdFecha { get; set; }

    public DateOnly? Fecha1 { get; set; }

    public int? IdDisponibilidad { get; set; }

    public virtual Disponibilidade? IdDisponibilidadNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
