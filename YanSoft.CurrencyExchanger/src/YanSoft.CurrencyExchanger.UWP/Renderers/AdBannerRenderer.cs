using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Advertising.WinRT.UI;
using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;
using YanSoft.CurrencyExchanger.Core.Configurations;
using YanSoft.CurrencyExchanger.Core.Controls;
using YanSoft.CurrencyExchanger.UWP.Renderers;

[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBannerRenderer))]
namespace YanSoft.CurrencyExchanger.UWP.Renderers
{
    public class AdBannerRenderer : ViewRenderer<AdBanner, AdControl>
    {
        private AdControl adControl;
        public AdBannerRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdBanner> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement == null)
            {
                return;
            }
            if(Control == null)
            {
                adControl = CreateAdControl();
                e.NewElement.HeightRequest = adControl.Height;
                SetNativeControl(adControl);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe from event handlers and cleanup any resources
                Window.Current.SizeChanged -= Current_SizeChanged;
            }

            if (e.NewElement != null)
            {
                // Configure the control and subscribe to event handlers
                Window.Current.SizeChanged += Current_SizeChanged;
            }
        }

        private AdControl CreateAdControl()
        {
            adControl = new AdControl
            {
                ApplicationId = AppConfigurations.MicrosoftAdAppId,
                AdUnitId = AppConfigurations.MicrosoftAdUnitId
            };
            Tuple<int, int> initSize = GetAdSize();
            adControl.Width = initSize.Item1;
            adControl.Height = initSize.Item2;
            return adControl;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            Tuple<int, int> size = GetAdSize();
            adControl.Width = size.Item1;
            adControl.Height = size.Item2;
        }

        private Tuple<int, int> GetAdSize()
        {
            var availableWidth = Window.Current.Bounds.Width;
            if (availableWidth >= 728)
            {
                return new Tuple<int, int>(728, 90);
            }
            else if (availableWidth >= 640)
            {
                return new Tuple<int, int>(640, 100);
            }
            else if (availableWidth >= 320)
            {
                return new Tuple<int, int>(320, 50);
            }
            //else if (availableWidth >= 300)
            //{
            //    return new Tuple<int, int>(300, 50);
            //}
            else
            {
                return new Tuple<int, int>(300, 50);
            }
        }


    }
}
