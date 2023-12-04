using Microsoft.AspNetCore.Mvc;
using NutritionApp.Data;
using NutritionApp.Models;

namespace NutritionApp.Controllers
{
    public class IngredientController : Controller
    {
        IIngredientRepository repo;
        List<int> recipeIngredients = new List<int>();
        public IngredientController(IIngredientRepository r)
        {
            repo = r;
        }
        public IActionResult Index(List<Ingredient> ingredients)
        {
            return View(ingredients);
        }

        [HttpPost]
        public IActionResult Index(string toname, string ingr)
        {
            List<Ingredient> ingredients = new();
            Ingredient i;
            if (toname == null)
                ingredients = repo.GetIngredients().ToList();
            else
                ingredients = repo.GetIngredients().Where(p => p.Name == toname).ToList();
            if (ingr != null)
            {
                i = repo.GetIngredientById(int.Parse(ingr));
                return RedirectToAction("ConfirmIngredient", i);
            }

            return View("Index", ingredients);
        }

        public IActionResult ConfirmIngredient(Ingredient i)
        {
            return View(i);  
        }

        [HttpPost]
        public IActionResult ConfirmIngredient(string yesno, Ingredient i)
        {
            if (yesno == "Yes")
                return RedirectToAction("AddRecipe", "Recipe", i);
            else 
                return RedirectToAction("Index");
        }
        public IActionResult AddIngredient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddIngredient(Ingredient model)
        {
            // Save model to db
            repo.StoreIngredient(model);

            return RedirectToAction("Index");
        }
    }
}
