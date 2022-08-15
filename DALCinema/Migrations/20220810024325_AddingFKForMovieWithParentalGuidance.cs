using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALCinema.Migrations
{
    public partial class AddingFKForMovieWithParentalGuidance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movies_ParentalGuidenceId",
                table: "Movies",
                column: "ParentalGuidenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_ParentalGuidance_ParentalGuidenceId",
                table: "Movies",
                column: "ParentalGuidenceId",
                principalTable: "ParentalGuidance",
                principalColumn: "ParentalGuidenceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_ParentalGuidance_ParentalGuidenceId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ParentalGuidenceId",
                table: "Movies");
        }
    }
}
