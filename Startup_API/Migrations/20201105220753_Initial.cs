using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Startup_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(nullable: false),
                    Category_Parent = table.Column<string>(nullable: true),
                    Parent_Id = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    topParentMapper = table.Column<string>(nullable: true),
                    seo_keywords = table.Column<string>(nullable: true),
                    insert_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkRepo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link = table.Column<string>(nullable: false),
                    link_iframe = table.Column<string>(nullable: true),
                    link_description = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    vote = table.Column<int>(nullable: false),
                    insert_date = table.Column<DateTime>(nullable: false),
                    categoryId = table.Column<int>(nullable: false),
                    linkTypeId = table.Column<int>(nullable: false),
                    sourcesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRepo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Linktype_Name = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    insert_date = table.Column<DateTime>(nullable: false),
                    seo_keywords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source_Name = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    insert_date = table.Column<DateTime>(nullable: false),
                    seo_keywords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkRepository",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link = table.Column<string>(nullable: false),
                    link_iframe = table.Column<string>(nullable: true),
                    link_description = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    vote = table.Column<int>(nullable: false),
                    seo_keywords = table.Column<string>(nullable: true),
                    insert_date = table.Column<DateTime>(nullable: false),
                    categoriesId = table.Column<int>(nullable: false),
                    linkTypeId = table.Column<int>(nullable: false),
                    sourcesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRepository", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkRepository_Categories_categoriesId",
                        column: x => x.categoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkRepository_LinkType_linkTypeId",
                        column: x => x.linkTypeId,
                        principalTable: "LinkType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkRepository_Sources_sourcesId",
                        column: x => x.sourcesId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkRepository_categoriesId",
                table: "LinkRepository",
                column: "categoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRepository_linkTypeId",
                table: "LinkRepository",
                column: "linkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRepository_sourcesId",
                table: "LinkRepository",
                column: "sourcesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkRepo");

            migrationBuilder.DropTable(
                name: "LinkRepository");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "LinkType");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
