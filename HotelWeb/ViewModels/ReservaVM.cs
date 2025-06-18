namespace HotelWeb.ViewModels
{
    public class ReservaVM
    {
        public DateOnly? FechaIngreso { get; set; }
        public DateOnly? FechaSalida { get; set; }
        public int NroHuespedes { get; set; }
        public int IdHabitacion { get; set; }

    }
}
