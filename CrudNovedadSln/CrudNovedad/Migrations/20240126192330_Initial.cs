using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudNovedad.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListaDeVariablesSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadDeMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaDeVariablesSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoNovSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNovSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NovedadSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagenes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoNovId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovedadSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovedadSet_TipoNovSet_TipoNovId",
                        column: x => x.TipoNovId,
                        principalTable: "TipoNovSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovedadSet_TipoNovId",
                table: "NovedadSet",
                column: "TipoNovId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaDeVariablesSet");

            migrationBuilder.DropTable(
                name: "NovedadSet");

            migrationBuilder.DropTable(
                name: "TipoNovSet");
        }
    }
}
