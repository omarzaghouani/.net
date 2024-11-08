using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FlightConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassengers_Flights_FlightId",
                table: "FlightPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassengers_Passengers_passengersPassportNumber",
                table: "FlightPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassengers",
                table: "FlightPassengers");

            migrationBuilder.DropColumn(
                name: "PlaneId",
                table: "Flights");

            migrationBuilder.RenameTable(
                name: "FlightPassengers",
                newName: "reservition");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassengers_passengersPassportNumber",
                table: "reservition",
                newName: "IX_reservition_passengersPassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservition",
                table: "reservition",
                columns: new[] { "FlightId", "passengersPassportNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PLaneFK",
                table: "Flights",
                column: "PLaneFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PLaneFK",
                table: "Flights",
                column: "PLaneFK",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservition_Flights_FlightId",
                table: "reservition",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservition_Passengers_passengersPassportNumber",
                table: "reservition",
                column: "passengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PLaneFK",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_reservition_Flights_FlightId",
                table: "reservition");

            migrationBuilder.DropForeignKey(
                name: "FK_reservition_Passengers_passengersPassportNumber",
                table: "reservition");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PLaneFK",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservition",
                table: "reservition");

            migrationBuilder.RenameTable(
                name: "reservition",
                newName: "FlightPassengers");

            migrationBuilder.RenameIndex(
                name: "IX_reservition_passengersPassportNumber",
                table: "FlightPassengers",
                newName: "IX_FlightPassengers_passengersPassportNumber");

            migrationBuilder.AddColumn<int>(
                name: "PlaneId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassengers",
                table: "FlightPassengers",
                columns: new[] { "FlightId", "passengersPassportNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassengers_Flights_FlightId",
                table: "FlightPassengers",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassengers_Passengers_passengersPassportNumber",
                table: "FlightPassengers",
                column: "passengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
