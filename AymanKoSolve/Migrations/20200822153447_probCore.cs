using Microsoft.EntityFrameworkCore.Migrations;

namespace AymanKoSolve.Migrations
{
    public partial class probCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "problemHeader");

            migrationBuilder.AddColumn<string>(
                name: "problemTypeImage",
                table: "problemTypes",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "problemSourceImage",
                table: "problemSources",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "problemContents",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "problemTypeImage",
                table: "problemTypes");

            migrationBuilder.DropColumn(
                name: "problemSourceImage",
                table: "problemSources");

            migrationBuilder.DropColumn(
                name: "code",
                table: "problemContents");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "problemHeader",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
