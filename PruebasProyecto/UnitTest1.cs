using HotelWeb.Controllers;
using HotelWeb.Models;
using HotelWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Collections.Generic;

namespace PruebasProyecto
{
    public class UnitTest1
    {
        private DbContextOptions<WebHotelContext> GetDbOptions()
        {
            return new DbContextOptionsBuilder<WebHotelContext>()
                .UseInMemoryDatabase(databaseName: "TestDb") // Esto ahora funcionará
                .Options;
        }

        [Fact]
        public async Task Registrarse_UsuarioNuevo_RedireccionaAIniciarSesion()
        {
            // Arrange
            var options = GetDbOptions();
            using var context = new WebHotelContext(options);
            var controller = new AccesoController(context);

            var modeloUser = new UsuarioVM
            {
                Correo = "nuevo@correo.com",
                Contrasenia = "1234",
                ConfirmarContrasenia = "1234"
            };

            // Act
            var result = await controller.Registrarse(modeloUser);

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("IniciarSesion", redirect.ActionName);
        }

        [Fact]
        public async Task Registrarse_CorreoExistente_MuestraMensajeError()
        {
            // Arrange
            var options = GetDbOptions();
            using var context = new WebHotelContext(options);
            context.Usuarios.Add(new Usuario { Correo = "existe@correo.com", Contrasenia = "1234" });
            context.SaveChanges();

            var controller = new AccesoController(context);

            var modeloUser = new UsuarioVM
            {
                Correo = "existe@correo.com",
                Contrasenia = "1234",
                ConfirmarContrasenia = "1234"
            };

            // Act
            var result = await controller.Registrarse(modeloUser);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Este correo ya esta asociado a una cuenta.", controller.ViewData["MensajeError"]);
        }

        [Fact]
        public async Task Registrarse_ContraseniasNoCoinciden_MuestraMensajeError()
        {
            // Arrange
            var options = GetDbOptions();
            using var context = new WebHotelContext(options);
            var controller = new AccesoController(context);

            var modeloUser = new UsuarioVM
            {
                Correo = "nuevo@correo.com",
                Contrasenia = "1234",
                ConfirmarContrasenia = "5678"
            };

            // Act
            var result = await controller.Registrarse(modeloUser);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Las contraseñas no coinciden", controller.ViewData["MensajeError"]);
        }

        [Fact]
        public async Task IniciarSesion_CredencialesInvalidas_MuestraMensajeError()
        {
            // Arrange
            var options = GetDbOptions();
            using var context = new WebHotelContext(options);
            var controller = new AccesoController(context);

            var modeloUser = new IniciarSesionVM
            {
                Correo = "noexiste@correo.com",
                Contrasenia = "1234"
            };

            // Act
            var result = await controller.IniciarSesion(modeloUser);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("No se encontraron usuarios con dichas credenciales.", controller.ViewData["MensajeError"]);
        }
    }
}