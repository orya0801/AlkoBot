using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkoBot.ViewModels
{
    public class CocktailViewModel
    {
        public int CocktailId { get; set; }

        [Required(ErrorMessage = "Please enter cocktail name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter cocktail description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter cocktail recipe")]
        [Display(Name = "Recipe")]
        public string Recipe { get; set; }

        [Required(ErrorMessage = "Please choose cocktail image")]
        [Display(Name = "Cocktail Picture")]
        public IFormFile CocktailImage { get; set; }
    }
}
