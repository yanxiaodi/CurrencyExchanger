using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XD.UWP.CurrencyExchanger.UWPAPP.Models
{
    /// <summary>
    /// Shake behavior
    /// </summary>
    public enum ShakeBehavior
    {
        /// <summary>
        /// Disable
        /// </summary>
        Disable = 0,
        /// <summary>
        /// Update currency rates
        /// </summary>
        UpdateCurrencyRates = 1,
        /// <summary>
        /// Clear currency list
        /// </summary>
        ClearCurrencyList = 2,
        /// <summary>
        /// Set base currency
        /// </summary>
        SetBaseCurrency = 3
    }
    /// <summary>
    /// History chart type
    /// </summary>
    public enum HistoryChartType
    {
        /// <summary>
        /// 1 day
        /// </summary>
        OneDay = 0,
        /// <summary>
        /// 5 days
        /// </summary>
        FiveDays = 1,
        /// <summary>
        /// 3 months
        /// </summary>
        ThreeMonths = 2,
        /// <summary>
        /// 1 year
        /// </summary>
        OneYear = 3,
        /// <summary>
        /// 2 years
        /// </summary>
        TwoYears = 4
    }
}
