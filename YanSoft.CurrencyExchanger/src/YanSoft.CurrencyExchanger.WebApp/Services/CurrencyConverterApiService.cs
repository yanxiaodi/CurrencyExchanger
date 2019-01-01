using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.WebApp.Models;
using System.Linq;
using Newtonsoft.Json.Linq;
using YanSoft.CurrencyExchanger.WebApp.Utils;

namespace YanSoft.CurrencyExchanger.WebApp.Services
{
    /// <summary>
    /// The data comes from www.currencyconverterapi.com.
    /// </summary>
    public class CurrencyConverterApiService : IApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiUri = "https://free.currencyconverterapi.com/api/v6/";

        public CurrencyConverterApiService(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }
        public async Task<CurrencyRatesResponse> GetLatestRates(string baseCode, IEnumerable<string> targetCodes)
        {
            HttpClient httpClient = _clientFactory.CreateClient(Constants.CurrencyConverterHttpClientName);
            IEnumerable<string> targets = targetCodes.ToList().Select(x => $"{baseCode}_{x}");
            var queryParam = string.Join(',', targets);
            var url = $"{_apiUri}convert?q={queryParam}";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                var result = new CurrencyRatesResponse();
                targetCodes.ToList().ForEach(targetCode =>
                {
                    var currencyRate = new CurrencyRate
                    {
                        BaseCode = baseCode,
                        TargetCode = targetCode
                    };
                    if (decimal.TryParse(responseObject["results"][$"{baseCode}_{targetCode}"]["val"].ToString(), out var rate))
                    {
                        currencyRate.Rate = rate;
                    }
                    result.Rates.Add(currencyRate);
                });
                return result;
            }
            else
            {
                return new CurrencyRatesResponse();
            }
        }
    }
}
