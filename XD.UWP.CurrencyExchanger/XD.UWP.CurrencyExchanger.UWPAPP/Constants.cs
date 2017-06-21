using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XD.UWP.CurrencyExchanger.UWPAPP
{
    public class Constants
    {
        public const string AppCode = "CurrencyExchanger";

        public const string ProductId = "9WZDNCRDQ91S";

        #region local database

        /// <summary>
        /// The database file name
        /// </summary>
        public const string DbFileName = "Sqlite.db";
        #endregion


        /// <summary>
        /// Yahool finance Api
        /// </summary>
        public const string ApiUrl = "http://finance.yahoo.com/d/quotes.csv?s={0}&f=sl1d1t1ba&e=.csv"; // put list of currencies like this: "s=CUR1CUR2=X&s=CUR3CUR4=X&..."
        /// <summary>
        /// Yahool finance chart Api
        /// </summary>
        public const string HistoryChartImageUrl = "http://chart.finance.yahoo.com/{0}{1}{2}=X&lang=en-US&region=US";
        /// <summary>
        /// 1 day
        /// </summary>
        public const string Chart1DayParam = "b?s=";
        /// <summary>
        /// 5 days
        /// </summary>
        public const string Chart5DaysParam = "w?s=";
        /// <summary>
        /// 3 months
        /// </summary>
        public const string Chart3MonthsParam = "3m?";
        /// <summary>
        /// 1 year
        /// </summary>
        public const string Chart1YearParam = "1y?";
        /// <summary>
        /// 2 years
        /// </summary>
        public const string Chart2YearsParam = "2y?";
        /// <summary>
        /// The para template
        /// </summary>
        public const string ParaTemplate = "{0}{1}=X";
        /// <summary>
        /// The tile URI para template
        /// </summary>
        public const string tileUriParaTemplate = "s={0}";
        /// <summary>
        /// NA
        /// </summary>
        public const string NA = "N/A";
        /// <summary>
        /// The trim chars
        /// </summary>
        public static char[] TrimChars = new char[] { '"', '\'' };

        /// <summary>
        /// data field names
        /// </summary>
        public enum DataFieldNames : byte
        {
            CurrencyCodes = 0,
            Rate,
            TradeDate,
            TradeTime,
            Bid,
            Ask
        }





        /// <summary>
        /// The umeng application key
        /// </summary>
        public const string UmengAppKey = "4f77b8ed5270157f6b000089";


        #region In app payment
        /// <summary>
        /// Support the live tile 
        /// </summary>
        public const string LiveTileSupport = "LiveTileSupport";
        /// <summary>
        /// Remove the advertisement
        /// </summary>
        public const string NoAdvertisement = "NoAdvertisement";
        #endregion

    }
}
