using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.Common
{
    public class AppSettings
    {
        public void SetValue<T>(string key, T value)
        {
            try
            {
                Preferences.Set(key, SerializerHelper.ToJson<T>(value));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }

        public T GetValue<T>(string key, T defaultValue)
        {
            T value;
            if (Preferences.ContainsKey(key))
            {
                value = SerializerHelper.FromJson<T>(Preferences.Get(key, defaultValue.ToString()).ToString());
            }
            else
            {
                value = defaultValue;
            }
            return value;

        }

        #region IsAutoRefreshRatesOnStartupEnabled
        const string IsAutoRefreshRatesOnStartupEnabledKeyName = "IsAutoRefreshRatesOnStartupEnabled";
        const bool IsAutoRefreshRatesOnStartupEnabledDefault = true;
        public bool IsAutoRefreshRatesOnStartupEnabled
        {
            get => Preferences.Get(IsAutoRefreshRatesOnStartupEnabledKeyName, IsAutoRefreshRatesOnStartupEnabledDefault);
            set => Preferences.Set(IsAutoRefreshRatesOnStartupEnabledKeyName, value);
        }
        #endregion

        #region IsPullToRefreshEnabled
        const string IsPullToRefreshEnabledKeyName = "IsPullToRefreshEnabled";
        const bool IsPullToRefreshEnabledDefault = false;
        public bool IsPullToRefreshEnabled
        {
            get => Preferences.Get(IsPullToRefreshEnabledKeyName, IsPullToRefreshEnabledDefault);
            set => Preferences.Set(IsPullToRefreshEnabledKeyName, value);
        }
        #endregion

        #region IsPinBaseCurrencyToTopEnabled
        const string IsPinBaseCurrencyToTopEnabledKeyName = "IsPinBaseCurrencyToTopEnabled";
        const bool IsPinBaseCurrencyToTopEnabledDefault = true;
        public bool IsPinBaseCurrencyToTopEnabled
        {
            get => Preferences.Get(IsPinBaseCurrencyToTopEnabledKeyName, IsPinBaseCurrencyToTopEnabledDefault);
            set => Preferences.Set(IsPinBaseCurrencyToTopEnabledKeyName, value);
        }
        #endregion


        #region DecimalPrecision
        const string DecimalPrecisionKeyName = "DecimalPrecision";
        const int DecimalPrecisionDefault = 2;
        public int DecimalPrecision
        {
            get => Preferences.Get(DecimalPrecisionKeyName, DecimalPrecisionDefault);
            set => Preferences.Set(DecimalPrecisionKeyName, value);
        }
        #endregion

        #region IsLocalizedCurrencySymbolEnabled
        const string IsLocalizedCurrencySymbolEnabledKeyName = "IsLocalizedCurrencySymbolEnabled";
        const bool IsLocalizedCurrencySymbolEnabledDefault = false;
        public bool IsLocalizedCurrencySymbolEnabled
        {
            get => Preferences.Get(IsLocalizedCurrencySymbolEnabledKeyName, IsLocalizedCurrencySymbolEnabledDefault);
            set => Preferences.Set(IsLocalizedCurrencySymbolEnabledKeyName, value);
        }
        #endregion



        #region IsAutoInitializeToZeroEnabled
        const string IsAutoInitializeToZeroEnabledKeyName = "IsAutoInitializeToZeroEnabled";
        const bool IsAutoInitializeToZeroEnabledDefault = true;
        public bool IsAutoInitializeToZeroEnabled
        {
            get => Preferences.Get(IsAutoInitializeToZeroEnabledKeyName, IsAutoInitializeToZeroEnabledDefault);
            set => Preferences.Set(IsAutoInitializeToZeroEnabledKeyName, value);
        }
        #endregion

        #region DefaultChartRange
        const string DefaultChartRangeKeyName = "DefaultChartRange";
        const string DefaultChartRangeDefault = HistoryRange.RangeOneMonth;
        public string DefaultChartRange
        {
            get => Preferences.Get(DefaultChartRangeKeyName, DefaultChartRangeDefault);
            set => Preferences.Set(DefaultChartRangeKeyName, value);
        }
        #endregion

        #region LanguageCode
        const string LanguageCodeKeyName = "LanguageCode";
        const string LanguageCodeDefault = "en-US";
        public string LanguageCode
        {
            get => Preferences.Get(LanguageCodeKeyName, LanguageCodeDefault);
            set => Preferences.Set(LanguageCodeKeyName, value);
        }
        #endregion

    }
}
