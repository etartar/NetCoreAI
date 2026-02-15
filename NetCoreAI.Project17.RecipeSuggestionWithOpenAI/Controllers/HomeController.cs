using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project17.RecipeSuggestionWithOpenAI.Models;
using System.Diagnostics;

namespace NetCoreAI.Project17.RecipeSuggestionWithOpenAI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
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
