using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ComponentesCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class MigracionPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Ordenadores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Temperatura = table.Column<int>(type: "int", nullable: true),
                    OrdenadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordenadores_PedidoId",
                table: "Ordenadores",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenadores_Pedidos_PedidoId",
                table: "Ordenadores",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenadores_Pedidos_PedidoId",
                table: "Ordenadores");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Ordenadores_PedidoId",
                table: "Ordenadores");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Ordenadores");
        }
    }
}
