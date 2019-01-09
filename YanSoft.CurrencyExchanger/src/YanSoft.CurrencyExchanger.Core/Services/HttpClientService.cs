using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using YanSoft.CurrencyExchanger.Core.Configurations;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public class HttpClientService : IHttpClientService
    {
        private static HttpClient _httpClient;
        public HttpClient CreateClient()
        {
            if(_httpClient != null)
            {
                return _httpClient;
            }
            else
            {
                _httpClient = new HttpClient();
                DateTime dtNow = DateTime.UtcNow;
                var saltKey = Guid.NewGuid().ToString();
                _httpClient.DefaultRequestHeaders.Add("token", ValidateHelper.GetToken(dtNow, saltKey));
                _httpClient.DefaultRequestHeaders.Add("version", AppConfigurations.AppVersion.ToString());
                _httpClient.DefaultRequestHeaders.Add("sk", saltKey);
                return _httpClient;
            }
        }
    }
}
