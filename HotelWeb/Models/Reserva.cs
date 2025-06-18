using System;
using System.Collections.Generic;

namespace HotelWeb.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int? IdHabitacion { get; set; }

    public int? IdFecha { get; set; }

    public int? IdUsuario { get; set; }

    public int? NroHuespedes { get; set; }

    public virtual Fecha? IdFechaNavigation { get; set; }

    public virtual Habitacione? IdHabitacionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
