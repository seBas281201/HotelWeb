CREATE DATABASE WebHotel;

SELECT name FROM sys.databases;

USE master

USE WebHotel;

CREATE TABLE roles (
    id_rol INT PRIMARY KEY IDENTITY(1,1),
    rol NVARCHAR(50)
);

CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    id_rol INT DEFAULT 1,
    correo NVARCHAR(60),
    contrasenia NVARCHAR(60),
    FOREIGN KEY (id_rol) REFERENCES roles(id_rol)
);

CREATE TABLE sedes (
    id_sede INT PRIMARY KEY IDENTITY(1,1),
    pais NVARCHAR(60),
    ciudad NVARCHAR(60),
    nro_habitaciones INT
);

CREATE TABLE disponibilidades (
    id_disponibilidad INT PRIMARY KEY IDENTITY(1,1),
    estado INT
);

CREATE TABLE tipo_habitaciones (
    id_tipo INT PRIMARY KEY IDENTITY(1,1),
    categoria NVARCHAR(60)
);

CREATE TABLE habitaciones (
    id_habitacion INT PRIMARY KEY IDENTITY(1,1),
    id_tipo INT,
    id_sede INT,
    id_disponibilidad INT,
    FOREIGN KEY (id_tipo) REFERENCES tipo_habitaciones(id_tipo),
    FOREIGN KEY (id_sede) REFERENCES sedes(id_sede),
    FOREIGN KEY (id_disponibilidad) REFERENCES disponibilidades(id_disponibilidad)
);

CREATE TABLE fechas (
    id_fecha INT PRIMARY KEY IDENTITY(1,1),
    id_disponibilidad int,
	fecha_ingreso DATE,
    fecha_salida DATE,
	FOREIGN KEY (id_disponibilidad) REFERENCES disponibilidades(id_disponibilidad)
);

CREATE TABLE reservas (
    id_reserva INT PRIMARY KEY IDENTITY(1,1),
    id_habitacion INT,
    id_fecha INT,
    id_usuario INT,
    nro_huespedes INT,
    FOREIGN KEY (id_habitacion) REFERENCES habitaciones(id_habitacion),
    FOREIGN KEY (id_fecha) REFERENCES fechas(id_fecha),
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);


select h.Nombre as NombreHabitacion, th.categoria as Categoria, h.Precio as Precio,
            r.id_reserva as IdReserva, r.nro_huespedes as Huespedes, 
            s.pais as Sede, f.fecha_ingreso as Ingreso, f.fecha_salida as Salida,
			f.id_disponibilidad as Estado
            from reservas r
            inner join habitaciones h on r.id_habitacion = h.id_habitacion
            inner join tipo_habitaciones th on th.id_tipo = h.id_tipo
            inner join fechas f on r.id_fecha = f.id_fecha
            inner join sedes s on s.id_sede = h.id_sede 
            where r.id_usuario = 1

update f
set f.id_disponibilidad = 2
from reservas r
inner join fechas f on f.id_fecha = r.id_fecha
where r.id_reserva = 6

select calificacion from habitaciones order by Calificacion desc;

select * from disponibilidades
select * from usuarios where id_usuario = 1
select Nombre, id_sede from habitaciones
select * from sedes
select * from reservas
select * from fechas


CREATE PROCEDURE registrarReserva
    @fechaIngreso DATE,
    @fechaSalida DATE,
    @idHabitacion INT,
    @idUsuario INT,
    @nroHuespedes INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO fechas (fecha_ingreso, fecha_salida, id_disponibilidad)
    VALUES (@fechaIngreso, @fechaSalida, 2);

    DECLARE @idFecha INT;
    SET @idFecha = SCOPE_IDENTITY(); 

    INSERT INTO reservas (id_habitacion, id_fecha, id_usuario, nro_huespedes)
    VALUES (@idHabitacion, @idFecha, @idUsuario, @nroHuespedes);
END;


SELECT * FROM usuarios;
SELECT * FROM roles
SELECT id_habitacion, id_disponibilidad from habitaciones;
select * from fechas
select * from reservas
SELECT Nombre from habitaciones

