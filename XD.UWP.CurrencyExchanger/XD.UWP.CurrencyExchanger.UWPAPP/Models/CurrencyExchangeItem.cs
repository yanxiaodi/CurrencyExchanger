using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using XD.UWP.CurrencyExchanger.UWPAPP.Services;

namespace XD.UWP.CurrencyExchanger.UWPAPP.Models
{
    public class CurrencyExchangeItem : BindableBase
    {

        public CurrencyExchangeItem()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public CurrencyExchangeItem(CurrencyItem itemBase, CurrencyItem itemTarget, int sortOrder)
        {
            this.Id = Guid.NewGuid().ToString();
            this.CurrencyBase = itemBase;
            this.CurrencyBaseCode = itemBase.Code;
            this.CurrencyTarget = itemTarget;
            this.CurrencyTargetCode = itemTarget.Code;
            if (this.CurrencyBase.Code.Equals(this.CurrencyTarget.Code))
            {
                this.IsStandard = true;
                this.Rate = 1;
                this.InverseRate = 1;
            }
            else
            {
                this.IsStandard = false;
                this.Rate = this.InverseRate = 0;
            }
            this.TradeDate = DateTime.Now;
            this.SortOrder = sortOrder;
            this.Amount = 0;
            this.AmountText = CurrencyService.Instance.FormatCurrencyAmount(this.Amount, this.CurrencyTarget.CultureName);
        }


        string _Id = default(string);
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get { return _Id; } set { Set(ref _Id, value); } }




        DateTime _TradeDate = default(DateTime);
        /// <summary>
        /// Gets or sets the trade date.
        /// </summary>
        /// <value>
        /// The trade date.
        /// </value>
        public DateTime TradeDate { get { return _TradeDate; } set { Set(ref _TradeDate, value); } }



        decimal _Rate = default(decimal);
        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public decimal Rate { get { return _Rate; } set { Set(ref _Rate, value); } }


        decimal _Bid = default(decimal);
        /// <summary>
        /// Gets or sets the bid.
        /// </summary>
        /// <value>
        /// The bid.
        /// </value>
        public decimal Bid { get { return _Bid; } set { Set(ref _Bid, value); } }




        decimal _Ask = default(decimal);
        /// <summary>
        /// Gets or sets the ask.
        /// </summary>
        /// <value>
        /// The ask.
        /// </value>
        public decimal Ask { get { return _Ask; } set { Set(ref _Ask, value); } }


        decimal _InverseRate = default(decimal);
        /// <summary>
        /// Gets or sets the inverse rate.
        /// </summary>
        /// <value>
        /// The inverse rate.
        /// </value>
        public decimal InverseRate { get { return _InverseRate; } set { Set(ref _InverseRate, value); } }



        decimal _InverseBid = default(decimal);
        /// <summary>
        /// Gets or sets the inverse bid.
        /// </summary>
        /// <value>
        /// The inverse bid.
        /// </value>
        public decimal InverseBid { get { return _InverseBid; } set { Set(ref _InverseBid, value); } }



        decimal _InverseAsk = default(decimal);
        /// <summary>
        /// Gets or sets the inverse ask.
        /// </summary>
        /// <value>
        /// The inverse ask.
        /// </value>
        public decimal InverseAsk { get { return _InverseAsk; } set { Set(ref _InverseAsk, value); } }



        bool _IsStandard = default(bool);
        /// <summary>
        /// Gets or sets a value indicating whether this instance is standard.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is standard; otherwise, <c>false</c>.
        /// </value>
        public bool IsStandard { get { return _IsStandard; } set { Set(ref _IsStandard, value); } }




        decimal _Amount = default(decimal);
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get { return _Amount; } set { Set(ref _Amount, value); } }



        string _AmountText = default(string);
        public string AmountText { get { return _AmountText; } set { Set(ref _AmountText, value); } }




        CurrencyItem _CurrencyBase = default(CurrencyItem);
        /// <summary>
        /// Gets or sets the currency base.
        /// </summary>
        /// <value>
        /// The currency base.
        /// </value>
        public CurrencyItem CurrencyBase { get { return _CurrencyBase; } set { Set(ref _CurrencyBase, value); } }




        string _CurrencyBaseCode = default(string);
        /// <summary>
        /// Gets or sets the currency base code.
        /// </summary>
        /// <value>
        /// The currency base code.
        /// </value>
        public string CurrencyBaseCode { get { return _CurrencyBaseCode; } set { Set(ref _CurrencyBaseCode, value); } }




        CurrencyItem _CurrencyTarget = default(CurrencyItem);
        /// <summary>
        /// Gets or sets the currency target.
        /// </summary>
        /// <value>
        /// The currency target.
        /// </value>
        public CurrencyItem CurrencyTarget { get { return _CurrencyTarget; } set { Set(ref _CurrencyTarget, value); } }




        string _CurrencyTargetCode = default(string);
        /// <summary>
        /// Gets or sets the currency target code.
        /// </summary>
        /// <value>
        /// The currency target code.
        /// </value>
        public string CurrencyTargetCode { get { return _CurrencyTargetCode; } set { Set(ref _CurrencyTargetCode, value); } }




        int _SortOrder = default(int);
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get { return _SortOrder; } set { Set(ref _SortOrder, value); } }

    }
}
