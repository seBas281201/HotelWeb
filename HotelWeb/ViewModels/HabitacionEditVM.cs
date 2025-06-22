namespace HotelWeb.ViewModels
{
    public class HabitacionEditVM
    {
        public int IdHabitacion { get; set; }
        public string? Nombre { get; set; }

        public string? Calificacion { get; set; }
        public string? Categoria { get; set; }
        public List<string>? DescripcionLista { get; set; }
        public string? DescripcionTextoPlano { get; set; }
        public int? Precio { get; set; }


    }
}
