using NutritionApp.Models;

namespace NutritionApp.Data
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private AppDbContext dbContext;

        public RecipeIngredientRepository(AppDbContext context)
        {
            dbContext = context;
        }

        public RecipeIngredient GetRecipeIngredientById(int id)
        {
            return dbContext.RecipeIngredients.Find(id);
        }

        public List<RecipeIngredient> GetRecipeIngredients()
        {
            return dbContext.RecipeIngredients.ToList();
        }

        public int StoreRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            dbContext.RecipeIngredients.Add(recipeIngredient);
            return dbContext.SaveChanges();
        }
    }
}
