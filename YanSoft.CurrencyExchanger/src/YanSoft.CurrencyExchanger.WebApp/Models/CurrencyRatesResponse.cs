using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.WebApp.Utils;

namespace YanSoft.CurrencyExchanger.WebApp.Models
{
    public class CurrencyRatesResponse
    {
        public CurrencyRatesResponse()
        {
            Timestamp = DateTimeHelper.ConvertDateTimeToTimestamp(DateTime.UtcNow);
            Rates = new List<CurrencyRate>();
        }
        public int Timestamp { get; set; }
        public List<CurrencyRate> Rates { get; set; }
    }
}
