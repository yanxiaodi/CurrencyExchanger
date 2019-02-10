using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Reflection;
using Plugin.Multilingual;
using YanSoft.CurrencyExchanger.Core.Resources;
using System.Globalization;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public class AppResourcesService : IAppResourcesService
    {
        const string ResourceId = "YanSoft.CurrencyExchanger.Core.Resources.AppResources";

        private Lazy<ResourceManager> resManager = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(AppResourcesService).GetTypeInfo().Assembly));


        public void Refresh()
        {
            resManager = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(AppResourcesService).GetTypeInfo().Assembly));
        }
        public string GetString(string key, CultureInfo ci = null)
        {
            if (key == null)
                return "";
            if(ci == null)
            {
                ci = CrossMultilingual.Current.CurrentCultureInfo;
            }
            //System.Diagnostics.Debug.WriteLine(ci);
            var translation = resManager.Value.GetString(key, ci);
            return translation;
        }
    }
}
