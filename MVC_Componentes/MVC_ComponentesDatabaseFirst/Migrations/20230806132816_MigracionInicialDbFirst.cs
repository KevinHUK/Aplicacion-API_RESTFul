using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ComponentesDatabaseFirst.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicialDbFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    ComponenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    NumeroDeSerie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Grados = table.Column<int>(type: "int", nullable: false),
                    Megas = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.ComponenteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componentes");
        }
    }
}
