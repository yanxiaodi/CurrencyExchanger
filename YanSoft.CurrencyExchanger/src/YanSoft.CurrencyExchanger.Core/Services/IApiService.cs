using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.Core.Models.Dto;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public interface IApiService
    {
        Task<ResponseInfo<CurrencyRatesResponse>> GetLatestRates(string baseCode, string targetCodes);

        Task<ResponseInfo<CurrencyRatesHistoryResponse>> GetRatesHistoryByRange(string baseCode, string targetCode, string range, string interval);
    }
}
