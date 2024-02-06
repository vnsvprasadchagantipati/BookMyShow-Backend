using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyShowNewWebAPI.Migrations
{
    public partial class setssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovID",
                table: "Movies",
                newName: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Movies",
                newName: "MovID");
        }
    }
}
