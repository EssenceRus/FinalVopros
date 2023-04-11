using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_MED.Migrations
{
    /// <inheritdoc />
    public partial class fffffffffffffffffffffffffffffffff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LogDate",
                table: "StorageLogs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeekId",
                table: "StorageLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StorageLogs_DayOfWeekId",
                table: "StorageLogs",
                column: "DayOfWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageLogs_DayOfWeeks_DayOfWeekId",
                table: "StorageLogs",
                column: "DayOfWeekId",
                principalTable: "DayOfWeeks",
                principalColumn: "DayOfWeekId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageLogs_DayOfWeeks_DayOfWeekId",
                table: "StorageLogs");

            migrationBuilder.DropIndex(
                name: "IX_StorageLogs_DayOfWeekId",
                table: "StorageLogs");

            migrationBuilder.DropColumn(
                name: "DayOfWeekId",
                table: "StorageLogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogDate",
                table: "StorageLogs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }
    }
}
