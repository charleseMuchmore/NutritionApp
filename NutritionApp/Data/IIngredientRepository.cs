using NutritionApp.Models;

namespace NutritionApp.Data
{
    public interface IIngredientRepository
    {
        public Ingredient GetIngredientById(int id) { throw new NotImplementedException(); }

        public List<Ingredient> GetIngredients() { throw new NotImplementedException(); }

        public int StoreIngredient(Ingredient ingredient) { throw new NotImplementedException(); }
    }
}
