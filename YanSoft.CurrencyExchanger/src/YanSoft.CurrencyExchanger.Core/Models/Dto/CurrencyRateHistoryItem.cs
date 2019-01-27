using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YanSoft.CurrencyExchanger.Core.Models.Dto
{
    public class CurrencyRateHistoryItem
    {
        public int Timestamp { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public DateTime DateTime { get; set; }
    }
}
