using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.Core.Configurations;
using YanSoft.CurrencyExchanger.Core.Models.Dto;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientService _httpClientService;
        public ApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ResponseInfo<CurrencyRatesResponse>> GetLatestRates(string baseCode, string targetCodes)
        {
            var url = $"{AppConfigurations.ApiUrl}GetLatestRates?baseCode={baseCode}&targetCodes={targetCodes}&api-version=1.0";
            var result = new ResponseInfo<CurrencyRatesResponse>();
            try
            {
                var response = await _httpClientService.CreateClient().GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    result = SerializerHelper.FromJson<ResponseInfo<CurrencyRatesResponse>>(responseString);
                }
                return result;
            }
            catch
            {
                result.Message = "Service unavailable.";
                return result;
            }
        }
    }
}
