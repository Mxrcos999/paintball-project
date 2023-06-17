using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paintball_Project.Infrastructure.Migrations
{
    public partial class Remodelandobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberHours",
                table: "schedulings");

            migrationBuilder.DropColumn(
                name: "NumberPlayers",
                table: "schedulings");

            migrationBuilder.RenameColumn(
                name: "DateTimeRegistration",
                table: "schedulings",
                newName: "DateTimeChange");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeChange",
                table: "schedulings",
                newName: "DateTimeRegistration");

            migrationBuilder.AddColumn<int>(
                name: "NumberHours",
                table: "schedulings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberPlayers",
                table: "schedulings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
