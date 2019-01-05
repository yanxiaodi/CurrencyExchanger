using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.Models
{
    public class CurrencyExchangeItem
    {
        public Guid Id { get; set; }
        public string SourceCode { get; set; }
        public string TargetCode { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public int SortOrder { get; set; }
        public bool IsStandard { get; set; }
        public int UpdateTimeUtc { get; set; }

        public CurrencyExchangeItem()
        {

        }

        public CurrencyExchangeItem(CurrencyItem source, CurrencyItem target, int sortOrder)
        {
            //Id = Guid.NewGuid();
            SourceCode = source.Code;
            TargetCode = target.Code;
            if (source.Code.Equals(target.Code))
            {
                IsStandard = true;
                Rate = 1;
                Amount = 1;
            }
            else
            {
                IsStandard = false;
                Rate = 0;
                Amount = 0;
            }
            UpdateTimeUtc = DateTimeHelper.ConvertDateTimeToTimestamp(DateTime.UtcNow);
            SortOrder = sortOrder;
        }

    }
}
