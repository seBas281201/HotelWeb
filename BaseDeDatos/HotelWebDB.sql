create database WebHotel;
 
use WebHotel;
 
create table roles (
    id_rol int primary key identity(1,1),
    rol nvarchar(50)
);
 
create table usuarios (
    id_usuario int primary key identity(1,1),
    id_rol int default 1,
    correo nvarchar(60),
    contrasenia nvarchar(60),
    foreign key (id_rol) references roles(id_rol)
);
 
create table sedes (
    id_sede int primary key identity(1,1),
    pais nvarchar(60),
    ciudad nvarchar(60),
    nro_habitaciones int
);
 
create table disponibilidades (
    id_disponibilidad int primary key identity(1,1),
    estado int
);
 
create table tipo_habitaciones (
    id_tipo int primary key identity(1,1),
    categoria nvarchar(60)
);
 
create table habitaciones (
    id_habitacion int primary key identity(1,1),
    id_tipo int,
    id_sede int,
    id_disponibilidad int,
    foreign key (id_tipo) references tipo_habitaciones(id_tipo),
    foreign key (id_sede) references sedes(id_sede),
    foreign key (id_disponibilidad) references disponibilidades(id_disponibilidad)
);
 
create table fechas (
    id_fecha int primary key identity(1,1),
	id_disponibilidad int,
    fecha date
);
 
create table reservas (
    id_reserva int primary key identity(1,1),
    id_habitacion int,
    id_fecha int,
    id_usuario int,
    foreign key (id_habitacion) references habitaciones(id_habitacion),
    foreign key (id_fecha) references fechas(id_fecha),
    foreign key (id_usuario) references usuarios(id_usuario)
);
 
alter table fechas
add foreign key (id_disponibilidad) references disponibilidades(id_disponibilidad);
 
INSERT INTO roles (rol) VALUES ('Usuario');
INSERT INTO roles (rol) VALUES ('Administrador');
 