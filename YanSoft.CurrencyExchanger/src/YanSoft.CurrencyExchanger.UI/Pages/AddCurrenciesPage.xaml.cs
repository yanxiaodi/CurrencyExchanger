using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YanSoft.CurrencyExchanger.Core.Utils;
using YanSoft.CurrencyExchanger.Core.ViewModels;

namespace YanSoft.CurrencyExchanger.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail)]
    public partial class AddCurrenciesPage : MvxContentPage<AddCurrenciesViewModel>
	{
		public AddCurrenciesPage()
		{
			InitializeComponent ();
            Title = AppResourcesHelper.GetString("AddCurrencies_PageTitle");

        }

        private void EntrySearchKeyword_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.NewTextValue);
            if (BindingContext.DataContext is AddCurrenciesViewModel vm)
            {
                vm.SearchCurrencyCommand.Execute(e.NewTextValue);
            }
        }
    }
}
