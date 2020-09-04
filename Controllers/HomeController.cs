using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlkoBot.Models;

namespace AlkoBot.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db;
        public HomeController(DatabaseContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Cocktails.ToListAsync());
        }

        public IActionResult CreateCocktail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCocktail(Cocktail cocktail)
        {
            db.Cocktails.Add(cocktail);
            //foreach (var ingredient in ingredients)
            //{
            //    db.Recipes.Add(
            //        new Recipe()
            //        {
            //            CocktailId = cocktail.CocktailId,
            //            IngredientId = ingredient.IngredientId,
            //            // В данном случае передается единица, указанная пользователем, а не основная
            //            Unit = ingredient.Unit,
            //            Amount = ingredient.Amount
            //        });
            //}

            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CocktailDetails(int? id)
        {
            if (id != null)
            {
                Cocktail cocktail = await db.Cocktails.FirstOrDefaultAsync(p => p.CocktailId == id);
                if (cocktail != null)
                    return View(cocktail);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> EditCocktail(int? id)
        {
            if(id != null)
            {
                Cocktail cocktail = await db.Cocktails.FirstOrDefaultAsync(c => c.CocktailId == id.Value);
                if (cocktail != null)
                    return View(cocktail);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditCocktail(Cocktail cocktail)
        {
            db.Cocktails.Update(cocktail);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("DeleteCocktail")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Cocktail cocktail = await db.Cocktails.FirstOrDefaultAsync(p => p.CocktailId == id);
                if (cocktail != null)
                    return View(cocktail);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCocktail(int? id)
        {
            if (id != null)
            {
                Cocktail cocktail = new Cocktail { CocktailId = id.Value };
                db.Entry(cocktail).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
