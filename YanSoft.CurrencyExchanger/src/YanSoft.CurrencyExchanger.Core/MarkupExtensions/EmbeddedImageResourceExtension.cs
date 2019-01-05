using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace YanSoft.CurrencyExchanger.Core.MarkupExtensions
{
    /// <summary>
    /// Use it like: <Image Source="{ext:ImageResource WorkingWithImages.beach.jpg}" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Xaml.IMarkupExtension" />
    [Preserve(AllMembers = true)]
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}
