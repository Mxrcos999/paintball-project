using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Paintball_Project.Infrastructure.Migrations
{
    public partial class Criandorelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_schedulings",
                table: "schedulings");

            migrationBuilder.RenameTable(
                name: "schedulings",
                newName: "player");

            migrationBuilder.AddPrimaryKey(
                name: "PK_player",
                table: "player",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "scheduling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    NumberPlayer = table.Column<int>(type: "integer", nullable: false),
                    DateHourScheduling = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeCreating = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheduling", x => x.Id);
                    table.ForeignKey(
                        name: "fk_scheduling_player",
                        column: x => x.PlayerId,
                        principalTable: "player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scheduling_PlayerId",
                table: "scheduling",
                column: "PlayerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scheduling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_player",
                table: "player");

            migrationBuilder.RenameTable(
                name: "player",
                newName: "schedulings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_schedulings",
                table: "schedulings",
                column: "Id");
        }
    }
}
