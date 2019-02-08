using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Reflection;
using Plugin.Multilingual;
using YanSoft.CurrencyExchanger.Core.Resources;
using System.Globalization;

namespace YanSoft.CurrencyExchanger.Core.Utils
{
    public static class AppResourcesHelper
    {

        public static string GetString(string key, CultureInfo ci = null)
        {
            if (key == null)
                return "";
            if(ci == null)
            {
                ci = CrossMultilingual.Current.CurrentCultureInfo;
            }
            //System.Diagnostics.Debug.WriteLine(ci);
            var translation = AppResources.ResourceManager.GetString(key, ci);
            //System.Diagnostics.Debug.WriteLine(translation);

            if (translation == null)
            {

#if DEBUG
                throw new ArgumentException(
                    String.Format($"Key '{key}' was not found in resources for culture '{ci.Name}'."),
                    "Text");
#else
				translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
