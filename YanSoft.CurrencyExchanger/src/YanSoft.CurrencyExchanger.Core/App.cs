using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Plugin.Multilingual;
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
            RegisterAppStart<MasterDetailViewModel>();
        }
    }
}
