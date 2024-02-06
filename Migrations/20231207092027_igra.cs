using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyShowNewWebAPI.Migrations
{
    public partial class igra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "mulID",
                table: "Movies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_mulID",
                table: "Movies",
                column: "mulID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Multiplexes_mulID",
                table: "Movies",
                column: "mulID",
                principalTable: "Multiplexes",
                principalColumn: "MulID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Multiplexes_mulID",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_mulID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "mulID",
                table: "Movies");
        }
    }
}
