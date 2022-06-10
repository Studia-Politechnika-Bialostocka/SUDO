using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUDO.Migrations
{
    public partial class ImprovedOpine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Opine",
                newName: "PunctualityRating");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Opine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CommentedUserId",
                table: "Opine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentUserId",
                table: "Opine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DrivingRating",
                table: "Opine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProprietyRating",
                table: "Opine",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentedUserId",
                table: "Opine");

            migrationBuilder.DropColumn(
                name: "CurrentUserId",
                table: "Opine");

            migrationBuilder.DropColumn(
                name: "DrivingRating",
                table: "Opine");

            migrationBuilder.DropColumn(
                name: "ProprietyRating",
                table: "Opine");

            migrationBuilder.RenameColumn(
                name: "PunctualityRating",
                table: "Opine",
                newName: "Rating");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Opine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
