using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.iOS.Utils
{
    public class AppVersionHelper : IAppVersionHelper
    {
        public string GetBuildNumber()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }

        public string GetBuildVersion()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }
    }
}
