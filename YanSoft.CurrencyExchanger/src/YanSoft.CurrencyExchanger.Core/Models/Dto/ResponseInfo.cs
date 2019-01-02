using System;
using System.Collections.Generic;
using System.Text;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.Models.Dto
{
    public class ResponseInfo
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Timestamp { get; set; }

        public ResponseInfo()
        {
            IsSuccess = false;
            Message = string.Empty;
            Timestamp = DateTimeHelper.ConvertDateTimeToTimestamp(DateTime.UtcNow);
        }

        public ResponseInfo(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
            Timestamp = DateTimeHelper.ConvertDateTimeToTimestamp(DateTime.UtcNow);
        }
    }

    public class ResponseInfo<T> : ResponseInfo
    {
        public T Result { get; set; }

    }
}
