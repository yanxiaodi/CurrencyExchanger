using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using YanSoft.CurrencyExchanger.Core.Services;

namespace YanSoft.CurrencyExchanger.UWP.Services
{
    public class ToastService : IToastService
    {
        public void ShowToast(string message)
        {
            ShowToast(message, 1000);
        }

        private void ShowToast(string message, double duration)
        {
            var label = new TextBlock
            {
                Text = message,
                Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            var style = new Style { TargetType = typeof(FlyoutPresenter) };
            var accentColor = (Windows.UI.Color)Application.Current.Resources["SystemAccentColor"];
            style.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(accentColor)));
            style.Setters.Add(new Setter(FrameworkElement.MaxHeightProperty, 1));
            var flyout = new Flyout
            {
                Content = label,
                Placement = FlyoutPlacementMode.Full,
                FlyoutPresenterStyle = style,
            };

            flyout.ShowAt(Window.Current.Content as FrameworkElement);

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(duration) };
            timer.Tick += (sender, e) => {
                timer.Stop();
                flyout.Hide();
            };
            timer.Start();
        }
    }
}
