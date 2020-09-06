using Microsoft.EntityFrameworkCore.Migrations;

namespace AymanKoSolve.Migrations
{
    public partial class newCOlletction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_problemContents_problemHeader_problemid",
                table: "problemContents");

            migrationBuilder.DropForeignKey(
                name: "FK_problemHeader_problemSources_problemSourceID",
                table: "problemHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_problemHeader_problemTypes_problemTypeID",
                table: "problemHeader");

            migrationBuilder.DropIndex(
                name: "IX_problemContents_problemid",
                table: "problemContents");

            migrationBuilder.DropColumn(
                name: "problemid",
                table: "problemContents");

            migrationBuilder.AlterColumn<int>(
                name: "problemTypeID",
                table: "problemHeader",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "problemSourceID",
                table: "problemHeader",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "problemHeaderproblemid",
                table: "problemContents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_problemContents_problemHeaderproblemid",
                table: "problemContents",
                column: "problemHeaderproblemid");

            migrationBuilder.AddForeignKey(
                name: "FK_problemContents_problemHeader_problemHeaderproblemid",
                table: "problemContents",
                column: "problemHeaderproblemid",
                principalTable: "problemHeader",
                principalColumn: "problemid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_problemHeader_problemSources_problemSourceID",
                table: "problemHeader",
                column: "problemSourceID",
                principalTable: "problemSources",
                principalColumn: "problemSourceID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_problemHeader_problemTypes_problemTypeID",
                table: "problemHeader",
                column: "problemTypeID",
                principalTable: "problemTypes",
                principalColumn: "problemTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_problemContents_problemHeader_problemHeaderproblemid",
                table: "problemContents");

            migrationBuilder.DropForeignKey(
                name: "FK_problemHeader_problemSources_problemSourceID",
                table: "problemHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_problemHeader_problemTypes_problemTypeID",
                table: "problemHeader");

            migrationBuilder.DropIndex(
                name: "IX_problemContents_problemHeaderproblemid",
                table: "problemContents");

            migrationBuilder.DropColumn(
                name: "problemHeaderproblemid",
                table: "problemContents");

            migrationBuilder.AlterColumn<int>(
                name: "problemTypeID",
                table: "problemHeader",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "problemSourceID",
                table: "problemHeader",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "problemid",
                table: "problemContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_problemContents_problemid",
                table: "problemContents",
                column: "problemid");

            migrationBuilder.AddForeignKey(
                name: "FK_problemContents_problemHeader_problemid",
                table: "problemContents",
                column: "problemid",
                principalTable: "problemHeader",
                principalColumn: "problemid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_problemHeader_problemSources_problemSourceID",
                table: "problemHeader",
                column: "problemSourceID",
                principalTable: "problemSources",
                principalColumn: "problemSourceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_problemHeader_problemTypes_problemTypeID",
                table: "problemHeader",
                column: "problemTypeID",
                principalTable: "problemTypes",
                principalColumn: "problemTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
