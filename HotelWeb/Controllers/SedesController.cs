using HotelWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelWeb.ViewModels;

namespace HotelWeb.Controllers
{
    public class SedesController : Controller
    {

        private readonly WebHotelContext _context;
        public SedesController(WebHotelContext webContext)
        {

            _context = webContext;

        }

        public IActionResult VerSedes()
        {
            return View();
        }

        public IActionResult VerHabitacionesSedePrincipal()
        {
            var habitaciones = _context.Habitaciones.
                Include(h => h.IdTipoNavigation).
                Where(h => h.IdSede == 1).
                Select(h => new HabitacionesVM
                {
                    IdHabitacion = h.IdHabitacion,
                    Nombre = h.Nombre,
                    UrlImagen = h.UrlImagen,
                    Categoria = h.IdTipoNavigation != null ? h.IdTipoNavigation.Categoria : "Sin categoria",
                    Calificacion = h.Calificacion,
                    DescripcionLista = h.Descripcion.Split(new[] { "\r\n", "\n" }, 
                    StringSplitOptions.RemoveEmptyEntries).ToList(),
                    Precio = h.Precio

                }).ToList();

            return View(habitaciones);
        }
    }
}
