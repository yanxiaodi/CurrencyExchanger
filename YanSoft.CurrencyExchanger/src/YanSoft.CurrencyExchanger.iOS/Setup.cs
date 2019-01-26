using Google.MobileAds;
using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using Plugin.Toasts;
using YanSoft.CurrencyExchanger.Core.Configurations;

namespace YanSoft.CurrencyExchanger.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, UI.App>
    {
        protected override void InitializeIoC()
        {

            base.InitializeIoC();
            Mvx.IoCProvider.RegisterType<IToastNotificator, ToastNotification>();
            ToastNotification.Init();

#if DEBUG 
            MobileAds.Configure(AppConfigurations.AdMobIosTestAppId);
#endif
#if !DEBUG
            MobileAds.Configure(AppConfigurations.AdMobIosAppId);
#endif

        }
    }
}
