using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project17.RecipeSuggestionWithOpenAI.Services;

namespace NetCoreAI.Project17.RecipeSuggestionWithOpenAI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly OpenAIService _openAiService;

        public DefaultController(OpenAIService openAiService)
        {
            _openAiService = openAiService;
        }

        [HttpGet]
        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(string ingredients)
        {
            var result = await _openAiService.GetRecipeAsync(ingredients);
            ViewBag.recipe = result;
            return View();
        }
    }
}