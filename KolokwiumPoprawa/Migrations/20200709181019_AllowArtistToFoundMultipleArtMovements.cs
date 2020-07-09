using Microsoft.EntityFrameworkCore.Migrations;

namespace KolokwiumPoprawa.Migrations
{
    public partial class AllowArtistToFoundMultipleArtMovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArtMovements_IdMovementFounder",
                table: "ArtMovements");

            migrationBuilder.CreateIndex(
                name: "IX_ArtMovements_IdMovementFounder",
                table: "ArtMovements",
                column: "IdMovementFounder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArtMovements_IdMovementFounder",
                table: "ArtMovements");

            migrationBuilder.CreateIndex(
                name: "IX_ArtMovements_IdMovementFounder",
                table: "ArtMovements",
                column: "IdMovementFounder",
                unique: true);
        }
    }
}
