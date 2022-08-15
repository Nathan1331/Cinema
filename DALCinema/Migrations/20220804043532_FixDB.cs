using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALCinema.Migrations
{
    public partial class FixDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountSits",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "AmountSits",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SitsPrice",
                table: "Rooms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountSits",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "SitsPrice",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "AmountSits",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
