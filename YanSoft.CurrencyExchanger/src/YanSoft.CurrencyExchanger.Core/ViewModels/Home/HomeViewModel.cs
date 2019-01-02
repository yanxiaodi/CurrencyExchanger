using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Services;

namespace YanSoft.CurrencyExchanger.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public override async Task Initialize()
        {
            //var service = Mvx.IoCProvider.Resolve<IDataService<CurrencyExchangeItem>>();
            //var item = new CurrencyExchangeItem(new CurrencyItem("USD", "USA Dollor"), new CurrencyItem("CNY", "Chinese Yuan"), 0);
            //await service.InsertAsync(item);
            //var list = await service.GetAllAsync();
            await base.Initialize();
        }
    }
}
