using Microsoft.EntityFrameworkCore.Migrations;

namespace AymanKoSolve.Migrations
{
    public partial class newCOlletctionn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "problemSourceID",
                table: "problemHeader",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "problemHeaderID",
                table: "problemContents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_problemContents_problemHeaderID",
                table: "problemContents",
                column: "problemHeaderID");

            migrationBuilder.AddForeignKey(
                name: "FK_problemContents_problemHeader_problemHeaderID",
                table: "problemContents",
                column: "problemHeaderID",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_problemContents_problemHeader_problemHeaderID",
                table: "problemContents");

            migrationBuilder.DropForeignKey(
                name: "FK_problemHeader_problemSources_problemSourceID",
                table: "problemHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_problemHeader_problemTypes_problemTypeID",
                table: "problemHeader");

            migrationBuilder.DropIndex(
                name: "IX_problemContents_problemHeaderID",
                table: "problemContents");

            migrationBuilder.DropColumn(
                name: "problemHeaderID",
                table: "problemContents");

            migrationBuilder.AlterColumn<int>(
                name: "problemTypeID",
                table: "problemHeader",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "problemSourceID",
                table: "problemHeader",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "problemHeaderproblemid",
                table: "problemContents",
                type: "int",
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
    }
}
