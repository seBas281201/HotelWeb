using Microsoft.AspNetCore.Mvc;
using HotelWeb.ViewModels;
using HotelWeb.Models;
using Microsoft.EntityFrameworkCore;
using HotelWeb.Helpers;

namespace HotelWeb.Controllers
{
    public class AdminController : Controller
    {

        private readonly WebHotelContext _context;
        public AdminController(WebHotelContext webContext)
        {

            _context = webContext;

        }

        public IActionResult VerModulo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ModuloUsuarios()
        {   
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModuloUsuarios(UsuarioUpdateVM userUDT)
        {
            
            Usuario? usuarioExitente = await _context.Usuarios.Where(
                
                
                  u => u.Correo == userUDT.Correo
                
                
                ).FirstOrDefaultAsync();

            if (usuarioExitente == null)
            {

                ViewData["MensajeInfo"] = "Este usuario no se encuentra en el sistema.";
                return View();  

            }

            else if (ClaimsHelper.GetEmail(User) == userUDT.Correo)
            {

                ViewData["MensajeInfo"] = "No puedes cambiar tu propio acceso.";
                return View();

            }

            else
            {

                if (userUDT.Rol.Equals("Administrador"))
                {

                    usuarioExitente.IdRol = 2;
                    await _context.SaveChangesAsync();

                }

                if (userUDT.Rol.Equals("Usuario"))
                {

                    usuarioExitente.IdRol = 1;
                    await _context.SaveChangesAsync();

                }

            }

            ViewData["MensajeInfo"] = "Permisos actualizados de forma exitosa.";
            return View();
        }

        public IActionResult ModuloHabitaciones()
        {
                var habitaciones = _context.Habitaciones.
                Include(h => h.IdTipoNavigation).
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

        [HttpGet]
        public IActionResult Editarhabitacion(int id)
        {
            var habitacion = _context.Habitaciones.
                Include(h => h.IdTipoNavigation).
                Where(h => h.IdHabitacion == id).
                Select(h => new HabitacionEditVM
                {
                    IdHabitacion = id,
                    Nombre = h.Nombre,
                    Calificacion = h.Calificacion,
                    Categoria = h.IdTipoNavigation != null ? h.IdTipoNavigation.Categoria : "Sin categoria",
                    DescripcionLista = h.Descripcion.Split(new[] { "\r\n", "\n" },
                    StringSplitOptions.RemoveEmptyEntries).ToList(),
                    DescripcionTextoPlano = h.Descripcion,
                    Precio = h.Precio

                }).ToList();

            return View(habitacion);
        }
        
        [HttpPost]
        public async Task<IActionResult> Editarhabitacion(List<HabitacionEditVM> HabitacionUDT)
        {
            var HabitacionModificar = await _context.Habitaciones.
                Include(h => h.IdTipoNavigation).
                Where(h => h.IdHabitacion == HabitacionUDT[0].IdHabitacion).FirstOrDefaultAsync();

            HabitacionModificar.Nombre = HabitacionUDT[0].Nombre;
            HabitacionModificar.Calificacion = HabitacionUDT[0].Calificacion;
            HabitacionModificar.IdTipoNavigation.Categoria = HabitacionUDT[0].Categoria;
            HabitacionModificar.Descripcion = HabitacionUDT[0].DescripcionTextoPlano;
            HabitacionModificar.Precio = HabitacionUDT[0].Precio;
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "La habitacion fue actualizada correctamente.";
            
            return RedirectToAction("EditarHabitacion", new { id = HabitacionUDT[0].IdHabitacion });
        }
    }
}
