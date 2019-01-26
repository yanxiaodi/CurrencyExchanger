using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YanSoft.CurrencyExchanger.WebApp.Utils
{
    public static class CacheHelper
    {
        public static string GetCurrenciesOfCurrencyConverterCacheKeyName() => "CurrencyConverterCurrencies";
        public static string GetLatestRatesOfCurrencyConverterCacheKeyName(string baseCode) => $"LatestRatesOfCurrencyConverter-BaseCode_{baseCode}";


        public static string GetCurrenciesOfFixerCacheKeyName() => "FixerCurrencies";




        public static string GetCurrenciesOfYahooFinanceCacheKeyName() => "YahooFinanceCurrencies";


    }
}
