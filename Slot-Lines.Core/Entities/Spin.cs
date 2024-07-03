using Slot_Lines.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Lines.Core.Entities
{
    public class Spin
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public decimal Odd { get; set; }
        public SpinStatus Status { get; set; }
        public decimal BetAmount { get; set; }
        public decimal WinAmount { get; set; }  
        public string Matrix { get; set; }

    }
}
