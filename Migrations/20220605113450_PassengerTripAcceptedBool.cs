using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUDO.Migrations
{
    public partial class PassengerTripAcceptedBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "PassengerTrips",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "PassengerTrips");
        }
    }
}
