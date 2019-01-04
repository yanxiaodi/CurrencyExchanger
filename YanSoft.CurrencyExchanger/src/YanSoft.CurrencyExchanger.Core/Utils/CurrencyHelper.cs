using System;
using System.Collections.Generic;
using System.Text;

namespace YanSoft.CurrencyExchanger.Core.Utils
{
    public static class CurrencyHelper
    {
        public static string FormatCurrencyAmount(decimal amount, string cultureName)
        {
            //TODO 
            return amount.ToString("C");
        }
    }
}
