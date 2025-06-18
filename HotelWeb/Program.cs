using Microsoft.EntityFrameworkCore;
using HotelWeb.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WebHotelContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(options =>
    {

        options.LoginPath = "/Acceso/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(80);

    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
