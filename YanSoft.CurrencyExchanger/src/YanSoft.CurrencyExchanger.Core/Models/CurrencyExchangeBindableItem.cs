using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;

namespace YanSoft.CurrencyExchanger.Core.Models
{
    public class CurrencyExchangeBindableItem : MvxViewModel
    {
        public Guid Id { get; set; }


        #region BaseCurrency;
        private CurrencyItem _baseCurrency;
        public CurrencyItem BaseCurrency
        {
            get => _baseCurrency;
            set => SetProperty(ref _baseCurrency, value);
        }
        #endregion


        #region BaseCode;
        private string _baseCode;
        public string BaseCode
        {
            get => _baseCode;
            set => SetProperty(ref _baseCode, value);
        }
        #endregion


        #region TargetCurrency;
        private CurrencyItem _targetCurrency;
        public CurrencyItem TargetCurrency
        {
            get => _targetCurrency;
            set => SetProperty(ref _targetCurrency, value);
        }
        #endregion


        #region TargetCode;
        private string _targetCode;
        public string TargetCode
        {
            get => _targetCode;
            set => SetProperty(ref _targetCode, value);
        }
        #endregion


        #region Rate;
        private decimal _rate;
        public decimal Rate
        {
            get => _rate;
            set => SetProperty(ref _rate, value);
        }
        #endregion


        #region Amount;
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }
        #endregion


        #region AmountText;
        private string _amountText;
        public string AmountText
        {
            get => _amountText;
            set => SetProperty(ref _amountText, value);
        }
        #endregion


        #region SortOrder;
        private int _sortOrder;
        public int SortOrder
        {
            get => _sortOrder;
            set => SetProperty(ref _sortOrder, value);
        }
        #endregion


        #region IsBaseCurrency;
        private bool _isBaseCurrency;
        public bool IsBaseCurrency
        {
            get => _isBaseCurrency;
            set => SetProperty(ref _isBaseCurrency, value);
        }
        #endregion


        #region UpdateTimeUtc;
        private DateTime _updateTimeUtc;
        public DateTime UpdateTimeUtc
        {
            get => _updateTimeUtc;
            set => SetProperty(ref _updateTimeUtc, value);
        }
        #endregion
    }
}
