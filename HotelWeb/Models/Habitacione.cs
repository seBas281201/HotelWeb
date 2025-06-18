using System;
using System.Collections.Generic;

namespace HotelWeb.Models;

public partial class Habitacione
{
    public int IdHabitacion { get; set; }

    public int? IdTipo { get; set; }

    public int? IdSede { get; set; }

    public int? IdDisponibilidad { get; set; }

    public string? UrlImagen { get; set; }

    public string? Nombre { get; set; }

    public string? Calificacion { get; set; }

    public string? Descripcion { get; set; }

    public int? Precio { get; set; }

    public string? UrlImagenServicio1 { get; set; }

    public string? UrlImagenServicio2 { get; set; }

    public string? DescripcionBreve { get; set; }

    public virtual Disponibilidade? IdDisponibilidadNavigation { get; set; }

    public virtual Sede? IdSedeNavigation { get; set; }

    public virtual TipoHabitacione? IdTipoNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
