using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    esActivo = table.Column<bool>(type: "bit", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__8A3D240CED1907F1", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "NumeroDocumento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroDocumento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    idRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    esActivo = table.Column<bool>(type: "bit", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__3C872F76D60D3150", x => x.idRol);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    idLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    editorial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    idCategoria = table.Column<int>(type: "int", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true),
                    esActivo = table.Column<bool>(type: "bit", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Libro__07F4A132B3DE1441", x => x.idLibro);
                    table.ForeignKey(
                        name: "FK__Libro__idCate__5812160E",
                        column: x => x.idCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    correo = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    telefono = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    idRol = table.Column<int>(type: "int", nullable: true),
                    clave = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    esActivo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A6E137D226", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__idRol__3A81B327",
                        column: x => x.idRol,
                        principalTable: "Rol",
                        principalColumn: "idRol");
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    idPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroDocumento = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    tipoDocumento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    documentoCliente = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    nombreCliente = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prestamo__077D5614D2880592", x => x.idPrestamo);
                    table.ForeignKey(
                        name: "FK__Prestamo__idUsuario__5CD6CB2B",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "DetallePrestamo",
                columns: table => new
                {
                    idDetallePrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPrestamo = table.Column<int>(type: "int", nullable: true),
                    idLibro = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    devuelta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleV__BFE2843F851DE491", x => x.idDetallePrestamo);
                    table.ForeignKey(
                        name: "FK__DetalleVe__idPro__60A75C0F",
                        column: x => x.idLibro,
                        principalTable: "Libro",
                        principalColumn: "idLibro");
                    table.ForeignKey(
                        name: "FK__DetalleVe__idVen__5FB337D6",
                        column: x => x.idPrestamo,
                        principalTable: "Prestamo",
                        principalColumn: "idPrestamo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePrestamo_idLibro",
                table: "DetallePrestamo",
                column: "idLibro");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePrestamo_idPrestamo",
                table: "DetallePrestamo",
                column: "idPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_idCategoria",
                table: "Libro",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_idUsuario",
                table: "Prestamo",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idRol",
                table: "Usuario",
                column: "idRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePrestamo");

            migrationBuilder.DropTable(
                name: "NumeroDocumento");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
