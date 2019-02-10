using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using Plugin.Multilingual;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Messengers;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Resources;
using YanSoft.CurrencyExchanger.Core.Services;

namespace YanSoft.CurrencyExchanger.Core.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly AppSettings _appSettings;
        private readonly GlobalContext _globalContext;
        private readonly IMvxMessenger _messenger;
        private readonly IAppResourcesService _appResourcesService;
        public SettingsViewModel(IMvxNavigationService navigationService,
            AppSettings appSettings, GlobalContext globalContext,
            IMvxMessenger messenger, IAppResourcesService appResourcesService)
        {
            _navigationService = navigationService;
            _appSettings = appSettings;
            _globalContext = globalContext;
            _messenger = messenger;
            _appResourcesService = appResourcesService;
            LanguageItemList = new ObservableCollection<LanguageItem>(_globalContext.LanguageItemList);
            CurrentLanguageItem = _globalContext.LanguageItemList.Find(x => x.Code == _appSettings.LanguageCode);

        }



        #region IsAutoRefreshRatesOnStartup;
        private bool _isAutoRefreshRatesOnStartup;
        public bool IsAutoRefreshRatesOnStartup
        {
            get
            {
                _isAutoRefreshRatesOnStartup = _appSettings.IsAutoRefreshRatesOnStartupEnabled;
                return _isAutoRefreshRatesOnStartup;
            }
            set
            {
                SetProperty(ref _isAutoRefreshRatesOnStartup, value);
                _appSettings.IsAutoRefreshRatesOnStartupEnabled = value;
            }
        }
        #endregion


        #region IsEnablePullToRefresh;
        private bool _isEnablePullToRefresh;
        public bool IsEnablePullToRefresh
        {
            get
            {
                _isEnablePullToRefresh = _appSettings.IsPullToRefreshEnabled;
                return _isEnablePullToRefresh;
            }
            set
            {
                SetProperty(ref _isEnablePullToRefresh, value);
                _appSettings.IsPullToRefreshEnabled = value;
            }
        }
        #endregion


        #region IsPinBaseCurrencyToTopEnabled;
        private bool _isPinBaseCurrencyToTopEnabled;
        public bool IsPinBaseCurrencyToTopEnabled
        {
            get
            {
                _isPinBaseCurrencyToTopEnabled = _appSettings.IsPinBaseCurrencyToTopEnabled;
                return _isPinBaseCurrencyToTopEnabled;
            }
            set
            {
                SetProperty(ref _isPinBaseCurrencyToTopEnabled, value);
                _appSettings.IsPinBaseCurrencyToTopEnabled = value;
            }
        }
        #endregion

        #region DecimalPrecision;
        private int _decimalPrecision;
        public int DecimalPrecision
        {
            get
            {
                _decimalPrecision = _appSettings.DecimalPrecision;
                return _decimalPrecision;
            }
            set
            {
                SetProperty(ref _decimalPrecision, value);
                _appSettings.DecimalPrecision = value;
            }
        }
        #endregion


        #region IsEnableLocalizedCurrencySymbol;
        private bool _isEnableLocalizedCurrencySymbol;
        public bool IsEnableLocalizedCurrencySymbol
        {
            get
            {
                _isEnableLocalizedCurrencySymbol = _appSettings.IsLocalizedCurrencySymbolEnabled;
                return _isEnableLocalizedCurrencySymbol;
            }
            set
            {
                SetProperty(ref _isEnableLocalizedCurrencySymbol, value);
                _appSettings.IsLocalizedCurrencySymbolEnabled = value;
            }
        }
        #endregion


        #region IsEnableAutoInitializeToZero;
        private bool _isEnableAutoInitializeToZero;
        public bool IsEnableAutoInitializeToZero
        {
            get
            {
                _isEnableAutoInitializeToZero = _appSettings.IsAutoInitializeToZeroEnabled;
                return _isEnableAutoInitializeToZero;
            }
            set
            {
                SetProperty(ref _isEnableAutoInitializeToZero, value);
                _appSettings.IsAutoInitializeToZeroEnabled = value;
            }
        }
        #endregion


        #region LanguageItemList;
        private ObservableCollection<LanguageItem> _languageItemList;
        public ObservableCollection<LanguageItem> LanguageItemList
        {
            get => _languageItemList;
            set => SetProperty(ref _languageItemList, value);
        }
        #endregion


        #region CurrentLanguageItem;
        private LanguageItem _currentLanguageItem;
        public LanguageItem CurrentLanguageItem
        {
            get
            {
                _currentLanguageItem = _globalContext.LanguageItemList.Find(x => x.Code == _appSettings.LanguageCode);
                return _currentLanguageItem;
            }
            set
            {
                if (value != null && _appSettings.LanguageCode != value.Code)
                {
                    SetProperty(ref _currentLanguageItem, value);
                    _appSettings.LanguageCode = value.Code;
                    var culture = new CultureInfo(value.Code);
                    CrossMultilingual.Current.CurrentCultureInfo = culture;
                    AppResources.Culture = culture;
                    _appResourcesService.Refresh();
                    _globalContext.RefreshAllCurrencyItemList(culture);
                    _globalContext.CurrentBaseCurrency = _globalContext.CurrentBaseCurrency.ToCurrencyExchangeItem().ToCurrencyExchangeBindableItem();
                    var message = new UpdateLanguageMessage(this, value.Code);
                    _messenger.Publish(message);
                }
            }
        }
        #endregion


    }
}
