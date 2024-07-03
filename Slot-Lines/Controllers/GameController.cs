using Microsoft.AspNetCore.Mvc;
using Slot_Lines.BLL.Services;

namespace Slot_Lines.Controllers
{
    public class GameController : Controller
    {
        private GameService _gameService;
        public GameController(GameService gameService)
        {
            _gameService = gameService; 
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
