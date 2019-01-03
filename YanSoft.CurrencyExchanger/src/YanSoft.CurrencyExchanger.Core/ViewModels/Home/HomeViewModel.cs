using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Services;

namespace YanSoft.CurrencyExchanger.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public override async Task Initialize()
        {
            var service = Mvx.IoCProvider.Resolve<IDataService<CurrencyExchangeItem>>();
            var list = await service.GetAllAsync();
            //CurrencyList = new ObservableCollection<CurrencyItem>(Mvx.IoCProvider.Resolve<Context>().AllCurrencyItemList);
            CurrencyList = new ObservableCollection<CurrencyExchangeItem>(list);
            await base.Initialize();
        }


        #region CurrencyList;
        private ObservableCollection<CurrencyExchangeItem> _currencyList;
        public ObservableCollection<CurrencyExchangeItem> CurrencyList
        {
            get => _currencyList;
            set => SetProperty(ref _currencyList, value);
        }
        #endregion
    }
}
