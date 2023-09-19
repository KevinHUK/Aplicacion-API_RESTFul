using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_ComponentesCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class MigracionOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Ordenador_OrdenadorId",
                table: "Componentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ordenador",
                table: "Ordenador");

            migrationBuilder.RenameTable(
                name: "Ordenador",
                newName: "Ordenadores");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenadorId",
                table: "Componentes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ordenadores",
                table: "Ordenadores",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Componentes",
                columns: new[] { "Id", "Categoria", "Cores", "Descripcion", "Grados", "Megas", "NumeroDeSerie", "OrdenadorId", "Precio" },
                values: new object[,]
                {
                    { 1, 0, 9, "Procesador Intel i7", 10, 0L, "789-XCS", null, 134m },
                    { 2, 0, 10, "Procesador Intel i7", 12, 0L, "789-XCD", null, 138m },
                    { 3, 0, 11, "Procesador Intel i7", 12, 0L, "789-XCT", null, 138m },
                    { 4, 1, 0, "Banco De Memoria SDRAM", 10, 512L, "879FH", null, 100m },
                    { 5, 1, 0, "Banco De Memoria SDRAM", 15, 1024L, "879FH-L", null, 125m },
                    { 6, 1, 0, "Banco De Memoria SDRAM", 24, 2048L, "879FH-T", null, 150m },
                    { 7, 2, 0, "DiscoDuro SanDisk", 10, 512000L, "789-XX", null, 50m },
                    { 8, 2, 0, "DiscoDuro SanDisk", 29, 1024000L, "789-XX-2", null, 90m },
                    { 9, 2, 0, "DiscoDuro SanDisk", 39, 2048000L, "789-XX-3", null, 128m },
                    { 10, 0, 10, "Procesador Ryzen AMD", 30, 0L, "797-X", null, 78m },
                    { 11, 0, 29, "Procesador Ryzen AMD", 30, 0L, "797-X2", null, 178m },
                    { 12, 0, 34, "Procesador Ryzen AMD", 60, 0L, "797-X3", null, 278m },
                    { 13, 2, 0, "Disco Mecánico Patatin", 35, 250L, "788-fg", null, 37m },
                    { 14, 2, 0, "Disco Mecánico Patatin", 35, 250L, "788-fg-2", null, 67m },
                    { 15, 2, 0, "Disco Mecánico Patatin", 35, 250L, "788-fg-3", null, 97m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Ordenadores_OrdenadorId",
                table: "Componentes",
                column: "OrdenadorId",
                principalTable: "Ordenadores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Ordenadores_OrdenadorId",
                table: "Componentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ordenadores",
                table: "Ordenadores");

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Componentes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.RenameTable(
                name: "Ordenadores",
                newName: "Ordenador");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenadorId",
                table: "Componentes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ordenador",
                table: "Ordenador",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Ordenador_OrdenadorId",
                table: "Componentes",
                column: "OrdenadorId",
                principalTable: "Ordenador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
