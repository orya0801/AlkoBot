using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlkoBot.Models
{
    public class FavouriteCocktail
    {
        public DateTime Date { get; set; }
        public Cocktail Cocktail { get; set; }
        public bool Like { get; set; }
        public int UserId { get; set; }
    }
}
