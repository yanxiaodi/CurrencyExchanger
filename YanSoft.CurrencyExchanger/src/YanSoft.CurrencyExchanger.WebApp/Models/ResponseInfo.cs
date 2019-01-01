using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.WebApp.Utils;

namespace YanSoft.CurrencyExchanger.WebApp.Models
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
