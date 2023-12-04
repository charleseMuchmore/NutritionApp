namespace NutritionApp.Models
{
    public interface IRecipeRepository
    {
        public Recipe GetRecipeById(int id) { throw new NotImplementedException(); }

        public List<Recipe> GetRecipes() { throw new NotImplementedException(); }

        public int StoreRecipe(Recipe recipe) { throw new NotImplementedException(); }
    }
}
