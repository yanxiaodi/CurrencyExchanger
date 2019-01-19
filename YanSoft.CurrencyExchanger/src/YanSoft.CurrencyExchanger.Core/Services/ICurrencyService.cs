using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.Core.Models;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public interface ICurrencyService
    {
        Task<bool> GetCurrencyRates(ObservableCollection<CurrencyExchangeBindableItem> list);

        void CalculateCurrencyAmount(ObservableCollection<CurrencyExchangeBindableItem> list, CurrencyExchangeBindableItem target = null);

        Task<bool> SaveCurrencyData(ObservableCollection<CurrencyExchangeBindableItem> list);

        void UpdateCurrencyAmountText(ObservableCollection<CurrencyExchangeBindableItem> list);
    }
}
