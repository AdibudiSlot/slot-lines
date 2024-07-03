using Slot_Lines.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Slot_Lines.Core.Models
{
    public class GameStartInfoResponseModel
    {
        public ValidationType ErrorCode { get; set; }
        public decimal[] Stakes { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }

    }
}
