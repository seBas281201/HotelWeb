namespace HotelWeb.ViewModels
{
    public class MisReservasVM
    {

        public string NombreHabitacion { get; set; }
        public string Categoria { get; set; }
        public int IdReserva { get; set; }
        public int Huespedes { get; set; }
        public string Sede { get; set; }
        public DateOnly Ingreso { get; set; }
        public DateOnly Salida { get; set; }
        public int Precio { get; set; }
        public int Estado { get; set; }

    }
}
