using Repository.Sql;
using Slot_Lines.Core.Models;
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
        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DoSpinResponceModel> SpinAsync(DoSpinModel spinModel)
        {
            //TODO generate matrix and calculate
            // validate Stake
            return new DoSpinResponceModel();
        }

    }
}
