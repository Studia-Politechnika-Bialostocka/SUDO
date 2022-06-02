using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUDO.Migrations
{
    public partial class driverProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Opine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverProfileId = table.Column<int>(type: "int", nullable: true),
                    DriverProfileId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opine_DriverProfiles_DriverProfileId",
                        column: x => x.DriverProfileId,
                        principalTable: "DriverProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opine_DriverProfiles_DriverProfileId1",
                        column: x => x.DriverProfileId1,
                        principalTable: "DriverProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverProfiles_UserId",
                table: "DriverProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Opine_DriverProfileId",
                table: "Opine",
                column: "DriverProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Opine_DriverProfileId1",
                table: "Opine",
                column: "DriverProfileId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opine");

            migrationBuilder.DropTable(
                name: "DriverProfiles");
        }
    }
}
