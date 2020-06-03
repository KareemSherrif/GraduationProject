using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationProject.Migrations
{
    public partial class AddNamePropertyToProductAndUserProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserProduct");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Product");
        }
    }
}
