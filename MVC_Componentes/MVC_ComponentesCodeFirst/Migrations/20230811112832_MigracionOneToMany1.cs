using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ComponentesCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class MigracionOneToMany1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Propietario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    NumeroDeSerie = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    Grados = table.Column<int>(type: "int", nullable: false),
                    Megas = table.Column<long>(type: "bigint", nullable: true),
                    OrdenadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componentes_Ordenador_OrdenadorId",
                        column: x => x.OrdenadorId,
                        principalTable: "Ordenador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_OrdenadorId",
                table: "Componentes",
                column: "OrdenadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Ordenador");
        }
    }
}
