using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Lines.Core.Models.Redis
{
    public class GameLimitCacheModel
    {
        public int GameId { get; set; }
        public string CurrencyCode { get; set; }
        public List<decimal> QuickBets { get; set; }
    }
}
