namespace NutritionApp.Models
{
    public class RecipeIngredient
    {
        public int RecipeIngredientId { get; set; }
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
    }
}
