namespace NutritionApp.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; } //this is amount in oz
        public int Calories { get; set; }
        public int Carbs { get; set; }
        public int Protein { get; set; }
        public int Fiber { get; set; }
        public int Fat { get; set; }
    }
}
