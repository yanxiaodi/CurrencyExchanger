using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.WebApp.Models;

namespace YanSoft.CurrencyExchanger.WebApp.Services
{
    public class FixerApiService : IApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiUri = "http://data.fixer.io/api/";
        public FixerApiService(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public Task<List<Currency>> GetCurrencies()
        {
            throw new NotImplementedException();
        }

        public async Task<CurrencyRatesResponse> GetLatestRates(string sourceCode, IEnumerable<string> targetCodes)
        {
            HttpClient httpClient = _clientFactory.CreateClient(Constants.FixerHttpClientName);

            //var url = $"http://data.fixer.io/api/latest?access_key={Constants.ApiKey}&base={baseCode}&symbols={targetCodes}";
            var url = $"{_apiUri}latest?access_key={Constants.FixerApiKey}&base=&symbols=";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            return new CurrencyRatesResponse();
        }
    }
}
