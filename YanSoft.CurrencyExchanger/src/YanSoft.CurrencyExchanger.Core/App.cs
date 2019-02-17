using System.Globalization;
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
using YanSoft.CurrencyExchanger.Core.Configurations;
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


            await Mvx.IoCProvider.Resolve<IDataService<CurrencyExchangeItem>>().InitializeDatabaseAsync();

            Mvx.IoCProvider.RegisterSingleton(new GlobalContext());
            
            Mvx.IoCProvider.RegisterSingleton(new AppSettings());
            RegisterAppStart<MasterDetailViewModel>();
        }

        public override Task Startup()
        {
            AppCenter.Start($"uwp={AppConfigurations.AppCenterAppSecretUwp};android={AppConfigurations.AppCenterAppSecretAndroid};ios={AppConfigurations.AppCenterAppSecretIos}",
                  typeof(Analytics), typeof(Crashes));

            Mvx.IoCProvider.Resolve<GlobalContext>().InitializeAllCurrencyItemList();
            Mvx.IoCProvider.Resolve<GlobalContext>().InitializeOthers();

            var settings = Mvx.IoCProvider.Resolve<AppSettings>();
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo(settings.LanguageCode);
            AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;

            return base.Startup();

        }

    }
}
