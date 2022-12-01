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
        public IActionResult DetailPage(int id)
        {
            //VideoGame videoGame = Repo.VideoGames.First(x => x.Id == id);
            
            VideoGame idMatched = null;
            foreach (VideoGame videoGame in Repo.VideoGames)
            {
                if(id == videoGame.Id)
                {
                    idMatched = videoGame;
                }
            }
            return View(idMatched);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
