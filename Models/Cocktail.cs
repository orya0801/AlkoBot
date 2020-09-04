using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkoBot.Models
{
    public class Cocktail
    {
        [Key]
        public int CocktailId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
    }
}
