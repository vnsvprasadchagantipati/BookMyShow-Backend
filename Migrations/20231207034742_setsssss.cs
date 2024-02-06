using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyShowNewWebAPI.Migrations
{
    public partial class setsssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShowTiming",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MovName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowTiming",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "MovName",
                table: "Bookings");
        }
    }
}
