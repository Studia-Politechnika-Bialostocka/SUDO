using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUDO.Migrations
{
    public partial class addbetterratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Opines",
                newName: "PunctualityRating");

            migrationBuilder.AddColumn<int>(
                name: "DrivingRating",
                table: "Opines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProprietyRating",
                table: "Opines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrivingRating",
                table: "Opines");

            migrationBuilder.DropColumn(
                name: "ProprietyRating",
                table: "Opines");

            migrationBuilder.RenameColumn(
                name: "PunctualityRating",
                table: "Opines",
                newName: "Rating");
        }
    }
}
