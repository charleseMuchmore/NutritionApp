using NutritionApp.Models;

namespace NutritionApp.Data
{
    public class IngredientRepository : IIngredientRepository
    {
        private AppDbContext dbContext;

        public IngredientRepository(AppDbContext context)
        {
            dbContext = context;
        }

        public Ingredient GetIngredientById(int id)
        {
            return dbContext.Ingredients.Find(id);
        }

        public List<Ingredient> GetIngredients()
        {
            return dbContext.Ingredients.ToList();
        }

        public int StoreIngredient(Ingredient ingredient)
        {
            dbContext.Ingredients.Add(ingredient);
            return dbContext.SaveChanges();
        }
    }
}
