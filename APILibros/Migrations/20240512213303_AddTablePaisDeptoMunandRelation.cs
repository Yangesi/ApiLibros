using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILibros.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePaisDeptoMunandRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    CodigoPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.CodigoPais);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    CodigoPais = table.Column<int>(type: "int", nullable: false),
                    CodigoDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => new { x.CodigoPais, x.CodigoDepartamento });
                    table.ForeignKey(
                        name: "FK_Departamentos_Paises_CodigoPais",
                        column: x => x.CodigoPais,
                        principalTable: "Paises",
                        principalColumn: "CodigoPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    CodigoPais = table.Column<int>(type: "int", nullable: false),
                    CodigoDepartamento = table.Column<int>(type: "int", nullable: false),
                    CodigoMunicipio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => new { x.CodigoPais, x.CodigoDepartamento, x.CodigoMunicipio });
                    table.ForeignKey(
                        name: "FK_Municipios_Departamentos_CodigoPais_CodigoDepartamento",
                        columns: x => new { x.CodigoPais, x.CodigoDepartamento },
                        principalTable: "Departamentos",
                        principalColumns: new[] { "CodigoPais", "CodigoDepartamento" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
