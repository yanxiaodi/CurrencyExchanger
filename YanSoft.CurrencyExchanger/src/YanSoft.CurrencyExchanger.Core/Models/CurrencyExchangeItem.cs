using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YanSoft.CurrencyExchanger.Core.Models
{
    public class CurrencyExchangeItem
    {
        public Guid Id { get; set; }
        public CurrencyItem SourceCurrency { get; set; }
        public string SourceCode { get; set; }
        public CurrencyItem TargetCurrency { get; set; }
        public string TargetCode { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string AmountText { get; set; }
        public int SortOrder { get; set; }
        public bool IsStandard { get; set; }
        public DateTime UpdateTimeUtc { get; set; }

        public CurrencyExchangeItem()
        {

        }

        public CurrencyExchangeItem(CurrencyItem source, CurrencyItem target, int sortOrder)
        {
            //Id = Guid.NewGuid();
            SourceCurrency = source;
            SourceCode = source.Code;
            TargetCurrency = target;
            TargetCode = target.Code;
            if (source.Code.Equals(target.Code))
            {
                IsStandard = true;
                Rate = 1;
            }
            else
            {
                IsStandard = false;
                Rate = 0;
            }
            UpdateTimeUtc = DateTime.UtcNow;
            SortOrder = sortOrder;
            Amount = 0;
            //TODO Format the text later.
            AmountText = Amount.ToString();
        }

    }
}
