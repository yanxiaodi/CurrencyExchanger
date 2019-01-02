using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Plugin.Multilingual;
using YanSoft.CurrencyExchanger.Core.Data;
using YanSoft.CurrencyExchanger.Core.Resources;
using YanSoft.CurrencyExchanger.Core.ViewModels.Home;

namespace YanSoft.CurrencyExchanger.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            AppResource.Culture = CrossMultilingual.Current.DeviceCultureInfo;
            using(var db = new CurrencyDataContext())
            {
                db.Database.EnsureCreated();
            }
            RegisterAppStart<HomeViewModel>();
        }
    }
}
