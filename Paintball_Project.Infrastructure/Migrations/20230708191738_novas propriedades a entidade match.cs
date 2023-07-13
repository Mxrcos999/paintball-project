using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paintball_Project.Infrastructure.Migrations
{
    public partial class novaspropriedadesaentidadematch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityMaxPlayers",
                table: "match",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityMinPlayers",
                table: "match",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityMaxPlayers",
                table: "match");

            migrationBuilder.DropColumn(
                name: "QuantityMinPlayers",
                table: "match");
        }
    }
}
