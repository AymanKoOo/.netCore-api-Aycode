using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AymanKoSolve.Migrations
{
    public partial class createProbCoree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "problemSource",
                columns: table => new
                {
                    problemSourceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sourceName = table.Column<string>(maxLength: 200, nullable: false),
                    sourceDescription = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_problemSource", x => x.problemSourceID);
                });

            migrationBuilder.CreateTable(
                name: "problemType",
                columns: table => new
                {
                    problemTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problemTypee = table.Column<string>(maxLength: 200, nullable: false),
                    problemTDescription = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_problemType", x => x.problemTypeID);
                });

            migrationBuilder.CreateTable(
                name: "problemHeaders",
                columns: table => new
                {
                    problemid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problemName = table.Column<string>(maxLength: 200, nullable: false),
                    problemDescription = table.Column<string>(maxLength: 200, nullable: false),
                    problemImage = table.Column<string>(maxLength: 200, nullable: false),
                    code = table.Column<string>(maxLength: 200, nullable: false),
                    date = table.Column<DateTime>(maxLength: 200, nullable: false),
                    problemTypeID = table.Column<int>(nullable: false),
                    problemSourceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_problemHeaders", x => x.problemid);
                    table.ForeignKey(
                        name: "FK_problemHeaders_problemSource_problemSourceID",
                        column: x => x.problemSourceID,
                        principalTable: "problemSource",
                        principalColumn: "problemSourceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_problemHeaders_problemType_problemTypeID",
                        column: x => x.problemTypeID,
                        principalTable: "problemType",
                        principalColumn: "problemTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "problemContent",
                columns: table => new
                {
                    contentProblemid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contentProblemName = table.Column<string>(maxLength: 200, nullable: false),
                    contentProblemDescription = table.Column<string>(maxLength: 200, nullable: false),
                    contentproblemImage = table.Column<string>(maxLength: 200, nullable: false),
                    date = table.Column<DateTime>(maxLength: 200, nullable: false),
                    problemid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_problemContent", x => x.contentProblemid);
                    table.ForeignKey(
                        name: "FK_problemContent_problemHeaders_problemid",
                        column: x => x.problemid,
                        principalTable: "problemHeaders",
                        principalColumn: "problemid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_problemContent_problemid",
                table: "problemContent",
                column: "problemid");

            migrationBuilder.CreateIndex(
                name: "IX_problemHeaders_problemSourceID",
                table: "problemHeaders",
                column: "problemSourceID");

            migrationBuilder.CreateIndex(
                name: "IX_problemHeaders_problemTypeID",
                table: "problemHeaders",
                column: "problemTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "problemContent");

            migrationBuilder.DropTable(
                name: "problemHeaders");

            migrationBuilder.DropTable(
                name: "problemSource");

            migrationBuilder.DropTable(
                name: "problemType");
        }
    }
}
