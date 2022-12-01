using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie() { Title = "Fight Club", Star = "Brad pitt" },
                new Movie() { Title = "The Matrix", Star = "Keanu Reaves"}
            };
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Page()
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