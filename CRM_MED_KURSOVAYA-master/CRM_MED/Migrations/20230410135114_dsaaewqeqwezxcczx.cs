using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_MED.Migrations
{
    /// <inheritdoc />
    public partial class dsaaewqeqwezxcczx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Receptions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeekId",
                table: "Receptions",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Report",
                table: "Receptions",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_DayOfWeekId",
                table: "Receptions",
                column: "DayOfWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptions_DayOfWeeks_DayOfWeekId",
                table: "Receptions",
                column: "DayOfWeekId",
                principalTable: "DayOfWeeks",
                principalColumn: "DayOfWeekId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptions_DayOfWeeks_DayOfWeekId",
                table: "Receptions");

            migrationBuilder.DropIndex(
                name: "IX_Receptions_DayOfWeekId",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "DayOfWeekId",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "Report",
                table: "Receptions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Receptions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
