using HotelWeb.Models;
using HotelWeb.ViewModels;
using HotelWeb.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Controllers
{
    public class ReservasController : Controller
    {
        private readonly WebHotelContext _context;
        public ReservasController(WebHotelContext webContext)
        {

            _context = webContext;

        }

        [Authorize]
        [HttpGet]
        public IActionResult ReservaNY(int id)
        {
            var habitacion = _context.Habitaciones.Find(id);
            return View(habitacion);
        }

        [HttpPost]
        public async Task<IActionResult> ReservaNY(ReservaVM reservaVM)
        {
            int IdUsuario = int.Parse(ClaimsHelper.GetUserId(User));

            var fechasEnUso = await _context.Reservas
                .Include(r => r.IdFechaNavigation)
                .Where(r => r.IdHabitacion == reservaVM.IdHabitacion &&
                            r.IdFechaNavigation.FechaIngreso < reservaVM.FechaSalida &&
                            r.IdFechaNavigation.FechaSalida > reservaVM.FechaIngreso)
                .ToListAsync();

            if (fechasEnUso.Any())
            {

                TempData["MensajeInformacion"] = "Esa franja de fechas no esta disponible para esta habitacion por el momento.";
                return RedirectToAction("ReservaNY", new { id = reservaVM.IdHabitacion });


            }

            await _context.Database.ExecuteSqlRawAsync(

                "EXEC registrarReserva @fechaIngreso = {0}, @fechaSalida = {1}, @idHabitacion = {2}, " +
                "@idUsuario = {3}, @nroHuespedes = {4}", reservaVM.FechaIngreso, reservaVM.FechaSalida,
                reservaVM.IdHabitacion, IdUsuario, reservaVM.NroHuespedes


                );


            TempData["MensajeInformacion"] = "Reserva añadida correctamente";

            return RedirectToAction("ReservaNY", new { id = reservaVM.IdHabitacion });


        }

        [HttpGet]
        public async Task<IActionResult> MisReservas()
        {

            int IdUsuario = int.Parse(ClaimsHelper.GetUserId(User));

                        string sql = @"select h.Nombre as NombreHabitacion, th.categoria as Categoria, h.Precio as Precio,
            r.id_reserva as IdReserva, r.nro_huespedes as Huespedes, 
            s.pais as Sede, f.fecha_ingreso as Ingreso, f.fecha_salida as Salida
            from reservas r
            inner join habitaciones h on r.id_habitacion = h.id_habitacion
            inner join tipo_habitaciones th on th.id_tipo = h.id_tipo
            inner join fechas f on r.id_fecha = f.id_fecha
            inner join sedes s on s.id_sede = h.id_sede 
            where r.id_usuario = {0}";

            var reservas = await _context.Set<MisReservasVM>().FromSqlRaw(sql, IdUsuario).
                ToListAsync();

            return View(reservas);

        }

    }
}
