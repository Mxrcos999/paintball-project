using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paintball_Project.Infrastructure.Migrations
{
    public partial class novapropriedade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationMatch",
                table: "scheduling",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationMatch",
                table: "scheduling");
        }
    }
}
