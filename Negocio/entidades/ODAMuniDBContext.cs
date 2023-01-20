using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MuniApp.Negocio.entidades;

public partial class ODAMuniDBContext : DbContext
{
    public ODAMuniDBContext()
    {
    }

    public ODAMuniDBContext(DbContextOptions<ODAMuniDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActualizacionCobroDetalle> ActualizacionCobroDetalle { get; set; }

    public virtual DbSet<ActualizacionEvent> ActualizacionEvent { get; set; }

    public virtual DbSet<Anio> Anio { get; set; }

    public virtual DbSet<Arqueo> Arqueo { get; set; }

    public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }

    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    public virtual DbSet<Auditoria> Auditoria { get; set; }

    public virtual DbSet<Cobro> Cobro { get; set; }

    public virtual DbSet<CobroDetalle> CobroDetalle { get; set; }

    public virtual DbSet<CobroRelacion> CobroRelacion { get; set; }

    public virtual DbSet<CobroTipo> CobroTipo { get; set; }

    public virtual DbSet<Deuda> Deuda { get; set; }

    public virtual DbSet<DeudaDetalle> DeudaDetalle { get; set; }

    public virtual DbSet<DeudasMigracion> DeudasMigracion { get; set; }

    public virtual DbSet<Domicilio> Domicilio { get; set; }

    public virtual DbSet<Entidad> Entidad { get; set; }

    public virtual DbSet<EstadoPago> EstadoPago { get; set; }

    public virtual DbSet<EventVieja> EventVieja { get; set; }

    public virtual DbSet<Eventualidad> Eventualidad { get; set; }

    public virtual DbSet<Pago> Pago { get; set; }

    public virtual DbSet<PagoDetalle> PagoDetalle { get; set; }

    public virtual DbSet<PagoTipo> PagoTipo { get; set; }

    public virtual DbSet<Perfil> Perfil { get; set; }

    public virtual DbSet<Periodo> Periodo { get; set; }

