using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace YanSoft.CurrencyExchanger.UI
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjE3MjdAMzEzNjJlMzQyZTMwZ0FWVFFhUlJ0V0JQUXJSTmhmd3VKMzFSWkdTNTlSZWU4K0xkdktzb0NhYz0=");
            InitializeComponent();
        }
    }
}
