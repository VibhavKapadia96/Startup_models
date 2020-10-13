using Microsoft.EntityFrameworkCore.Migrations;

namespace Startup_API.Migrations
{
    public partial class Initialize : Migration
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
                    Parent_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category_Name", "Category_Parent", "Parent_Id" },
                values: new object[] { 1, "GRE", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category_Name", "Category_Parent", "Parent_Id" },
                values: new object[] { 2, "GMATE", null, 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category_Name", "Category_Parent", "Parent_Id" },
                values: new object[] { 3, "Quant", "GRE", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
