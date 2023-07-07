using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Paintball_Project.Infrastructure.Migrations
{
    public partial class removendoentidadeplayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_scheduling_player",
                table: "scheduling");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropIndex(
                name: "IX_scheduling_PlayerId",
                table: "scheduling");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "scheduling");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "scheduling",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "scheduling",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "scheduling");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "scheduling");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "scheduling",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTimeChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeCreating = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scheduling_PlayerId",
                table: "scheduling",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_scheduling_player",
                table: "scheduling",
                column: "PlayerId",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
