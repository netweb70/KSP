using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class DB_Context : DbContext
    {
        public DB_Context()
        {
        }

        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<DetallePrestamo> DetallePrestamo { get; set; } = null!;
        public virtual DbSet<NumeroDocumento> NumeroDocumentos { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamo { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Connection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240CED1907F1");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DetallePrestamo>(entity =>
            {
                entity.HasKey(e => e.IdDetallePrestamo)
                    .HasName("PK__DetalleV__BFE2843F851DE491");

                entity.Property(e => e.IdDetallePrestamo).HasColumnName("idDetallePrestamo");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Devuelta).HasColumnName("devuelta");

                entity.Property(e => e.IdLibro).HasColumnName("idLibro");

                entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.DetallePrestamo)
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("FK__DetalleVe__idPro__60A75C0F");

                entity.HasOne(d => d.IdPrestamoNavigation)
                    .WithMany(p => p.DetallePrestamo)
                    .HasForeignKey(d => d.IdPrestamo)
                    .HasConstraintName("FK__DetalleVe__idVen__5FB337D6");
            });

            modelBuilder.Entity<NumeroDocumento>(entity =>
            {
                entity.ToTable("NumeroDocumento");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__Libro__07F4A132B3DE1441");

                entity.ToTable("Libro");

                entity.Property(e => e.IdLibro).HasColumnName("idLibro");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Editorial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("editorial");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Libro__idCate__5812160E");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__3C872F76D60D3150");

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6E137D226");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Clave)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.EsActivo).HasColumnName("esActivo");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuario__idRol__3A81B327");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PK__Prestamo__077D5614D2880592");

                entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");

                entity.Property(e => e.DocumentoCliente)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("documentoCliente");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");


                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("numeroDocumento");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipoDocumento");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Prestamo)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Prestamo__idUsuario__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
