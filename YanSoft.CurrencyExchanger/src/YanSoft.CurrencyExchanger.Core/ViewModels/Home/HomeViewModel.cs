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

namespace YanSoft.CurrencyExchanger.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IDataService<CurrencyExchangeItem> _dataService;
        private readonly AppSettings _appSettings;
        public HomeViewModel(IMvxNavigationService navigationService, ICurrencyService currencyService, IDataService<CurrencyExchangeItem> dataService, AppSettings appSettings)
        {
            _currencyService = currencyService;
            _navigationService = navigationService;
            _dataService = dataService;
            _appSettings = appSettings;
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
            var service = Mvx.IoCProvider.Resolve<IDataService<CurrencyExchangeItem>>();
            var list = await service.GetAllAsync();
            CurrencyList = new ObservableCollection<CurrencyExchangeBindableItem>(list.ConvertAll((x) => x.ToCurrencyExchangeBindableItem()).OrderBy(x => x.SortOrder));
            await GetLatestRatesAsync();
            await base.Initialize();
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
                            await GetLatestRatesAsync();
                        },
                        OnGetLatestRatesException);
                });
                return _getLatestRatesAsyncCommand;
            }
        }
        private async Task GetLatestRatesAsync()
        {
            // Implement your logic here.
            await _currencyService.GetCurrencyRates(CurrencyList);
            _currencyService.CalculateCurrencyAmount(CurrencyList, CurrencyList.First(x => x.IsStandard));
            await _currencyService.SaveCurrencyData(CurrencyList);
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
        private IMvxAsyncCommand _navigateToAddCurrenciesAsyncCommand;
        public IMvxAsyncCommand NavigateToAddCurrenciesAsyncCommand
        {
            get
            {
                _navigateToAddCurrenciesAsyncCommand = _navigateToAddCurrenciesAsyncCommand ?? new MvxAsyncCommand(MyCommandAsync);
                return _navigateToAddCurrenciesAsyncCommand;
            }
        }
        private async Task MyCommandAsync()
        {
            // Implement your logic here.
            await _navigationService.Navigate<AddCurrenciesViewModel, ObservableCollection<CurrencyExchangeBindableItem>>(CurrencyList);
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
            if (_appSettings.IsEnableAutoInitializeToZero)
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
                CurrencyExchangeBindableItem target = CurrencyList.FirstOrDefault(x => x.TargetCode == CurrentCalcCurrencyExchangeItem.TargetCode && x.SourceCode == CurrentCalcCurrencyExchangeItem.SourceCode);
                if (target != null)
                {
                    target.Amount = result;
                    _currencyService.CalculateCurrencyAmount(CurrencyList, target);
                    await _currencyService.SaveCurrencyData(CurrencyList);
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
