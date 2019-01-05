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
        private static HttpClient httpClient;
        public HttpClient CreateClient()
        {
            if(httpClient != null)
            {
                return httpClient;
            }
            else
            {
                httpClient = new HttpClient();
                DateTime dtNow = DateTime.UtcNow;
                var saltKey = Guid.NewGuid().ToString();
                httpClient.DefaultRequestHeaders.Add("token", ValidateHelper.GetToken(dtNow, saltKey));
                httpClient.DefaultRequestHeaders.Add("version", AppConfigurations.AppVersion.ToString());
                httpClient.DefaultRequestHeaders.Add("sk", saltKey);
                return httpClient;
            }
        }
    }
}
