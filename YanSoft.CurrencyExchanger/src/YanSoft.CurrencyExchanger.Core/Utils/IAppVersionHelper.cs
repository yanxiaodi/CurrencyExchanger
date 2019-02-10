using System;
using System.Collections.Generic;
using System.Text;

namespace YanSoft.CurrencyExchanger.Core.Utils
{
    public interface IAppVersionHelper
    {
        string GetBuildVersion();
        string GetBuildNumber();
    }
}