alter table habitaciones add urlImagen nvarchar(60);
alter table habitaciones add Nombre nvarchar(60);
alter table habitaciones add Calificacion nvarchar(3);
alter table habitaciones add Descripcion text;
alter table Habitaciones add Precio int;

INSERT INTO roles (rol) VALUES ('Usuario'), ('Administrador');
insert into tipo_habitaciones (categoria) values('Premium'),('B�sica'),('Familiar');
insert into sedes (pais, ciudad, nro_habitaciones) values('Estados Unidos' ,'Nueva York' , 100),('Colombia' ,'Cartagena' , 100),('Jap�n' ,'Tokio' , 100);
insert into disponibilidades(estado) values(1),(0);

-- habitaciones de sede ny
insert into habitaciones (id_tipo, id_sede, id_disponibilidad, urlImagen, Nombre, Calificacion, Descripcion, Precio) values(1,1,1,'~/css/premium1.jpg','Suite Esmeralda','4.8','� Room service 24/7

� Decoraci�n sofisticada

� Almohadas hipoalerg�nicas

� Ba�o de spa

� Vista privilegiada

� Detalles de bienvenida', 2350000)
insert into habitaciones (id_tipo, id_sede, id_disponibilidad, urlImagen, Nombre, Calificacion, Descripcion, Precio) values (1,1,1,'~/css/premium2.jpg','Suite Diamante','5.0','� Terraza privada con vista alta de la ciudad

� Ba�o con sauna

� Cena privada con chef

� Smart TV de 85'' con streaming incluido

� Minibar premium

� Cama king con almohadas memory foam', 2500000), (1,1,1,'~/css/premium3.jpg','Suite Rub�','4.9','� Piscina privada climatizada

� Cava de vinos en la habitaci�n

� Sillas de masaje

� Ba�o de spa

� Escritorio ejecutivo con vista

� Servicio de transporte privado', 2400000), (2,1,1,'~/css/basica1.jpg','Est�ndar Elegante','3.8','� Cama queen size

� WiFi de alta velocidad

� Aire acondicionado

� Escritorio de trabajo

� Ba�o privado con agua caliente

� Desayuno continental', 280000), (2,1,1,'~/css/basica2.jpg','Est�ndar Vista Jard�n','3.7','� Cama doble

� Balc�n con vista al jard�n

� TV de 42''

� Mini nevera

� Servicio de limpieza diario

� Caja fuerte', 310000), (2,1,1,'~/css/basica3.jpg','Est�ndar Relax','4.0','� Cama doble con colch�n ortop�dico

� Ventanas insonorizadas

� Smart TV con Netflix

� Cafetera en la habitaci�n

� Ba�o con ducha efecto lluvia

� Aire acondicionado', 350000),(2,1,1,'~/css/basica4.jpg','Est�ndar Business','4.4','� Escritorio amplio con l�mpara de lectura

� WiFi r�pido y gratuito

� Caja fuerte para laptop

� Ba�o de spa

� Cama queen

� Minibar Est�ndar', 400000),(3,1,1,'~/css/familiar1.jpg','Familiar Deluxe','4.6','� Dos camas dobles

� Zona de juegos para ni�os

� Cocina peque�a equipada

� Smart TV en cada �rea

� Desayuno buffet incluido

� Sof� cama adicional', 850000),(3,1,1,'~/css/familiar2.jpg','Familiar Confort','4.7','� Cama king y una cama individual

� �rea de descanso con sof� grande

� Microondas y minibar

� TV con programaci�n infantil

� Ba�o espacioso con doble lavabo

� Cena privilegiada con men� infantil incluido', 1133284);

select * from disponibilidades

alter table habitaciones add urlImagenServicio1 nvarchar(60);
alter table habitaciones add urlImagenServicio2 nvarchar(60);
alter table habitaciones add descripcionBreve text;
select * from habitaciones

--- Habitacion1 sede ny
update habitaciones set urlImagenServicio1 = '~/css/spa.jpg' where id_habitacion = 1;
update habitaciones set urlImagenServicio2 = '~/css/regalo.jpg' where id_habitacion = 1;
update habitaciones set descripcionBreve = 'Una habitaci�n que combina lujo y confort en cada detalle. Con un dise�o sofisticado, vistas impresionantes y un ba�o tipo spa para la m�xima relajaci�n.' where id_habitacion = 1;

--- habitacion2 sede ny
update habitaciones set urlImagenServicio1 = '~/css/cena.jpg' where id_habitacion = 2;
update habitaciones set urlImagenServicio2 = '~/css/bar.jpg' where id_habitacion = 2;
update habitaciones set descripcionBreve = 'Disfruta de una experiencia �nica en nuestra suite m�s exclusiva. Rel�jate en una terraza privada con una vista panor�mica de la ciudad, perfecta para un atardecer inolvidable.' where id_habitacion = 2;

--- habitacion3 sede ny
update habitaciones set urlImagenServicio1 = '~/css/chofer.jpg' where id_habitacion = 3;
update habitaciones set urlImagenServicio2 = '~/css/piscina.jpg' where id_habitacion = 3;
update habitaciones set descripcionBreve = 'Sum�rgete en el confort absoluto de una habitaci�n dise�ada para el descanso y la distinci�n. Disfruta de una piscina privada climatizada y un ba�o de spa que revitaliza cuerpo y mente.' where id_habitacion = 3;

--- habitacion4 sede ny
update habitaciones set urlImagenServicio1 = '~/css/wifi.jpg' where id_habitacion = 4;
update habitaciones set urlImagenServicio2 = '~/css/escritorio.jpg' where id_habitacion = 4;
update habitaciones set descripcionBreve = 'Un espacio acogedor pensado para tu descanso y productividad. Esta habitaci�n cuenta con una cama queen size para un sue�o reparador.' where id_habitacion = 4;

--- habitacion5 sede ny
update habitaciones set urlImagenServicio1 = '~/css/tv.jpg' where id_habitacion = 5;
update habitaciones set urlImagenServicio2 = '~/css/jardin.jpg' where id_habitacion = 5;
update habitaciones set descripcionBreve = 'Rel�jate en una habitaci�n acogedora con cama doble y balc�n privado que ofrece una vista serena al jard�n.' where id_habitacion = 5;


--- habitacion6 sede ny
update habitaciones set urlImagenServicio1 = '~/css/duchaLluvia.jpg' where id_habitacion = 6;
update habitaciones set urlImagenServicio2 = '~/css/ventana.jpg' where id_habitacion = 6;
update habitaciones set descripcionBreve = 'Pensada para quienes valoran el descanso profundo y los peque�os placeres, esta habitaci�n ofrece una cama doble con colch�n ortop�dico, ventanas insonorizadas y aire acondicionado para un ambiente perfecto.' where id_habitacion = 6;


--- habitacion7 sede ny
update habitaciones set urlImagenServicio1 = '~/css/ducha2.jpg' where id_habitacion = 7;
update habitaciones set urlImagenServicio2 = '~/css/biblioteca.jpg' where id_habitacion = 7;
update habitaciones set descripcionBreve = 'Dise�ada para quienes buscan equilibrio entre trabajo y descanso, esta habitaci�n ofrece un escritorio amplio con l�mpara de lectura.' where id_habitacion = 7;

--- habitacion8 sede ny
update habitaciones set urlImagenServicio1 = '~/css/desayuno.jpg' where id_habitacion = 8;
update habitaciones set urlImagenServicio2 = '~/css/juegos.jpg' where id_habitacion = 8;
update habitaciones set descripcionBreve = 'Ideal para familias que buscan comodidad y flexibilidad, esta habitaci�n ofrece dos camas dobles y un sof� cama adicional, garantizando espacio para todos. Los m�s peque�os disfrutar�n de una zona de juegos exclusiva.' where id_habitacion = 8;

--- habitacion9 sede ny
update habitaciones set urlImagenServicio1 = '~/css/cenahabitacion.jpg' where id_habitacion = 9;
update habitaciones set urlImagenServicio2 = '~/css/sofahabitacion.jpg' where id_habitacion = 9;
update habitaciones set descripcionBreve = 'Dise�ada para ofrecer comodidad a toda la familia, esta habitaci�n cuenta con una cama king y una cama individual, adem�s de un �rea de descanso con sof� grande para compartir momentos especiales.' where id_habitacion = 9;

select * from tipo_habitaciones
select * from sedes

-- habitaciones de sede colombia
insert into habitaciones (id_tipo, id_sede, id_disponibilidad, urlImagen, Nombre, Calificacion, Descripcion, Precio, urlImagenServicio1, urlImagenServicio2, descripcionBreve) values
(1,2,1,'~/css/premiumcol1.jpg', 'Brisa de Coral','5.0','� Vista panor�mica al mar Caribe

� Balc�n con jacuzzi privado

� Decoraci�n con arte local exclusivo

� Cama King con s�banas de lino egipcio

� Amenidades de lujo

� Asistente virtual para servicios 24/7',1800000,'~/css/vistas.jpg', '~/css/jacuzzi.jpg', 'Refugio frente al mar con jacuzzi y lujo artesanal, ideal para escapar con estilo.'),
(1,2,1,'~/css/premiumcol2.jpg', 'Amanecer Real','4.9','� Ventanales de piso a techo

� Tina de hidromasaje frente al mar

� Minibar con selecci�n gourmet

� Iluminaci�n ambiental con control por voz

� Servicio de aromaterapia personalizado

� Cortinas t�rmicas autom�ticas',1650000,'~/css/minibar.jpg', '~/css/hidromasaje.jpg', 'Dise�ada para impresionar desde el primer rayo de sol hasta la �ltima nota arom�tica.'),
(1,2,1,'~/css/premiumcol3.jpg', 'Orqu�dea Marina','5.0','� Techos altos con vigas de madera tropical

� Ducha tipo cascada doble

� Terraza con comedor privado

� Acceso a piscina infinita exclusiva

� Obsequio de bienvenida artesanal

� Almohadas con men� personalizado',1650000,'~/css/balconprivado.jpg', '~/css/piscinainfi.jpg', 'Elegancia tropical con terraza privada, perfecta para desconectar con sofisticaci�n.'),
(3,2,1,'~/css/familiar1col.jpg', 'Arena Serena','4.7','� Sala de estar independiente

� Dos ba�os completos

� Cocina equipada

� Juegos de playa incluidos

� Balc�n con hamaca doble

� Capacidad para 5 personas',950000,'~/css/actividadninios.jpg', '~/css/cocinaplaya.jpg', 'Espaciosa y pensada para familias activas, con zona de juegos y vistas relajantes.'),
(3,2,1,'~/css/familiar2col.jpg', 'Cielo Caribe�o','4.5','� Dos camas queen y un sof� cama

� Cortinas blackout

� Cuna disponible bajo solicitud

� Frigobar con snacks para ni�os

� TV con canales infantiles

� Decoraci�n tem�tica costera',870000,'~/css/snackNinio.jpg', '~/css/cortinasBO.jpg', 'Decoraci�n costera y confort familiar, donde grandes y chicos se sienten en casa.'),
(3,2,1,'~/css/familiar3col.jpg', 'N�car del Sol','4.4','� Vista lateral al mar

� Escritorio para trabajo remoto

� Cama king + literas

� Zona de picnic privada

� Wifi de alta velocidad

� Aire acondicionado multisplit',820000,'~/css/vistaMar.jpg', '~/css/escritorioPlaya.jpg', 'Para familias modernas que buscan comodidad, conexi�n y brisa de mar.'),
(2,2,1,'~/css/basica1col.jpg', 'Bruma Serena','4.4','� Cama queen

� Ventilador de techo

� Ba�o con ducha sencilla

� Escritorio compacto

� Balc�n con silla playera

� Smart TV peque�a',230000,'~/css/sillaPlaya.jpg', '~/css/ventiladorTecho.jpg', 'Econ�mica y c�moda, con lo esencial para descansar tras un d�a en la playa.'),
(2,2,1,'~/css/basica2col.jpg', 'Luz de Playa','4.3','� Cama doble

� Vista al patio interior

� Cortinas ligeras

� Minibar peque�o

� TV con Netflix

� Ducha el�ctrica',150000,'~/css/cortinasLigeras.jpg', '~/css/barMini.jpg', 'Sencilla y c�lida, ideal para viajeros que priorizan el precio y la cercan�a al mar.')

-- Habitaciones de sede Barcelona
insert into habitaciones (
  id_tipo, id_sede, id_disponibilidad, urlImagen, Nombre, Calificacion, Descripcion,
  Precio, urlImagenServicio1, urlImagenServicio2, descripcionBreve
) values
-- Premium
(1,3,1,'~/css/premium1bar.jpg', 'Gaud� Suite', '4.9', '� Vista panor�mica a la Sagrada Familia

� Jacuzzi privado

� Terraza privada

� Cama King size

� Desayuno gourmet incluido

� Decoraci�n de autor catal�n

� Sistema de sonido envolvente', 1950000, '~/css/sagradaFamilia.jpg', '~/css/DesayunoPremium.jpg',
'Una suite inspirada en el arte catal�n con terraza y vistas privilegiadas.'),
(1,3,1,'~/css/premium2bar.jpg', 'Ramblas Deluxe', '4.8', '� Balc�n con vista a Las Ramblas

� Iluminaci�n inteligente

� Minibar premium

� M�quina de caf� Nespresso

� Escritorio de trabajo ergon�mico

� Ducha tipo lluvia

� Ropa de cama de lujo', 1720000, '~/css/CafeNess.jpg', '~/css/escritorioBar.jpg',
'Confort y dise�o en el coraz�n vibrante de Barcelona.'),
(1,3,1,'~/css/premium3bar.jpg', 'Mir� Sky Room', '4.7', '� Vista al skyline de Barcelona

� Ventanales de piso a techo

� Control de temperatura digital

� Televisor Smart 65"

� Cortinas el�ctricas

� Almohadas hipoalerg�nicas

� Servicio de mayordomo opcional', 1680000, '~/css/vistaBar.jpg', '~/css/Mayordomo.jpg',
'Altura, lujo y arte en una experiencia �nica sobre la ciudad.'),

-- Familiares
(3,3,1,'~/css/familiar1bar.jpg', 'Montju�c Family Room', '4.5', '� Dos camas queen

� Zona de juegos para ni�os

� Cocina equipada

� Sala de estar compartida

� Ba�o amplio con ba�era

� Cuna bajo solicitud

� TV 50" en �rea com�n', 1250000, '~/css/salaDeEstar.jpg', '~/css/juegosNinios.jpg',
'Amplia, c�moda y perfecta para familias que desean sentirse como en casa.'),
(3,3,1,'~/css/familiar2bar.jpg', 'Park G�ell Familiar', '4.6', '� Capacidad para 5 personas

� Dos habitaciones conectadas

� Microondas y nevera peque�a

� Decoraci�n inspirada en Gaud�

� Ropa de cama infantil disponible

� Escritorio para tareas o trabajo

� Juegos de mesa disponibles', 1350000, '~/css/cocinaBar02.jpg', '~/css/vistasBarc.jpg',
'Colores, dise�o y comodidad para toda la familia.'),
(3,3,1,'~/css/familiar3bar.jpg', 'Eixample Comfort', '4.4', '� Sof� cama adicional

� Cama matrimonial y cama individual

� Peque�o comedor

� Cocina abierta

� Smart TV con apps de streaming

� Ba�o privado con doble lavamanos

� Balc�n interno', 1150000, '~/css/banioPrivado.jpg', '~/css/comedorPequenio.jpg',
'Funcional y acogedora, perfecta para estancias familiares o de grupo.'),

-- B�sicas
(2,3,1,'~/css/basica1bar.jpg', 'Poble Studio', '3.8', '� Ubicaci�n c�ntrica

� Cama doble

� Peque�a zona de trabajo

� WiFi gratuito

� Ba�o privado con ducha

� Decoraci�n minimalista

� Ventilador de techo', 280000, '~/css/wifi.jpg', '~/css/ventiladorTecho.jpg',
'Ideal para viajeros pr�cticos que buscan buen precio y ubicaci�n.'),
(2,3,1,'~/css/basica2bar.jpg', 'Sants Compact Room', '4.0', '� TV 32" con cable

� Armario empotrado

� Escritorio compacto

� Cortinas blackout

� Caja fuerte

� Ba�o con agua caliente

� Aire acondicionado port�til', 310000, '~/css/EscritorioBarcelona.jpg', '~/css/cortinaoscura.jpg',
'Funcionalidad sin complicaciones en una ubicaci�n estrat�gica.'); 
