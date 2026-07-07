using api.Models;
using API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace api.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Guium> Guia { get; set; }
    public virtual DbSet<Horario> Horarios { get; set; }
    public virtual DbSet<Operador> Operadors { get; set; }
    public virtual DbSet<Pago> Pagos { get; set; }
    public virtual DbSet<Resena> Resenas { get; set; }
    public virtual DbSet<Reservacion> Reservacions { get; set; }
    public virtual DbSet<Tour> Tours { get; set; }
    public virtual DbSet<UsuarioSistema> UsuarioSistemas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("pk_cliente");
            entity.ToTable("cliente", "tt");
            entity.HasIndex(e => e.Gmail, "uq_cliente_gmail").IsUnique();
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido).HasMaxLength(80).IsUnicode(false).HasColumnName("apellido");
            entity.Property(e => e.FechaRegistro).HasPrecision(0).HasDefaultValueSql("(sysdatetime())").HasColumnName("fecha_registro");
            entity.Property(e => e.Gmail).HasMaxLength(120).IsUnicode(false).HasColumnName("gmail");
            entity.Property(e => e.Nombre).HasMaxLength(80).IsUnicode(false).HasColumnName("nombre");
            entity.Property(e => e.PaisOrigen).HasMaxLength(80).IsUnicode(false).HasColumnName("pais_origen");
            entity.Property(e => e.Telefono).HasMaxLength(20).IsUnicode(false).HasColumnName("telefono");
        });

        modelBuilder.Entity<Guium>(entity =>
        {
            entity.HasKey(e => e.IdGuia).HasName("pk_guia");
            entity.ToTable("guia", "tt");
            entity.HasIndex(e => e.Telefono, "uq_guia_telefono").IsUnique();
            entity.Property(e => e.IdGuia).HasColumnName("id_guia");
            entity.Property(e => e.Apellido).HasMaxLength(80).IsUnicode(false).HasColumnName("apellido");
            entity.Property(e => e.Especialidad).HasMaxLength(100).IsUnicode(false).HasColumnName("especialidad");
            entity.Property(e => e.Estado).HasMaxLength(15).IsUnicode(false).HasDefaultValue("ACTIVO").HasColumnName("estado");
            entity.Property(e => e.IdTour).HasColumnName("id_tour");
            entity.Property(e => e.Nombre).HasMaxLength(80).IsUnicode(false).HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasMaxLength(20).IsUnicode(false).HasColumnName("telefono");
            entity.HasOne(d => d.IdTourNavigation).WithMany(p => p.Guia)
                .HasForeignKey(d => d.IdTour).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_guia_tour");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("pk_horario");
            entity.ToTable("horario", "tt");
            entity.HasIndex(e => new { e.IdTour, e.Fecha, e.Hora }, "uq_horario_tour_fecha_hora").IsUnique();
            entity.Property(e => e.IdHorario).HasColumnName("id_horario");
            entity.Property(e => e.CuposDisponible).HasColumnName("cupos_disponible");
            entity.Property(e => e.Estado).HasMaxLength(15).IsUnicode(false).HasDefaultValue("DISPONIBLE").HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasPrecision(0).HasColumnName("hora");
            entity.Property(e => e.IdGuia).HasColumnName("id_guia");
            entity.Property(e => e.IdTour).HasColumnName("id_tour");
            entity.HasOne(d => d.IdGuiaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdGuia).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_horario_guia");
            entity.HasOne(d => d.IdTourNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdTour).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_horario_tour");
        });

        modelBuilder.Entity<Operador>(entity =>
        {
            entity.HasKey(e => e.IdOperador).HasName("pk_operador");
            entity.ToTable("operador", "tt");
            entity.HasIndex(e => e.Email, "uq_operador_email").IsUnique();
            entity.Property(e => e.IdOperador).HasColumnName("id_operador");
            entity.Property(e => e.ComisionesPorcentaje).HasDefaultValue(2.00m).HasColumnType("decimal(5, 2)").HasColumnName("comisiones_porcentaje");
            entity.Property(e => e.Email).HasMaxLength(120).IsUnicode(false).HasColumnName("email");
            entity.Property(e => e.Estado).HasMaxLength(15).IsUnicode(false).HasDefaultValue("ACTIVO").HasColumnName("estado");
            entity.Property(e => e.FechaRegistro).HasPrecision(0).HasDefaultValueSql("(sysdatetime())").HasColumnName("fecha_registro");
            entity.Property(e => e.NombreNegocio).HasMaxLength(100).IsUnicode(false).HasColumnName("nombre_negocio");
            entity.Property(e => e.PlanSuscripcion).HasMaxLength(20).IsUnicode(false).HasColumnName("plan_suscripcion");
            entity.Property(e => e.Telefono).HasMaxLength(20).IsUnicode(false).HasColumnName("telefono");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("pk_pago");
            entity.ToTable("pago", "tt");
            entity.HasIndex(e => e.ReferenciaExterna, "uq_pago_referencia").IsUnique();
            entity.HasIndex(e => e.IdReserva, "uq_pago_reserva").IsUnique();
            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.Estado).HasMaxLength(15).IsUnicode(false).HasDefaultValue("PENDIENTE").HasColumnName("estado");
            entity.Property(e => e.FechaPago).HasPrecision(0).HasDefaultValueSql("(sysdatetime())").HasColumnName("fecha_pago");
            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.Metodo).HasMaxLength(20).IsUnicode(false).HasColumnName("metodo");
            entity.Property(e => e.Moneda).HasMaxLength(5).IsUnicode(false).HasColumnName("moneda");
            entity.Property(e => e.Monto).HasColumnType("decimal(12, 2)").HasColumnName("monto");
            entity.Property(e => e.ReferenciaExterna).HasMaxLength(100).IsUnicode(false).HasColumnName("referencia_externa");
            entity.HasOne(d => d.IdReservaNavigation).WithOne(p => p.Pago)
                .HasForeignKey<Pago>(d => d.IdReserva).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_pago_reservacion");
        });

        modelBuilder.Entity<Resena>(entity =>
        {
            entity.HasKey(e => e.IdResena).HasName("pk_resena");
            entity.ToTable("resena", "tt");
            entity.HasIndex(e => new { e.IdCliente, e.IdTour }, "uq_resena_cliente_tour").IsUnique();
            entity.Property(e => e.IdResena).HasColumnName("id_resena");
            entity.Property(e => e.FechaResena).HasPrecision(0).HasDefaultValueSql("(sysdatetime())").HasColumnName("fecha_resena");
            entity.Property(e => e.Gmail).HasMaxLength(120).IsUnicode(false).HasColumnName("gmail");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdTour).HasColumnName("id_tour");
            entity.Property(e => e.Resena1).HasMaxLength(500).IsUnicode(false).HasColumnName("resena");
            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.IdCliente).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_resena_cliente");
            entity.HasOne(d => d.IdTourNavigation).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.IdTour).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_resena_tour");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("pk_reservacion");
            entity.ToTable("reservacion", "tt");
            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.CantidadPersonas).HasColumnName("cantidad_personas");
            entity.Property(e => e.Estado).HasMaxLength(15).IsUnicode(false).HasDefaultValue("PENDIENTE").HasColumnName("estado");
            entity.Property(e => e.FechaCreacion).HasPrecision(0).HasDefaultValueSql("(sysdatetime())").HasColumnName("fecha_creacion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdHorario).HasColumnName("id_horario");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(12, 2)").HasColumnName("monto_total");
            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdCliente).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_reservacion_cliente");
            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdHorario).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_reservacion_horario");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.IdTour).HasName("pk_tour");
            entity.ToTable("tour", "tt");
            entity.HasIndex(e => new { e.IdOperador, e.Nombre }, "uq_tour_operador_nombre").IsUnique();
            entity.Property(e => e.IdTour).HasColumnName("id_tour");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Descripcion).HasMaxLength(500).IsUnicode(false).HasColumnName("descripcion");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.Estado).HasMaxLength(15).IsUnicode(false).HasDefaultValue("ACTIVO").HasColumnName("estado");
            entity.Property(e => e.IdOperador).HasColumnName("id_operador");
            entity.Property(e => e.Nombre).HasMaxLength(100).IsUnicode(false).HasColumnName("nombre");
            entity.Property(e => e.PrecioColones).HasColumnType("decimal(12, 2)").HasColumnName("precio_colones");
            entity.Property(e => e.PrecioUsd).HasColumnType("decimal(10, 2)").HasColumnName("precio_usd");
            entity.HasOne(d => d.IdOperadorNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.IdOperador).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_tour_operador");
        });

        modelBuilder.Entity<UsuarioSistema>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("pk_usuario_sistema");
            entity.ToTable("usuario_sistema", "tt");
            entity.HasIndex(e => e.Correo, "uq_usuario_correo").IsUnique();
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ContrasenaHash).HasMaxLength(200).IsUnicode(false).HasColumnName("contrasena_hash");
            entity.Property(e => e.Correo).HasMaxLength(120).IsUnicode(false).HasColumnName("correo");
            entity.Property(e => e.Estado).HasMaxLength(15).IsUnicode(false).HasDefaultValue("ACTIVO").HasColumnName("estado");
            entity.Property(e => e.FechaRegistro).HasPrecision(0).HasDefaultValueSql("(sysdatetime())").HasColumnName("fecha_registro");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdOperador).HasColumnName("id_operador");
            entity.Property(e => e.Rol).HasMaxLength(20).IsUnicode(false).HasColumnName("rol");
            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.UsuarioSistemas)
                .HasForeignKey(d => d.IdCliente).HasConstraintName("fk_usuario_cliente");
            entity.HasOne(d => d.IdOperadorNavigation).WithMany(p => p.UsuarioSistemas)
                .HasForeignKey(d => d.IdOperador).HasConstraintName("fk_usuario_operador");
        });

        // ← PASO 7: Registrar TourResult y MensajeResult
        modelBuilder.Entity<TourResult>().HasNoKey();
        modelBuilder.Entity<MensajeResult>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }

    public async Task<List<TourResult>> sp_ObtenerTours(int? idOperador = null)
    {
        return await Database.SqlQueryRaw<TourResult>(
            "EXEC tt.sp_ObtenerTours @IdOperador",
            new SqlParameter("@IdOperador", (object?)idOperador ?? DBNull.Value)
        ).ToListAsync();
    }

    public async Task<TourResult?> sp_CrearTour(
        int idOperador, string nombre, string? descripcion,
        decimal precioUsd, decimal precioColones, int capacidad, int duracion)
    {
        var result = await Database.SqlQueryRaw<TourResult>(
            "EXEC tt.sp_CrearTour @IdOperador, @Nombre, @Descripcion, @PrecioUsd, @PrecioColones, @Capacidad, @Duracion",
            new SqlParameter("@IdOperador", idOperador),
            new SqlParameter("@Nombre", nombre),
            new SqlParameter("@Descripcion", (object?)descripcion ?? DBNull.Value),
            new SqlParameter("@PrecioUsd", precioUsd),
            new SqlParameter("@PrecioColones", precioColones),
            new SqlParameter("@Capacidad", capacidad),
            new SqlParameter("@Duracion", duracion)
        ).ToListAsync();
        return result.FirstOrDefault();
    }

    public async Task<TourResult?> sp_ActualizarTour(
        int idTour, string? nombre, string? descripcion,
        decimal? precioUsd, decimal? precioColones, int? capacidad, int? duracion)
    {
        return await Database.SqlQueryRaw<TourResult>(
            "EXEC tt.sp_ActualizarTour @IdTour, @Nombre, @Descripcion, @PrecioUsd, @PrecioColones, @Capacidad, @Duracion",
            new SqlParameter("@IdTour", idTour),
            new SqlParameter("@Nombre", (object?)nombre ?? DBNull.Value),
            new SqlParameter("@Descripcion", (object?)descripcion ?? DBNull.Value),
            new SqlParameter("@PrecioUsd", (object?)precioUsd ?? DBNull.Value),
            new SqlParameter("@PrecioColones", (object?)precioColones ?? DBNull.Value),
            new SqlParameter("@Capacidad", (object?)capacidad ?? DBNull.Value),
            new SqlParameter("@Duracion", (object?)duracion ?? DBNull.Value)
        ).FirstOrDefaultAsync();
    }

    public async Task<MensajeResult?> sp_EliminarTour(int idTour)
    {
        return await Database.SqlQueryRaw<MensajeResult>(
            "EXEC tt.sp_EliminarTour @IdTour",
            new SqlParameter("@IdTour", idTour)
        ).FirstOrDefaultAsync();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}