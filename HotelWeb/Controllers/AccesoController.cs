using Microsoft.AspNetCore.Mvc;
using HotelWeb.Models;
using HotelWeb.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Controllers
{
    public class AccesoController : Controller
    {
        private readonly WebHotelContext _context;
        public AccesoController(WebHotelContext webContext)
        {

           _context = webContext;

        }

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(UsuarioVM modeloUser)
        {

            if (modeloUser.Contrasenia != modeloUser.ConfirmarContrasenia)
            {
                ViewData["MensajeError"] = "Las contraseñas no coinciden";
                return View();
            }


            Usuario user = new Usuario()
            {

                Correo = modeloUser.Correo,
                Contrasenia = modeloUser.Contrasenia

            };

            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();

            if (user.IdUsuario != 0)
            {

                return RedirectToAction("IniciarSesion", "Acceso");

            }

            else
            {

                ViewData["MensajeError"] = "No se pudo crear el usuario, intente de nuevo.";

            }


            return View();
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> IniciarSesion(IniciarSesionVM modeloUser)
        {

            Usuario? usuarioExistente = await _context.Usuarios.Where(
                
                u => u.Correo == modeloUser.Correo &&
                u.Contrasenia == modeloUser.Contrasenia

                ).FirstOrDefaultAsync();

            if(usuarioExistente == null)
            {

                ViewData["MensajeError"] = "No se encontraron usuarios con dichas credenciales.";
                return View();

            }

            return RedirectToAction("Index", "Home");

        }

    }
}
