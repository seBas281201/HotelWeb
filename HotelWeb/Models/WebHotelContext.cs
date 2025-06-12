using System;
using System.Collections.Generic;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code.
        // optionsBuilder.UseSqlServer("Server=SEBASPC\\MSSQLSERVER01; Database=WebHotel; Trusted_Connection=True; TrustServerCertificate=True;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Disponibilidade>(entity =>
        {
            entity.HasKey(e => e.IdDisponibilidad).HasName("PK__disponib__319B171B8CB77451");

            entity.ToTable("disponibilidades");

            entity.Property(e => e.IdDisponibilidad).HasColumnName("id_disponibilidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<Fecha>(entity =>
        {
            entity.HasKey(e => e.IdFecha).HasName("PK__fechas__E9FBC1BFF7E6DF3A");

            entity.ToTable("fechas");

            entity.Property(e => e.IdFecha).HasColumnName("id_fecha");
            entity.Property(e => e.Fecha1).HasColumnName("fecha");
            entity.Property(e => e.IdDisponibilidad).HasColumnName("id_disponibilidad");

            entity.HasOne(d => d.IdDisponibilidadNavigation).WithMany(p => p.Fechas)
                .HasForeignKey(d => d.IdDisponibilidad)
                .HasConstraintName("FK__fechas__id_dispo__6754599E");
        });

        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__habitaci__773F28F3F65B0E7E");

            entity.ToTable("habitaciones");

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.IdDisponibilidad).HasColumnName("id_disponibilidad");
            entity.Property(e => e.IdSede).HasColumnName("id_sede");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

            entity.HasOne(d => d.IdDisponibilidadNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdDisponibilidad)
                .HasConstraintName("FK__habitacio__id_di__6477ECF3");

            entity.HasOne(d => d.IdSedeNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdSede)
                .HasConstraintName("FK__habitacio__id_se__6383C8BA");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__habitacio__id_ti__628FA481");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__reservas__423CBE5D6B99BAC4");

            entity.ToTable("reservas");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdFecha).HasColumnName("id_fecha");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdFechaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdFecha)
                .HasConstraintName("FK__reservas__id_fec__6B24EA82");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__reservas__id_hab__6A30C649");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__reservas__id_usu__6C190EBB");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__6ABCB5E0EDB3E69E");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.IdSede).HasName("PK__sedes__D693504B01A605C8");

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
            entity.HasKey(e => e.IdTipo).HasName("PK__tipo_hab__CF901089F00E2B0D");

            entity.ToTable("tipo_habitaciones");

            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.Categoria)
                .HasMaxLength(60)
                .HasColumnName("categoria");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD43A1E562");

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
                .HasConstraintName("FK__usuarios__id_rol__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
