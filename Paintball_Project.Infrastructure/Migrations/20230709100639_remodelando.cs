using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Paintball_Project.Infrastructure.Migrations
{
    public partial class remodelando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecharge",
                table: "matchsettings");

            migrationBuilder.DropColumn(
                name: "NumberBalls",
                table: "matchsettings");

            migrationBuilder.DropColumn(
                name: "NumberPlayer",
                table: "matchsettings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "matchsettings");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "matchsettings");

            migrationBuilder.CreateTable(
                name: "chargedata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    NumberBalls = table.Column<decimal>(type: "numeric", nullable: false),
                    MatchSettingsId = table.Column<int>(type: "integer", nullable: false),
                    DateTimeCreating = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chargedata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chargedata_matchsettings_MatchSettingsId",
                        column: x => x.MatchSettingsId,
                        principalTable: "matchsettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gamedata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    NumberBalls = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    MatchSettingsId = table.Column<int>(type: "integer", nullable: false),
                    DateTimeCreating = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gamedata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gamedata_matchsettings_MatchSettingsId",
                        column: x => x.MatchSettingsId,
                        principalTable: "matchsettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chargedata_MatchSettingsId",
                table: "chargedata",
                column: "MatchSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_gamedata_MatchSettingsId",
                table: "gamedata",
                column: "MatchSettingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chargedata");

            migrationBuilder.DropTable(
                name: "gamedata");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecharge",
                table: "matchsettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberBalls",
                table: "matchsettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberPlayer",
                table: "matchsettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "matchsettings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "matchsettings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
