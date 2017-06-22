using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XD.UWP.CurrencyExchanger.UWPAPP.Models;
using XD.UWP.CurrencyExchanger.UWPAPP.Utilities;

namespace XD.UWP.CurrencyExchanger.UWPAPP
{

    public class Context
    {
        public static Context Instance { get; } = new Context();
        private Context()
        {
            // private constructor
        }

        /// <summary>
        /// Gets or sets all currency item list.
        /// </summary>
        /// <value>
        /// All currency item list.
        /// </value>
        public List<CurrencyItem> AllCurrencyItemList { get; set; }



        /// <summary>
        /// Gets or sets the currency exchange item list.
        /// </summary>
        /// <value>
        /// The currency exchange item list.
        /// </value>
        public ObservableCollection<CurrencyExchangeItem> CurrencyExchangeItemList { get; set; }


        public async Task Init()
        {
            AllCurrencyItemList = new List<CurrencyItem>()
            {
                new CurrencyItem{Code = "AED", Description = AppResources.AED, Image="flag_united_arab_emirates"},
new CurrencyItem{Code = "ALL", Description = AppResources.ALL, Image="flag_albania", CultureName="sq"},
//new CurrencyItem{Code = "ANG", Description = AppResources.ANG, Image=""},
new CurrencyItem{Code = "ARS", Description = AppResources.ARS, Image="flag_argentina", CultureName="es-AR"},
new CurrencyItem{Code = "AUD", Description = AppResources.AUD, Image="flag_australia", CultureName="en-AU"},
new CurrencyItem{Code = "AWG", Description = AppResources.AWG, Image="flag_aruba", CultureName=""},
new CurrencyItem{Code = "BBD", Description = AppResources.BBD, Image="flag_barbados", CultureName=""},
new CurrencyItem{Code = "BDT", Description = AppResources.BDT, Image="flag_bangladesh", CultureName="bn-BD"},
new CurrencyItem{Code = "BGN", Description = AppResources.BGN, Image="flag_bulgaria", CultureName="bg"},
new CurrencyItem{Code = "BHD", Description = AppResources.BHD, Image="flag_bahrain", CultureName="ar-BH"},
new CurrencyItem{Code = "BIF", Description = AppResources.BIF, Image="flag_burundi", CultureName=""},
new CurrencyItem{Code = "BMD", Description = AppResources.BMD, Image="flag_bermuda", CultureName=""},
new CurrencyItem{Code = "BND", Description = AppResources.BND, Image="flag_brunei", CultureName="ms-BN"},
new CurrencyItem{Code = "BOB", Description = AppResources.BOB, Image="flag_bolivia", CultureName="quz-BO"},
new CurrencyItem{Code = "BRL", Description = AppResources.BRL, Image="flag_brazil", CultureName="pt-BR"},
new CurrencyItem{Code = "BSD", Description = AppResources.BSD, Image="flag_bahamas", CultureName=""},
new CurrencyItem{Code = "BTN", Description = AppResources.BTN, Image="flag_bhutan", CultureName=""},
new CurrencyItem{Code = "BWP", Description = AppResources.BWP, Image="flag_botswana", CultureName=""},
new CurrencyItem{Code = "BYR", Description = AppResources.BYR, Image="flag_belarus", CultureName="be"},
new CurrencyItem{Code = "BZD", Description = AppResources.BZD, Image="flag_belize", CultureName="en-BZ"},
new CurrencyItem{Code = "CAD", Description = AppResources.CAD, Image="flag_canada", CultureName="en-CA"},
new CurrencyItem{Code = "CHF", Description = AppResources.CHF, Image="flag_switzerland", CultureName="fr-CH"},
new CurrencyItem{Code = "CLP", Description = AppResources.CLP, Image="flag_chile", CultureName="arn-CL"},
new CurrencyItem{Code = "CNY", Description = AppResources.CNY, Image="flag_china", CultureName="zh-CN"},
new CurrencyItem{Code = "COP", Description = AppResources.COP, Image="flag_colombia", CultureName="es-CO"},
new CurrencyItem{Code = "CRC", Description = AppResources.CRC, Image="flag_costa_rica", CultureName="es-CR"},
//new CurrencyItem{Code = "CSD", Description = AppResources.CSD},
new CurrencyItem{Code = "CUP", Description = AppResources.CUP, Image="flag_cuba", CultureName=""},
new CurrencyItem{Code = "CVE", Description = AppResources.CVE, Image="flag_cape_verde", CultureName=""},
//new CurrencyItem{Code = "CYP", Description = AppResources.CYP},
new CurrencyItem{Code = "CZK", Description = AppResources.CZK, Image="flag_czech_republic", CultureName="cs"},
//new CurrencyItem{Code = "DEM", Description = AppResources.DEM},
new CurrencyItem{Code = "DJF", Description = AppResources.DJF, Image="flag_djibouti", CultureName=""},
new CurrencyItem{Code = "DKK", Description = AppResources.DKK, Image="flag_denmark", CultureName="da-DK"},
new CurrencyItem{Code = "DOP", Description = AppResources.DOP, Image="flag_dominica", CultureName="es-DO"},
new CurrencyItem{Code = "DZD", Description = AppResources.DZD, Image="flag_algeria", CultureName="ar-DZ"},
new CurrencyItem{Code = "ECS", Description = AppResources.ECS, Image="flag_ecuador", CultureName="quz-EC"},
new CurrencyItem{Code = "EEK", Description = AppResources.EEK, Image="flag_estonia", CultureName="et"},
new CurrencyItem{Code = "EGP", Description = AppResources.EGP, Image="flag_egypt", CultureName="ar-EG"},
new CurrencyItem{Code = "ERN", Description = AppResources.ERN, Image="flag_eritrea", CultureName=""},
new CurrencyItem{Code = "ETB", Description = AppResources.ETB, Image="flag_ethiopia", CultureName="am-ET"},
//欧元暂用法国的区域
new CurrencyItem{Code = "EUR", Description = AppResources.EUR, Image="flag_eu", CultureName="fr-FR"},
new CurrencyItem{Code = "FJD", Description = AppResources.FJD, Image="flag_fiji", CultureName=""},
new CurrencyItem{Code = "FKP", Description = AppResources.FKP, Image="flag_falkland_islands", CultureName=""},
//new CurrencyItem{Code = "FRF", Description = AppResources.FRF},
new CurrencyItem{Code = "GBP", Description = AppResources.GBP, Image="flag_united_kingdom", CultureName="en-GB"},
new CurrencyItem{Code = "GHC", Description = AppResources.GHC, Image="flag_ghana", CultureName=""},
new CurrencyItem{Code = "GIP", Description = AppResources.GIP, Image="flag_gibraltar", CultureName=""},
new CurrencyItem{Code = "GMD", Description = AppResources.GMD, Image="flag_gambia", CultureName=""},
new CurrencyItem{Code = "GNF", Description = AppResources.GNF, Image="flag_guinea", CultureName=""},
new CurrencyItem{Code = "GTQ", Description = AppResources.GTQ, Image="flag_guatemala", CultureName="qut-GT"},
new CurrencyItem{Code = "GYD", Description = AppResources.GYD, Image="flag_guyana", CultureName=""},
//香港旗
new CurrencyItem{Code = "HKD", Description = AppResources.HKD, Image="flag_hong_kong", CultureName="zh-HK"},
//new CurrencyItem{Code = "HKD", Description = AppResources.HKD, Image="flag_china"},
new CurrencyItem{Code = "HNL", Description = AppResources.HNL, Image="flag_honduras", CultureName="es-HN"},
new CurrencyItem{Code = "HRK", Description = AppResources.HRK, Image="flag_croatia", CultureName="hr"},
new CurrencyItem{Code = "HTG", Description = AppResources.HTG, Image="flag_haiti", CultureName=""},
new CurrencyItem{Code = "HUF", Description = AppResources.HUF, Image="flag_hungary", CultureName="hu-HU"},
new CurrencyItem{Code = "IDR", Description = AppResources.IDR, Image="flag_indonesia", CultureName="id"},
new CurrencyItem{Code = "ILS", Description = AppResources.ILS, Image="flag_israel", CultureName="he-IL"},
new CurrencyItem{Code = "INR", Description = AppResources.INR, Image="flag_india", CultureName="en-IN"},
new CurrencyItem{Code = "IQD", Description = AppResources.IQD, Image="flag_iraq", CultureName="ar-IQ"},
new CurrencyItem{Code = "IRR", Description = AppResources.IRR, Image="flag_iran", CultureName=""},
new CurrencyItem{Code = "ISK", Description = AppResources.ISK, Image="flag_iceland", CultureName="is"},
//new CurrencyItem{Code = "ITL", Description = AppResources.ITL},
new CurrencyItem{Code = "JMD", Description = AppResources.JMD, Image="flag_jamaica", CultureName="en-JM"},
new CurrencyItem{Code = "JOD", Description = AppResources.JOD, Image="flag_jordan", CultureName="ar-JO"},
new CurrencyItem{Code = "JPY", Description = AppResources.JPY, Image="flag_japan", CultureName="ja"},
new CurrencyItem{Code = "KES", Description = AppResources.KES, Image="flag_kenya", CultureName="sw-KE"},
new CurrencyItem{Code = "KHR", Description = AppResources.KHR, Image="flag_cambodia", CultureName="km-KH"},
new CurrencyItem{Code = "KMF", Description = AppResources.KMF, Image="flag_comoros", CultureName=""},
new CurrencyItem{Code = "KPW", Description = AppResources.KPW, Image="flag_north_korea", CultureName="ko-KR"},
new CurrencyItem{Code = "KRW", Description = AppResources.KRW, Image="flag_south_korea", CultureName="ko-KR"},
new CurrencyItem{Code = "KWD", Description = AppResources.KWD, Image="flag_kuwait", CultureName="ar-KW"},
new CurrencyItem{Code = "KYD", Description = AppResources.KYD, Image="flag_cayman_islands", CultureName=""},
new CurrencyItem{Code = "KZT", Description = AppResources.KZT, Image="flag_kazakhstan", CultureName="kk-KZ"},
new CurrencyItem{Code = "LAK", Description = AppResources.LAK, Image="flag_laos", CultureName=""},
new CurrencyItem{Code = "LBP", Description = AppResources.LBP, Image="flag_lebanon", CultureName="ar-LB"},
new CurrencyItem{Code = "LKR", Description = AppResources.LKR, Image="flag_sri_lanka", CultureName="si-LK"},
new CurrencyItem{Code = "LRD", Description = AppResources.LRD, Image="flag_liberia", CultureName=""},
new CurrencyItem{Code = "LSL", Description = AppResources.LSL, Image="flag_lesotho", CultureName=""},
new CurrencyItem{Code = "LTL", Description = AppResources.LTL, Image="flag_lithuania", CultureName="lt"},
new CurrencyItem{Code = "LVL", Description = AppResources.LVL, Image="flag_latvia", CultureName="lv"},
new CurrencyItem{Code = "LYD", Description = AppResources.LYD, Image="flag_libya", CultureName="ar-LY"},
new CurrencyItem{Code = "MAD", Description = AppResources.MAD, Image="flag_morocco", CultureName="ar-MA"},
new CurrencyItem{Code = "MDL", Description = AppResources.MDL, Image="flag_moldova", CultureName=""},
//new CurrencyItem{Code = "MGF", Description = AppResources.MGF},
new CurrencyItem{Code = "MKD", Description = AppResources.MKD, Image="flag_macedonia", CultureName="mk"},
new CurrencyItem{Code = "MMK", Description = AppResources.MMK, Image="flag_burma", CultureName=""},
new CurrencyItem{Code = "MNT", Description = AppResources.MNT, Image="flag_mongolia", CultureName="mn"},
new CurrencyItem{Code = "MOP", Description = AppResources.MOP, Image="flag_macau", CultureName="zh-MO"},
new CurrencyItem{Code = "MRO", Description = AppResources.MRO, Image="flag_mauritania", CultureName=""},
new CurrencyItem{Code = "MTL", Description = AppResources.MTL, Image="flag_malta", CultureName="mt-MT"},
new CurrencyItem{Code = "MUR", Description = AppResources.MUR, Image="flag_mauritius", CultureName=""},
new CurrencyItem{Code = "MVR", Description = AppResources.MVR, Image="flag_maldives", CultureName="dv-MV"},
new CurrencyItem{Code = "MWK", Description = AppResources.MWK, Image="flag_malawi", CultureName=""},
new CurrencyItem{Code = "MXN", Description = AppResources.MXN, Image="flag_mexico", CultureName="es-MX"},
new CurrencyItem{Code = "MYR", Description = AppResources.MYR, Image="flag_malaysia", CultureName="en-MY"},
//new CurrencyItem{Code = "MZM", Description = AppResources.MZM},
new CurrencyItem{Code = "NAD", Description = AppResources.NAD, Image="flag_namibia", CultureName=""},
new CurrencyItem{Code = "NGN", Description = AppResources.NGN, Image="flag_nigeria", CultureName="ha-Latn-NG"},
new CurrencyItem{Code = "NIO", Description = AppResources.NIO, Image="flag_nicaragua", CultureName="es-NI"},
new CurrencyItem{Code = "NOK", Description = AppResources.NOK, Image="flag_norway", CultureName="nb-NO"},
new CurrencyItem{Code = "NPR", Description = AppResources.NPR, Image="flag_nepal", CultureName="ne"},
new CurrencyItem{Code = "NZD", Description = AppResources.NZD, Image="flag_new_zealand", CultureName="en-NZ"},
new CurrencyItem{Code = "OMR", Description = AppResources.OMR, Image="flag_oman", CultureName="ar-OM"},
new CurrencyItem{Code = "PAB", Description = AppResources.PAB, Image="flag_panama", CultureName="es-PA"},
new CurrencyItem{Code = "PEN", Description = AppResources.PEN, Image="flag_peru", CultureName="es-PE"},
new CurrencyItem{Code = "PGK", Description = AppResources.PGK, Image="flag_papua_new_guinea", CultureName=""},
new CurrencyItem{Code = "PHP", Description = AppResources.PHP, Image="flag_philippines", CultureName="en-PH"},
new CurrencyItem{Code = "PKR", Description = AppResources.PKR, Image="flag_pakistan", CultureName="ur-PK"},
new CurrencyItem{Code = "PLN", Description = AppResources.PLN, Image="flag_poland", CultureName="pl-PL"},
new CurrencyItem{Code = "PYG", Description = AppResources.PYG, Image="flag_paraguay", CultureName="es-PY"},
new CurrencyItem{Code = "QAR", Description = AppResources.QAR, Image="flag_qatar", CultureName="ar-QA"},
//new CurrencyItem{Code = "ROL", Description = AppResources.ROL},
new CurrencyItem{Code = "RON", Description = AppResources.RON, Image="flag_romania", CultureName="ro"},
new CurrencyItem{Code = "RUB", Description = AppResources.RUB, Image="flag_russia", CultureName="ru"},
new CurrencyItem{Code = "RWF", Description = AppResources.RWF, Image="flag_rwanda", CultureName="rw-RW"},
new CurrencyItem{Code = "SAR", Description = AppResources.SAR, Image="flag_saudi_arabia", CultureName="ar-SA"},
new CurrencyItem{Code = "SBD", Description = AppResources.SBD, Image="flag_solomon_islands", CultureName=""},
new CurrencyItem{Code = "SCR", Description = AppResources.SCR, Image="flag_seychelles", CultureName=""},
new CurrencyItem{Code = "SDG", Description = AppResources.SDG, Image="flag_sudan", CultureName=""},
//new CurrencyItem{Code = "SDP", Description = AppResources.SDP},
new CurrencyItem{Code = "SEK", Description = AppResources.SEK, Image="flag_sweden", CultureName="smj-SE"},
new CurrencyItem{Code = "SGD", Description = AppResources.SGD, Image="flag_singapore", CultureName="zh-SG"},
new CurrencyItem{Code = "SHP", Description = AppResources.SHP, Image="flag_saint_helena", CultureName=""},
new CurrencyItem{Code = "SIT", Description = AppResources.SIT, Image="flag_slovenia", CultureName="sl"},
new CurrencyItem{Code = "SKK", Description = AppResources.SKK, Image="flag_slovakia", CultureName="sk-SK"},
new CurrencyItem{Code = "SLL", Description = AppResources.SLL, Image="flag_sierra_leone", CultureName=""},
new CurrencyItem{Code = "SOS", Description = AppResources.SOS, Image="flag_somalia", CultureName=""},
//new CurrencyItem{Code = "SRG", Description = AppResources.SRG},
new CurrencyItem{Code = "STD", Description = AppResources.STD, Image="flag_sao_tome_and_principe", CultureName=""},
new CurrencyItem{Code = "SVC", Description = AppResources.SVC, Image="flag_el_salvador", CultureName="es-SV"},
new CurrencyItem{Code = "SYP", Description = AppResources.SYP, Image="flag_syria", CultureName="syr-SY"},
new CurrencyItem{Code = "SZL", Description = AppResources.SZL, Image="flag_swaziland", CultureName=""},
new CurrencyItem{Code = "THB", Description = AppResources.THB, Image="flag_thailand", CultureName="th-TH"},
new CurrencyItem{Code = "TND", Description = AppResources.TND, Image="flag_tunisia", CultureName="ar-TN"},
new CurrencyItem{Code = "TOP", Description = AppResources.TOP, Image="flag_tonga", CultureName=""},
new CurrencyItem{Code = "TRY", Description = AppResources.TRY, Image="flag_turkey", CultureName="tr-TR"},
new CurrencyItem{Code = "TTD", Description = AppResources.TTD, Image="flag_trinidad_and_tobago", CultureName="en-TT"},
//台湾 用中国国旗
new CurrencyItem{Code = "TWD", Description = AppResources.TWD, Image="taiwan", CultureName="zh-TW"},
//new CurrencyItem{Code = "TWD", Description = AppResources.TWD, Image="flag_china"},
new CurrencyItem{Code = "TZS", Description = AppResources.TZS, Image="flag_tanzania", CultureName=""},
new CurrencyItem{Code = "UAH", Description = AppResources.UAH, Image="flag_ukraine", CultureName="uk-UA"},
new CurrencyItem{Code = "UGX", Description = AppResources.UGX, Image="flag_uganda", CultureName=""},
new CurrencyItem{Code = "USD", Description = AppResources.USD, Image="flag_usa", CultureName="en-US"},
new CurrencyItem{Code = "UYU", Description = AppResources.UYU, Image="flag_uruguay", CultureName="es-UY"},
new CurrencyItem{Code = "VEF", Description = AppResources.VEF, Image="flag_venezuela", CultureName="es-VE"},
new CurrencyItem{Code = "VND", Description = AppResources.VND, Image="flag_vietnam", CultureName="vi-VN"},
new CurrencyItem{Code = "VUV", Description = AppResources.VUV, Image="flag_vanuatu", CultureName=""},
new CurrencyItem{Code = "WST", Description = AppResources.WST, Image="flag_samoa", CultureName=""},
//中非共同体法郎 暂用喀麦隆国旗代替
new CurrencyItem{Code = "XAF", Description = AppResources.XAF, Image="flag_cameroon", CultureName=""},
new CurrencyItem{Code = "XAG", Description = AppResources.XAG, Image="flag_white", CultureName=""},
new CurrencyItem{Code = "XAL", Description = AppResources.XAL, Image="flag_white", CultureName=""},
new CurrencyItem{Code = "XAU", Description = AppResources.XAU, Image="flag_white", CultureName=""},
new CurrencyItem{Code = "XCD", Description = AppResources.XCD, Image="flag_white", CultureName=""},
new CurrencyItem{Code = "XCP", Description = AppResources.XCP, Image="flag_white", CultureName=""},
new CurrencyItem{Code = "XOF", Description = AppResources.XOF, Image="flag_mali", CultureName=""},
new CurrencyItem{Code = "XPD", Description = AppResources.XPD, Image="flag_white", CultureName=""},
new CurrencyItem{Code = "XPF", Description = AppResources.XPF, Image="flag_french_polynesia", CultureName=""},
new CurrencyItem{Code = "XPT", Description = AppResources.XPT, Image="flag_white", CultureName=""},
new CurrencyItem{Code = "YER", Description = AppResources.YER, Image="flag_yemen", CultureName="yemen"},
new CurrencyItem{Code = "ZAR", Description = AppResources.ZAR, Image="flag_south_africa", CultureName=""},
new CurrencyItem{Code = "ZMK", Description = AppResources.ZMK, Image="flag_zambia", CultureName=""},
new CurrencyItem{Code = "ZWD", Description = AppResources.ZWD, Image="flag_zimbabwe", CultureName="en-ZW"}
//new CurrencyItem{Code = "ZWN", Description = AppResources.ZWN}

            };

            CurrencyExchangeItemList = new ObservableCollection<CurrencyExchangeItem>();

            CurrencyItem itemBase = AllCurrencyItemList.FirstOrDefault(x => x.Code == "USD");
            List<CurrencyItem> listDefault = AllCurrencyItemList.Where(x => x.Code == "USD" || x.Code == "EUR" || x.Code == "CNY" || x.Code == "JPY").ToList();
            //listDefault.ForEach(async x =>
            //{
            //    CurrencyExchangeItem item = new CurrencyExchangeItem(itemBase, x, CurrencyExchangeItemList.Count);
            //    CurrencyExchangeItemList.Add(item);
            //    //await ServiceLocator.Instance.Resolve<CurrencyExchangeDataService>().InsertAsync(item.ToDtoCurrencyExchangeItem());
            //});


        }

        public string ConvertStringWithNewline(string text)
        {
            List<string> list = text.Split('|').ToList();
            string last = list.Last();
            StringBuilder sb = new StringBuilder();

            list.RemoveAt(list.Count - 1);
            list.ForEach(x => sb.Append(x).Append(System.Environment.NewLine));
            sb.Append(last);
            return sb.ToString();
        }
    }
}
