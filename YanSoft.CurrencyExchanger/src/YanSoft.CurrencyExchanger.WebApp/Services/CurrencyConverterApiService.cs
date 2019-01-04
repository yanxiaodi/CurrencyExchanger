using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.WebApp.Models;
using Newtonsoft.Json.Linq;
using YanSoft.CurrencyExchanger.WebApp.Utils;
using Microsoft.Extensions.Caching.Memory;

namespace YanSoft.CurrencyExchanger.WebApp.Services
{
    /// <summary>
    /// The data comes from www.currencyconverterapi.com.
    /// </summary>
    public class CurrencyConverterApiService : IApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMemoryCache _cache;
        private readonly string _apiUri = "https://free.currencyconverterapi.com/api/v6/";

        public CurrencyConverterApiService(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            _clientFactory = httpClientFactory;
            _cache = memoryCache;
        }

        public async Task<List<Currency>> GetCurrencies()
        {
            var result = new List<Currency>();
            var cacheEntry = new List<Currency>();
            if (_cache.TryGetValue(CacheHelper.GetCurrenciesOfCurrencyConverterCacheKeyName(), out cacheEntry))
            {
                return cacheEntry;
            }
            else
            {
                #region Get data from Api.

                //HttpClient httpClient = _clientFactory.CreateClient(Constants.CurrencyConverterHttpClientName);

                //var url = $"{_apiUri}currencies";
                //HttpResponseMessage response = await httpClient.GetAsync(url);
                //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    var responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                //    responseObject["results"].Values().ToList().ForEach(x =>
                //    {
                //        var item = new Currency
                //        {
                //            Code = x["id"].ToString(),
                //            Name = x["currencyName"].ToString()
                //        };
                //        result.Add(item);
                //    });
                //    _cache.Set(CacheHelper.GetCurrenciesOfCurrencyConverterCacheKeyName(), result, DateTime.Now.AddYears(1));
                //    return result;
                //}
                //else
                //{
                //    return result;
                //}
                #endregion

                result = GetCurrencyList();
                _cache.Set(CacheHelper.GetCurrenciesOfCurrencyConverterCacheKeyName(), result, DateTime.Now.AddYears(1));
                return result;
            }
        }

