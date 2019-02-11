using System;
using System.Collections.Generic;
using System.Text;
using YanSoft.CurrencyExchanger.Core.Configurations;

namespace YanSoft.CurrencyExchanger.Core.Utils
{
    public static class ValidateHelper
    {
        public static string GetToken(DateTime timeNow, string saltKey)
        {
            int timeStamp = DateTimeHelper.ConvertDateTimeToTimestamp(timeNow.ToUniversalTime());
            string key = AppConfigurations.TokenKey;
            string value = $"ts={timeStamp.ToString()}&key={key}&sk={saltKey}";
            string signature = SHA1(value);
            signature = signature.Insert(7, timeStamp.ToString() + "|");
            return signature;
        }
        public static string SHA1(string source)
        {
            byte[] value = Encoding.UTF8.GetBytes(source);
            var sha1 = new System.Security.Cryptography.SHA1Managed();
            var result = sha1.ComputeHash(value);
            string delimitedHexHash = BitConverter.ToString(result);
            string hexHash = delimitedHexHash.Replace("-", "");
            return hexHash;
        }
    }
}
