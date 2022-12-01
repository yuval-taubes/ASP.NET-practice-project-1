using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {
        internal VideoGameRepository Repo = new VideoGameRepository();
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Repo);
        }
        public IActionResult DetailPage(string name)
        {
            VideoGame videoGame = Repo.VideoGames.First(x => x.Title == name);

            //VideoGame idMatched = Repo.VideoGames.First();
            //foreach (VideoGame videoGame in Repo.VideoGames)
            //{
            //    if(id == videoGame.Id)
            //    {
            //        idMatched = videoGame;
            //    }
            //}
            return View(videoGame);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
