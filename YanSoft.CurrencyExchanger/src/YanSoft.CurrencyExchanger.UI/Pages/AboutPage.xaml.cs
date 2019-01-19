using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YanSoft.CurrencyExchanger.Core.ViewModels;

namespace YanSoft.CurrencyExchanger.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, Title = "About")]
    public partial class AboutPage : MvxContentPage<AboutViewModel>
    {
		public AboutPage ()
		{
			InitializeComponent ();
		}
	}
}
