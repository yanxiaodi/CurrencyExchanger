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

        public async Task<List<CurrencyExchangeItem>> GetAllCurreciesAsync()
        {
            return await _dataService.GetAllAsync();
        }

        public void CalculateCurrencyAmount(ObservableCollection<CurrencyExchangeBindableItem> list, CurrencyExchangeBindableItem targetCurrency = null)
        {
            CurrencyExchangeBindableItem standardItem = list.FirstOrDefault(x => x.IsBaseCurrency);
            if (standardItem != null)
            {
                if (targetCurrency != null)
                {
                    if (targetCurrency.IsBaseCurrency)
                    {
                        standardItem.Amount = targetCurrency.Amount;
                    }
                    else
                    {
                        if (targetCurrency.Rate != 0)
                        {
                            standardItem.Amount = targetCurrency.Amount / targetCurrency.Rate;
                        }
                    }
                    standardItem.AmountText = CurrencyHelper.FormatCurrencyAmount(standardItem.Amount, standardItem.TargetCurrency.CultureName);
                }
                foreach (var item in list.Where(x => x.IsBaseCurrency == false).ToList())
                {
                    if (targetCurrency != null)
                    {
                        if (targetCurrency.TargetCode != item.TargetCode)
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

        public void SetBaseCurrency(ObservableCollection<CurrencyExchangeBindableItem> list, CurrencyExchangeBindableItem baseCurrency)
        {
            foreach (var x in list)
            {
                x.IsBaseCurrency = false;
                x.BaseCurrency = baseCurrency.TargetCurrency;
                x.BaseCode = baseCurrency.TargetCode;
            }
            baseCurrency.IsBaseCurrency = true;
        }


        public async Task<bool> GetCurrencyRatesAsync(ObservableCollection<CurrencyExchangeBindableItem> list)
        {
            var sourceCode = list.First().BaseCode;
            var targetCodes = string.Join(",", list.Where(x => !x.IsBaseCurrency).Select(x => x.TargetCode).ToList());
            var response = await _apiService.GetLatestRates(sourceCode, targetCodes);
            if (response.IsSuccess)
            {
                foreach (var item in list)
                {
                    if (!item.IsBaseCurrency)
                    {
                        var result = response.Result.Rates.FirstOrDefault(x => x.Target == item.TargetCode);
                        item.Rate = result != null ? result.Rate : 0;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DeleteCurrencyAsync(ObservableCollection<CurrencyExchangeBindableItem> list, CurrencyExchangeBindableItem item)
        {
            var target = list.FirstOrDefault(x => x.Id == item.Id);
            if(target != null)
            {
                list.Remove(target);
                for (var i = 0; i < list.Count; i++)
                {
                    list[i].SortOrder = i;
                }
                await _dataService.DeleteAsync(target.Id);
                await _dataService.UpdateRangeAsync(list.Select(x => x.ToCurrencyExchangeItem()));
            }        
        }

        public async Task UpdateSortOrderAsync(ObservableCollection<CurrencyExchangeBindableItem> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                list[i].SortOrder = i;
            }
            await _dataService.UpdateRangeAsync(list.Select(x => x.ToCurrencyExchangeItem()));
        }



        public async Task<bool> SaveCurrencyDataAsync(ObservableCollection<CurrencyExchangeBindableItem> list)
        {
            return await _dataService.UpdateRangeAsync(list.Select(x => x.ToCurrencyExchangeItem()));
        }

        public void UpdateCurrencyAmountText(ObservableCollection<CurrencyExchangeBindableItem> list)
        {
            foreach (var item in list)
            {
                item.AmountText = CurrencyHelper.FormatCurrencyAmount(item.Amount, item.TargetCurrency.CultureName);
            }
        }

        public async Task AddCurrenciesAsync(ObservableCollection<CurrencyExchangeBindableItem> list, IEnumerable<CurrencyExchangeItem> items)
        {
            items.ToList().ForEach(x => list.Add(x.ToCurrencyExchangeBindableItem()));
            await _dataService.AddRangeAsync(items);
        }
    }
}
