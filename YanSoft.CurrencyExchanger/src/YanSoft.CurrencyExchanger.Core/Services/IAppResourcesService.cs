using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public interface IAppResourcesService
    {
        void Refresh();
        string GetString(string key, CultureInfo ci = null);
    }
}
