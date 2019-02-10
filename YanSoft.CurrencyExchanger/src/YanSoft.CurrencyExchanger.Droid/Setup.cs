using Android.App;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using YanSoft.CurrencyExchanger.Core.Services;
using YanSoft.CurrencyExchanger.Core.Utils;
using YanSoft.CurrencyExchanger.Droid.Services;
using YanSoft.CurrencyExchanger.Droid.Utils;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace YanSoft.CurrencyExchanger.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, UI.App>
    {
        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.IoCProvider.RegisterSingleton<IToastService>(new ToastService());
            Mvx.IoCProvider.RegisterSingleton<IAppVersionHelper>(new AppVersionHelper());
        }
    }
}
