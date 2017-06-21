using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XD.UWP.CurrencyExchanger.UWPAPP.Models.Dto
{
    public class DtoCurrencyExchangeItem
    {
        public string Id { get; set; }

        public DateTime TradeDate { get; set; }

        public decimal Rate { get; set; }

        public decimal Bid { get; set; }

        public decimal Ask { get; set; }

        public decimal InverseRate { get; set; }

        public decimal InverseBid { get; set; }

        public decimal InverseAsk { get; set; }

        public bool IsStandard { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyBaseCode { get; set; }

        public string CurrencyTargetCode { get; set; }

        public int SortOrder { get; set; }
    }
}
