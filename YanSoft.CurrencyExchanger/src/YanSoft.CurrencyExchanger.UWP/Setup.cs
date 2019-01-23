using MvvmCross;
using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Plugin;
using MvvmCross.ViewModels;
using Plugin.Toasts;
using Plugin.Toasts.UWP;

namespace YanSoft.CurrencyExchanger.UWP
{
    public class Setup : MvxFormsWindowsSetup<Core.App, UI.App>
    {

        protected override void InitializeIoC()
        {
            
            base.InitializeIoC();
            Mvx.IoCProvider.RegisterType<IToastNotificator, ToastNotification>();
            ToastNotification.Init();
        }


    }
}
