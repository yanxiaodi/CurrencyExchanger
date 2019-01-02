using System;
using System.Collections.Generic;
using System.Text;

namespace YanSoft.CurrencyExchanger.Core.Models
{
    public class CurrencyItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string CultureName { get; set; }

        public CurrencyItem()
        {

        }

        public CurrencyItem(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
