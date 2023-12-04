using NutritionApp.Models;

namespace NutritionApp.Data
{
    public class RecipeRepository : IRecipeRepository
    {
        private AppDbContext dbContext;

        public RecipeRepository(AppDbContext context)
        {
            dbContext = context;
        }

        public Recipe GetRecipeById(int id)
        {
            return dbContext.Recipes.Find(id);
        }

        public List<Recipe> GetRecipes()
        {
            return dbContext.Recipes.ToList();
        }

        public int StoreRecipe(Recipe recipe)
        {
            dbContext.Recipes.Add(recipe);
            return dbContext.SaveChanges();
        }
    }
}
