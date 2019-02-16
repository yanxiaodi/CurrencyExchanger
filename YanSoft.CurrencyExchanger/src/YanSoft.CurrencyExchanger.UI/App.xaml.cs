using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using YanSoft.CurrencyExchanger.Core.Configurations;

namespace YanSoft.CurrencyExchanger.UI
{
    public partial class App : Application
    {
        public App()
        {
#if !DEBUG
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(AppConfigurations.SyncfusionLicenseKey);
#endif
            InitializeComponent();
        }
    }
}
