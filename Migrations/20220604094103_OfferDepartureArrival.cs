using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUDO.Migrations
{
    public partial class OfferDepartureArrival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Arrival",
                table: "Offer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Departure",
                table: "Offer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Stops",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Stops",
                table: "Offer");
        }
    }
}
