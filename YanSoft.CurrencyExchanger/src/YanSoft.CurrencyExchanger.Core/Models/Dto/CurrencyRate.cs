using System;
using System.Collections.Generic;
using System.Text;

namespace YanSoft.CurrencyExchanger.Core.Models.Dto
{
    public class CurrencyRate
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public decimal Rate { get; set; }
    }
}
