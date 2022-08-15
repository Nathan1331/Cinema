using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALCinema.Migrations
{
    public partial class AddingEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sits_Schedules_ScheduleId",
                table: "Sits");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Schedules",
                newName: "StartDateTime");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Sits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "Sits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Sits_Schedules_ScheduleId",
                table: "Sits",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sits_Schedules_ScheduleId",
                table: "Sits");

            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Sits");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "Schedules",
                newName: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Sits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sits_Schedules_ScheduleId",
                table: "Sits",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId");
        }
    }
}
