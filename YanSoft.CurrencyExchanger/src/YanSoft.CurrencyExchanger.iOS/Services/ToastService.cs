using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using YanSoft.CurrencyExchanger.Core.Services;

namespace YanSoft.CurrencyExchanger.iOS.Services
{
    public class ToastService : IToastService
    {
        public void ShowToast(string message)
        {
            ShowToast(message, 1.5);
        }

        private void ShowToast(string message, double duration)
        {
            var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);

            var alertDelay = NSTimer.CreateScheduledTimer(duration, obj =>
            {
                DismissMessage(alert, obj);
            });

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        private void DismissMessage(UIAlertController alert, NSTimer alertDelay)
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }

            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}
