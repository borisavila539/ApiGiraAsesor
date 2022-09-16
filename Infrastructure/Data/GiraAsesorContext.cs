using Core.Entities;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Persistence.Data
{
    public partial class GiraAsesorContext : DbContext
    {
        public GiraAsesorContext()
        {
        }

        public GiraAsesorContext(DbContextOptions<GiraAsesorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaTipoGastoViajeEntity> CategoriaTipoGastoViaje { get; set; }
        public virtual DbSet<EstadoEntity> Estado { get; set; }
        public virtual DbSet<GastosViajeDetalleEntity> GastosViajeDetalle { get; set; }
        public virtual DbSet<TipoGastoViajeEntity> TipoGastoViaje { get; set; }
        public virtual DbSet<UsuariosEntity> Usuarios { get; set; }
        public virtual DbSet<EmpresaEntity> Empresa { get; set; }
        public virtual DbSet<MonedasxEmpresaEntity> MonedasxEmpresa { get; set; }
        public virtual DbSet<MaestroMonedaEntity> MaestroMoneda { get; set; }
        public virtual DbSet<UsuariosAsesoresEntity> UsuariosAsesores { get; set; }
        public virtual DbSet<UsuarioRolEntity> UsuarioRol { get; set; }
        public virtual DbSet<RolesEntity> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaTipoGastoViajeEntity>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaTipoGastoViaje)
                    .HasName("pkCategoriaTipoGastoViaje");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoGastoViajeNavigation)
                    .WithMany(p => p.CategoriaTipoGastoViaje)
                    .HasForeignKey(d => d.IdTipoGastoViaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCategoriaTipoGastoViaje");
            });

            modelBuilder.Entity<EstadoEntity>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("pkEstado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GastosViajeDetalleEntity>(entity =>
            {
                entity.HasKey(e => e.IdGastoViajeDetalle)
                    .HasName("pkGastosViajeDetalle");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionAdmin)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionGasto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaFactura).HasColumnType("date");

                entity.Property(e => e.Imagen);

                entity.Property(e => e.MensajeAx)
                    .HasColumnName("MensajeAX")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NoFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Proveedor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioAsesor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Administrador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaTipoGastoViajeNavigation)
                    .WithMany(p => p.GastosViajeDetalle)
                    .HasForeignKey(d => d.IdCategoriaTipoGastoViaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkGastosViajeDetalleCategoriaTipoGastoViaje");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.GastosViajeDetalle)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("fkGastosViajeDetalleEstado");
            });

            modelBuilder.Entity<TipoGastoViajeEntity>(entity =>
            {
                entity.HasKey(e => e.IdTipoGastoViaje)
                    .HasName("pkTipoGastoViaje");

                entity.HasIndex(e => e.Diario)
                    .HasName("ukTipoGastoViajeDiario")
                    .IsUnique();

                entity.Property(e => e.Diario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuariosEntity>(entity =>
            {
                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmpresaId)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FlagAdministradorProductos).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlagTodosAsesores).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<EmpresaEntity>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.EmpresaId)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.DocumentoFiscal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEmpresa)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.RegistroTributario).IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MonedasxEmpresaEntity>(entity =>
            {
                entity.HasKey(e => e.IdMonedaxEmpresa)
                    .HasName("PK__Monedasx__60A1F1DBE877DCB6");

                entity.Property(e => e.EmpresaId)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdMoneda)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.MonedasxEmpresa)
                    .HasForeignKey(d => d.IdMoneda)
                    .HasConstraintName("FK__MonedasxE__IdMon__3C89F72A");
            });

            modelBuilder.Entity<MaestroMonedaEntity>(entity =>
            {
                entity.HasKey(e => e.IdMoneda)
                    .HasName("PK__MaestroM__AA69067115CD65BA");

                entity.Property(e => e.IdMoneda)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Abreviacion)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Moneda)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuariosAsesoresEntity>(entity =>
            {
                entity.ToTable("Usuarios_Asesores");

                entity.Property(e => e.CodigoAsesor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            });

            modelBuilder.Entity<RolesEntity>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(75);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<UsuarioRolEntity>(entity =>
            {
                entity.ToTable("Usuario_Rol");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditedBy)
                    .IsRequired()
                    .HasColumnName("editedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditedDate)
                    .HasColumnName("editedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
