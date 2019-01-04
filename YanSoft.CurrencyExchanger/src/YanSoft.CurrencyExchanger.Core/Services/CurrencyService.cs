using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.Core.Models;
using System.Linq;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IApiService apiService;
        private readonly IDataService<CurrencyExchangeItem> dataService;

        public CurrencyService(IApiService apiService, IDataService<CurrencyExchangeItem> dataService)
        {
            this.apiService = apiService;
            this.dataService = dataService;
        }

        public void CalculateCurrencyAmount(ObservableCollection<CurrencyExchangeItem> list, CurrencyExchangeItem target = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetCurrencyRates(ObservableCollection<CurrencyExchangeBindableItem> list)
        {
            var sourceCode = list.First().SourceCode;
            var targetCodes = string.Join(",", list.Where(x => !x.IsStandard).Select(x => x.TargetCode).ToList());
            var response = await apiService.GetLatestRates(sourceCode, targetCodes);
            if (response.IsSuccess)
            {
                foreach (var item in list)
                {
                    if (!item.IsStandard)
                    {
                        var result = response.Result.Rates.FirstOrDefault(x => x.Target == item.TargetCode);
                        item.Rate = result != null ? result.Rate : 0;
                    }
                }
                await SaveCurrencyData(list);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SaveCurrencyData(ObservableCollection<CurrencyExchangeBindableItem> list)
        {
            return await dataService.UpdateRangeAsync(list.Select(x => x.ToCurrencyExchangeItem()));
        }
    }
}
