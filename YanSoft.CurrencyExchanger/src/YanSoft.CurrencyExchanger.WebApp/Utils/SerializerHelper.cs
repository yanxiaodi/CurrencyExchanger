using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YanSoft.CurrencyExchanger.WebApp.Utils
{
    public static class SerializerHelper
    {
        public static string ToJson<T>(T serialObject)
        {
            return JsonConvert.SerializeObject(serialObject);
        }

        public static T FromJson<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
