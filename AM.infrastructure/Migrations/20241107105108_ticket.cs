using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "Tickets",
                newName: "PassengerFK");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                newName: "IX_Tickets_PassengerFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassengerFK",
                table: "Tickets",
                column: "PassengerFK",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassengerFK",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PassengerFK",
                table: "Tickets",
                newName: "PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PassengerFK",
                table: "Tickets",
                newName: "IX_Tickets_PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
