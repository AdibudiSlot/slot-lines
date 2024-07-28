using Microsoft.AspNetCore.Mvc;
using Slot_Lines.BLL.Services;
using Slot_Lines.Core.Enums;
using Slot_Lines.Core.Models;

namespace Slot_Lines.Controllers
{
    [ApiController]
    public class GameController : Controller
    {
        private GameService _gameService;
        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<GameStartInfoResponseModel> GetGameStartInfoAsync(GameStartInfoModel gameInitialState)
        {
            //TODO Validate Game And Partner
            //And Get  
            // Last Spin
            // Balance
            var gameStartInfo = await _gameService.GetGameStartInfoAsync(gameInitialState);

            return gameStartInfo;
        }
        public async Task<DoSpinResponceModel> SpinActionAsync(DoSpinModel doSpin)
        {
            var responce = await _gameService.SpinAsync(doSpin);
            return responce;
        }
    }
}
