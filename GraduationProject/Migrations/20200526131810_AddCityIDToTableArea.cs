using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationProject.Migrations
{
    public partial class AddCityIDToTableArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Cities_CityID",
                table: "Areas");

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "Areas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Cities_CityID",
                table: "Areas",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Cities_CityID",
                table: "Areas");

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "Areas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Cities_CityID",
                table: "Areas",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
