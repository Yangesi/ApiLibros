using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILibros.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnDireccionTableLibros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "libros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "libros");
        }
    }
}
