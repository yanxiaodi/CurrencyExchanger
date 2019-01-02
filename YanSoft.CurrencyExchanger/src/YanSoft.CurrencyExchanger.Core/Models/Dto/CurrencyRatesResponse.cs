using System;
using System.Collections.Generic;
using System.Text;

namespace YanSoft.CurrencyExchanger.Core.Models.Dto
{
    public class CurrencyRatesResponse
    {
        public CurrencyRatesResponse()
        {
            Rates = new List<CurrencyRate>();
        }
        public int Timestamp { get; set; }
        public List<CurrencyRate> Rates { get; set; }
    }
}
