using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Services;
using YanSoft.CurrencyExchanger.Core.Utils;
using YanSoft.CurrencyExchanger.Core.ViewModels;

namespace YanSoft.CurrencyExchanger.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail)]
    public partial class EditListPage : MvxContentPage<EditListViewModel>
    {
        public EditListPage()
        {
            InitializeComponent();
            Title = AppResourcesHelper.GetString("EditList_PageTitle");

        }

        private async void ListView_ItemDragging(object sender, Syncfusion.ListView.XForms.ItemDraggingEventArgs e)
        {
            if(e.Action == Syncfusion.ListView.XForms.DragAction.Drop)
            {
                // This Delay method must be called here. Otherwise, the ListView cannot get the right orders.
                await Task.Delay(100);
                if (BindingContext.DataContext is EditListViewModel vm)
                {
                    var target = e.ItemData as CurrencyExchangeBindableItem;
                    vm.CurrencyList.Move(e.OldIndex, e.NewIndex);
                    await Mvx.IoCProvider.Resolve<ICurrencyService>().UpdateSortOrderAsync(vm.CurrencyList);
                }

            }
        }
    }
}
