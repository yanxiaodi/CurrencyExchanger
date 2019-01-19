using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MvvmCross;
using YanSoft.CurrencyExchanger.Core.Common;

namespace YanSoft.CurrencyExchanger.Core.Utils
{
    public static class CurrencyHelper
    {
        public static string FormatCurrencyAmount(decimal amount, string cultureName)
        {
            //TODO
            var appSettings = Mvx.IoCProvider.Resolve<AppSettings>();
            if (appSettings.IsEnableLocalizedCurrencySymbol)
            {
                string currencyFormat = string.Format("C{0}", appSettings.DecimalPrecision);
                if (string.IsNullOrEmpty(cultureName))
                {
                    CultureInfo ci = CultureInfo.CurrentCulture;
                    return amount.ToString(currencyFormat, ci);
                }
                else
                {
                    string result = amount.ToString();
                    try
                    {
                        CultureInfo ci = new CultureInfo(cultureName);
                        result = amount.ToString(currencyFormat, ci);
                    }
                    catch
                    {
                        CultureInfo ci = CultureInfo.CurrentCulture;
                        result = amount.ToString(currencyFormat, ci);
                    }
                    return result;
                }
            }
            else
            {
                string numberFormat = string.Format("N{0}", appSettings.DecimalPrecision);
                return amount.ToString(numberFormat);
            }
        }
    }
}
