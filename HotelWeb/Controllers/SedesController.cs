using HotelWeb.Models;
using HotelWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Authorize]
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

        public IActionResult VerHabitacionesSedeColombia()
        {
            var habitaciones = _context.Habitaciones.
                Include(h => h.IdTipoNavigation).
                Where(h => h.IdSede == 2).
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

        public IActionResult VerHabitacionesSedeEspania()
        {
            var habitaciones = _context.Habitaciones.
                Include(h => h.IdTipoNavigation).
                Where(h => h.IdSede == 3).
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
