using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyShowNewWebAPI.Migrations
{
    public partial class igrag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovName",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
