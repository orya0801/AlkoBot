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
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.CocktailId);
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

            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Coefficient = table.Column<double>(nullable: false),
                    IngredientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MainUnitUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_MeasurementUnits_MainUnitUnitId",
                        column: x => x.MainUnitUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    CocktailId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    MainUnitUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => new { x.CocktailId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_Recipes_MeasurementUnits_MainUnitUnitId",
                        column: x => x.MainUnitUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteCocktails_CocktailId",
                table: "FavouriteCocktails",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MainUnitUnitId",
                table: "Ingredients",
                column: "MainUnitUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnits_IngredientId",
                table: "MeasurementUnits",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MainUnitUnitId",
                table: "Recipes",
                column: "MainUnitUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementUnits_Ingredients_IngredientId",
                table: "MeasurementUnits",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_MeasurementUnits_MainUnitUnitId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "FavouriteCocktails");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "MeasurementUnits");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
