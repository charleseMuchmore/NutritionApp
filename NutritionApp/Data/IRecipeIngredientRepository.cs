using NutritionApp.Models;

namespace NutritionApp.Data
{
    public interface IRecipeIngredientRepository
    {
        public RecipeIngredient GetRecipeIngredientById(int id) { throw new NotImplementedException(); }

        public List<RecipeIngredient> GetRecipeIngredients() { throw new NotImplementedException(); }

        public int StoreRecipeIngredient(RecipeIngredient recipeIngredient) { throw new NotImplementedException(); }
    }
}
