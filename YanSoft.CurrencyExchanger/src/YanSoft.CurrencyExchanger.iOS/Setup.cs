using Google.MobileAds;
using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using Plugin.Toasts;
using YanSoft.CurrencyExchanger.Core.Configurations;
using YanSoft.CurrencyExchanger.Core.Services;
using YanSoft.CurrencyExchanger.Core.Utils;
using YanSoft.CurrencyExchanger.iOS.Services;
using YanSoft.CurrencyExchanger.iOS.Utils;

namespace YanSoft.CurrencyExchanger.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, UI.App>
    {
        protected override void InitializeIoC()
        {

            base.InitializeIoC();
            Mvx.IoCProvider.RegisterType<IToastNotificator, ToastNotification>();
            ToastNotification.Init();
            Mvx.IoCProvider.RegisterSingleton<IToastService>(new ToastService());
            Mvx.IoCProvider.RegisterSingleton<IAppVersionHelper>(new AppVersionHelper());


#if DEBUG 
            MobileAds.Configure(AppConfigurations.AdMobIosTestAppId);
#endif
#if !DEBUG
            MobileAds.Configure(AppConfigurations.AdMobIosAppId);
#endif

        }
    }
}
