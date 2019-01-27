using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.XForms.iOS.Buttons;
using UIKit;

namespace YanSoft.CurrencyExchanger.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            SfListViewRenderer.Init();
            SfSegmentedControlRenderer.Init();
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
