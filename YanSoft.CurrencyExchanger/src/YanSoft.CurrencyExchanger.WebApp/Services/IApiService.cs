using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.WebApp.Models;

namespace YanSoft.CurrencyExchanger.WebApp.Services
{
    public interface IApiService
    {
        List<Currency> GetCurrencies();

        /// <summary>
        /// Gets the latest rates.
        /// </summary>
        /// <param name="baseCode">The base code.</param>
        /// <param name="targetCodes">The target codes</param>
        /// <returns></returns>
        Task<CurrencyRatesResponse> GetLatestRates(string baseCode, IEnumerable<string> targetCodes);

        Task<CurrencyRatesHistoryResponse> GetHistoryRates(string baseCode, string targetCode, int timestampStart, int timestampEnd, string interval);
    }
}
