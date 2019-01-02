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
                HttpClient httpClient = _clientFactory.CreateClient(Constants.CurrencyConverterHttpClientName);
                
                var url = $"{_apiUri}currencies";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                    responseObject["results"].Values().ToList().ForEach(x =>
                    {
                        var item = new Currency
                        {
                            Code = x["id"].ToString(),
                            Name = x["currencyName"].ToString()
                        };
                        result.Add(item);
                    });
                    _cache.Set(CacheHelper.GetCurrenciesOfCurrencyConverterCacheKeyName(), result, DateTime.Now.AddYears(1));
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }

        public async Task<CurrencyRatesResponse> GetLatestRates(string sourceCode, IEnumerable<string> targetCodes)
        {
            var result = new CurrencyRatesResponse();

            var cacheEntry = new List<CurrencyRate>();
            if (_cache.TryGetValue(CacheHelper.GetLatestRatesOfCurrencyConverterCacheKeyName(sourceCode), out cacheEntry))
            {
                result.Rates = cacheEntry.Where(x => targetCodes.ToList().Contains(x.TargetCode)).ToList();
                return result;
            }
            else
            {
                HttpClient httpClient = _clientFactory.CreateClient(Constants.CurrencyConverterHttpClientName);
                //Currently, I need to request all the currencies and store the result in the cache.
                IEnumerable<string> targets = targetCodes.ToList().Select(x => $"{sourceCode}_{x}");
                var queryParam = string.Join(',', targets);
                var url = $"{_apiUri}convert?q={queryParam}";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                    targetCodes.ToList().ForEach(targetCode =>
                    {
                        var currencyRate = new CurrencyRate
                        {
                            SourceCode = sourceCode,
                            TargetCode = targetCode
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
