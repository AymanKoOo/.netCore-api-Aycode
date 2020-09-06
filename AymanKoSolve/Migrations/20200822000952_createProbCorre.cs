using Microsoft.EntityFrameworkCore.Migrations;

namespace AymanKoSolve.Migrations
{
    public partial class createProbCorre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_problemContent_problemHeaders_problemid",
                table: "problemContent");

            migrationBuilder.DropForeignKey(
                name: "FK_problemHeaders_problemSource_problemSourceID",
                table: "problemHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_problemHeaders_problemType_problemTypeID",
                table: "problemHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_problemType",
                table: "problemType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_problemSource",
                table: "problemSource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_problemHeaders",
                table: "problemHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_problemContent",
                table: "problemContent");

            migrationBuilder.RenameTable(
                name: "problemType",
                newName: "problemTypes");

            migrationBuilder.RenameTable(
                name: "problemSource",
                newName: "problemSources");

            migrationBuilder.RenameTable(
                name: "problemHeaders",
                newName: "problemHeader");

            migrationBuilder.RenameTable(
                name: "problemContent",
                newName: "problemContents");

            migrationBuilder.RenameIndex(
                name: "IX_problemHeaders_problemTypeID",
                table: "problemHeader",
                newName: "IX_problemHeader_problemTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_problemHeaders_problemSourceID",
                table: "problemHeader",
                newName: "IX_problemHeader_problemSourceID");

            migrationBuilder.RenameIndex(
                name: "IX_problemContent_problemid",
                table: "problemContents",
                newName: "IX_problemContents_problemid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_problemTypes",
                table: "problemTypes",
                column: "problemTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_problemSources",
                table: "problemSources",
                column: "problemSourceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_problemHeader",
                table: "problemHeader",
                column: "problemid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_problemContents",
                table: "problemContents",
                column: "contentProblemid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_problemTypes",
                table: "problemTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_problemSources",
                table: "problemSources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_problemHeader",
                table: "problemHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_problemContents",
                table: "problemContents");

            migrationBuilder.RenameTable(
                name: "problemTypes",
                newName: "problemType");

            migrationBuilder.RenameTable(
                name: "problemSources",
                newName: "problemSource");

            migrationBuilder.RenameTable(
                name: "problemHeader",
                newName: "problemHeaders");

            migrationBuilder.RenameTable(
                name: "problemContents",
                newName: "problemContent");

            migrationBuilder.RenameIndex(
                name: "IX_problemHeader_problemTypeID",
                table: "problemHeaders",
                newName: "IX_problemHeaders_problemTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_problemHeader_problemSourceID",
                table: "problemHeaders",
                newName: "IX_problemHeaders_problemSourceID");

            migrationBuilder.RenameIndex(
                name: "IX_problemContents_problemid",
                table: "problemContent",
                newName: "IX_problemContent_problemid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_problemType",
                table: "problemType",
                column: "problemTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_problemSource",
                table: "problemSource",
                column: "problemSourceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_problemHeaders",
                table: "problemHeaders",
                column: "problemid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_problemContent",
                table: "problemContent",
                column: "contentProblemid");

            migrationBuilder.AddForeignKey(
                name: "FK_problemContent_problemHeaders_problemid",
                table: "problemContent",
                column: "problemid",
                principalTable: "problemHeaders",
                principalColumn: "problemid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_problemHeaders_problemSource_problemSourceID",
                table: "problemHeaders",
                column: "problemSourceID",
                principalTable: "problemSource",
                principalColumn: "problemSourceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_problemHeaders_problemType_problemTypeID",
                table: "problemHeaders",
                column: "problemTypeID",
                principalTable: "problemType",
                principalColumn: "problemTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
