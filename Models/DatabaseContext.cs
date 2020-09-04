using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using MySql.Data.EntityFrameworkCore;

namespace AlkoBot.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<FavouriteCocktail> FavouriteCocktails { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Alkobot.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavouriteCocktail>().HasNoKey();

            modelBuilder.Entity<Recipe>()
                .HasKey(c => new { c.CocktailId, c.IngredientId });
        }
 
    }
}
