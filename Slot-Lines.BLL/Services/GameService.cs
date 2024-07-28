using Repository.Redis;
using Repository.Sql;
using Slot_Lines.Core.Enums;
using Slot_Lines.Core.Models;
using Slot_Lines_DAL.Repositories.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Lines.BLL.Services
{
    public class GameService
    {
        public IUnitOfWork _unitOfWork;
        public GameRedisRepository _redis;
        public GameService(IUnitOfWork unitOfWork, GameRedisRepository redis)
        {
            _unitOfWork = unitOfWork;
            _redis = redis;
        }

        public async Task<GameStartInfoResponseModel> GetGameStartInfoAsync(GameStartInfoModel gameStartInfo)
        {
            var gameLimitCacheModel = await _redis.GetGameLimitAsync(gameStartInfo.GameId,"USD");

            return new GameStartInfoResponseModel
            {
                Balance = 10000,
                Currency = "USD",
                ErrorCode = ValidationType.Success,
                Stakes = gameLimitCacheModel.QuickBets.ToArray(),
            };
        }

        public async Task<DoSpinResponceModel> SpinAsync(DoSpinModel spinModel)
        {

            //TODO generate matrix and calculate
            // validate Stake
            return new DoSpinResponceModel();
        }

    }
}
