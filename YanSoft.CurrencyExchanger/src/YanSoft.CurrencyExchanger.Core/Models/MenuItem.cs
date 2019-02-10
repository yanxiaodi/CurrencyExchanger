using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;

namespace YanSoft.CurrencyExchanger.Core.Models
{
    public class CommonMenuItem : MvxViewModel
    {
        public string Icon { get; set; }

        public string Code { get; set; }

        #region Name;
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        #endregion
    }
}
