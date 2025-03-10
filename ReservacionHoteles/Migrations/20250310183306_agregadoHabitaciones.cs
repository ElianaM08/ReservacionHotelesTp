using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservacionHoteles.Migrations
{
    /// <inheritdoc />
    public partial class agregadoHabitaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GestionReserva_Habitaciones_DestinosRefId",
                table: "GestionReserva");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa2RefId",
                table: "GestionReserva");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa3RefId",
                table: "GestionReserva");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa4RefId",
                table: "GestionReserva");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa5RefId",
                table: "GestionReserva");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa6RefId",
                table: "GestionReserva");

            migrationBuilder.DropIndex(
                name: "IX_GestionReserva_Tarifa2RefId",
                table: "GestionReserva");

            migrationBuilder.DropIndex(
                name: "IX_GestionReserva_Tarifa3RefId",
                table: "GestionReserva");

            migrationBuilder.DropIndex(
                name: "IX_GestionReserva_Tarifa4RefId",
                table: "GestionReserva");

            migrationBuilder.DropIndex(
                name: "IX_GestionReserva_Tarifa5RefId",
                table: "GestionReserva");

            migrationBuilder.DropIndex(
                name: "IX_GestionReserva_Tarifa6RefId",
                table: "GestionReserva");

            migrationBuilder.DropColumn(
                name: "Tarifa2RefId",
                table: "GestionReserva");

            migrationBuilder.DropColumn(
                name: "Tarifa3RefId",
                table: "GestionReserva");

            migrationBuilder.DropColumn(
                name: "Tarifa4RefId",
                table: "GestionReserva");

            migrationBuilder.DropColumn(
                name: "Tarifa5RefId",
                table: "GestionReserva");

            migrationBuilder.DropColumn(
                name: "Tarifa6RefId",
                table: "GestionReserva");

            migrationBuilder.CreateIndex(
                name: "IX_GestionReserva_HabitacionesRefId",
                table: "GestionReserva",
                column: "HabitacionesRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_GestionReserva_Habitaciones_HabitacionesRefId",
                table: "GestionReserva",
                column: "HabitacionesRefId",
                principalTable: "Habitaciones",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GestionReserva_Habitaciones_HabitacionesRefId",
                table: "GestionReserva");

            migrationBuilder.DropIndex(
                name: "IX_GestionReserva_HabitacionesRefId",
                table: "GestionReserva");

            migrationBuilder.AddColumn<int>(
                name: "Tarifa2RefId",
                table: "GestionReserva",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tarifa3RefId",
                table: "GestionReserva",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tarifa4RefId",
                table: "GestionReserva",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tarifa5RefId",
                table: "GestionReserva",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tarifa6RefId",
                table: "GestionReserva",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_GestionReserva_Habitaciones_DestinosRefId",
                table: "GestionReserva",
                column: "DestinosRefId",
                principalTable: "Habitaciones",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa2RefId",
                table: "GestionReserva",
                column: "Tarifa2RefId",
                principalTable: "Tarifa",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa3RefId",
                table: "GestionReserva",
                column: "Tarifa3RefId",
                principalTable: "Tarifa",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa4RefId",
                table: "GestionReserva",
                column: "Tarifa4RefId",
                principalTable: "Tarifa",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa5RefId",
                table: "GestionReserva",
                column: "Tarifa5RefId",
                principalTable: "Tarifa",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GestionReserva_Tarifa_Tarifa6RefId",
                table: "GestionReserva",
                column: "Tarifa6RefId",
                principalTable: "Tarifa",
                principalColumn: "ID");
        }
    }
}
