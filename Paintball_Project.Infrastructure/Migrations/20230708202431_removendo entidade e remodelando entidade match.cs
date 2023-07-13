using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Paintball_Project.Infrastructure.Migrations
{
    public partial class removendoentidadeeremodelandoentidadematch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "match");

            migrationBuilder.DropTable(
                name: "schedulesettings");

            migrationBuilder.CreateTable(
                name: "matchsettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    NumberBalls = table.Column<int>(type: "integer", nullable: false),
                    IsRecharge = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantityMaxPlayers = table.Column<int>(type: "integer", nullable: false),
                    QuantityMinPlayers = table.Column<int>(type: "integer", nullable: false),
                    NumberPlayer = table.Column<int>(type: "integer", nullable: false),
                    DurationMatch = table.Column<int>(type: "integer", nullable: false),
                    DateTimeCreating = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matchsettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matchsettings");

            migrationBuilder.CreateTable(
                name: "match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTimeChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeCreating = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRecharge = table.Column<bool>(type: "boolean", nullable: false),
                    NumberBalls = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantityMaxPlayers = table.Column<int>(type: "integer", nullable: false),
                    QuantityMinPlayers = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_match", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "schedulesettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTimeChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeCreating = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DurationMatch = table.Column<int>(type: "integer", nullable: false),
                    NumberPlayer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedulesettings", x => x.Id);
                });
        }
    }
}
