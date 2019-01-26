using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Plugin.Multilingual;
using Plugin.Toasts;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Data;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Resources;
using YanSoft.CurrencyExchanger.Core.Services;
using YanSoft.CurrencyExchanger.Core.ViewModels;

namespace YanSoft.CurrencyExchanger.Core
{
    public class App : MvxApplication
    {
        public override async void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;

            await Mvx.IoCProvider.Resolve<IDataService<CurrencyExchangeItem>>().InitializeDatabaseAsync();

            Mvx.IoCProvider.RegisterSingleton(new GlobalContext());
            Mvx.IoCProvider.Resolve<GlobalContext>().Initialize();
            Mvx.IoCProvider.RegisterSingleton(new AppSettings());
            RegisterAppStart<MasterDetailViewModel>();
        }

        public override Task Startup()
        {
            AppCenter.Start("uwp=ec4b3fea-1676-4964-a5f3-8c449b57f1e0;" +
                  "android=6b6af17f-9bfd-4c74-8ac4-fcfcef223bb2" +
                  "ios=cea8fbf3-310d-4f98-b77b-d22a02e6fac2",
                  typeof(Analytics), typeof(Crashes));
            return base.Startup();

        }


    }
}
