using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.OracleClient;
using System.Linq;
using System.Threading.Tasks;

namespace AlkoBot.Models
{
    public class Recipe
    {
        [ForeignKey("CocktailId")]
        public int CocktailId { get; set;}

        [ForeignKey("IngredientId")]
        public int IngredientId { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
    }
}
