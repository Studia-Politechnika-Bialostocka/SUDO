using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUDO.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_AspNetUsers_ApplicationUserId",
                table: "Offer");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Offer",
                newName: "DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_ApplicationUserId",
                table: "Offer",
                newName: "IX_Offer_DriverId");

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

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Offer",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_DriverId",
                table: "Offer",
                newName: "IX_Offer_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_AspNetUsers_ApplicationUserId",
                table: "Offer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
