using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Models.Dto;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public interface ICurrencyService
    {
        Task<bool> GetCurrencyRatesAsync(ObservableCollection<CurrencyExchangeBindableItem> list);
        Task<List<CurrencyRateHistoryItem>> GetCurrencyRatesHistoryAsync(CurrencyItem baseCurrency, CurrencyItem targetCurrency, string range);

        void CalculateCurrencyAmount(ObservableCollection<CurrencyExchangeBindableItem> list, CurrencyExchangeBindableItem targetCurrency = null);
        void SetBaseCurrency(ObservableCollection<CurrencyExchangeBindableItem> list, CurrencyExchangeBindableItem baseCurrency);
        Task<List<CurrencyExchangeItem>> GetAllCurreciesAsync();
        Task<bool> SaveCurrencyDataAsync(ObservableCollection<CurrencyExchangeBindableItem> list);
        Task AddCurrenciesAsync(ObservableCollection<CurrencyExchangeBindableItem> list, IEnumerable<CurrencyExchangeItem> items);
        Task DeleteCurrencyAsync(ObservableCollection<CurrencyExchangeBindableItem> list, CurrencyExchangeBindableItem item);
        Task UpdateSortOrderAsync(ObservableCollection<CurrencyExchangeBindableItem> list);
        void UpdateCurrencyAmountText(ObservableCollection<CurrencyExchangeBindableItem> list);
    }
}
