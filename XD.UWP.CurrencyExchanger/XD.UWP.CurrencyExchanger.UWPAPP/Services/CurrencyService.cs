using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using XD.UWP.CurrencyExchanger.UWPAPP.Models;
using XD.UWP.CurrencyExchanger.UWPAPP.Models.Dto;
using XD.UWP.CurrencyExchanger.UWPAPP.Services.SettingsServices;

namespace XD.UWP.CurrencyExchanger.UWPAPP.Services
{


    public class CurrencyService
    {
        public static CurrencyService Instance { get; } = new CurrencyService();
        private CurrencyService()
        {
            // private constructor
        }


        /// <summary>
        /// Gets the currency rates.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public async Task GetCurrencyRates(ObservableCollection<CurrencyExchangeItem> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CurrencyExchangeItem item in list)
            {
                //Do not calculate the rates if target code equals base code.
                if (item.CurrencyBaseCode.Equals(item.CurrencyTargetCode))
                {
                    item.Rate = item.Bid = item.Ask = item.InverseRate = item.InverseBid = item.InverseAsk = 1;
                    item.TradeDate = DateTime.Now;
                }
                else
                {
                    if (sb.Length > 0)
                        sb.Append('+');
                    sb.AppendFormat(CultureInfo.InvariantCulture, Constants.ParaTemplate, item.CurrencyBaseCode, item.CurrencyTargetCode);
                    //加入反向汇率
                    sb.Append('+');
                    sb.AppendFormat(CultureInfo.InvariantCulture, Constants.ParaTemplate, item.CurrencyTargetCode, item.CurrencyBaseCode);
                }

            }
            if (sb.Length > 0)
            {
                string requestUrl = String.Format(CultureInfo.InvariantCulture, Constants.ApiUrl, sb.ToString());
                HttpClient client = new HttpClient();
                //client.Timeout = TimeSpan.FromSeconds(30);
                using (client)
                {
                    try
                    {
                        string resultRaw = await client.GetStringAsync(new Uri(requestUrl));
                        //保存调试信息

                        if (resultRaw.Length > 0)
                        {
                            using (StringReader reader = new StringReader(resultRaw))
                            {
                                while (reader.Peek() > 0)
                                {
                                    CurrencyExchangeItem target = new CurrencyExchangeItem();
                                    #region 正常汇率

                                    string[] fields = reader.ReadLine().Split(new char[] { ',' });
                                    string[] fieldsInverse = reader.ReadLine().Split(new char[] { ',' });

                                    string fromCode = fields[(int)Constants.DataFieldNames.CurrencyCodes].Trim(Constants.TrimChars).Substring(0, 3);
                                    string toCode = fields[(int)Constants.DataFieldNames.CurrencyCodes].Trim(Constants.TrimChars).Substring(3, 3);

                                    if ((fields.Length == 0) || (fields[(int)Constants.DataFieldNames.TradeDate].Trim(Constants.TrimChars).Equals(Constants.NA, StringComparison.OrdinalIgnoreCase))
                                        || fields[(int)Constants.DataFieldNames.CurrencyCodes].Trim(Constants.TrimChars).Equals(Constants.NA, StringComparison.OrdinalIgnoreCase))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        //update the rates
                                        target = list.FirstOrDefault(x => x.CurrencyBaseCode == fromCode && x.CurrencyTargetCode == toCode);
                                        if (target != null)
                                        {
                                            if (fields[(int)Constants.DataFieldNames.Rate].Equals(Constants.NA, StringComparison.OrdinalIgnoreCase))
                                            {
                                                target.Rate = target.Bid = target.Ask = 0;
                                            }
                                            else
                                            {
                                                target.Rate = this.ParseDoubleValue(fields[(int)Constants.DataFieldNames.Rate]);
                                                target.Bid = this.ParseDoubleValue(fields[(int)Constants.DataFieldNames.Bid]);
                                                target.Ask = this.ParseDoubleValue(fields[(int)Constants.DataFieldNames.Ask]);
                                            }
                                            #region inverse rates
                                            //string[] fieldsInverse = reader.ReadLine().Split(new char[] { ',' });
                                            string fromCodeInverse = fieldsInverse[(int)Constants.DataFieldNames.CurrencyCodes].Trim(Constants.TrimChars).Substring(0, 3);
                                            string toCodeInverse = fieldsInverse[(int)Constants.DataFieldNames.CurrencyCodes].Trim(Constants.TrimChars).Substring(3, 3);

                                            if ((fieldsInverse.Length == 0) || (fieldsInverse[(int)Constants.DataFieldNames.TradeDate].Trim(Constants.TrimChars).Equals(Constants.NA, StringComparison.OrdinalIgnoreCase))
                                                || fieldsInverse[(int)Constants.DataFieldNames.CurrencyCodes].Trim(Constants.TrimChars).Equals(Constants.NA, StringComparison.OrdinalIgnoreCase))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                if (fieldsInverse[(int)Constants.DataFieldNames.Rate].Equals(Constants.NA, StringComparison.OrdinalIgnoreCase))
                                                {
                                                    target.InverseRate = target.InverseBid = target.InverseAsk = 0;
                                                }
                                                else
                                                {
                                                    target.InverseRate = this.ParseDoubleValue(fieldsInverse[(int)Constants.DataFieldNames.Rate]);
                                                    target.InverseBid = this.ParseDoubleValue(fieldsInverse[(int)Constants.DataFieldNames.Bid]);
                                                    target.InverseAsk = this.ParseDoubleValue(fieldsInverse[(int)Constants.DataFieldNames.Ask]);
                                                }
                                            }
                                            #endregion

                                        }
                                    }
                                    #endregion

                                    target.TradeDate = DateTime.Now;
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                }

            }
        }


        /// <summary>
        /// Gets the currency rates and calculate amount, save to database.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public async Task GetCurrencyRatesAndCalculateAmount(ObservableCollection<CurrencyExchangeItem> list)
        {
            await GetCurrencyRates(list);
            CalculateCurrencyAmount(list);
            //List<DtoCurrencyExchangeItem> items = new List<DtoCurrencyExchangeItem>();
            //list.ToList().ForEach(x => items.Add(x.ToDtoCurrencyExchangeItem()));

            //TODO
            //await ServiceLocator.Instance.Resolve<CurrencyExchangeDataService>().UpdateAllAsync(list.Select(x => x.ToDtoCurrencyExchangeItem()).ToList());

        }
        /// <summary>
        /// Calculates the currency amount.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="target">The target.</param>
        public void CalculateCurrencyAmount(ObservableCollection<CurrencyExchangeItem> list, CurrencyExchangeItem target = null)
        {
            CurrencyExchangeItem standardItem = list.FirstOrDefault(x => x.IsStandard == true);
            if (standardItem != null)
            {
                if (target != null)
                {
                    if (target.IsStandard)
                    {
                        standardItem.Amount = target.Amount;
                    }
                    else
                    {
                        standardItem.Amount = target.Amount * target.InverseRate;
                    }
                    standardItem.AmountText = this.FormatCurrencyAmount(standardItem.Amount, standardItem.CurrencyTarget.CultureName);
                }
                foreach (var item in list.Where(x => x.IsStandard == false).ToList())
                {
                    if (target != null)
                    {
                        if (target.CurrencyTargetCode != item.CurrencyTargetCode)
                        {
                            item.Amount = standardItem.Amount * item.Rate;
                        }
                    }
                    else
                    {
                        item.Amount = standardItem.Amount * item.Rate;
                    }
                    item.AmountText = this.FormatCurrencyAmount(item.Amount, item.CurrencyTarget.CultureName);
                }
            }
        }


        /// <summary>
        /// 转换为小数 因部分国家使用“，”为小数点 因此必须强制使用“.”来进行转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public decimal ParseDoubleValue(string value)
        {
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo culture = new CultureInfo("en-US");
            decimal result = 0;
            decimal.TryParse(value, style, culture, out result);
            return result;
        }


        /// <summary>
        /// Formats the currency amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        public string FormatCurrencyAmount(decimal amount, string cultureName)
        {

            if (SettingsService.Instance.IsLocalizedCurrencySymbol)
            {
                string currencyFormat = string.Format("C{0}", SettingsService.Instance.DecimalPrecision);
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
                string numberFormat = string.Format("N{0}", SettingsService.Instance.DecimalPrecision);
                return amount.ToString(numberFormat);
            }
        }

        /// <summary>
        /// 设置基准货币
        /// </summary>
        /// <param name="list"></param>
        /// <param name="target"></param>
        public void SetStandardCurrency(ObservableCollection<CurrencyExchangeItem> list, CurrencyExchangeItem item)
        {
            //修改基准货币
            foreach (var x in list)
            {
                x.IsStandard = false;
                x.CurrencyBase = item.CurrencyTarget;
                x.CurrencyBaseCode = item.CurrencyTargetCode;
            }
            item.IsStandard = true;
        }


        public string GetDefaultHistoryChartImageUrl(DtoCurrencyExchangeItem item)
        {
            string url = string.Empty;
            switch (SettingsService.Instance.DefaultChartType)
            {
                case HistoryChartType.OneDay:
                    url = string.Format(CultureInfo.InvariantCulture, Constants.HistoryChartImageUrl, Constants.Chart1DayParam, item.CurrencyBaseCode, item.CurrencyTargetCode);
                    break;
                case HistoryChartType.FiveDays:
                    url = string.Format(CultureInfo.InvariantCulture, Constants.HistoryChartImageUrl, Constants.Chart5DaysParam, item.CurrencyBaseCode, item.CurrencyTargetCode);
                    break;
                case HistoryChartType.ThreeMonths:
                    url = string.Format(CultureInfo.InvariantCulture, Constants.HistoryChartImageUrl, Constants.Chart3MonthsParam, item.CurrencyBaseCode, item.CurrencyTargetCode);
                    break;
                case HistoryChartType.OneYear:
                    url = string.Format(CultureInfo.InvariantCulture, Constants.HistoryChartImageUrl, Constants.Chart1YearParam, item.CurrencyBaseCode, item.CurrencyTargetCode);
                    break;
                case HistoryChartType.TwoYears:
                    url = string.Format(CultureInfo.InvariantCulture, Constants.HistoryChartImageUrl, Constants.Chart2YearsParam, item.CurrencyBaseCode, item.CurrencyTargetCode);
                    break;
                default:
                    break;
            }
            return url;
        }

    }





}
