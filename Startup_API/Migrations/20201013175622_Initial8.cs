using Microsoft.EntityFrameworkCore.Migrations;

namespace Startup_API.Migrations
{
    public partial class Initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Sourece_Name",
                table: "Sources");

            migrationBuilder.AddColumn<string>(
                name: "Source_Name",
                table: "Sources",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source_Name",
                table: "Sources");

            migrationBuilder.AddColumn<string>(
                name: "Sourece_Name",
                table: "Sources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category_Name", "Category_Parent", "Parent_Id", "status" },
                values: new object[] { 1, "GRE", null, 0, "live" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category_Name", "Category_Parent", "Parent_Id", "status" },
                values: new object[] { 2, "GMATE", null, 0, "live" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category_Name", "Category_Parent", "Parent_Id", "status" },
                values: new object[] { 3, "Quant", "GRE", 1, "live" });
        }
    }
}