    public virtual DbSet<PeriodoTipo> PeriodoTipo { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<PersonaEntidad> PersonaEntidad { get; set; }

    public virtual DbSet<PersonaEntidadDeudaDetalle> PersonaEntidadDeudaDetalle { get; set; }

    public virtual DbSet<PersonaEstado> PersonaEstado { get; set; }

    public virtual DbSet<PersonaTipo> PersonaTipo { get; set; }

    public virtual DbSet<Rubro> Rubro { get; set; }

    public virtual DbSet<UsuarioReferencia> UsuarioReferencia { get; set; }

    public virtual DbSet<__MigrationHistory> __MigrationHistory { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ODAMuniDB;Data Source=localhost\\SQLEXPRESS;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<ActualizacionCobroDetalle>(entity =>
        {
            entity.HasKey(e => e.idActRelacion);

            entity.HasOne(d => d.CobroDetalle).WithMany(p => p.ActualizacionCobroDetalle)
                .HasForeignKey(d => d.CobroDetalleId)
                .HasConstraintName("FK_ActualizacionCobroDetalle_CobroDetalle");

            entity.HasOne(d => d.idActNavigation).WithMany(p => p.ActualizacionCobroDetalle)
                .HasForeignKey(d => d.idAct)
                .HasConstraintName("FK_ActualizacionCobroDetalle_ActualizacionEvent");
        });

        modelBuilder.Entity<ActualizacionEvent>(entity =>
        {
            entity.HasKey(e => e.idAct);

            entity.Property(e => e.MontoNueva).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoVieja).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Anio>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Arqueo>(entity =>
        {
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Faltante).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.Finalizado).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoraFin)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoraInicio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Iniciado).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Sobrante).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalEfectivo).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.UsuarioFinalizo).WithMany(p => p.ArqueoUsuarioFinalizo)
                .HasForeignKey(d => d.UsuarioFinalizoId)
                .HasConstraintName("FK_Arqueo_UsuarioReferencia1");

            entity.HasOne(d => d.UsuarioIncio).WithMany(p => p.ArqueoUsuarioIncio)
                .HasForeignKey(d => d.UsuarioIncioId)
                .HasConstraintName("FK_Arqueo_UsuarioReferencia");
        });

        modelBuilder.Entity<AspNetRoles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.HasIndex(e => e.Name, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUserClaims>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogins>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserRoles>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK_dbo.AspNetUserRoles");

            entity.HasIndex(e => e.RoleId, "IX_RoleId");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.UserId).HasMaxLength(128);
            entity.Property(e => e.RoleId).HasMaxLength(128);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");
        });

        modelBuilder.Entity<AspNetUsers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.HasIndex(e => e.UserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Perfil).WithMany(p => p.AspNetUsers)
                .HasForeignKey(d => d.PerfilId)
                .HasConstraintName("FK_AspNetUsers_Perfil");

            entity.HasOne(d => d.Usuario).WithMany(p => p.AspNetUsers)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetUsers_UsuarioReferencia");
        });

        modelBuilder.Entity<Auditoria>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
        });

        modelBuilder.Entity<Cobro>(entity =>
        {
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Descuento).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Final).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Recargo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecuenciaId)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Arqueo).WithMany(p => p.Cobro)
                .HasForeignKey(d => d.ArqueoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cobro_Arqueo");

            entity.HasOne(d => d.Persona).WithMany(p => p.Cobro)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cobro_Persona");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Cobro)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Cobro_UsuarioReferencia");
        });

        modelBuilder.Entity<CobroDetalle>(entity =>
        {
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cobro).WithMany(p => p.CobroDetalle)
                .HasForeignKey(d => d.CobroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CobroDetalle_Cobro");

            entity.HasOne(d => d.Eventualidad).WithMany(p => p.CobroDetalle)
                .HasForeignKey(d => d.EventualidadId)
                .HasConstraintName("FK_CobroDetalle_Eventualidad");

            entity.HasOne(d => d.PersonaEntidadDeudaDetalle).WithMany(p => p.CobroDetalle)
                .HasForeignKey(d => d.PersonaEntidadDeudaDetalleId)
                .HasConstraintName("FK_CobroDetalle_PersonaEntidadDeudaDetalle");
        });

        modelBuilder.Entity<CobroRelacion>(entity =>
        {
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.MontoCobrado).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cobro).WithMany(p => p.CobroRelacion)
                .HasForeignKey(d => d.CobroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CobroRelacion_Cobro");

            entity.HasOne(d => d.CobroTipo).WithMany(p => p.CobroRelacion)
                .HasForeignKey(d => d.CobroTipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CobroRelacion_CobroTipo");
        });

        modelBuilder.Entity<CobroTipo>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Deuda>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.Interes).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Observacion).IsUnicode(false);
            entity.Property(e => e.Padron)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Anio).WithMany(p => p.Deuda)
                .HasForeignKey(d => d.AnioId)
                .HasConstraintName("FK_Deuda_Anio");

            entity.HasOne(d => d.PeriodoTipo).WithMany(p => p.Deuda)
                .HasForeignKey(d => d.PeriodoTipoId)
                .HasConstraintName("FK_Deuda_PeriodoTipoId");

            entity.HasOne(d => d.PersonaTipo).WithMany(p => p.Deuda)
                .HasForeignKey(d => d.PersonaTipoId)
                .HasConstraintName("FK_Deuda_PersonaTipo");

            entity.HasOne(d => d.Rubro).WithMany(p => p.Deuda)
                .HasForeignKey(d => d.RubroId)
                .HasConstraintName("FK_Deuda_Rubro");
        });

        modelBuilder.Entity<DeudaDetalle>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Recargo).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Deuda).WithMany(p => p.DeudaDetalle)
                .HasForeignKey(d => d.DeudaId)
                .HasConstraintName("FK_DeudaDetalle_Deuda");

            entity.HasOne(d => d.Periodo).WithMany(p => p.DeudaDetalle)
                .HasForeignKey(d => d.PeriodoId)
                .HasConstraintName("FK_DeudaDetalle_Periodo");
        });

        modelBuilder.Entity<DeudasMigracion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CUIT).HasMaxLength(255);
            entity.Property(e => e.Migrado).HasDefaultValueSql("((0))");
            entity.Property(e => e.Padron).HasMaxLength(255);
            entity.Property(e => e.Periodos).HasMaxLength(255);
        });

        modelBuilder.Entity<Domicilio>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Barrio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PersonaEntidad).WithMany(p => p.Domicilio)
                .HasForeignKey(d => d.PersonaEntidadId)
                .HasConstraintName("FK_Domicilio_PersonaEntidad");

            entity.HasOne(d => d.Persona).WithMany(p => p.Domicilio)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("FK_Domicilio_Persona");
        });

        modelBuilder.Entity<Entidad>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Rubro).WithMany(p => p.Entidad)
                .HasForeignKey(d => d.RubroId)
                .HasConstraintName("FK_Entidad_Rubro");
        });

        modelBuilder.Entity<EstadoPago>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EventVieja>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Eventualidad>(entity =>
        {
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Descripción).IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(5000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Hora)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoNeto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PagoReferencia).IsUnicode(false);
            entity.Property(e => e.Referencia)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.CobroDetalle).WithMany(p => p.Pago)
                .HasForeignKey(d => d.CobroDetalleId)
                .HasConstraintName("FK_Pago_CobroDetalle");

            entity.HasOne(d => d.EstadoPago).WithMany(p => p.Pago)
                .HasForeignKey(d => d.EstadoPagoId)
                .HasConstraintName("FK_Pago_EstadoPago");

            entity.HasOne(d => d.PagoDetalle).WithMany(p => p.Pago)
                .HasForeignKey(d => d.PagoDetalleId)
                .HasConstraintName("FK_Pago_PagoDetalle");

            entity.HasOne(d => d.PagoTipo).WithMany(p => p.Pago)
                .HasForeignKey(d => d.PagoTipoId)
                .HasConstraintName("FK_Pago_PagoTipo");

            entity.HasOne(d => d.PersonaEntidadDeutaDetalle).WithMany(p => p.Pago)
                .HasForeignKey(d => d.PersonaEntidadDeutaDetalleId)
                .HasConstraintName("FK_Pago_PersonaEntidadDeudaDetalle");
        });

        modelBuilder.Entity<PagoDetalle>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.SecuenciaId)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.collection_status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.external_reference)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.merchant_account_id)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.net_received_amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.payment_type)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.preference_id)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.processing_mode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.site_id)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.total_paid_amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.transaction_amount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Persona).WithMany(p => p.PagoDetalle)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("FK_PagoDetalle_Persona");
        });

        modelBuilder.Entity<PagoTipo>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PeriodoTipo).WithMany(p => p.Periodo)
                .HasForeignKey(d => d.PeriodoTipoId)
                .HasConstraintName("FK_Periodo_PeriodoTipoId");
        });

        modelBuilder.Entity<PeriodoTipo>(entity =>
        {
            entity.HasKey(e => e.PeriodoTipoId).HasName("PK_PeriodoTipoId");

            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.ActualizoDeuda).HasDefaultValueSql("((0))");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CUIT)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("date");
            entity.Property(e => e.FechaUltimaActualizacion).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.PersonaEstado).WithMany(p => p.Persona)
                .HasForeignKey(d => d.PersonaEstadoId)
                .HasConstraintName("FK_Persona_PersonaEstado");

            entity.HasOne(d => d.PersonaTipo).WithMany(p => p.Persona)
                .HasForeignKey(d => d.PersonaTipoId)
                .HasConstraintName("FK_Persona_PersonaTipo");
        });

        modelBuilder.Entity<PersonaEntidad>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Entidad).WithMany(p => p.PersonaEntidad)
                .HasForeignKey(d => d.EntidadId)
                .HasConstraintName("FK_PersonaEntidad_Entidad");

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonaEntidad)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("FK_PersonaEntidad_Persona");
        });

        modelBuilder.Entity<PersonaEntidadDeudaDetalle>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Anulado).HasDefaultValueSql("((0))");
            entity.Property(e => e.FechaPago).HasColumnType("date");
            entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Mora).HasDefaultValueSql("((0))");
            entity.Property(e => e.PrePago).HasDefaultValueSql("((0))");
            entity.Property(e => e.Recargo).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.DeudaDetalle).WithMany(p => p.PersonaEntidadDeudaDetalle)
                .HasForeignKey(d => d.DeudaDetalleId)
                .HasConstraintName("FK_PersonaEntidadDeudaDetalle_DeudaDetalle");

            entity.HasOne(d => d.PersonaEntidad).WithMany(p => p.PersonaEntidadDeudaDetalle)
                .HasForeignKey(d => d.PersonaEntidadId)
                .HasConstraintName("FK_PersonaEntidadDeudaDetalle_PersonaEntidad");

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonaEntidadDeudaDetalle)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("FK_PersonaEntidadDeudaDetalle_Persona");

            entity.HasOne(d => d.UsuarioIdAnuloNavigation).WithMany(p => p.PersonaEntidadDeudaDetalle)
                .HasForeignKey(d => d.UsuarioIdAnulo)
                .HasConstraintName("FK_PersonaEntidadDeudaDetalle_UsuarioReferencia");
        });

        modelBuilder.Entity<PersonaEstado>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PersonaTipo>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rubro>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioReferencia>(entity =>
        {
            entity.HasKey(e => e.UsuarioRefId);

            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.AspNetUsersId).HasMaxLength(128);
        });

        modelBuilder.Entity<__MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
