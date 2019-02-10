using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.UWP.Utils
{
    public class AppVersionHelper : IAppVersionHelper
    {
        private Package _package;

        public AppVersionHelper()
        {
            _package = Package.Current;
        }

        public string GetBuildNumber()
        {
            PackageVersion version = _package.Id.Version;
            return version.Build.ToString();
        }

        public string GetBuildVersion()
        {
            PackageVersion version = _package.Id.Version;
            return $"V{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
