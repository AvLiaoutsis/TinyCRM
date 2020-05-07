using Microsoft.EntityFrameworkCore.Migrations;

namespace TinyCRMConsole.Migrations
{
    public partial class addproductcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategory",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Product",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ProductCategory",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