        private List<Currency> GetCurrencyList()
        {
            var result = new List<Currency>()
                {
                    new Currency { Code = "AED" },
                    new Currency { Code = "AFN" },
                    new Currency { Code = "ALL" },
                    new Currency { Code = "AMD" },
                    new Currency { Code = "ANG" },
                    new Currency { Code = "AOA" },
                    new Currency { Code = "ARS" },
                    new Currency { Code = "AUD" },
                    new Currency { Code = "AWG" },
                    new Currency { Code = "AZN" },
                    new Currency { Code = "BAM" },
                    new Currency { Code = "BBD" },
                    new Currency { Code = "BDT" },
                    new Currency { Code = "BGN" },
                    new Currency { Code = "BHD" },
                    new Currency { Code = "BIF" },
                    new Currency { Code = "BMD" },
                    new Currency { Code = "BND" },
                    new Currency { Code = "BOB" },
                    new Currency { Code = "BRL" },
                    new Currency { Code = "BSD" },
                    new Currency { Code = "BTC" },
                    new Currency { Code = "BTN" },
                    new Currency { Code = "BWP" },
                    new Currency { Code = "BYN" },
                    new Currency { Code = "BYR" },
                    new Currency { Code = "BZD" },
                    new Currency { Code = "CAD" },
                    new Currency { Code = "CDF" },
                    new Currency { Code = "CHF" },
                    new Currency { Code = "CLP" },
                    new Currency { Code = "CNY" },
                    new Currency { Code = "COP" },
                    new Currency { Code = "CRC" },
                    new Currency { Code = "CUP" },
                    new Currency { Code = "CVE" },
                    new Currency { Code = "CZK" },
                    new Currency { Code = "DJF" },
                    new Currency { Code = "DKK" },
                    new Currency { Code = "DOP" },
                    new Currency { Code = "DZD" },
                    new Currency { Code = "EGP" },
                    new Currency { Code = "ERN" },
                    new Currency { Code = "ETB" },
                    new Currency { Code = "EUR" },
                    new Currency { Code = "FJD" },
                    new Currency { Code = "FKP" },
                    new Currency { Code = "GBP" },
                    new Currency { Code = "GEL" },
                    new Currency { Code = "GHS" },
                    new Currency { Code = "GIP" },
                    new Currency { Code = "GMD" },
                    new Currency { Code = "GNF" },
                    new Currency { Code = "GTQ" },
                    new Currency { Code = "GYD" },
                    new Currency { Code = "HKD" },
                    new Currency { Code = "HNL" },
                    new Currency { Code = "HRK" },
                    new Currency { Code = "HTG" },
                    new Currency { Code = "HUF" },
                    new Currency { Code = "IDR" },
                    new Currency { Code = "ILS" },
                    new Currency { Code = "INR" },
                    new Currency { Code = "IQD" },
                    new Currency { Code = "IRR" },
                    new Currency { Code = "ISK" },
                    new Currency { Code = "JMD" },
                    new Currency { Code = "JOD" },
                    new Currency { Code = "JPY" },
                    new Currency { Code = "KES" },
                    new Currency { Code = "KGS" },
                    new Currency { Code = "KHR" },
                    new Currency { Code = "KMF" },
                    new Currency { Code = "KPW" },
                    new Currency { Code = "KRW" },
                    new Currency { Code = "KWD" },
                    new Currency { Code = "KYD" },
                    new Currency { Code = "KZT" },
                    new Currency { Code = "LAK" },
                    new Currency { Code = "LBP" },
                    new Currency { Code = "LKR" },
                    new Currency { Code = "LRD" },
                    new Currency { Code = "LSL" },
                    new Currency { Code = "LTL" },
                    new Currency { Code = "LVL" },
                    new Currency { Code = "LYD" },
                    new Currency { Code = "MAD" },
                    new Currency { Code = "MDL" },
                    new Currency { Code = "MGA" },
                    new Currency { Code = "MKD" },
                    new Currency { Code = "MMK" },
                    new Currency { Code = "MNT" },
                    new Currency { Code = "MOP" },
                    new Currency { Code = "MRO" },
                    new Currency { Code = "MUR" },
                    new Currency { Code = "MVR" },
                    new Currency { Code = "MWK" },
                    new Currency { Code = "MXN" },
                    new Currency { Code = "MYR" },
                    new Currency { Code = "MZN" },
                    new Currency { Code = "NAD" },
                    new Currency { Code = "NGN" },
                    new Currency { Code = "NIO" },
                    new Currency { Code = "NOK" },
                    new Currency { Code = "NPR" },
                    new Currency { Code = "NZD" },
                    new Currency { Code = "OMR" },
                    new Currency { Code = "PAB" },
                    new Currency { Code = "PEN" },
                    new Currency { Code = "PGK" },
                    new Currency { Code = "PHP" },
                    new Currency { Code = "PKR" },
                    new Currency { Code = "PLN" },
                    new Currency { Code = "PYG" },
                    new Currency { Code = "QAR" },
                    new Currency { Code = "RON" },
                    new Currency { Code = "RSD" },
                    new Currency { Code = "RUB" },
                    new Currency { Code = "RWF" },
                    new Currency { Code = "SAR" },
                    new Currency { Code = "SBD" },
                    new Currency { Code = "SCR" },
                    new Currency { Code = "SDG" },
                    new Currency { Code = "SEK" },
                    new Currency { Code = "SGD" },
                    new Currency { Code = "SHP" },
                    new Currency { Code = "SIT" },
                    new Currency { Code = "SLL" },
                    new Currency { Code = "SOS" },
                    new Currency { Code = "SRD" },
                    new Currency { Code = "STD" },
                    new Currency { Code = "SVC" },
                    new Currency { Code = "SYP" },
                    new Currency { Code = "SZL" },
                    new Currency { Code = "THB" },
                    new Currency { Code = "TJS" },
                    new Currency { Code = "TMT" },
                    new Currency { Code = "TND" },
                    new Currency { Code = "TOP" },
                    new Currency { Code = "TRY" },
                    new Currency { Code = "TTD" },
                    new Currency { Code = "TWD" },
                    new Currency { Code = "TZS" },
                    new Currency { Code = "UAH" },
                    new Currency { Code = "UGX" },
                    new Currency { Code = "USD" },
                    new Currency { Code = "UYU" },
                    new Currency { Code = "UZS" },
                    new Currency { Code = "VEF" },
                    new Currency { Code = "VND" },
                    new Currency { Code = "VUV" },
                    new Currency { Code = "WST" },
                    new Currency { Code = "XAF" },
                    new Currency { Code = "XAG" },
                    new Currency { Code = "XAU" },
                    new Currency { Code = "XCD" },
                    new Currency { Code = "XDR" },
                    new Currency { Code = "XOF" },
                    new Currency { Code = "XPF" },
                    new Currency { Code = "YER" },
                    new Currency { Code = "ZAR" },
                    new Currency { Code = "ZMK" },
                    new Currency { Code = "ZMW" }
                };
            return result;
        }

        public async Task<CurrencyRatesResponse> GetLatestRates(string sourceCode, IEnumerable<string> targetCodes)
        {
            var result = new CurrencyRatesResponse();

            var cacheEntry = new List<CurrencyRate>();
            if (_cache.TryGetValue(CacheHelper.GetLatestRatesOfCurrencyConverterCacheKeyName(sourceCode), out cacheEntry))
            {
                result.Rates = cacheEntry.Where(x => targetCodes.ToList().Contains(x.Target)).ToList();
                return result;
            }
            else
            {
                HttpClient httpClient = _clientFactory.CreateClient(Constants.CurrencyConverterHttpClientName);
                // Request all the currencies and store the result in the cache.
                List<Currency> currenciesCache = await GetCurrencies();

                // Currently, only take 2 currencies for development.
                IEnumerable<string> targets = currenciesCache.ToList().Where(x => targetCodes.Contains(x.Code)).Select(x => $"{sourceCode}_{x.Code}");
                var queryParam = string.Join(',', targets.Take(2));
                //IEnumerable<string> targets = currenciesCache.ToList().Select(x => $"{sourceCode}_{x.Code}");
                //var queryParam = string.Join(',', targets);
                var url = $"{_apiUri}convert?q={queryParam}";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                    targetCodes.ToList().ForEach(targetCode =>
                    {
                        var currencyRate = new CurrencyRate
                        {
                            Source = sourceCode,
                            Target = targetCode
                        };
                        if (decimal.TryParse(responseObject["results"][$"{sourceCode}_{targetCode}"]["val"].ToString(), out var rate))
                        {
                            currencyRate.Rate = rate;
                        }
                        else
                        {
                            currencyRate.Rate = 0;
                        }
                        result.Rates.Add(currencyRate);
                    });
                    _cache.Set(CacheHelper.GetLatestRatesOfCurrencyConverterCacheKeyName(sourceCode), result.Rates, DateTime.Now.AddMinutes(10));
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }
    }
}
