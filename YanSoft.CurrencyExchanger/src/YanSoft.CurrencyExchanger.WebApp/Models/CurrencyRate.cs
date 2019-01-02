using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YanSoft.CurrencyExchanger.WebApp.Models
{
    public class CurrencyRate
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public decimal Rate { get; set; }
    }
}
