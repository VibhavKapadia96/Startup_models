using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Startup_API.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkRepo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkRepo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    downvote = table.Column<int>(type: "int", nullable: false),
                    insert_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    linkTypeId = table.Column<int>(type: "int", nullable: false),
                    link_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_iframe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sourcesId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRepo", x => x.Id);
                });
        }
    }
}
