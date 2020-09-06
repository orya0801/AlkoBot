using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlkoBot.Models;
using AlkoBot.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AlkoBot.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(DatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            db = context;
            webHostEnvironment = hostEnvironment;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCocktail(CocktailViewModel cocktailModel)
        {
      
            if(ModelState.IsValid) 
            {
                string uniqueFileName = UploadedFile(cocktailModel);
                Cocktail cocktail = new Cocktail
                {
                    Name = cocktailModel.Name,
                    Description = cocktailModel.Description,
                    Recipe = cocktailModel.Recipe,
                    CocktailPicture = uniqueFileName
                };

                db.Cocktails.Add(cocktail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        private string UploadedFile(CocktailViewModel cocktailModel)
        {
            string uniqueFileName = null;

            if(cocktailModel.CocktailImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + cocktailModel.CocktailImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    cocktailModel.CocktailImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
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
