using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Xamarin.Forms.Internals;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Services;

namespace YanSoft.CurrencyExchanger.Core.ViewModels
{
    public class AddCurrenciesViewModel : BaseViewModel
    {
        private readonly GlobalContext _globalContext;
        private readonly IDataService<CurrencyExchangeItem> _dataService;
        public AddCurrenciesViewModel(GlobalContext globalContext, IDataService<CurrencyExchangeItem> dataService)
        {
            _globalContext = globalContext;
            _dataService = dataService;
            CurrencyItemSelectedList = new ObservableCollection<CurrencySelectableBindableItem>();
            CurrencyItemSourceList = new ObservableCollection<CurrencySelectableBindableItem>();
            CurrencyItemList = new MvxObservableCollection<CurrencySelectableBindableItem>();
        }

        #region Properties

        

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

        #region CurrencyItemSelectedList;
        private ObservableCollection<CurrencySelectableBindableItem> _currencyItemSelectedList;
        public ObservableCollection<CurrencySelectableBindableItem> CurrencyItemSelectedList
        {
            get => _currencyItemSelectedList;
            set => SetProperty(ref _currencyItemSelectedList, value);
        }
        #endregion

        #endregion


        #region Lifecycle


        public override async Task Initialize()
        {
            await base.Initialize();
            List<CurrencyExchangeItem> localCurrencyList = await _dataService.GetAllAsync();
            _globalContext.AllCurrencyItemList.Where(x => localCurrencyList.Count(c => c.TargetCode == x.Code) == 0 )
                .ForEach(x =>
                {
                    CurrencyItemSourceList.Add(new CurrencySelectableBindableItem { CurrencyItem = x, IsSelected = false});
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

        #endregion


    }
}
