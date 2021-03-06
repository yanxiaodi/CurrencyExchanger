using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Resources;
using YanSoft.CurrencyExchanger.Core.Services;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.Common
{
    public class GlobalContext
    {


        public List<CurrencyItem> AllCurrencyItemList { get; set; }
        public CurrencyExchangeBindableItem CurrentBaseCurrency { get; set; }

        public Dictionary<string, string> HistoryRangeIntervalSetting { get; set; }

        public List<LanguageItem> LanguageItemList { get; set; }

        public void InitializeAllCurrencyItemList()
        {
            AllCurrencyItemList = new List<CurrencyItem>()
            {
                new CurrencyItem{Code = "AED", Name = AppResources.Currency_AED, Image="flag_united_arab_emirates", CultureName=""},
                new CurrencyItem{Code = "AFN", Name = AppResources.Currency_AFN, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "ALL", Name = AppResources.Currency_ALL, Image="flag_albania", CultureName="sq"},
                new CurrencyItem{Code = "AMD", Name = AppResources.Currency_AMD, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "ANG", Name = AppResources.Currency_ANG, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "AOA", Name = AppResources.Currency_AOA, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "ARS", Name = AppResources.Currency_ARS, Image="flag_argentina", CultureName="es-AR"},
                new CurrencyItem{Code = "AUD", Name = AppResources.Currency_AUD, Image="flag_australia", CultureName="en-AU"},
                new CurrencyItem{Code = "AWG", Name = AppResources.Currency_AWG, Image="flag_aruba", CultureName=""},
                new CurrencyItem{Code = "AZN", Name = AppResources.Currency_AZN, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "BAM", Name = AppResources.Currency_BAM, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "BBD", Name = AppResources.Currency_BBD, Image="flag_barbados", CultureName=""},
                new CurrencyItem{Code = "BDT", Name = AppResources.Currency_BDT, Image="flag_bangladesh", CultureName="bn-BD"},
                new CurrencyItem{Code = "BGN", Name = AppResources.Currency_BGN, Image="flag_bulgaria", CultureName="bg"},
                new CurrencyItem{Code = "BHD", Name = AppResources.Currency_BHD, Image="flag_bahrain", CultureName="ar-BH"},
                new CurrencyItem{Code = "BIF", Name = AppResources.Currency_BIF, Image="flag_burundi", CultureName=""},
                new CurrencyItem{Code = "BMD", Name = AppResources.Currency_BMD, Image="flag_bermuda", CultureName=""},
                new CurrencyItem{Code = "BND", Name = AppResources.Currency_BND, Image="flag_brunei", CultureName="ms-BN"},
                new CurrencyItem{Code = "BOB", Name = AppResources.Currency_BOB, Image="flag_bolivia", CultureName="quz-BO"},
                new CurrencyItem{Code = "BRL", Name = AppResources.Currency_BRL, Image="flag_brazil", CultureName="pt-BR"},
                new CurrencyItem{Code = "BSD", Name = AppResources.Currency_BSD, Image="flag_bahamas", CultureName=""},
                new CurrencyItem{Code = "BTC", Name = AppResources.Currency_BTC, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "BTN", Name = AppResources.Currency_BTN, Image="flag_bhutan", CultureName=""},
                new CurrencyItem{Code = "BWP", Name = AppResources.Currency_BWP, Image="flag_botswana", CultureName=""},
                new CurrencyItem{Code = "BYN", Name = AppResources.Currency_BYN, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "BYR", Name = AppResources.Currency_BYR, Image="flag_belarus", CultureName="be"},
                new CurrencyItem{Code = "BZD", Name = AppResources.Currency_BZD, Image="flag_belize", CultureName="en-BZ"},
                new CurrencyItem{Code = "CAD", Name = AppResources.Currency_CAD, Image="flag_canada", CultureName="en-CA"},
                new CurrencyItem{Code = "CDF", Name = AppResources.Currency_CDF, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "CHF", Name = AppResources.Currency_CHF, Image="flag_switzerland", CultureName="fr-CH"},
                new CurrencyItem{Code = "CLP", Name = AppResources.Currency_CLP, Image="flag_chile", CultureName="arn-CL"},
                new CurrencyItem{Code = "CNY", Name = AppResources.Currency_CNY, Image="flag_china", CultureName="zh-CN"},
                new CurrencyItem{Code = "COP", Name = AppResources.Currency_COP, Image="flag_colombia", CultureName="es-CO"},
                new CurrencyItem{Code = "CRC", Name = AppResources.Currency_CRC, Image="flag_costa_rica", CultureName="es-CR"},
                new CurrencyItem{Code = "CUP", Name = AppResources.Currency_CUP, Image="flag_cuba", CultureName=""},
                new CurrencyItem{Code = "CVE", Name = AppResources.Currency_CVE, Image="flag_cape_verde", CultureName=""},
                new CurrencyItem{Code = "CZK", Name = AppResources.Currency_CZK, Image="flag_czech_republic", CultureName="cs"},
                new CurrencyItem{Code = "DJF", Name = AppResources.Currency_DJF, Image="flag_djibouti", CultureName=""},
                new CurrencyItem{Code = "DKK", Name = AppResources.Currency_DKK, Image="flag_denmark", CultureName="da-DK"},
                new CurrencyItem{Code = "DOP", Name = AppResources.Currency_DOP, Image="flag_dominica", CultureName="es-DO"},
                new CurrencyItem{Code = "DZD", Name = AppResources.Currency_DZD, Image="flag_algeria", CultureName="ar-DZ"},
                new CurrencyItem{Code = "EGP", Name = AppResources.Currency_EGP, Image="flag_egypt", CultureName="ar-EG"},
                new CurrencyItem{Code = "ERN", Name = AppResources.Currency_ERN, Image="flag_eritrea", CultureName=""},
                new CurrencyItem{Code = "ETB", Name = AppResources.Currency_ETB, Image="flag_ethiopia", CultureName="am-ET"},
                new CurrencyItem{Code = "EUR", Name = AppResources.Currency_EUR, Image="flag_eu", CultureName="fr-FR"},
                new CurrencyItem{Code = "FJD", Name = AppResources.Currency_FJD, Image="flag_fiji", CultureName=""},
                new CurrencyItem{Code = "FKP", Name = AppResources.Currency_FKP, Image="flag_falkland_islands", CultureName=""},
                new CurrencyItem{Code = "GBP", Name = AppResources.Currency_GBP, Image="flag_united_kingdom", CultureName="en-GB"},
                new CurrencyItem{Code = "GEL", Name = AppResources.Currency_GEL, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "GHS", Name = AppResources.Currency_GHS, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "GIP", Name = AppResources.Currency_GIP, Image="flag_gibraltar", CultureName=""},
                new CurrencyItem{Code = "GMD", Name = AppResources.Currency_GMD, Image="flag_gambia", CultureName=""},
                new CurrencyItem{Code = "GNF", Name = AppResources.Currency_GNF, Image="flag_guinea", CultureName=""},
                new CurrencyItem{Code = "GTQ", Name = AppResources.Currency_GTQ, Image="flag_guatemala", CultureName="qut-GT"},
                new CurrencyItem{Code = "GYD", Name = AppResources.Currency_GYD, Image="flag_guyana", CultureName=""},
                // Hongkong
                new CurrencyItem{Code = "HKD", Name = AppResources.Currency_HKD, Image="flag_hong_kong", CultureName="zh-HK"},
                new CurrencyItem{Code = "HNL", Name = AppResources.Currency_HNL, Image="flag_honduras", CultureName="es-HN"},
                new CurrencyItem{Code = "HRK", Name = AppResources.Currency_HRK, Image="flag_croatia", CultureName="hr"},
                new CurrencyItem{Code = "HTG", Name = AppResources.Currency_HTG, Image="flag_haiti", CultureName=""},
                new CurrencyItem{Code = "HUF", Name = AppResources.Currency_HUF, Image="flag_hungary", CultureName="hu-HU"},
                new CurrencyItem{Code = "IDR", Name = AppResources.Currency_IDR, Image="flag_indonesia", CultureName="id"},
                new CurrencyItem{Code = "ILS", Name = AppResources.Currency_ILS, Image="flag_israel", CultureName="he-IL"},
                new CurrencyItem{Code = "INR", Name = AppResources.Currency_INR, Image="flag_india", CultureName="en-IN"},
                new CurrencyItem{Code = "IQD", Name = AppResources.Currency_IQD, Image="flag_iraq", CultureName="ar-IQ"},
                new CurrencyItem{Code = "IRR", Name = AppResources.Currency_IRR, Image="flag_iran", CultureName=""},
                new CurrencyItem{Code = "ISK", Name = AppResources.Currency_ISK, Image="flag_iceland", CultureName="is"},
                new CurrencyItem{Code = "JMD", Name = AppResources.Currency_JMD, Image="flag_jamaica", CultureName="en-JM"},
                new CurrencyItem{Code = "JOD", Name = AppResources.Currency_JOD, Image="flag_jordan", CultureName="ar-JO"},
                new CurrencyItem{Code = "JPY", Name = AppResources.Currency_JPY, Image="flag_japan", CultureName="ja"},
                new CurrencyItem{Code = "KES", Name = AppResources.Currency_KES, Image="flag_kenya", CultureName="sw-KE"},
                new CurrencyItem{Code = "KGS", Name = AppResources.Currency_KGS, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "KHR", Name = AppResources.Currency_KHR, Image="flag_cambodia", CultureName="km-KH"},
                new CurrencyItem{Code = "KMF", Name = AppResources.Currency_KMF, Image="flag_comoros", CultureName=""},
                new CurrencyItem{Code = "KPW", Name = AppResources.Currency_KPW, Image="flag_north_korea", CultureName="ko-KR"},
                new CurrencyItem{Code = "KRW", Name = AppResources.Currency_KRW, Image="flag_south_korea", CultureName="ko-KR"},
                new CurrencyItem{Code = "KWD", Name = AppResources.Currency_KWD, Image="flag_kuwait", CultureName="ar-KW"},
                new CurrencyItem{Code = "KYD", Name = AppResources.Currency_KYD, Image="flag_cayman_islands", CultureName=""},
                new CurrencyItem{Code = "KZT", Name = AppResources.Currency_KZT, Image="flag_kazakhstan", CultureName="kk-KZ"},
                new CurrencyItem{Code = "LAK", Name = AppResources.Currency_LAK, Image="flag_laos", CultureName=""},
                new CurrencyItem{Code = "LBP", Name = AppResources.Currency_LBP, Image="flag_lebanon", CultureName="ar-LB"},
                new CurrencyItem{Code = "LKR", Name = AppResources.Currency_LKR, Image="flag_sri_lanka", CultureName="si-LK"},
                new CurrencyItem{Code = "LRD", Name = AppResources.Currency_LRD, Image="flag_liberia", CultureName=""},
                new CurrencyItem{Code = "LSL", Name = AppResources.Currency_LSL, Image="flag_lesotho", CultureName=""},
                new CurrencyItem{Code = "LTL", Name = AppResources.Currency_LTL, Image="flag_lithuania", CultureName="lt"},
                new CurrencyItem{Code = "LVL", Name = AppResources.Currency_LVL, Image="flag_latvia", CultureName="lv"},
                new CurrencyItem{Code = "LYD", Name = AppResources.Currency_LYD, Image="flag_libya", CultureName="ar-LY"},
                new CurrencyItem{Code = "MAD", Name = AppResources.Currency_MAD, Image="flag_morocco", CultureName="ar-MA"},
                new CurrencyItem{Code = "MDL", Name = AppResources.Currency_MDL, Image="flag_moldova", CultureName=""},
                new CurrencyItem{Code = "MGA", Name = AppResources.Currency_MGA, Image="flag_white", CultureName=""},

                new CurrencyItem{Code = "MKD", Name = AppResources.Currency_MKD, Image="flag_macedonia", CultureName="mk"},
                new CurrencyItem{Code = "MMK", Name = AppResources.Currency_MMK, Image="flag_burma", CultureName=""},
                new CurrencyItem{Code = "MNT", Name = AppResources.Currency_MNT, Image="flag_mongolia", CultureName="mn"},
                new CurrencyItem{Code = "MOP", Name = AppResources.Currency_MOP, Image="flag_macau", CultureName="zh-MO"},
                new CurrencyItem{Code = "MRO", Name = AppResources.Currency_MRO, Image="flag_mauritania", CultureName=""},
                new CurrencyItem{Code = "MUR", Name = AppResources.Currency_MUR, Image="flag_mauritius", CultureName=""},
                new CurrencyItem{Code = "MVR", Name = AppResources.Currency_MVR, Image="flag_maldives", CultureName="dv-MV"},
                new CurrencyItem{Code = "MWK", Name = AppResources.Currency_MWK, Image="flag_malawi", CultureName=""},
                new CurrencyItem{Code = "MXN", Name = AppResources.Currency_MXN, Image="flag_mexico", CultureName="es-MX"},
                new CurrencyItem{Code = "MYR", Name = AppResources.Currency_MYR, Image="flag_malaysia", CultureName="en-MY"},
                new CurrencyItem{Code = "MZN", Name = AppResources.Currency_MZN, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "NAD", Name = AppResources.Currency_NAD, Image="flag_namibia", CultureName=""},
                new CurrencyItem{Code = "NGN", Name = AppResources.Currency_NGN, Image="flag_nigeria", CultureName="ha-Latn-NG"},
                new CurrencyItem{Code = "NIO", Name = AppResources.Currency_NIO, Image="flag_nicaragua", CultureName="es-NI"},
                new CurrencyItem{Code = "NOK", Name = AppResources.Currency_NOK, Image="flag_norway", CultureName="nb-NO"},
                new CurrencyItem{Code = "NPR", Name = AppResources.Currency_NPR, Image="flag_nepal", CultureName="ne"},
                new CurrencyItem{Code = "NZD", Name = AppResources.Currency_NZD, Image="flag_new_zealand", CultureName="en-NZ"},
                new CurrencyItem{Code = "OMR", Name = AppResources.Currency_OMR, Image="flag_oman", CultureName="ar-OM"},
                new CurrencyItem{Code = "PAB", Name = AppResources.Currency_PAB, Image="flag_panama", CultureName="es-PA"},
                new CurrencyItem{Code = "PEN", Name = AppResources.Currency_PEN, Image="flag_peru", CultureName="es-PE"},
                new CurrencyItem{Code = "PGK", Name = AppResources.Currency_PGK, Image="flag_papua_new_guinea", CultureName=""},
                new CurrencyItem{Code = "PHP", Name = AppResources.Currency_PHP, Image="flag_philippines", CultureName="en-PH"},
                new CurrencyItem{Code = "PKR", Name = AppResources.Currency_PKR, Image="flag_pakistan", CultureName="ur-PK"},
                new CurrencyItem{Code = "PLN", Name = AppResources.Currency_PLN, Image="flag_poland", CultureName="pl-PL"},
                new CurrencyItem{Code = "PYG", Name = AppResources.Currency_PYG, Image="flag_paraguay", CultureName="es-PY"},
                new CurrencyItem{Code = "QAR", Name = AppResources.Currency_QAR, Image="flag_qatar", CultureName="ar-QA"},
                new CurrencyItem{Code = "RON", Name = AppResources.Currency_RON, Image="flag_romania", CultureName="ro"},
                new CurrencyItem{Code = "RSD", Name = AppResources.Currency_RSD, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "RUB", Name = AppResources.Currency_RUB, Image="flag_russia", CultureName="ru"},
                new CurrencyItem{Code = "RWF", Name = AppResources.Currency_RWF, Image="flag_rwanda", CultureName="rw-RW"},
                new CurrencyItem{Code = "SAR", Name = AppResources.Currency_SAR, Image="flag_saudi_arabia", CultureName="ar-SA"},
                new CurrencyItem{Code = "SBD", Name = AppResources.Currency_SBD, Image="flag_solomon_islands", CultureName=""},
                new CurrencyItem{Code = "SCR", Name = AppResources.Currency_SCR, Image="flag_seychelles", CultureName=""},
                new CurrencyItem{Code = "SDG", Name = AppResources.Currency_SDG, Image="flag_sudan", CultureName=""},
                new CurrencyItem{Code = "SEK", Name = AppResources.Currency_SEK, Image="flag_sweden", CultureName="smj-SE"},
                new CurrencyItem{Code = "SGD", Name = AppResources.Currency_SGD, Image="flag_singapore", CultureName="zh-SG"},
                new CurrencyItem{Code = "SHP", Name = AppResources.Currency_SHP, Image="flag_saint_helena", CultureName=""},
                new CurrencyItem{Code = "SIT", Name = AppResources.Currency_SIT, Image="flag_slovenia", CultureName="sl"},
                new CurrencyItem{Code = "SLL", Name = AppResources.Currency_SLL, Image="flag_sierra_leone", CultureName=""},
                new CurrencyItem{Code = "SOS", Name = AppResources.Currency_SOS, Image="flag_somalia", CultureName=""},
                new CurrencyItem{Code = "SRD", Name = AppResources.Currency_SRD, Image="flag_white"},
                new CurrencyItem{Code = "STD", Name = AppResources.Currency_STD, Image="flag_sao_tome_and_principe", CultureName=""},
                new CurrencyItem{Code = "SVC", Name = AppResources.Currency_SVC, Image="flag_el_salvador", CultureName="es-SV"},
                new CurrencyItem{Code = "SYP", Name = AppResources.Currency_SYP, Image="flag_syria", CultureName="syr-SY"},
                new CurrencyItem{Code = "SZL", Name = AppResources.Currency_SZL, Image="flag_swaziland", CultureName=""},
                new CurrencyItem{Code = "THB", Name = AppResources.Currency_THB, Image="flag_thailand", CultureName="th-TH"},
                new CurrencyItem{Code = "TJS", Name = AppResources.Currency_TJS, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "TMT", Name = AppResources.Currency_TMT, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "TND", Name = AppResources.Currency_TND, Image="flag_tunisia", CultureName="ar-TN"},
                new CurrencyItem{Code = "TOP", Name = AppResources.Currency_TOP, Image="flag_tonga", CultureName=""},
                new CurrencyItem{Code = "TRY", Name = AppResources.Currency_TRY, Image="flag_turkey", CultureName="tr-TR"},
                new CurrencyItem{Code = "TTD", Name = AppResources.Currency_TTD, Image="flag_trinidad_and_tobago", CultureName="en-TT"},
                // Taiwan
                new CurrencyItem{Code = "TWD", Name = AppResources.Currency_TWD, Image="flag_taiwan", CultureName="zh-TW"},
                new CurrencyItem{Code = "TZS", Name = AppResources.Currency_TZS, Image="flag_tanzania", CultureName=""},
                new CurrencyItem{Code = "UAH", Name = AppResources.Currency_UAH, Image="flag_ukraine", CultureName="uk-UA"},
                new CurrencyItem{Code = "UGX", Name = AppResources.Currency_UGX, Image="flag_uganda", CultureName=""},
                new CurrencyItem{Code = "USD", Name = AppResources.Currency_USD, Image="flag_usa", CultureName="en-US"},
                new CurrencyItem{Code = "UYU", Name = AppResources.Currency_UYU, Image="flag_uruguay", CultureName="es-UY"},
                new CurrencyItem{Code = "UZS", Name = AppResources.Currency_UZS, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "VEF", Name = AppResources.Currency_VEF, Image="flag_venezuela", CultureName="es-VE"},
                new CurrencyItem{Code = "VND", Name = AppResources.Currency_VND, Image="flag_vietnam", CultureName="vi-VN"},
                new CurrencyItem{Code = "VUV", Name = AppResources.Currency_VUV, Image="flag_vanuatu", CultureName=""},
                new CurrencyItem{Code = "WST", Name = AppResources.Currency_WST, Image="flag_samoa", CultureName=""},
                new CurrencyItem{Code = "XAF", Name = AppResources.Currency_XAF, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "XAG", Name = AppResources.Currency_XAG, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "XAU", Name = AppResources.Currency_XAU, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "XCD", Name = AppResources.Currency_XCD, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "XDR", Name = AppResources.Currency_XDR, Image="flag_white", CultureName=""},
                new CurrencyItem{Code = "XOF", Name = AppResources.Currency_XOF, Image="flag_mali", CultureName=""},
                new CurrencyItem{Code = "XPF", Name = AppResources.Currency_XPF, Image="flag_french_polynesia", CultureName=""},
                new CurrencyItem{Code = "YER", Name = AppResources.Currency_YER, Image="flag_yemen", CultureName="yemen"},
                new CurrencyItem{Code = "ZAR", Name = AppResources.Currency_ZAR, Image="flag_south_africa", CultureName=""},
                new CurrencyItem{Code = "ZMK", Name = AppResources.Currency_ZMK, Image="flag_zambia", CultureName=""},
                new CurrencyItem{Code = "ZMW", Name = AppResources.Currency_ZMW, Image="flag_white", CultureName=""}
            };
        }

        public void InitializeOthers()
        {
            HistoryRangeIntervalSetting = new Dictionary<string, string>
            {
                { HistoryRange.RangeOneDay, HistoryInterval.FiveMinutes },
                { HistoryRange.RangeFiveDays, HistoryInterval.ThirtyMinutes },
                { HistoryRange.RangeOneMonth, HistoryInterval.OneHour },
                { HistoryRange.RangeThreeMonths, HistoryInterval.OneDay },
                { HistoryRange.RangeSixMonths, HistoryInterval.OneDay },
                { HistoryRange.RangeOneYear, HistoryInterval.OneDay },
                { HistoryRange.RangeTwoYears, HistoryInterval.OneDay },
            };

            LanguageItemList = new List<LanguageItem>
            {
                new LanguageItem { DisplayName = "中文简体 - Chinese (simplified)", Code = "zh-Hans"},
                new LanguageItem { DisplayName = "中文繁体 - Chinese (Traditional)", Code = "zh-Hant"},
                new LanguageItem { DisplayName = "English - English", Code = "en" },
                new LanguageItem { DisplayName = "Français - French", Code = "fr" },
                new LanguageItem { DisplayName = "Deutsche - German", Code = "de" },
                new LanguageItem { DisplayName = "日本語 - Japanese", Code = "ja" },
                new LanguageItem { DisplayName = "한국어 - Korean", Code = "ko" },
                new LanguageItem { DisplayName = "Русский - Russian", Code = "ru" }
            };
        }

        public void RefreshAllCurrencyItemList(CultureInfo ci)
        {
            AllCurrencyItemList.ForEach(x =>
            {
                x.Name = Mvx.IoCProvider.Resolve<IAppResourcesService>().GetString($"Currency_{x.Code}", ci);
            });
        }
    }
}
