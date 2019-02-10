using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YanSoft.CurrencyExchanger.Core.Models.Dto
{
    public class CurrencyRatesHistoryResponse
    {
        public string Base { get; set; }
        public string Target { get; set; }
        public List<CurrencyRateHistoryItem> Items { get; set; }

        public CurrencyRatesHistoryResponse()
        {
            Items = new List<CurrencyRateHistoryItem>();
        }
    }
}
