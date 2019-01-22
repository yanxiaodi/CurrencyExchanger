using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using Plugin.Toasts;

namespace YanSoft.CurrencyExchanger.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, UI.App>
    {
        protected override void InitializeIoC()
        {
            Mvx.IoCProvider.RegisterType<IToastNotificator, ToastNotification>();
            ToastNotification.Init();
            base.InitializeIoC();
        }
    }
}
