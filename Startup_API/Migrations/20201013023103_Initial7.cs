using Microsoft.EntityFrameworkCore.Migrations;

namespace Startup_API.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkRepo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link = table.Column<string>(nullable: false),
                    link_iframe = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    vote = table.Column<int>(nullable: false),
                    categoriesId = table.Column<int>(nullable: true),
                    linkTypeId = table.Column<int>(nullable: true),
                    sourcesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRepo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkRepo_Categories_categoriesId",
                        column: x => x.categoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkRepo_LinkType_linkTypeId",
                        column: x => x.linkTypeId,
                        principalTable: "LinkType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkRepo_Sources_sourcesId",
                        column: x => x.sourcesId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkRepo_categoriesId",
                table: "LinkRepo",
                column: "categoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRepo_linkTypeId",
                table: "LinkRepo",
                column: "linkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRepo_sourcesId",
                table: "LinkRepo",
                column: "sourcesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkRepo");
        }
    }
}
