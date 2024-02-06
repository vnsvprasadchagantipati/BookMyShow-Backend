using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyShowNewWebAPI.Migrations
{
    public partial class setss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ShowDateTime",
                table: "Shows",
                type: "datetime2",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ShowDateTime",
                table: "Shows",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 30);
        }
    }
}
