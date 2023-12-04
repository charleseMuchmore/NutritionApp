using Microsoft.AspNetCore.Mvc;
using NutritionApp.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace NutritionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRecipeRepository repo;

        public HomeController(ILogger<HomeController> logger, IRecipeRepository r)
        {
            _logger = logger;
            repo = r;
        }

        public IActionResult Index(List<Recipe> recipes)
        {
            return View(recipes);
        }

        [HttpPost]
        public IActionResult Index(string toname)
        {
            List<Recipe> recipes = new();
            if (!(string.IsNullOrEmpty(toname))) 
                recipes = repo.GetRecipes().Where(p => p.Name == toname).ToList();

            return View("Index", recipes);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}