using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUDO.Migrations
{
    public partial class OfferWithDriverId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_AspNetUsers_DriverId",
                table: "Offer");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Offer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_AspNetUsers_DriverId",
                table: "Offer",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_AspNetUsers_DriverId",
                table: "Offer");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Offer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_AspNetUsers_DriverId",
                table: "Offer",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
