using Microsoft.AspNetCore.Mvc;
using NutritionApp.Data;
using NutritionApp.Models;

namespace NutritionApp.Controllers
{
    public class RecipeController : Controller
    {
        IRecipeRepository repo;
        IIngredientRepository ingredientRepository;
        IRecipeIngredientRepository ingrRepo;

        public RecipeController(IRecipeRepository r, IIngredientRepository inRepo, IRecipeIngredientRepository ir)
        {
            repo = r;
            ingredientRepository = inRepo;
            ingrRepo = ir;
        }
        public IActionResult Index(List<Recipe> recipes)
        {
            return View(recipes);
        }

        [HttpPost]
        public IActionResult Index(string toname)
        {
            List<Recipe> recipes = repo.GetRecipes().Where(p => p.Name == toname).ToList();

            return View("Index", recipes);
        }


        public IActionResult AddRecipe(Ingredient i)
        {
            List<Ingredient> ingredients = new();
            Recipe recipe = new();

            RecipeIngredient ing = new();
            // On first load, i will be null, but other times it will have something in it
            if (i.Name != null)
            {
                /*ingredients.Add(i);*/
/*                repo.StoreRecipe(recipe);
*/              ing.IngredientId = i.IngredientId;
                ing.RecipeId = recipe.RecipeId;
                ingrRepo.StoreRecipeIngredient(ing);

                List<RecipeIngredient> ingrs = ingrRepo.GetRecipeIngredients().Where(p => p.RecipeId == recipe.RecipeId).ToList();
                foreach(var recipeIngr in ingrs)
                {
                    ingredients.Add(ingredientRepository.GetIngredientById(recipeIngr.IngredientId));
                }
            }
            
            // The view wants a list of ingredients to display
            return View(ingredients);
        }

        [HttpPost]
        public IActionResult AddRecipe(Recipe model)
        {
            // Save model to db
            repo.StoreRecipe(model);

            return RedirectToAction("AddRecipe");
        }
    }
}
