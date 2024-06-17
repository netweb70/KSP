﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DB_Context))]
    partial class DB_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCategoria");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("descripcion");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit")
                        .HasColumnName("esActivo");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaRegistro")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("IdCategoria")
                        .HasName("PK__Categori__8A3D240CED1907F1");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("API.Models.DetallePrestamo", b =>
                {
                    b.Property<int>("IdDetallePrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDetallePrestamo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetallePrestamo"), 1L, 1);

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<int?>("Devuelta")
                        .HasColumnType("int")
                        .HasColumnName("devuelta");

                    b.Property<int?>("IdLibro")
                        .HasColumnType("int")
                        .HasColumnName("idLibro");

                    b.Property<int?>("IdPrestamo")
                        .HasColumnType("int")
                        .HasColumnName("idPrestamo");

                    b.HasKey("IdDetallePrestamo")
                        .HasName("PK__DetalleV__BFE2843F851DE491");

                    b.HasIndex("IdLibro");

                    b.HasIndex("IdPrestamo");

                    b.ToTable("DetallePrestamo");
                });

            modelBuilder.Entity("API.Models.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idLibro");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLibro"), 1L, 1);

                    b.Property<string>("Codigo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("codigo");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Editorial")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("editorial");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit")
                        .HasColumnName("esActivo");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaRegistro")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("idCategoria");

                    b.Property<int?>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.HasKey("IdLibro")
                        .HasName("PK__Libro__07F4A132B3DE1441");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Libro", (string)null);
                });

            modelBuilder.Entity("API.Models.NumeroDocumento", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaRegistro")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id");

                    b.ToTable("NumeroDocumento", (string)null);
                });

            modelBuilder.Entity("API.Models.Prestamo", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPrestamo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestamo"), 1L, 1);

                    b.Property<string>("DocumentoCliente")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("documentoCliente");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaRegistro")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.Property<string>("NombreCliente")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("nombreCliente");

                    b.Property<string>("NumeroDocumento")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("numeroDocumento");

                    b.Property<string>("TipoDocumento")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipoDocumento");

                    b.HasKey("IdPrestamo")
                        .HasName("PK__Prestamo__077D5614D2880592");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("API.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("descripcion");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit")
                        .HasColumnName("esActivo");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaRegistro")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("IdRol")
                        .HasName("PK__Rol__3C872F76D60D3150");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("API.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Clave")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("clave");

                    b.Property<string>("Correo")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("correo");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit")
                        .HasColumnName("esActivo");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    b.Property<string>("Nombre")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("telefono");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__645723A6E137D226");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("API.Models.DetallePrestamo", b =>
                {
                    b.HasOne("API.Models.Libro", "IdLibroNavigation")
                        .WithMany("DetallePrestamo")
                        .HasForeignKey("IdLibro")
                        .HasConstraintName("FK__DetalleVe__idPro__60A75C0F");

                    b.HasOne("API.Models.Prestamo", "IdPrestamoNavigation")
                        .WithMany("DetallePrestamo")
                        .HasForeignKey("IdPrestamo")
                        .HasConstraintName("FK__DetalleVe__idVen__5FB337D6");

                    b.Navigation("IdLibroNavigation");

                    b.Navigation("IdPrestamoNavigation");
                });

            modelBuilder.Entity("API.Models.Libro", b =>
                {
                    b.HasOne("API.Models.Categoria", "IdCategoriaNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("FK__Libro__idCate__5812160E");

                    b.Navigation("IdCategoriaNavigation");
                });

            modelBuilder.Entity("API.Models.Prestamo", b =>
                {
                    b.HasOne("API.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Prestamo")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Prestamo__idUsuario__5CD6CB2B");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("API.Models.Usuario", b =>
                {
                    b.HasOne("API.Models.Rol", "IdRolNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .HasConstraintName("FK__Usuario__idRol__3A81B327");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("API.Models.Categoria", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("API.Models.Libro", b =>
                {
                    b.Navigation("DetallePrestamo");
                });

            modelBuilder.Entity("API.Models.Prestamo", b =>
                {
                    b.Navigation("DetallePrestamo");
                });

            modelBuilder.Entity("API.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("API.Models.Usuario", b =>
                {
                    b.Navigation("Prestamo");
                });
#pragma warning restore 612, 618
        }
    }
}
