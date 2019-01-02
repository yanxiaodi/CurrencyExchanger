using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YanSoft.CurrencyExchanger.WebApp.Utils
{
    public static class CacheHelper
    {
        public static string GetCurrenciesOfCurrencyConverterCacheKeyName() => "Currencies";
        public static string GetLatestRatesOfCurrencyConverterCacheKeyName(string baseCode) => $"LatestRatesOfCurrencyConverter-BaseCode_{baseCode}";
    }
}
