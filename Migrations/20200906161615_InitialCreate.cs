using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkoBot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    CocktailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Recipe = table.Column<string>(nullable: false),
                    CocktailPicture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.CocktailId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "PreviousActions",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrevAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousActions", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteCocktails",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    CocktailId = table.Column<int>(nullable: true),
                    Like = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_FavouriteCocktails_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "CocktailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteCocktails_CocktailId",
                table: "FavouriteCocktails",
                column: "CocktailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteCocktails");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "PreviousActions");

            migrationBuilder.DropTable(
                name: "Cocktails");
        }
    }
}
