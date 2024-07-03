using Slot_Lines.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slot_Lines.Core.Models
{
    public class DoSpinResponceModel
    {
        public ValidationType ErrorCode { get; set; }
        public decimal WinAmount { get; set; }
        public SpinStatus SpinStatus { get; set; }
        public decimal Odd { get; set; }
        public int[][] Matrix { get; set; }

    }
}
