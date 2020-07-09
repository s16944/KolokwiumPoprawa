using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KolokwiumPoprawa.Migrations
{
    public partial class AddRequiredStructures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    IdCity = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Population = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.IdCity);
                });

            migrationBuilder.CreateTable(
                name: "ArtMovements",
                columns: table => new
                {
                    IdArtMovement = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNextArtMovement = table.Column<int>(nullable: false),
                    IdMovementFounder = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DateFounded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMovements", x => x.IdArtMovement);
                    table.ForeignKey(
                        name: "FK_ArtMovements_ArtMovements_IdNextArtMovement",
                        column: x => x.IdNextArtMovement,
                        principalTable: "ArtMovements",
                        principalColumn: "IdArtMovement",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    IdArtist = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArtMovement = table.Column<int>(nullable: false),
                    IdCityOfBirth = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.IdArtist);
                    table.ForeignKey(
                        name: "FK_Artists_ArtMovements_IdArtMovement",
                        column: x => x.IdArtMovement,
                        principalTable: "ArtMovements",
                        principalColumn: "IdArtMovement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artists_Cities_IdCityOfBirth",
                        column: x => x.IdCityOfBirth,
                        principalTable: "Cities",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    IdPainting = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceType = table.Column<string>(maxLength: 100, nullable: false),
                    PaintingMedia = table.Column<string>(maxLength: 100, nullable: false),
                    IdArtist = table.Column<int>(nullable: false),
                    IdCoAuthor = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.IdPainting);
                    table.ForeignKey(
                        name: "FK_Paintings_Artists_IdArtist",
                        column: x => x.IdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paintings_Artists_IdCoAuthor",
                        column: x => x.IdCoAuthor,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_IdArtMovement",
                table: "Artists",
                column: "IdArtMovement");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_IdCityOfBirth",
                table: "Artists",
                column: "IdCityOfBirth");

            migrationBuilder.CreateIndex(
                name: "IX_ArtMovements_IdMovementFounder",
                table: "ArtMovements",
                column: "IdMovementFounder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtMovements_IdNextArtMovement",
                table: "ArtMovements",
                column: "IdNextArtMovement");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_IdArtist",
                table: "Paintings",
                column: "IdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_IdCoAuthor",
                table: "Paintings",
                column: "IdCoAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtMovements_Artists_IdMovementFounder",
                table: "ArtMovements",
                column: "IdMovementFounder",
                principalTable: "Artists",
                principalColumn: "IdArtist",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_ArtMovements_IdArtMovement",
                table: "Artists");

            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "ArtMovements");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
