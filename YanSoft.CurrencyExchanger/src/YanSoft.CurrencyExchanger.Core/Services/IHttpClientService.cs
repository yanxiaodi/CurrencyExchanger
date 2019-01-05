using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public interface IHttpClientService
    {
        HttpClient CreateClient();
    }
}
