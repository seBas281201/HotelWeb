using System;
using System.Collections.Generic;
using HotelWeb.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Models;

public partial class WebHotelContext : DbContext
{
    public WebHotelContext()
    {
    }

    public WebHotelContext(DbContextOptions<WebHotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Disponibilidade> Disponibilidades { get; set; }

    public virtual DbSet<Fecha> Fechas { get; set; }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<TipoHabitacione> TipoHabitaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public DbSet<MisReservasVM> MisReservasVMs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Disponibilidade>(entity =>
        {
            entity.HasKey(e => e.IdDisponibilidad).HasName("PK__disponib__319B171B8B674D70");

            entity.ToTable("disponibilidades");

            entity.Property(e => e.IdDisponibilidad).HasColumnName("id_disponibilidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<MisReservasVM>().HasNoKey().ToView(null);

        modelBuilder.Entity<Fecha>(entity =>
        {
            entity.HasKey(e => e.IdFecha).HasName("PK__fechas__E9FBC1BFB906238F");

            entity.ToTable("fechas");

            entity.Property(e => e.IdFecha).HasColumnName("id_fecha");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaSalida).HasColumnName("fecha_salida");
            entity.Property(e => e.IdDisponibilidad).HasColumnName("id_disponibilidad");

            entity.HasOne(d => d.IdDisponibilidadNavigation).WithMany(p => p.Fechas)
                .HasForeignKey(d => d.IdDisponibilidad)
                .HasConstraintName("FK__fechas__id_dispo__01142BA1");
        });

        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__habitaci__773F28F323F83F7E");

            entity.ToTable("habitaciones");

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.Calificacion).HasMaxLength(3);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.DescripcionBreve)
                .HasColumnType("text")
                .HasColumnName("descripcionBreve");
            entity.Property(e => e.IdDisponibilidad).HasColumnName("id_disponibilidad");
            entity.Property(e => e.IdSede).HasColumnName("id_sede");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.Nombre).HasMaxLength(60);
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(60)
                .HasColumnName("urlImagen");
            entity.Property(e => e.UrlImagenServicio1)
                .HasMaxLength(60)
                .HasColumnName("urlImagenServicio1");
            entity.Property(e => e.UrlImagenServicio2)
                .HasMaxLength(60)
                .HasColumnName("urlImagenServicio2");

            entity.HasOne(d => d.IdDisponibilidadNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdDisponibilidad)
                .HasConstraintName("FK__habitacio__id_di__571DF1D5");

            entity.HasOne(d => d.IdSedeNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdSede)
                .HasConstraintName("FK__habitacio__id_se__5629CD9C");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__habitacio__id_ti__5535A963");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__reservas__423CBE5D61EC6C28");

            entity.ToTable("reservas");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdFecha).HasColumnName("id_fecha");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NroHuespedes).HasColumnName("nro_huespedes");

            entity.HasOne(d => d.IdFechaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdFecha)
                .HasConstraintName("FK__reservas__id_fec__5DCAEF64");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__reservas__id_hab__5CD6CB2B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__reservas__id_usu__5EBF139D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__6ABCB5E01C23265A");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede).HasName("PK__sedes__D693504B272C12A9");

            entity.ToTable("sedes");

            entity.Property(e => e.IdSede).HasColumnName("id_sede");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(60)
                .HasColumnName("ciudad");
            entity.Property(e => e.NroHabitaciones).HasColumnName("nro_habitaciones");
            entity.Property(e => e.Pais)
                .HasMaxLength(60)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<TipoHabitacione>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__tipo_hab__CF901089A0C1E653");

            entity.ToTable("tipo_habitaciones");

            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.Categoria)
                .HasMaxLength(60)
                .HasColumnName("categoria");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD39FFF7CD");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(60)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .HasColumnName("correo");
            entity.Property(e => e.IdRol)
                .HasDefaultValue(1)
                .HasColumnName("id_rol");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__usuarios__id_rol__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
