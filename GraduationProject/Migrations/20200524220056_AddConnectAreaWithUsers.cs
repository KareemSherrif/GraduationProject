using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationProject.Migrations
{
    public partial class AddConnectAreaWithUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AreaID",
                table: "AspNetUsers",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Areas_AreaID",
                table: "AspNetUsers",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Areas_AreaID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AreaID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "AspNetUsers");
        }
    }
}
