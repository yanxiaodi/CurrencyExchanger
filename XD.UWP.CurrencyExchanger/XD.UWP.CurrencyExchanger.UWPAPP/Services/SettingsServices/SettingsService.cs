using System;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;
using XD.UWP.CurrencyExchanger.UWPAPP.Models;

namespace XD.UWP.CurrencyExchanger.UWPAPP.Services.SettingsServices
{
    public class SettingsService
    {
        public static SettingsService Instance { get; } = new SettingsService();
        Template10.Services.SettingsService.ISettingsHelper _helper;
        private SettingsService()
        {
            _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public bool UseShellBackButton
        {
            get { return _helper.Read<bool>(nameof(UseShellBackButton), true); }
            set
            {
                _helper.Write(nameof(UseShellBackButton), value);
                BootStrapper.Current.NavigationService.GetDispatcherWrapper().Dispatch(() =>
                {
                    BootStrapper.Current.ShowShellBackButton = value;
                    BootStrapper.Current.UpdateShellBackButton();
                });
            }
        }

        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = ApplicationTheme.Light;
                var value = _helper.Read<string>(nameof(AppTheme), theme.ToString());
                return Enum.TryParse<ApplicationTheme>(value, out theme) ? theme : ApplicationTheme.Dark;
            }
            set
            {
                _helper.Write(nameof(AppTheme), value.ToString());
                (Window.Current.Content as FrameworkElement).RequestedTheme = value.ToElementTheme();
                Views.Shell.HamburgerMenu.RefreshStyles(value, true);
            }
        }

        public TimeSpan CacheMaxDuration
        {
            get { return _helper.Read<TimeSpan>(nameof(CacheMaxDuration), TimeSpan.FromDays(2)); }
            set
            {
                _helper.Write(nameof(CacheMaxDuration), value);
                BootStrapper.Current.CacheMaxDuration = value;
            }
        }

        public bool ShowHamburgerButton
        {
            get { return _helper.Read<bool>(nameof(ShowHamburgerButton), true); }
            set
            {
                _helper.Write(nameof(ShowHamburgerButton), value);
                Views.Shell.HamburgerMenu.HamburgerButtonVisibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public bool IsFullScreen
        {
            get { return _helper.Read<bool>(nameof(IsFullScreen), false); }
            set
            {
                _helper.Write(nameof(IsFullScreen), value);
                Views.Shell.HamburgerMenu.IsFullScreen = value;
            }
        }


        /// <summary>
        /// Gets or sets the share email.
        /// </summary>
        /// <value>
        /// The share email.
        /// </value>
        public string ShareEmail
        {
            get { return _helper.Read<string>(nameof(ShareEmail), string.Empty); }
            set
            {
                _helper.Write(nameof(ShareEmail), value);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is automatic refresh rates on startup.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is automatic refresh rates on startup; otherwise, <c>false</c>.
        /// </value>
        public bool IsAutoRefreshRatesOnStartup
        {
            get { return _helper.Read<bool>(nameof(IsAutoRefreshRatesOnStartup), false); }
            set
            {
                _helper.Write(nameof(IsAutoRefreshRatesOnStartup), value);
            }
        }


        /// <summary>
        /// Gets or sets the decimal precision.
        /// </summary>
        /// <value>
        /// The decimal precision.
        /// </value>
        public int DecimalPrecision
        {
            get { return _helper.Read<int>(nameof(DecimalPrecision), 2); }
            set
            {
                _helper.Write(nameof(DecimalPrecision), value);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is localized currency symbol.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is localized currency symbol; otherwise, <c>false</c>.
        /// </value>
        public bool IsLocalizedCurrencySymbol
        {
            get { return _helper.Read<bool>(nameof(IsLocalizedCurrencySymbol), false); }
            set
            {
                _helper.Write(nameof(IsLocalizedCurrencySymbol), value);
            }
        }


        /// <summary>
        /// Gets or sets the default type of the chart.
        /// </summary>
        /// <value>
        /// The default type of the chart.
        /// </value>
        public HistoryChartType DefaultChartType
        {
            get { return _helper.Read<HistoryChartType>(nameof(DefaultChartType), HistoryChartType.ThreeMonths); }
            set
            {
                _helper.Write(nameof(DefaultChartType), value);
            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether this instance is enable pull to refresh.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enable pull to refresh; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnablePullToRefresh
        {
            get { return _helper.Read<bool>(nameof(IsEnablePullToRefresh), false); }
            set
            {
                _helper.Write(nameof(IsEnablePullToRefresh), value);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is enable automatic initialize0.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enable automatic initialize0; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnableAutoInitialize0
        {
            get { return _helper.Read<bool>(nameof(IsEnableAutoInitialize0), false); }
            set
            {
                _helper.Write(nameof(IsEnableAutoInitialize0), value);
            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether this instance is enable live tile.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enable live tile; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnableLiveTile
        {
            get { return _helper.Read<bool>(nameof(IsEnableLiveTile), false); }
            set
            {
                _helper.Write(nameof(IsEnableLiveTile), value);
            }
        }

    }
}
