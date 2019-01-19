using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.Models
{
    public static class ModelExtensions
    {
        public static CurrencyExchangeBindableItem ToCurrencyExchangeBindableItem(this CurrencyExchangeItem model)
        {
            var result = new CurrencyExchangeBindableItem
            {
                Id = model.Id,
                SourceCurrency = Mvx.IoCProvider.Resolve<GlobalContext>().AllCurrencyItemList.First(x => x.Code == model.SourceCode),
                SourceCode = model.SourceCode,
                TargetCurrency = Mvx.IoCProvider.Resolve<GlobalContext>().AllCurrencyItemList.First(x => x.Code == model.TargetCode),
                TargetCode = model.TargetCode,
                IsSourceCurrency = model.IsSourceCurrency,
                Rate = model.Rate,
                Amount = model.Amount,
                SortOrder = model.SortOrder,
                UpdateTimeUtc = DateTimeHelper.ConvertTimestampToDateTime(model.UpdateTimeUtc)
            };
            result.AmountText = CurrencyHelper.FormatCurrencyAmount(model.Amount, result.TargetCurrency.CultureName);

            return result;
        }


        public static CurrencyExchangeItem ToCurrencyExchangeItem(this CurrencyExchangeBindableItem model)
        {
            var result = new CurrencyExchangeItem
            {
                Id = model.Id,
                Amount = model.Amount,
                SourceCode = model.SourceCode,
                TargetCode = model.TargetCode,
                IsSourceCurrency = model.IsSourceCurrency,
                Rate = model.Rate,
                SortOrder = model.SortOrder,
                UpdateTimeUtc = DateTimeHelper.ConvertDateTimeToTimestamp(model.UpdateTimeUtc)
            };
            return result;
        }
    }
}
