using Microsoft.AspNetCore.Mvc;
using HotelWeb.Models;
using HotelWeb.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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

            Usuario? usuarioExistente = await _context.Usuarios.Where(

                u => u.Correo == modeloUser.Correo

                ).FirstOrDefaultAsync();

            if (usuarioExistente == null)
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
            
            else
            {

                ViewData["MensajeError"] = "Este correo ya esta asociado a una cuenta.";
                return View();

            }

            
        }

        [HttpGet]
        public IActionResult IniciarSesion(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> IniciarSesion(IniciarSesionVM modeloUser, string? returnUrl = null)
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

            var claims = new List<Claim>
           {

                new Claim(ClaimTypes.NameIdentifier, usuarioExistente.IdUsuario.ToString()),
                new Claim(ClaimTypes.Email, usuarioExistente.Correo),
                new Claim(ClaimTypes.Role, usuarioExistente.IdRol.ToString())

           };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims , 
                CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {

                AllowRefresh = true

            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties

                );

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");

        }

    }
}
