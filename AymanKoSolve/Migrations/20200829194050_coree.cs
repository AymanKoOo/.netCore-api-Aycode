using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AymanKoSolve.Migrations
{
    public partial class coree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "problemHeader",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "problemContents",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "problemHeader",
                type: "datetime2",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "problemContents",
                type: "datetime2",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
