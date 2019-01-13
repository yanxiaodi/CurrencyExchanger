using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;

namespace YanSoft.CurrencyExchanger.Core.Models
{
    public class CurrencySelectableBindableItem : MvxViewModel
    {

        #region IsSelected;
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
        #endregion

        public CurrencyItem CurrencyItem { get; set; }
    }
}
