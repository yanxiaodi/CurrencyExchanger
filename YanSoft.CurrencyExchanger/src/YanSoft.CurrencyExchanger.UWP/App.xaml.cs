using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using MvvmCross.Forms.Platforms.Uap.Views;
using Syncfusion.ListView.XForms.UWP;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace YanSoft.CurrencyExchanger.UWP
{
    sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs activationArgs)
        {
            base.OnLaunched(activationArgs);
            // you'll need to add `using System.Reflection;`
            var assembliesToInclude = new List<Assembly>
            {

                //Now, add all the assemblies your app uses
                typeof(SfListViewRenderer).GetTypeInfo().Assembly
            };

            // replaces Xamarin.Forms.Forms.Init(e);        
            Xamarin.Forms.Forms.Init(activationArgs, assembliesToInclude);
        }
    }

    public abstract class MvxFormsApp : MvxWindowsApplication<Setup, Core.App, UI.App, MainPage>
    {
    }
}
