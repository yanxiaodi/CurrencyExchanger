using MvvmCross;
using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Plugin;
using MvvmCross.ViewModels;
using Plugin.Toasts;
using Plugin.Toasts.UWP;
using YanSoft.CurrencyExchanger.Core.Services;
using YanSoft.CurrencyExchanger.Core.Utils;
using YanSoft.CurrencyExchanger.UWP.Services;
using YanSoft.CurrencyExchanger.UWP.Utils;

namespace YanSoft.CurrencyExchanger.UWP
{
    public class Setup : MvxFormsWindowsSetup<Core.App, UI.App>
    {

        protected override void InitializeIoC()
        {
            
            base.InitializeIoC();
            Mvx.IoCProvider.RegisterType<IToastNotificator, ToastNotification>();
            Mvx.IoCProvider.RegisterSingleton<IToastService>(new ToastService());
            ToastNotification.Init();
            Mvx.IoCProvider.RegisterSingleton<IAppVersionHelper>(new AppVersionHelper());
        }


    }
}
