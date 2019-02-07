using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Reflection;
using Plugin.Multilingual;

namespace YanSoft.CurrencyExchanger.Core.Utils
{
    public static class AppResourcesHelper
    {
        const string ResourceId = "YanSoft.CurrencyExchanger.Core.Resources.AppResources";

        static readonly Lazy<ResourceManager> ResManager = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(AppResourcesHelper).GetTypeInfo().Assembly));

        public static string GetString(string key)
        {
            if (key == null)
                return "";

            var ci = CrossMultilingual.Current.CurrentCultureInfo;

            var translation = ResManager.Value.GetString(key, ci);

            if (translation == null)
            {

#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", key, ResourceId, ci.Name),
                    "Text");
#else
				translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
