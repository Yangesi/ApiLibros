using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILibros.Migrations
{
    /// <inheritdoc />
    public partial class AddTableResidencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Residencias",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPais = table.Column<int>(type: "int", nullable: false),
                    CodigoDepartamento = table.Column<int>(type: "int", nullable: false),
                    CodigoMunicipio = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residencias", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Residencias_Municipios_CodigoPais_CodigoDepartamento_CodigoMunicipio",
                        columns: x => new { x.CodigoPais, x.CodigoDepartamento, x.CodigoMunicipio },
                        principalTable: "Municipios",
                        principalColumns: new[] { "CodigoPais", "CodigoDepartamento", "CodigoMunicipio" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Residencias_CodigoPais_CodigoDepartamento_CodigoMunicipio",
                table: "Residencias",
                columns: new[] { "CodigoPais", "CodigoDepartamento", "CodigoMunicipio" });

            migrationBuilder.CreateIndex(
                name: "IX_Residencias_Direccion_CodigoPais_CodigoDepartamento_CodigoMunicipio",
                table: "Residencias",
                columns: new[] { "Direccion", "CodigoPais", "CodigoDepartamento", "CodigoMunicipio" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Residencias");
        }
    }
}
