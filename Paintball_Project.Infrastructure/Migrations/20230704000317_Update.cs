using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paintball_Project.Infrastructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Time",
                table: "match",
                type: "integer",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecharge",
                table: "match",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecharge",
                table: "match");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "match",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
