using System;
using System.Collections.Generic;
using System.Text;

namespace YanSoft.CurrencyExchanger.Core.Configurations
{
    public static class AppConfigurations
    {
        public const int AppVersion = 1;

#if DEBUG
        public const string ApiUrl = "https://freecurrencyexchanger.azurewebsites.net/api/CurrencyExchanger/";

        public const string AppCenterAppSecretUwp = "ec4b3fea-1676-4964-a5f3-8c449b57f1e0";
        public const string AppCenterAppSecretAndroid = "6b6af17f-9bfd-4c74-8ac4-fcfcef223bb2";
        public const string AppCenterAppSecretIos = "cea8fbf3-310d-4f98-b77b-d22a02e6fac2";

        public const string AdMobAndroidBannerAppId = "ca-app-pub-3940256099942544~3347511713";
        public const string AdMobAndroidBannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";

        public const string AdMobIosAppId = "ca-app-pub-3940256099942544~1458002511";
        public const string AdMobIosBannerAdUnitId = "ca-app-pub-3940256099942544/2934735716";

        public const string MicrosoftAdAppId = "3f83fe91-d6be-434d-a0ae-7351c5a997f1";
        public const string MicrosoftAdUnitId = "test";

        public const string FeedbackEmail = "abc@outlook.com";

        public const string TokenKey = "#{TokenKey}#";
#endif
#if !DEBUG
        public const string ApiUrl = "#{ApiUrl}#";

        public const string AppCenterAppSecretUwp = "#{AppCenterAppSecretUwp}#";
        public const string AppCenterAppSecretAndroid = "#{AppCenterAppSecretAndroid}#";
        public const string AppCenterAppSecretIos = "#{AppCenterAppSecretIos}#";

        public const string AdMobAndroidAppId = "#{AdMobAndroidAppId}#";
        public const string AdMobAndroidBannerAdUnitId = "#{AdMobAndroidBannerAdUnitId}#";


        public const string AdMobIosAppId = "ca-app-pub-2078627953552257~5136144944";
        public const string AdMobIosBannerAdUnitId = "ca-app-pub-2078627953552257/7316296163";


        public const string MicrosoftAdAppId = "#{MicrosoftAdAppId}#";
        public const string MicrosoftAdUnitId = "#{MicrosoftAdUnitId}#";


        public const string FeedbackEmail = "#{FeedbackEmail}#";

        public const string TokenKey = "#{TokenKey}#";
#endif
    }
}
