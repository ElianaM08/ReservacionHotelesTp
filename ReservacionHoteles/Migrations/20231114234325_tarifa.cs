using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservacionHoteles.Migrations
{
    /// <inheritdoc />
    public partial class tarifa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondicionPago",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionPago", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ListaPrecio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CondicionPagoRefId = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaPrecio", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ListaPrecio_CondicionPago_CondicionPagoRefId",
                        column: x => x.CondicionPagoRefId,
                        principalTable: "CondicionPago",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tarifa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PorcentajeDescuento = table.Column<int>(type: "int", nullable: false),
                    ListaPrecioRefId = table.Column<int>(type: "int", nullable: true),
                    TarifaPrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tarifa_ListaPrecio_ListaPrecioRefId",
                        column: x => x.ListaPrecioRefId,
                        principalTable: "ListaPrecio",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaPrecio_CondicionPagoRefId",
                table: "ListaPrecio",
                column: "CondicionPagoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifa_ListaPrecioRefId",
                table: "Tarifa",
                column: "ListaPrecioRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarifa");

            migrationBuilder.DropTable(
                name: "ListaPrecio");

            migrationBuilder.DropTable(
                name: "CondicionPago");
        }
    }
}
