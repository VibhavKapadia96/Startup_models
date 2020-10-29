using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Startup_API.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "insert_date",
                table: "Sources",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "seo_keywords",
                table: "Sources",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "insert_date",
                table: "LinkType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "seo_keywords",
                table: "LinkType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "insert_date",
                table: "LinkRepository",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "seo_keywords",
                table: "LinkRepository",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "insert_date",
                table: "LinkRepo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "insert_date",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "seo_keywords",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "insert_date",
                table: "Sources");

            migrationBuilder.DropColumn(
                name: "seo_keywords",
                table: "Sources");

            migrationBuilder.DropColumn(
                name: "insert_date",
                table: "LinkType");

            migrationBuilder.DropColumn(
                name: "seo_keywords",
                table: "LinkType");

            migrationBuilder.DropColumn(
                name: "insert_date",
                table: "LinkRepository");

            migrationBuilder.DropColumn(
                name: "seo_keywords",
                table: "LinkRepository");

            migrationBuilder.DropColumn(
                name: "insert_date",
                table: "LinkRepo");

            migrationBuilder.DropColumn(
                name: "insert_date",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "seo_keywords",
                table: "Categories");
        }
    }
}
