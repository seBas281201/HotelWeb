namespace HotelWeb.ViewModels
{
    public class HabitacionesVM
    {

        public int IdHabitacion { get; set; }
        public string? UrlImagen { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public string? Calificacion { get; set; }
        public List<string>? DescripcionLista { get; set; }
        public int? Precio { get; set; }
    }
}
