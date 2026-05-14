# 🏨 HotelWeb

Aplicación web desarrollada con **ASP.NET Core MVC + Entity Framework Core** orientada a la gestión de reservas hoteleras. El sistema permite el registro e inicio de sesión de usuarios, visualización de sedes y habitaciones, administración de reservas y acceso a un panel administrativo.

---

# 📌 Características Principales

## 👤 Autenticación de usuarios

* Registro de nuevos usuarios.
* Inicio y cierre de sesión.
* Autenticación basada en cookies.
* Control de acceso mediante roles.

## 🏨 Gestión de hoteles y habitaciones

* Visualización de sedes disponibles.
* Listado de habitaciones por sede.
* Información detallada de cada habitación:

  * Categoría.
  * Precio.
  * Calificación.
  * Descripción.
  * Imagen.

## 📅 Sistema de reservas

* Creación de reservas.
* Validación de disponibilidad por rango de fechas.
* Asociación de reservas con usuarios.
* Consulta de reservas realizadas.

## 🔐 Panel administrativo

* Gestión de usuarios.
* Gestión de habitaciones.
* Restricción de acceso por rol administrador.

---

# 🛠️ Tecnologías Utilizadas

## Backend

* ASP.NET Core MVC (.NET 8)
* Entity Framework Core
* SQL Server
* LINQ
* Cookie Authentication

## Frontend

* Razor Views (.cshtml)
* HTML5
* CSS3
* JavaScript

## Herramientas

* Visual Studio
* SQL Server Management Studio
* Git & GitHub

---

# 📂 Estructura del Proyecto

```bash
HotelWeb-master/
│
├── HotelWeb/
│   ├── Controllers/
│   ├── Models/
│   ├── ViewModels/
│   ├── Views/
│   ├── wwwroot/
│   ├── Helpers/
│   ├── Program.cs
│   └── appsettings.json
│
├── PruebasProyecto/
│
├── dbHotel.sql
└── HotelWeb.sln
```

---

# 📖 Arquitectura Utilizada

El proyecto sigue el patrón arquitectónico **MVC (Model - View - Controller)**:

## Models

Representan las entidades de la base de datos y la lógica de acceso mediante Entity Framework Core.

## Views

Interfaz visual desarrollada con Razor Views.

## Controllers

Gestionan las peticiones HTTP y la lógica de negocio.

## ViewModels

Modelos intermedios utilizados para transportar datos entre vistas y controladores.

---

# ⚙️ Configuración del Proyecto

## 1️⃣ Clonar el repositorio

```bash
git clone https://github.com/usuario/HotelWeb.git
```

---

## 2️⃣ Abrir la solución

Abrir el archivo:

```bash
HotelWeb.sln
```

con Visual Studio 2022 o superior.

---

## 3️⃣ Configurar la base de datos

### Crear la base de datos

1. Abrir SQL Server Management Studio.
2. Ejecutar el script:

```bash
dbHotel.sql
```

Esto creará:

* Tablas.
* Relaciones.
* Datos iniciales.
* Procedimientos almacenados.

---

## 4️⃣ Configurar cadena de conexión

Editar el archivo:

```json
appsettings.json
```

Ejemplo:

```json
"ConnectionStrings": {
  "CadenaSQL": "Server=TU_SERVIDOR;Database=dbHotel;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

## 5️⃣ Restaurar dependencias

```bash
dotnet restore
```

---

## 6️⃣ Ejecutar el proyecto

```bash
dotnet run
```

O ejecutar desde Visual Studio con:

```bash
F5
```

---

# 🔑 Funcionalidades del Sistema

## 👥 Usuarios

### Registro

Los usuarios pueden crear una cuenta mediante correo y contraseña.

### Inicio de sesión

El sistema implementa autenticación con cookies para mantener la sesión activa.

### Roles

El sistema maneja roles de usuario:

* Usuario.
* Administrador.

---

## 🏨 Habitaciones

Cada habitación contiene:

* Nombre.
* Imagen.
* Categoría.
* Descripción.
* Precio.
* Calificación.

---

## 📅 Reservas

El sistema valida automáticamente:

* Disponibilidad de fechas.
* Solapamiento de reservas.
* Cantidad de huéspedes.

Las reservas son registradas mediante procedimientos almacenados en SQL Server.

---

## 🛡️ Administración

El panel administrativo permite:

* Modificar roles de usuarios.
* Gestionar habitaciones.
* Controlar acceso administrativo.

---

# 🧪 Pruebas

El proyecto incluye un módulo:

```bash
PruebasProyecto/
```

destinado a pruebas unitarias.

---

# 📸 Capturas Recomendadas

Puedes agregar capturas en esta sección:

```md
## 📷 Capturas

![Inicio](ruta-imagen)
![Habitaciones](ruta-imagen)
![Reservas](ruta-imagen)
```

---

# 🚀 Posibles Mejoras Futuras

* Integración con pasarelas de pago.
* Panel administrativo avanzado.
* Implementación de JWT.
* API REST.
* Sistema de notificaciones.
* Historial de reservas.
* Dashboard estadístico.
* Responsive design mejorado.
* Integración con servicios en la nube.

---

# 📚 Conceptos Aplicados

* Arquitectura MVC.
* Entity Framework Core.
* Relaciones en bases de datos.
* LINQ.
* Autenticación y autorización.
* Manejo de sesiones.
* Procedimientos almacenados.
* Validación de formularios.
* Razor Pages.
* CRUD.

---

# 👨‍💻 Autor

## Sebastián Navarro

Desarrollador enfocado en tecnologías .NET y desarrollo de software.

* ASP.NET Core
* C#
* SQL Server
* Entity Framework Core
* Git & GitHub

---

# 📄 Licencia

Este proyecto fue desarrollado con fines educativos y de práctica. Aún se encuentra en fase de desarrollo, pero la versión actúal es la mas estable.
