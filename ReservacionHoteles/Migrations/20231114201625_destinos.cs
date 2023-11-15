using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservacionHoteles.Migrations
{
    /// <inheritdoc />
    public partial class destinos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Destino",
                table: "Hotel",
                newName: "TipoRefId");

            migrationBuilder.RenameColumn(
                name: "Clasificacion",
                table: "Hotel",
                newName: "TipoId");

            migrationBuilder.AddColumn<int>(
                name: "Calificacion",
                table: "Hotel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinoRefId",
                table: "Hotel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinosRefId",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Hotel",
                type: "smalldatetime",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumHabitaciones = table.Column<int>(type: "int", nullable: true),
                    NumPersonas = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilidad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRefId = table.Column<int>(type: "int", nullable: true),
                    HotelRefId = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Disponibilidad_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalTable: "Hotel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Disponibilidad_Tipo_TipoRefId",
                        column: x => x.TipoRefId,
                        principalTable: "Tipo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_DestinoRefId",
                table: "Hotel",
                column: "DestinoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_TipoId",
                table: "Hotel",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidad_HotelRefId",
                table: "Disponibilidad",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidad_TipoRefId",
                table: "Disponibilidad",
                column: "TipoRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Destinos_DestinoRefId",
                table: "Hotel",
                column: "DestinoRefId",
                principalTable: "Destinos",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Tipo_TipoId",
                table: "Hotel",
                column: "TipoId",
                principalTable: "Tipo",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Destinos_DestinoRefId",
                table: "Hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Tipo_TipoId",
                table: "Hotel");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Disponibilidad");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Tipo");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_DestinoRefId",
                table: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_TipoId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "Calificacion",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "DestinoRefId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "DestinosRefId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Hotel");

            migrationBuilder.RenameColumn(
                name: "TipoRefId",
                table: "Hotel",
                newName: "Destino");

            migrationBuilder.RenameColumn(
                name: "TipoId",
                table: "Hotel",
                newName: "Clasificacion");
        }
    }
}
