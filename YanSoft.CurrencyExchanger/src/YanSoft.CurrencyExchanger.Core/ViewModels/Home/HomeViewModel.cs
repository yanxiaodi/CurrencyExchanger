using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Services;
using System.Linq;
using MvvmCross.Navigation;
using YanSoft.CurrencyExchanger.Core.Calculator.Parser;
using Xamarin.Essentials;
using Plugin.Toasts;
using MvvmCross.Plugin.Messenger;
using YanSoft.CurrencyExchanger.Core.Messengers;

namespace YanSoft.CurrencyExchanger.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMvxNavigationService _navigationService;
        //private readonly IDataService<CurrencyExchangeItem> _dataService;
        private readonly AppSettings _appSettings;
        private readonly GlobalContext _globalContext;
        private readonly IToastService _toastService;
        private readonly MvxSubscriptionToken _token;
        public HomeViewModel(IMvxNavigationService navigationService,
            ICurrencyService currencyService, AppSettings appSettings,
            GlobalContext globalContext, IToastService toastService,
            IMvxMessenger messenger)
        {
            _currencyService = currencyService;
            _navigationService = navigationService;
            //_dataService = dataService;
            _appSettings = appSettings;
            _globalContext = globalContext;
            _toastService = toastService;
            IsPullToRefreshEnabled = false;
            IsRefreshing = false;
            _token = messenger.Subscribe<UpdateLanguageMessage>(OnUpdateLanguageMessage);
        }

        private void OnUpdateLanguageMessage(MvxMessage obj)
        {
            foreach (var item in CurrencyList)
            {
                item.TargetCurrencyName = _globalContext.AllCurrencyItemList.Find(x => x.Code == item.TargetCode).Name;
            }
        }



        #region Properties


        #region IsPullToRefreshEnabled;
        private bool _isPullToRefreshEnabled;
        public bool IsPullToRefreshEnabled
        {
            get => _isPullToRefreshEnabled;
            set => SetProperty(ref _isPullToRefreshEnabled, value);
        }
        #endregion


        #region IsRefreshing;
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        #endregion

        #region CurrencyList;
        private ObservableCollection<CurrencyExchangeBindableItem> _currencyList;
        public ObservableCollection<CurrencyExchangeBindableItem> CurrencyList
        {
            get => _currencyList;
            set => SetProperty(ref _currencyList, value);
        }
        #endregion

        #region Calculator

        #region IsCalculatorDialogVisible;
        private bool _isCalculatorDialogVisible;
        public bool IsCalculatorDialogVisible
        {
            get => _isCalculatorDialogVisible;
            set => SetProperty(ref _isCalculatorDialogVisible, value);
        }
        #endregion


        #region CalcExpression;
        private string _calcExpression;
        public string CalcExpression
        {
            get => _calcExpression;
            set => SetProperty(ref _calcExpression, value);
        }
        #endregion


        #region CalcResult;
        private string _calcResult;
        public string CalcResult
        {
            get => _calcResult;
            set => SetProperty(ref _calcResult, value);
        }
        #endregion

        #endregion



        #endregion


        #region Lifecycle events

        public override async Task Initialize()
        {
            IsPullToRefreshEnabled = _appSettings.IsPullToRefreshEnabled;

            var list = await _currencyService.GetAllCurreciesAsync();
            CurrencyList = new ObservableCollection<CurrencyExchangeBindableItem>(list.ConvertAll((x) => x.ToCurrencyExchangeBindableItem()).OrderBy(x => x.SortOrder));
            SetCurrentBaseCurrency();
            if (_appSettings.IsAutoRefreshRatesOnStartupEnabled)
            {
                // Connection to internet is available
                await GetLatestRatesAsync();
            }
            await base.Initialize();
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            IsPullToRefreshEnabled = _appSettings.IsPullToRefreshEnabled;
            if (_currencyList != null)
            {
                _currencyService.UpdateCurrencyAmountText(CurrencyList);
            }
        }

        private void SetCurrentBaseCurrency()
        {
            _globalContext.CurrentBaseCurrency = CurrencyList.FirstOrDefault(x => x.IsBaseCurrency);
            if (_globalContext.CurrentBaseCurrency == null)
            {
                CurrencyItem currency = _globalContext.AllCurrencyItemList.FirstOrDefault(x => x.Code == "USD");
                var item = new CurrencyExchangeItem(currency, currency, 0);
                _globalContext.CurrentBaseCurrency = item.ToCurrencyExchangeBindableItem();
            }
        }


        #endregion

        #region Commands

        #region GetLatestRatesAsyncCommand;

        #region GetLatestRatesTaskNotifier;
        private MvxNotifyTask _getLatestRatesTaskNotifier;
        /// <summary>
        /// Use the IsNotCompleted/IsCompleted properties of the GetLatestRatesTaskNotifier to show an indicator. Using the MvxNotifyTask is a recommended way to use an async command.
        /// </summary>
        /// <value>
        /// The GetLatestRates task notifier.
        /// </value>
        public MvxNotifyTask GetLatestRatesTaskNotifier
        {
            get => _getLatestRatesTaskNotifier;
            set => SetProperty(ref _getLatestRatesTaskNotifier, value);
        }
        #endregion

        private IMvxCommand _getLatestRatesAsyncCommand;
        public IMvxCommand GetLatestRatesAsyncCommand
        {
            get
            {
                _getLatestRatesAsyncCommand = _getLatestRatesAsyncCommand ?? new MvxCommand(() =>
                {
                    GetLatestRatesTaskNotifier = MvxNotifyTask.Create(async () =>
                        {
                            IsRefreshing = true;
                            await GetLatestRatesAsync();
                            if (IsRefreshing)
                            {
                                IsRefreshing = false;
                            }

                        },
                        OnGetLatestRatesException);
                });
                return _getLatestRatesAsyncCommand;
            }
        }
        private async Task GetLatestRatesAsync()
        {
            // Implement your logic here.
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                // Connection to internet is available
                await _currencyService.GetCurrencyRatesAsync(CurrencyList);
                _currencyService.CalculateCurrencyAmount(CurrencyList, _globalContext.CurrentBaseCurrency);

                if (_appSettings.IsPinBaseCurrencyToTopEnabled)
                {
                    if (_globalContext.CurrentBaseCurrency.SortOrder != 0)
                    {
                        var baseCurrency = CurrencyList.First(x =>
                        x.BaseCode == _globalContext.CurrentBaseCurrency.BaseCode
                        && x.TargetCode == _globalContext.CurrentBaseCurrency.TargetCode);
                        CurrencyList.Move(CurrencyList.IndexOf(baseCurrency), 0);
                        for (var i = 0; i < CurrencyList.Count; i++)
                        {
                            CurrencyList[i].SortOrder = i;
                        }
                    }
                }
                await _currencyService.SaveCurrencyDataAsync(CurrencyList);
            }
            else
            {
                //await _toastService.Notify(new NotificationOptions() { Title = Resources.AppResources.Toast_Title_Error, Description = Resources.AppResources.Toast_NetworkError });
                _toastService.ShowToast(Resources.AppResources.Toast_NetworkError);
            }
        }

        private void OnGetLatestRatesException(Exception ex)
        {
            // Catch and log the exception here.
        }
        #endregion


        #region RefreshRatesAsyncCommand;

        #region RefreshRatesTaskNotifier;
        private MvxNotifyTask _refreshRatesTaskNotifier;
        /// <summary>
        /// Use the IsNotCompleted/IsCompleted properties of the RefreshRatesTaskNotifier to show an indicator. Using the MvxNotifyTask is a recommended way to use an async command.
        /// </summary>
        /// <value>
        /// The RefreshRates task notifier.
        /// </value>
        public MvxNotifyTask RefreshRatesTaskNotifier
        {
            get => _refreshRatesTaskNotifier;
            set => SetProperty(ref _refreshRatesTaskNotifier, value);
        }
        #endregion

        private IMvxCommand _refreshRatesTaskNotifierAsyncCommand;
        public IMvxCommand RefreshRatesAsyncCommand
        {
            get
            {
                _refreshRatesTaskNotifierAsyncCommand = _refreshRatesTaskNotifierAsyncCommand ?? new MvxCommand(() =>
                {
                    RefreshRatesTaskNotifier = MvxNotifyTask.Create(async () =>
                        {
                            await RefreshRatesAsync();
                        },
                        OnRefreshRatesException);
                });
                return _refreshRatesTaskNotifierAsyncCommand;
            }
        }
        private async Task RefreshRatesAsync()
        {
            // Implement your logic here.
            await GetLatestRatesAsync();
        }

        private void OnRefreshRatesException(Exception ex)
        {
            // Catch and log the exception here.
        }
        #endregion



        #region NavigateToAddCurrenciesAsyncCommand;

        #region NavigateToAddCurrenciesTaskNotifier;
        private MvxNotifyTask _navigateToAddCurrenciesTaskNotifier;
        /// <summary>
        /// Use the IsNotCompleted/IsCompleted properties of the NavigateToAddCurrenciesTaskNotifier to show an indicator. Using the MvxNotifyTask is a recommended way to use an async command.
        /// </summary>
        /// <value>
        /// The NavigateToAddCurrencies task notifier.
        /// </value>
        public MvxNotifyTask NavigateToAddCurrenciesTaskNotifier
        {
            get => _navigateToAddCurrenciesTaskNotifier;
            set => SetProperty(ref _navigateToAddCurrenciesTaskNotifier, value);
        }
        #endregion

        private IMvxCommand _navigateToAddCurrenciesAsyncCommand;
        public IMvxCommand NavigateToAddCurrenciesAsyncCommand
        {
            get
            {
                _navigateToAddCurrenciesAsyncCommand = _navigateToAddCurrenciesAsyncCommand ?? new MvxCommand(() =>
                {
                    NavigateToAddCurrenciesTaskNotifier = MvxNotifyTask.Create(async () =>
                        {
                            await NavigateToAddCurrenciesAsync();
                        },
                        OnNavigateToAddCurrenciesException);
                });
                return _navigateToAddCurrenciesAsyncCommand;
            }
        }
        private async Task NavigateToAddCurrenciesAsync()
        {
            // Implement your logic here.
            await _navigationService.Navigate<AddCurrenciesViewModel, ObservableCollection<CurrencyExchangeBindableItem>>(CurrencyList);

        }

        private void OnNavigateToAddCurrenciesException(Exception ex)
        {
            // Catch and log the exception here.
        }
        #endregion


        #region NavigateToEditListAsyncCommand;

        #region NavigateToEditListTaskNotifier;
        private MvxNotifyTask _navigateToEditListTaskNotifier;
        /// <summary>
        /// Use the IsNotCompleted/IsCompleted properties of the NavigateToEditListTaskNotifier to show an indicator. Using the MvxNotifyTask is a recommended way to use an async command.
        /// </summary>
        /// <value>
        /// The NavigateToEditList task notifier.
        /// </value>
        public MvxNotifyTask NavigateToEditListTaskNotifier
        {
            get => _navigateToEditListTaskNotifier;
            set => SetProperty(ref _navigateToEditListTaskNotifier, value);
        }
        #endregion

        private IMvxCommand _navigateToEditListAsyncCommand;
        public IMvxCommand NavigateToEditListAsyncCommand
        {
            get
            {
                _navigateToEditListAsyncCommand = _navigateToEditListAsyncCommand ?? new MvxCommand(() =>
                {
                    NavigateToEditListTaskNotifier = MvxNotifyTask.Create(async () =>
                        {
                            await NavigateToEditListAsync();
                        },
                        OnNavigateToEditListException);
                });
                return _navigateToEditListAsyncCommand;
            }
        }
        private async Task NavigateToEditListAsync()
        {
            // Implement your logic here.
            await _navigationService.Navigate<EditListViewModel, ObservableCollection<CurrencyExchangeBindableItem>>(CurrencyList);

        }

        private void OnNavigateToEditListException(Exception ex)
        {
            // Catch and log the exception here.
        }
        #endregion


        #region SetBaseCurrencyAsyncCommand;
        private IMvxAsyncCommand<CurrencyExchangeBindableItem> _setBaseCurrencyAsyncCommand;
        public IMvxAsyncCommand<CurrencyExchangeBindableItem> SetBaseCurrencyAsyncCommand
        {
            get
            {
                _setBaseCurrencyAsyncCommand = _setBaseCurrencyAsyncCommand ?? new MvxAsyncCommand<CurrencyExchangeBindableItem>(SetBaseCurrencyAsync);
                return _setBaseCurrencyAsyncCommand;
            }
        }
        private async Task SetBaseCurrencyAsync(CurrencyExchangeBindableItem param)
        {
            // Implement your logic here.
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                // Connection to internet is available
                _globalContext.CurrentBaseCurrency = param;
                IsRefreshing = true;

                _currencyService.SetBaseCurrency(CurrencyList, param);
                await GetLatestRatesAsync();
                if (IsRefreshing)
                {
                    IsRefreshing = false;
                }
            }
            else
            {
                //await _toastService.Notify(new NotificationOptions() { Title = Resources.AppResources.Toast_Title_Error, Description = Resources.AppResources.Toast_NetworkError });
                _toastService.ShowToast(Resources.AppResources.Toast_NetworkError);

            }
        }
        #endregion




        #region DeleteCurrencyAsyncCommand;
        private IMvxAsyncCommand<CurrencyExchangeBindableItem> _deleteCurrencyAsyncCommand;
        public IMvxAsyncCommand<CurrencyExchangeBindableItem> DeleteCurrencyAsyncCommand
        {
            get
            {
                _deleteCurrencyAsyncCommand = _deleteCurrencyAsyncCommand ?? new MvxAsyncCommand<CurrencyExchangeBindableItem>(DeleteCurrencyAsync);
                return _deleteCurrencyAsyncCommand;
            }
        }
        private async Task DeleteCurrencyAsync(CurrencyExchangeBindableItem param)
        {
            // Implement your logic here.
            if (!param.IsBaseCurrency)
            {
                await _currencyService.DeleteCurrencyAsync(CurrencyList, param);
            }
            else
            {
                _toastService.ShowToast(Resources.AppResources.Toast_Can_Not_Delete_Base_Currency);

            }
        }
        #endregion



        #region NavigateToChartAsyncCommand;
        private IMvxAsyncCommand<CurrencyExchangeBindableItem> _navigateToChartAsyncCommand;
        public IMvxAsyncCommand<CurrencyExchangeBindableItem> NavigateToChartAsyncCommand
        {
            get
            {
                _navigateToChartAsyncCommand = _navigateToChartAsyncCommand ?? new MvxAsyncCommand<CurrencyExchangeBindableItem>(NavigateToChartAsync);
                return _navigateToChartAsyncCommand;
            }
        }
        private async Task NavigateToChartAsync(CurrencyExchangeBindableItem param)
        {
            // Implement your logic here.
            if (!param.IsBaseCurrency)
            {
                await _navigationService.Navigate<ChartViewModel, CurrencyExchangeBindableItem>(param);
            }
            else
            {
                _toastService.ShowToast(Resources.AppResources.Toast_No_Chart_Available_For_Base_Currency);
            }
        }
        #endregion

        #region Calculator


        #region CurrentCalcCurrencyExchangeItem;
        private CurrencyExchangeBindableItem _currentCalcCurrencyExchangeItem;
        public CurrencyExchangeBindableItem CurrentCalcCurrencyExchangeItem
        {
            get => _currentCalcCurrencyExchangeItem;
            set => SetProperty(ref _currentCalcCurrencyExchangeItem, value);
        }
        #endregion


        #region ShowCalculatorCommand;
        private IMvxCommand<CurrencyExchangeBindableItem> _showCalculatorCommand;
        public IMvxCommand<CurrencyExchangeBindableItem> ShowCalculatorCommand
        {
            get
            {
                _showCalculatorCommand = _showCalculatorCommand ?? new MvxCommand<CurrencyExchangeBindableItem>(ShowCalculator);
                return _showCalculatorCommand;
            }
        }
        private void ShowCalculator(CurrencyExchangeBindableItem param)
        {
            // Implement your logic here.
            CurrentCalcCurrencyExchangeItem = param;
            if (_appSettings.IsAutoInitializeToZeroEnabled)
            {
                CalcExpression = CalcResult = "0";
            }
            else
            {
                CalcExpression = CalcResult = param.Amount.ToString();
            }
            if (!IsCalculatorDialogVisible)
            {
                IsCalculatorDialogVisible = true;
            }
        }
        #endregion


        #region ClearCalcExpressionCommand;
        private IMvxCommand _clearCalcExpressionCommand;
        public IMvxCommand  ClearCalcExpressionCommand
        {
            get
            {
                _clearCalcExpressionCommand = _clearCalcExpressionCommand ?? new MvxCommand( ClearCalcExpression);
                return _clearCalcExpressionCommand;
            }
        }
        private void  ClearCalcExpression()
        {
            // Implement your logic here.
            CalcExpression = CalcResult = "0";
        }
        #endregion


        #region BackspaceCommand;
        private IMvxCommand _backspaceCommand;
        public IMvxCommand BackspaceCommand
        {
            get
            {
                _backspaceCommand = _backspaceCommand ?? new MvxCommand(Backspace);
                return _backspaceCommand;
            }
        }
        private void Backspace()
        {
            // Implement your logic here.
            if (CalcExpression == "0")
            {
                return;
            }
            if (CalcExpression.Length == 1)
            {
                CalcExpression = CalcResult = "0";
            }
            else
            {
                CalcExpression = CalcExpression.Substring(0, CalcExpression.Length - 1);
                var last = CalcExpression.Last().ToString();
                if (last != "+" && last != "-" && last != "*" && last != "/" && last != ".")
                {
                    var exp = ComputeExpression();
                    if (exp != null)
                    {
                        CalcResult = exp.Value.ToString();
                    }
                }
            }
        }
        #endregion


        #region AppendCalculatorTextCommand;
        private IMvxCommand<string> _appendCalculatorTextCommand;
        public IMvxCommand<string> AppendCalculatorTextCommand
        {
            get
            {
                _appendCalculatorTextCommand = _appendCalculatorTextCommand ?? new MvxCommand<string>(AppendCalculatorText);
                return _appendCalculatorTextCommand;
            }
        }
        private void AppendCalculatorText(string text)
        {
            // Implement your logic here.
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (CalcExpression == "0")
            {
                if (text != "+" && text != "-" && text != "*" && text != "/" && text != ".")
                {
                    CalcExpression = CalcResult = text;
                }
                else
                {
                    CalcExpression += text;
                }
            }
            else
            {
                // Only calculate the result when inputting the number.
                if (text != "+" && text != "-" && text != "*" && text != "/" && text != ".")
                {
                    CalcExpression += text;
                    var exp = ComputeExpression();
                    if (exp != null)
                    {
                        CalcResult = exp.Value.ToString();
                    }
                }
                else
                {
                    string last = CalcExpression.Last().ToString();
                    if (last != "+" && last != "-" && last != "*" && last != "/" && last != ".")
                    {
                        CalcExpression += text;
                    }
                }
            }
        }
        #endregion


        #region ComputeAnswerCommand;
        private IMvxCommand _computeAnswerCommand;
        public IMvxCommand ComputeAnswerCommand
        {
            get
            {
                _computeAnswerCommand = _computeAnswerCommand ?? new MvxCommand(ComputeAnswer);
                return _computeAnswerCommand;
            }
        }
        private void ComputeAnswer()
        {
            // Implement your logic here.
            var exp = ComputeExpression();
            if (exp != null)
            {
                CalcExpression = CalcResult = exp.Value.ToString();
            }
            else
            {
                CalcResult = "8-(";
            }
        }
        #endregion



        #region SetCurrencyAmountAsyncCommand;

        #region SetCurrencyAmountTaskNotifier;
        private MvxNotifyTask _setCurrencyAmountTaskNotifier;
        /// <summary>
        /// Use the IsNotCompleted/IsCompleted properties of the SetCurrencyAmountTaskNotifier to show an indicator. Using the MvxNotifyTask is a recommended way to use an async command.
        /// </summary>
        /// <value>
        /// The SetCurrencyAmount task notifier.
        /// </value>
        public MvxNotifyTask SetCurrencyAmountTaskNotifier
        {
            get => _setCurrencyAmountTaskNotifier;
            set => SetProperty(ref _setCurrencyAmountTaskNotifier, value);
        }
        #endregion

        private IMvxCommand _setCurrencyAmountAsyncCommand;
        public IMvxCommand SetCurrencyAmountAsyncCommand
        {
            get
            {
                _setCurrencyAmountAsyncCommand = _setCurrencyAmountAsyncCommand ?? new MvxCommand(() =>
                {
                    SetCurrencyAmountTaskNotifier = MvxNotifyTask.Create(async () =>
                        {
                            await SetCurrencyAmountAsync();
                        },
                        OnSetCurrencyAmountException);
                });
                return _setCurrencyAmountAsyncCommand;
            }
        }
        private async Task SetCurrencyAmountAsync()
        {
            // Implement your logic here.
            if (CalcResult != "8-(")
            {
                decimal.TryParse(CalcResult, out var result);
                CurrencyExchangeBindableItem target = CurrencyList.FirstOrDefault(x => x.TargetCode == CurrentCalcCurrencyExchangeItem.TargetCode && x.BaseCode == CurrentCalcCurrencyExchangeItem.BaseCode);
                if (target != null)
                {
                    target.Amount = result;
                    _currencyService.CalculateCurrencyAmount(CurrencyList, target);
                    await _currencyService.SaveCurrencyDataAsync(CurrencyList);
                }
                IsCalculatorDialogVisible = false;
            }
        }

        private void OnSetCurrencyAmountException(Exception ex)
        {
            // Catch and log the exception here.
        }
        #endregion


        #region CancelCalculatorCommand;
        private IMvxCommand _cancelCalculatorCommand;
        public IMvxCommand CancelCalculatorCommand
        {
            get
            {
                _cancelCalculatorCommand = _cancelCalculatorCommand ?? new MvxCommand(CancelCalculator);
                return _cancelCalculatorCommand;
            }
        }
        private void CancelCalculator()
        {
            // Implement your logic here.
            IsCalculatorDialogVisible = false;
        }
        #endregion

        private ConstantExpression ComputeExpression()
        {
            try
            {
                IExpression exp = FunctionParser.Parse(CalcExpression);
                if (exp != null)
                {
                    IExpression answer = exp.Simplify();
                    if (answer is ConstantExpression)
                    {
                        return (ConstantExpression)answer;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    //TODO
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


        #endregion

        #endregion


    }
}
