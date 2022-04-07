using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeWirolsut.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleType",
                table: "Vehicle",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Vehicle",
                newName: "VehicleType");
        }
    }
}
