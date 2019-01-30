using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.Toasts;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Services;

namespace YanSoft.CurrencyExchanger.Core.ViewModels
{
    public class AddCurrenciesViewModel : BaseViewModel<ObservableCollection<CurrencyExchangeBindableItem>>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ICurrencyService _currencyService;
        private readonly GlobalContext _globalContext;
        private readonly IToastService _toastService;

        public AddCurrenciesViewModel(IMvxNavigationService navigationService,
            ICurrencyService currencyService, GlobalContext globalContext, IToastService toastService)
        {
            _navigationService = navigationService;
            _currencyService = currencyService;
            _globalContext = globalContext;
            _toastService = toastService;

            //CurrencyItemSelectedList = new ObservableCollection<CurrencySelectableBindableItem>();
            CurrencyItemSourceList = new ObservableCollection<CurrencySelectableBindableItem>();
            CurrencyItemList = new MvxObservableCollection<CurrencySelectableBindableItem>();
        }

        #region Properties

        #region CurrencyList;
        private ObservableCollection<CurrencyExchangeBindableItem> _currencyList;
        public ObservableCollection<CurrencyExchangeBindableItem> CurrencyList
        {
            get => _currencyList;
            set => SetProperty(ref _currencyList, value);
        }
        #endregion

        #region CurrencyItemSourceList;
        private ObservableCollection<CurrencySelectableBindableItem> _currencyItemSourceList;
        public ObservableCollection<CurrencySelectableBindableItem> CurrencyItemSourceList
        {
            get => _currencyItemSourceList;
            set => SetProperty(ref _currencyItemSourceList, value);
        }
        #endregion


        #region CurrencyItemList;
        private ObservableCollection<CurrencySelectableBindableItem> _currencyItemList;
        public ObservableCollection<CurrencySelectableBindableItem> CurrencyItemList
        {
            get => _currencyItemList;
            set => SetProperty(ref _currencyItemList, value);
        }
        #endregion

        //#region CurrencyItemSelectedList;
        //private ObservableCollection<CurrencySelectableBindableItem> _currencyItemSelectedList;
        //public ObservableCollection<CurrencySelectableBindableItem> CurrencyItemSelectedList
        //{
        //    get => _currencyItemSelectedList;
        //    set => SetProperty(ref _currencyItemSelectedList, value);
        //}
        //#endregion



        #endregion


        #region Lifecycle events

        public override void Prepare(ObservableCollection<CurrencyExchangeBindableItem> list)
        {
            base.Prepare();
            CurrencyList = list;
        }


        public override async Task Initialize()
        {
            await base.Initialize();
            _globalContext.AllCurrencyItemList.Where(x => CurrencyList.Count(c => c.TargetCode == x.Code) == 0)
                .ForEach(x =>
                {
                    CurrencyItemSourceList.Add(new CurrencySelectableBindableItem { CurrencyItem = x, IsSelected = false });
                    CurrencyItemList.Add(new CurrencySelectableBindableItem { CurrencyItem = x, IsSelected = false });
                });
        }

        #endregion

        #region Commands


        #region SelectItemCommand;
        private IMvxCommand<CurrencySelectableBindableItem> _selectItemCommand;
        public IMvxCommand<CurrencySelectableBindableItem> SelectItemCommand
        {
            get
            {
                _selectItemCommand = _selectItemCommand ?? new MvxCommand<CurrencySelectableBindableItem>(SelectItem);
                return _selectItemCommand;
            }
        }
        private void SelectItem(CurrencySelectableBindableItem param)
        {
            // Implement your logic here.
            param.IsSelected = !param.IsSelected;
            var sourceTarget =
                CurrencyItemSourceList.SingleOrDefault(x => x.CurrencyItem.Code == param.CurrencyItem.Code);
            if (sourceTarget != null)
            {
                sourceTarget.IsSelected = param.IsSelected;
            }
        }
        #endregion


        #region SearchCurrencyCommand;
        private IMvxCommand<string> _searchCurrencyCommand;
        public IMvxCommand<string> SearchCurrencyCommand
        {
            get
            {
                _searchCurrencyCommand = _searchCurrencyCommand ?? new MvxCommand<string>(SearchCurrency);
                return _searchCurrencyCommand;
            }
        }
        private void SearchCurrency(string param)
        {
            // Implement your logic here.
            System.Diagnostics.Debug.WriteLine(param);
            CurrencyItemList.Clear();
            var keyword = param.Trim().ToLower();
            CurrencyItemSourceList.Where(x => x.CurrencyItem.Code.ToLower().Contains(keyword)
            || x.CurrencyItem.Name.ToLower().Contains(keyword))
                .ForEach(x =>
                {
                    CurrencyItemList.Add(x);
                });
        }
        #endregion


        #region AddCurrenciesAsyncCommand;
        private IMvxAsyncCommand _addCurrenciesAsyncCommand;
        public IMvxAsyncCommand AddCurrenciesAsyncCommand
        {
            get
            {
                _addCurrenciesAsyncCommand = _addCurrenciesAsyncCommand ?? new MvxAsyncCommand(AddCurrenciesAsync);
                return _addCurrenciesAsyncCommand;
            }
        }
        private async Task AddCurrenciesAsync()
        {
            // Implement your logic here.
            var baseCurrency = _globalContext.CurrentBaseCurrency;
            var count = CurrencyList.Count;
            var items = CurrencyItemSourceList.Where(x => x.IsSelected && CurrencyList.Count(c => c.TargetCode == x.CurrencyItem.Code) == 0)
                .Select(x => new CurrencyExchangeItem(new CurrencyItem { Code = baseCurrency.BaseCode }, new CurrencyItem { Code = x.CurrencyItem.Code }, ++count));
            await _currencyService.AddCurrenciesAsync(CurrencyList, items);
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                await _currencyService.GetCurrencyRatesAsync(CurrencyList);
            }
            else
            {
                //await _toastService.Notify(new NotificationOptions() { Title = Resources.AppResources.Toast_Title_Error, Description = Resources.AppResources.Toast_NetworkError });
                _toastService.ShowToast(Resources.AppResources.Toast_NetworkError);
            }
            _currencyService.CalculateCurrencyAmount(CurrencyList, _globalContext.CurrentBaseCurrency);
            await _navigationService.Close(this);
        }
        #endregion

        #endregion


    }
}
