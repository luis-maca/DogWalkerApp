using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogWalkerApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDogWalkDogRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogWalks_Dogs_DogId",
                table: "DogWalks");

            migrationBuilder.DropIndex(
                name: "IX_DogWalks_DogId",
                table: "DogWalks");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "DogWalks");

            migrationBuilder.CreateTable(
                name: "DogWalkDogs",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "INTEGER", nullable: false),
                    DogWalkId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogWalkDogs", x => new { x.DogId, x.DogWalkId });
                    table.ForeignKey(
                        name: "FK_DogWalkDogs_DogWalks_DogWalkId",
                        column: x => x.DogWalkId,
                        principalTable: "DogWalks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogWalkDogs_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogWalkDogs_DogWalkId",
                table: "DogWalkDogs",
                column: "DogWalkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogWalkDogs");

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "DogWalks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DogWalks_DogId",
                table: "DogWalks",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_DogWalks_Dogs_DogId",
                table: "DogWalks",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
