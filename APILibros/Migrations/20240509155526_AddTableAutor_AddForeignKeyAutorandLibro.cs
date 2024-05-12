using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILibros.Migrations
{
    public partial class AddTableAutor_AddForeignKeyAutorandLibro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.AutorId);
                });

            // Insertar un autor por defecto
            migrationBuilder.Sql("INSERT INTO autores (Nombre, Apellido, FechaNacimiento, Direccion, Nacionalidad) VALUES ('Default', 'Author', '1900-01-01', 'Unknown', 'None');");

            // Asegurar que todos los registros en libros tengan un AutorId que apunte al autor por defecto (suponiendo ID = 1)
            migrationBuilder.Sql("UPDATE libros SET AutorId = 1 WHERE AutorId = 0 OR AutorId IS NULL;");

            migrationBuilder.CreateIndex(
                name: "IX_libros_AutorId",
                table: "libros",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_libros_autores_AutorId",
                table: "libros",
                column: "AutorId",
                principalTable: "autores",
                principalColumn: "AutorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libros_autores_AutorId",
                table: "libros");

            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropIndex(
                name: "IX_libros_AutorId",
                table: "libros");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "libros");
        }
    }
}
