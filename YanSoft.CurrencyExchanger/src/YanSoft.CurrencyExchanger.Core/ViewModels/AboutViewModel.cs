using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using Xamarin.Essentials;
using YanSoft.CurrencyExchanger.Core.Configurations;
using YanSoft.CurrencyExchanger.Core.Resources;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        //TODO
        private string shareUrl = "";
        private readonly IAppVersionHelper _appVersionHelper;
        public AboutViewModel(IAppVersionHelper appVersionHelper)
        {
            _appVersionHelper = appVersionHelper;
            AppVersion = _appVersionHelper.GetBuildVersion();
            System.Diagnostics.Debug.WriteLine(_appVersionHelper.GetBuildVersion());
            System.Diagnostics.Debug.WriteLine(_appVersionHelper.GetBuildNumber());

        }

        #region Properties

        #region AppVersion;
        private string _appVersion;
        public string AppVersion
        {
            get => _appVersion;
            set => SetProperty(ref _appVersion, value);
        }
        #endregion
        #endregion

        #region Commands

        #region FeedbackAsyncCommand;
        private IMvxAsyncCommand _feedbackAsyncCommand;
        public IMvxAsyncCommand FeedbackAsyncCommand
        {
            get
            {
                _feedbackAsyncCommand = _feedbackAsyncCommand ?? new MvxAsyncCommand(FeedbackAsync);
                return _feedbackAsyncCommand;
            }
        }
        private async Task FeedbackAsync()
        {
            // Implement your logic here.
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Currency Exchanger Feedback",
                    Body = "",
                    To = new List<string> { AppConfigurations.FeedbackEmail },
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
        #endregion


        #region ShareAsyncCommand;
        private IMvxAsyncCommand _shareAsyncCommand;
        public IMvxAsyncCommand ShareAsyncCommand
        {
            get
            {
                _shareAsyncCommand = _shareAsyncCommand ?? new MvxAsyncCommand(ShareAsync);
                return _shareAsyncCommand;
            }
        }
        private async Task ShareAsync()
        {
            // Implement your logic here.
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = $"{AppResources.About_Share_Content} {shareUrl}",
            });
        }
        #endregion
        #endregion
    }
}
