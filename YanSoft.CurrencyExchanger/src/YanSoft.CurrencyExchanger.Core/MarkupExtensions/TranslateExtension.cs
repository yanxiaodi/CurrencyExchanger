using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace YanSoft.CurrencyExchanger.Core.MarkupExtensions
{
    /// <summary>
    /// Use it like: <Label Text="{utils:Translate App_Name}" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Xaml.IMarkupExtension" />
    [ContentProperty(nameof(Text))]
    public class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "YanSoft.CurrencyExchanger.Core.Resources.AppResources";

        static readonly Lazy<ResourceManager> ResManager = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var ci = CrossMultilingual.Current.CurrentCultureInfo;

            var translation = ResManager.Value.GetString(Text, ci);

            if (translation == null)
            {

#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
				translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
