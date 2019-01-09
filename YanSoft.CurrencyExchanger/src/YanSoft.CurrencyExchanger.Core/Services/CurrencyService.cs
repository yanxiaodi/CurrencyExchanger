using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.Core.Models;
using System.Linq;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IApiService _apiService;
        private readonly IDataService<CurrencyExchangeItem> _dataService;

        public CurrencyService(IApiService apiService, IDataService<CurrencyExchangeItem> dataService)
        {
            _apiService = apiService;
            _dataService = dataService;
        }

        public void CalculateCurrencyAmount(ObservableCollection<CurrencyExchangeBindableItem> list, CurrencyExchangeBindableItem target = null)
        {
            CurrencyExchangeBindableItem standardItem = list.FirstOrDefault(x => x.IsStandard == true);
            if (standardItem != null)
            {
                if (target != null)
                {
                    if (target.IsStandard)
                    {
                        standardItem.Amount = target.Amount;
                    }
                    else
                    {
                        standardItem.Amount = target.Amount / target.Rate;
                    }
                    standardItem.AmountText = CurrencyHelper.FormatCurrencyAmount(standardItem.Amount, standardItem.TargetCurrency.CultureName);
                }
                foreach (var item in list.Where(x => x.IsStandard == false).ToList())
                {
                    if (target != null)
                    {
                        if (target.TargetCode != item.TargetCode)
                        {
                            item.Amount = standardItem.Amount * item.Rate;
                        }
                    }
                    else
                    {
                        item.Amount = standardItem.Amount * item.Rate;
                    }
                    item.AmountText = CurrencyHelper.FormatCurrencyAmount(item.Amount, item.TargetCurrency.CultureName);
                }
            }
        }


        public async Task<bool> GetCurrencyRates(ObservableCollection<CurrencyExchangeBindableItem> list)
        {
            var sourceCode = list.First().SourceCode;
            var targetCodes = string.Join(",", list.Where(x => !x.IsStandard).Select(x => x.TargetCode).ToList());
            var response = await _apiService.GetLatestRates(sourceCode, targetCodes);
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
            return await _dataService.UpdateRangeAsync(list.Select(x => x.ToCurrencyExchangeItem()));
        }
    }
}
