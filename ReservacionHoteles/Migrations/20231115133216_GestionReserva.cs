using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservacionHoteles.Migrations
{
    /// <inheritdoc />
    public partial class GestionReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHoraEntrada = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    FechaHoraSalida = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    HotelRefId = table.Column<int>(type: "int", nullable: false),
                    DestinoRefId = table.Column<int>(type: "int", nullable: false),
                    HabitacionesRefId = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcion_Destinos_DestinoRefId",
                        column: x => x.DestinoRefId,
                        principalTable: "Destinos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcion_Habitaciones_HabitacionesRefId",
                        column: x => x.HabitacionesRefId,
                        principalTable: "Habitaciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcion_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GestionReserva",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHoraEntrada = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    FechaHoraSalida = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    HotelRefId = table.Column<int>(type: "int", nullable: true),
                    DestinosRefId = table.Column<int>(type: "int", nullable: true),
                    HabitacionesRefId = table.Column<int>(type: "int", nullable: true),
                    Tarifa1RefId = table.Column<int>(type: "int", nullable: true),
                    Tarifa2RefId = table.Column<int>(type: "int", nullable: true),
                    Tarifa3RefId = table.Column<int>(type: "int", nullable: true),
                    Tarifa4RefId = table.Column<int>(type: "int", nullable: true),
                    Tarifa5RefId = table.Column<int>(type: "int", nullable: true),
                    Tarifa6RefId = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestionReserva", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GestionReserva_Destinos_DestinosRefId",
                        column: x => x.DestinosRefId,
                        principalTable: "Destinos",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GestionReserva_Habitaciones_DestinosRefId",
                        column: x => x.DestinosRefId,
                        principalTable: "Habitaciones",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GestionReserva_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalTable: "Hotel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GestionReserva_Tarifa_Tarifa1RefId",
                        column: x => x.Tarifa1RefId,
                        principalTable: "Tarifa",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GestionReserva_Tarifa_Tarifa2RefId",
                        column: x => x.Tarifa2RefId,
                        principalTable: "Tarifa",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GestionReserva_Tarifa_Tarifa3RefId",
                        column: x => x.Tarifa3RefId,
                        principalTable: "Tarifa",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GestionReserva_Tarifa_Tarifa4RefId",
                        column: x => x.Tarifa4RefId,
                        principalTable: "Tarifa",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GestionReserva_Tarifa_Tarifa5RefId",
                        column: x => x.Tarifa5RefId,
                        principalTable: "Tarifa",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GestionReserva_Tarifa_Tarifa6RefId",
                        column: x => x.Tarifa6RefId,
                        principalTable: "Tarifa",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FuncionTarifa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarifaRefId = table.Column<int>(type: "int", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionTarifa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionTarifa_Funcion_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funcion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuncionTarifa_Tarifa_TarifaRefId",
                        column: x => x.TarifaRefId,
                        principalTable: "Tarifa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_DestinoRefId",
                table: "Funcion",
                column: "DestinoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_HabitacionesRefId",
                table: "Funcion",
                column: "HabitacionesRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_HotelRefId",
                table: "Funcion",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionTarifa_FuncionId",
                table: "FuncionTarifa",
                column: "FuncionId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionTarifa_TarifaRefId",
                table: "FuncionTarifa",
                column: "TarifaRefId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionReserva_DestinosRefId",
                table: "GestionReserva",
                column: "DestinosRefId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionReserva_HotelRefId",
                table: "GestionReserva",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionReserva_Tarifa1RefId",
                table: "GestionReserva",
                column: "Tarifa1RefId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionReserva_Tarifa2RefId",
                table: "GestionReserva",
                column: "Tarifa2RefId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionReserva_Tarifa3RefId",
                table: "GestionReserva",
                column: "Tarifa3RefId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionReserva_Tarifa4RefId",
                table: "GestionReserva",
                column: "Tarifa4RefId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionReserva_Tarifa5RefId",
                table: "GestionReserva",
                column: "Tarifa5RefId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionReserva_Tarifa6RefId",
                table: "GestionReserva",
                column: "Tarifa6RefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionTarifa");

            migrationBuilder.DropTable(
                name: "GestionReserva");

            migrationBuilder.DropTable(
                name: "Funcion");
        }
    }
}
