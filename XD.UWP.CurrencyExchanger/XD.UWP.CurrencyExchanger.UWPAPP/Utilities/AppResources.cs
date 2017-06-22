using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace XD.UWP.CurrencyExchanger.UWPAPP.Utilities
{
    public static class AppResources
    {
        private static ResourceLoader CurrentResourceLoader
        {
            get { return _loader ?? (_loader = ResourceLoader.GetForCurrentView("Resources")); }
        }

        private static ResourceLoader _loader;
        private static readonly Dictionary<string, string> ResourceCache = new Dictionary<string, string>();

        public static string GetString(string key)
        {
            string s;
            if (ResourceCache.TryGetValue(key, out s))
            {
                return s;
            }
            else
            {
                s = CurrentResourceLoader.GetString(key);
                ResourceCache[key] = s;
                return s;
            }
        }



        /// <summary>
        ///   查找类似 添加货币 的本地化字符串。
        /// </summary>
        public static string AddCurrency_PageName
        {
            get
            {
                return CurrentResourceLoader.GetString("AddCurrency_PageName");
            }
        }

        /// <summary>
        ///   查找类似 搜索: 的本地化字符串。
        /// </summary>
        public static string AddCurrency_Search
        {
            get
            {
                return CurrentResourceLoader.GetString("AddCurrency_Search");
            }
        }

        /// <summary>
        ///   查找类似 阿联酋迪拉姆 UAE Dirham 的本地化字符串。
        /// </summary>
        public static string AED
        {
            get
            {
                return CurrentResourceLoader.GetString("AED");
            }
        }

        /// <summary>
        ///   查找类似 阿尔巴尼亚列克 Albanian Lek 的本地化字符串。
        /// </summary>
        public static string ALL
        {
            get
            {
                return CurrentResourceLoader.GetString("ALL");
            }
        }

        /// <summary>
        ///   查找类似 掌中汇率 的本地化字符串。
        /// </summary>
        public static string APP_Name
        {
            get
            {
                return CurrentResourceLoader.GetString("APP_Name");
            }
        }


        /// <summary>
        /// 查找类似 确定 的本地化字符串。
        /// </summary>
        public static string App_OK
        {
            get
            {
                return CurrentResourceLoader.GetString("App_OK");
            }
        }

        /// <summary>
        /// 查找类似 取消 的本地化字符串。
        /// </summary>
        public static string App_Cancel
        {
            get
            {
                return CurrentResourceLoader.GetString("App_Cancel");
            }
        }

        /// <summary>
        ///   查找类似 添加 的本地化字符串。
        /// </summary>
        public static string AppBarButton_Add
        {
            get
            {
                return CurrentResourceLoader.GetString("AppBarButton_Add");
            }
        }

        /// <summary>
        ///   查找类似 选择 的本地化字符串。
        /// </summary>
        public static string AppBarButton_Select
        {
            get
            {
                return CurrentResourceLoader.GetString("AppBarButton_Select");
            }
        }

        /// <summary>
        ///   查找类似 添加 的本地化字符串。
        /// </summary>
        public static string AppBarButtonText
        {
            get
            {
                return CurrentResourceLoader.GetString("AppBarButtonText");
            }
        }

        /// <summary>
        ///   查找类似 菜单项 的本地化字符串。
        /// </summary>
        public static string AppBarMenuItemText
        {
            get
            {
                return CurrentResourceLoader.GetString("AppBarMenuItemText");
            }
        }

        /// <summary>
        ///   查找类似 我的应用程序 的本地化字符串。
        /// </summary>
        public static string ApplicationTitle
        {
            get
            {
                return CurrentResourceLoader.GetString("ApplicationTitle");
            }
        }

        /// <summary>
        ///   查找类似 阿根廷比索 Argentine Peso 的本地化字符串。
        /// </summary>
        public static string ARS
        {
            get
            {
                return CurrentResourceLoader.GetString("ARS");
            }
        }

        /// <summary>
        ///   查找类似 澳元 Australian Dollar 的本地化字符串。
        /// </summary>
        public static string AUD
        {
            get
            {
                return CurrentResourceLoader.GetString("AUD");
            }
        }

        /// <summary>
        ///   查找类似 阿鲁巴岛弗罗林 Aruba Florin 的本地化字符串。
        /// </summary>
        public static string AWG
        {
            get
            {
                return CurrentResourceLoader.GetString("AWG");
            }
        }

        /// <summary>
        ///   查找类似 巴巴多斯元 Barbados Dollar 的本地化字符串。
        /// </summary>
        public static string BBD
        {
            get
            {
                return CurrentResourceLoader.GetString("BBD");
            }
        }

        /// <summary>
        ///   查找类似 孟加拉塔卡 Bangladesh Taka 的本地化字符串。
        /// </summary>
        public static string BDT
        {
            get
            {
                return CurrentResourceLoader.GetString("BDT");
            }
        }

        /// <summary>
        ///   查找类似 保加利亚列瓦 Bulgarian Lev 的本地化字符串。
        /// </summary>
        public static string BGN
        {
            get
            {
                return CurrentResourceLoader.GetString("BGN");
            }
        }

        /// <summary>
        ///   查找类似 巴林第纳尔 Bahraini Dinar 的本地化字符串。
        /// </summary>
        public static string BHD
        {
            get
            {
                return CurrentResourceLoader.GetString("BHD");
            }
        }

        /// <summary>
        ///   查找类似 布隆迪法郎 Burundi Franc 的本地化字符串。
        /// </summary>
        public static string BIF
        {
            get
            {
                return CurrentResourceLoader.GetString("BIF");
            }
        }

        /// <summary>
        ///   查找类似 百慕大元 Bermuda Dollar 的本地化字符串。
        /// </summary>
        public static string BMD
        {
            get
            {
                return CurrentResourceLoader.GetString("BMD");
            }
        }

        /// <summary>
        ///   查找类似 文莱元 Brunei Dollar 的本地化字符串。
        /// </summary>
        public static string BND
        {
            get
            {
                return CurrentResourceLoader.GetString("BND");
            }
        }

        /// <summary>
        ///   查找类似 玻利维亚诺 Bolivian Boliviano 的本地化字符串。
        /// </summary>
        public static string BOB
        {
            get
            {
                return CurrentResourceLoader.GetString("BOB");
            }
        }

        /// <summary>
        ///   查找类似 巴西里亚伊 Brazilian Real 的本地化字符串。
        /// </summary>
        public static string BRL
        {
            get
            {
                return CurrentResourceLoader.GetString("BRL");
            }
        }

        /// <summary>
        ///   查找类似 巴哈马元 Bahamian Dollar 的本地化字符串。
        /// </summary>
        public static string BSD
        {
            get
            {
                return CurrentResourceLoader.GetString("BSD");
            }
        }

        /// <summary>
        ///   查找类似 不丹卢比 Bhutan Ngultrum 的本地化字符串。
        /// </summary>
        public static string BTN
        {
            get
            {
                return CurrentResourceLoader.GetString("BTN");
            }
        }

        /// <summary>
        ///   查找类似 博茨瓦纳普拉 Botswana Pula 的本地化字符串。
        /// </summary>
        public static string BWP
        {
            get
            {
                return CurrentResourceLoader.GetString("BWP");
            }
        }

        /// <summary>
        ///   查找类似 白俄罗斯卢布 Belarus Ruble 的本地化字符串。
        /// </summary>
        public static string BYR
        {
            get
            {
                return CurrentResourceLoader.GetString("BYR");
            }
        }

        /// <summary>
        ///   查找类似 伯利兹元 Belize Dollar 的本地化字符串。
        /// </summary>
        public static string BZD
        {
            get
            {
                return CurrentResourceLoader.GetString("BZD");
            }
        }

        /// <summary>
        ///   查找类似 加拿大元 Canadian Dollar 的本地化字符串。
        /// </summary>
        public static string CAD
        {
            get
            {
                return CurrentResourceLoader.GetString("CAD");
            }
        }

        /// <summary>
        ///   查找类似 瑞士法郎 Swiss Franc 的本地化字符串。
        /// </summary>
        public static string CHF
        {
            get
            {
                return CurrentResourceLoader.GetString("CHF");
            }
        }

        /// <summary>
        ///   查找类似 智利比索 Chilean Peso 的本地化字符串。
        /// </summary>
        public static string CLP
        {
            get
            {
                return CurrentResourceLoader.GetString("CLP");
            }
        }

        /// <summary>
        ///   查找类似 人民币 Chinese Yuan Renminbi 的本地化字符串。
        /// </summary>
        public static string CNY
        {
            get
            {
                return CurrentResourceLoader.GetString("CNY");
            }
        }

        /// <summary>
        ///   查找类似 哥伦比亚比索 Colombian Peso 的本地化字符串。
        /// </summary>
        public static string COP
        {
            get
            {
                return CurrentResourceLoader.GetString("COP");
            }
        }

        /// <summary>
        ///   查找类似 哥斯达黎加科朗 Costa Rica Colon 的本地化字符串。
        /// </summary>
        public static string CRC
        {
            get
            {
                return CurrentResourceLoader.GetString("CRC");
            }
        }

        /// <summary>
        ///   查找类似 古巴比索 Cuban Peso 的本地化字符串。
        /// </summary>
        public static string CUP
        {
            get
            {
                return CurrentResourceLoader.GetString("CUP");
            }
        }

        /// <summary>
        ///   查找类似 佛得角埃斯库多 Cape Verde Escudo 的本地化字符串。
        /// </summary>
        public static string CVE
        {
            get
            {
                return CurrentResourceLoader.GetString("CVE");
            }
        }

        /// <summary>
        ///   查找类似 捷克克朗 Czech Koruna 的本地化字符串。
        /// </summary>
        public static string CZK
        {
            get
            {
                return CurrentResourceLoader.GetString("CZK");
            }
        }

        /// <summary>
        ///   查找类似 吉布提法郎 Dijibouti Franc 的本地化字符串。
        /// </summary>
        public static string DJF
        {
            get
            {
                return CurrentResourceLoader.GetString("DJF");
            }
        }

        /// <summary>
        ///   查找类似 丹麦克朗 Danish Krone 的本地化字符串。
        /// </summary>
        public static string DKK
        {
            get
            {
                return CurrentResourceLoader.GetString("DKK");
            }
        }

        /// <summary>
        ///   查找类似 多米尼加比索 Dominican Peso 的本地化字符串。
        /// </summary>
        public static string DOP
        {
            get
            {
                return CurrentResourceLoader.GetString("DOP");
            }
        }

        /// <summary>
        ///   查找类似 阿尔及利亚第纳尔 Algerian Dinar 的本地化字符串。
        /// </summary>
        public static string DZD
        {
            get
            {
                return CurrentResourceLoader.GetString("DZD");
            }
        }

        /// <summary>
        ///   查找类似 厄瓜多尔苏克雷 Ecuador Sucre 的本地化字符串。
        /// </summary>
        public static string ECS
        {
            get
            {
                return CurrentResourceLoader.GetString("ECS");
            }
        }

        /// <summary>
        ///   查找类似 编辑列表 的本地化字符串。
        /// </summary>
        public static string EditList_PageName
        {
            get
            {
                return CurrentResourceLoader.GetString("EditList_PageName");
            }
        }

        /// <summary>
        ///   查找类似 爱沙尼亚克伦尼 Estonian Kroon 的本地化字符串。
        /// </summary>
        public static string EEK
        {
            get
            {
                return CurrentResourceLoader.GetString("EEK");
            }
        }

        /// <summary>
        ///   查找类似 埃及镑 Egyptian Pound 的本地化字符串。
        /// </summary>
        public static string EGP
        {
            get
            {
                return CurrentResourceLoader.GetString("EGP");
            }
        }

        /// <summary>
        ///   查找类似 厄立特里亚 Eritrea Nakfa 的本地化字符串。
        /// </summary>
        public static string ERN
        {
            get
            {
                return CurrentResourceLoader.GetString("ERN");
            }
        }

        /// <summary>
        ///   查找类似 不好意思！
        ///看起来程序发生了一个错误。8-(
        ///请联系我描述一下错误的发生情况，我会尽快解决这个问题。
        ///E-mail:yan_xiaodi@hotmail.com
        ///谢谢！ 的本地化字符串。
        /// </summary>
        public static string Error_Content
        {
            get
            {
                return CurrentResourceLoader.GetString("Error_Content");
            }
        }

        /// <summary>
        ///   查找类似 首页 的本地化字符串。
        /// </summary>
        public static string Error_MainMenu
        {
            get
            {
                return CurrentResourceLoader.GetString("Error_MainMenu");
            }
        }

        /// <summary>
        ///   查找类似 错误 的本地化字符串。
        /// </summary>
        public static string Error_PageName
        {
            get
            {
                return CurrentResourceLoader.GetString("Error_PageName");
            }
        }

        /// <summary>
        ///   查找类似 发送反馈 的本地化字符串。
        /// </summary>
        public static string Error_SendFeedback
        {
            get
            {
                return CurrentResourceLoader.GetString("Error_SendFeedback");
            }
        }

        /// <summary>
        ///   查找类似 埃塞俄比亚比尔 Ethiopian Birr 的本地化字符串。
        /// </summary>
        public static string ETB
        {
            get
            {
                return CurrentResourceLoader.GetString("ETB");
            }
        }

        /// <summary>
        ///   查找类似 欧元 Euro 的本地化字符串。
        /// </summary>
        public static string EUR
        {
            get
            {
                return CurrentResourceLoader.GetString("EUR");
            }
        }

        /// <summary>
        ///   查找类似 斐济元 Fiji Dollar 的本地化字符串。
        /// </summary>
        public static string FJD
        {
            get
            {
                return CurrentResourceLoader.GetString("FJD");
            }
        }

        /// <summary>
        ///   查找类似 福克兰群岛镑 Falkland Islands Pound 的本地化字符串。
        /// </summary>
        public static string FKP
        {
            get
            {
                return CurrentResourceLoader.GetString("FKP");
            }
        }

        /// <summary>
        ///   查找类似 英镑 British Pound 的本地化字符串。
        /// </summary>
        public static string GBP
        {
            get
            {
                return CurrentResourceLoader.GetString("GBP");
            }
        }

        /// <summary>
        ///   查找类似 加纳塞地 Ghanian Cedi 的本地化字符串。
        /// </summary>
        public static string GHC
        {
            get
            {
                return CurrentResourceLoader.GetString("GHC");
            }
        }

        /// <summary>
        ///   查找类似 直布罗陀镑 Gibraltar Pound 的本地化字符串。
        /// </summary>
        public static string GIP
        {
            get
            {
                return CurrentResourceLoader.GetString("GIP");
            }
        }

        /// <summary>
        ///   查找类似 冈比亚达拉西 Gambian Dalasi 的本地化字符串。
        /// </summary>
        public static string GMD
        {
            get
            {
                return CurrentResourceLoader.GetString("GMD");
            }
        }

        /// <summary>
        ///   查找类似 几内亚法郎 Guinea Franc 的本地化字符串。
        /// </summary>
        public static string GNF
        {
            get
            {
                return CurrentResourceLoader.GetString("GNF");
            }
        }

        /// <summary>
        ///   查找类似 危地马拉格查尔 Guatemala Quetzal 的本地化字符串。
        /// </summary>
        public static string GTQ
        {
            get
            {
                return CurrentResourceLoader.GetString("GTQ");
            }
        }

        /// <summary>
        ///   查找类似 圭亚那元 Guyana Dollar 的本地化字符串。
        /// </summary>
        public static string GYD
        {
            get
            {
                return CurrentResourceLoader.GetString("GYD");
            }
        }

        /// <summary>
        ///   查找类似 港元 Hong Kong Dollar 的本地化字符串。
        /// </summary>
        public static string HKD
        {
            get
            {
                return CurrentResourceLoader.GetString("HKD");
            }
        }

        /// <summary>
        ///   查找类似 洪都拉斯伦皮拉 Honduras Lempira 的本地化字符串。
        /// </summary>
        public static string HNL
        {
            get
            {
                return CurrentResourceLoader.GetString("HNL");
            }
        }

        /// <summary>
        ///   查找类似 克罗地亚库纳 Croatian Kuna 的本地化字符串。
        /// </summary>
        public static string HRK
        {
            get
            {
                return CurrentResourceLoader.GetString("HRK");
            }
        }

        /// <summary>
        ///   查找类似 海地古德 Haiti Gourde 的本地化字符串。
        /// </summary>
        public static string HTG
        {
            get
            {
                return CurrentResourceLoader.GetString("HTG");
            }
        }

        /// <summary>
        ///   查找类似 匈牙利福林 Hungarian Forint 的本地化字符串。
        /// </summary>
        public static string HUF
        {
            get
            {
                return CurrentResourceLoader.GetString("HUF");
            }
        }

        /// <summary>
        ///   查找类似 印度尼西亚卢比(盾) Indonesian Rupiah 的本地化字符串。
        /// </summary>
        public static string IDR
        {
            get
            {
                return CurrentResourceLoader.GetString("IDR");
            }
        }

        /// <summary>
        ///   查找类似 以色列镑 Israeli Shekel 的本地化字符串。
        /// </summary>
        public static string ILS
        {
            get
            {
                return CurrentResourceLoader.GetString("ILS");
            }
        }

        /// <summary>
        ///   查找类似 印度卢比 Indian Rupee 的本地化字符串。
        /// </summary>
        public static string INR
        {
            get
            {
                return CurrentResourceLoader.GetString("INR");
            }
        }

        /// <summary>
        ///   查找类似 伊拉克第纳尔 Iraqi Dinar 的本地化字符串。
        /// </summary>
        public static string IQD
        {
            get
            {
                return CurrentResourceLoader.GetString("IQD");
            }
        }

        /// <summary>
        ///   查找类似 伊朗里亚尔 Iran Rial 的本地化字符串。
        /// </summary>
        public static string IRR
        {
            get
            {
                return CurrentResourceLoader.GetString("IRR");
            }
        }

        /// <summary>
        ///   查找类似 冰岛克朗 Iceland Krona 的本地化字符串。
        /// </summary>
        public static string ISK
        {
            get
            {
                return CurrentResourceLoader.GetString("ISK");
            }
        }

        /// <summary>
        ///   查找类似 牙买加元 Jamaican Dollar 的本地化字符串。
        /// </summary>
        public static string JMD
        {
            get
            {
                return CurrentResourceLoader.GetString("JMD");
            }
        }

        /// <summary>
        ///   查找类似 约旦第纳尔 Jordanian Dinar 的本地化字符串。
        /// </summary>
        public static string JOD
        {
            get
            {
                return CurrentResourceLoader.GetString("JOD");
            }
        }

        /// <summary>
        ///   查找类似 日元 Japanese Yen 的本地化字符串。
        /// </summary>
        public static string JPY
        {
            get
            {
                return CurrentResourceLoader.GetString("JPY");
            }
        }

        /// <summary>
        ///   查找类似 肯尼亚先令 Kenyan Shilling 的本地化字符串。
        /// </summary>
        public static string KES
        {
            get
            {
                return CurrentResourceLoader.GetString("KES");
            }
        }

        /// <summary>
        ///   查找类似 柬埔寨利尔斯 Cambodia Riel 的本地化字符串。
        /// </summary>
        public static string KHR
        {
            get
            {
                return CurrentResourceLoader.GetString("KHR");
            }
        }

        /// <summary>
        ///   查找类似 科摩罗法郎 Comoros Franc 的本地化字符串。
        /// </summary>
        public static string KMF
        {
            get
            {
                return CurrentResourceLoader.GetString("KMF");
            }
        }

        /// <summary>
        ///   查找类似 朝鲜圆 North Korean Won 的本地化字符串。
        /// </summary>
        public static string KPW
        {
            get
            {
                return CurrentResourceLoader.GetString("KPW");
            }
        }

        /// <summary>
        ///   查找类似 韩元 South-Korean Won 的本地化字符串。
        /// </summary>
        public static string KRW
        {
            get
            {
                return CurrentResourceLoader.GetString("KRW");
            }
        }

        /// <summary>
        ///   查找类似 科威特第纳尔 Kuwaiti Dinar 的本地化字符串。
        /// </summary>
        public static string KWD
        {
            get
            {
                return CurrentResourceLoader.GetString("KWD");
            }
        }

        /// <summary>
        ///   查找类似 开曼岛元 Cayman Islands Dollar 的本地化字符串。
        /// </summary>
        public static string KYD
        {
            get
            {
                return CurrentResourceLoader.GetString("KYD");
            }
        }

        /// <summary>
        ///   查找类似 哈萨克斯坦腾格 Kazakhstan Tenge 的本地化字符串。
        /// </summary>
        public static string KZT
        {
            get
            {
                return CurrentResourceLoader.GetString("KZT");
            }
        }

        /// <summary>
        ///   查找类似 老挝基普 Lao Kip 的本地化字符串。
        /// </summary>
        public static string LAK
        {
            get
            {
                return CurrentResourceLoader.GetString("LAK");
            }
        }

        /// <summary>
        ///   查找类似 黎巴嫩镑 Lebanese Pound 的本地化字符串。
        /// </summary>
        public static string LBP
        {
            get
            {
                return CurrentResourceLoader.GetString("LBP");
            }
        }

        /// <summary>
        ///   查找类似 斯里兰卡卢比 Sri Lanka Rupee 的本地化字符串。
        /// </summary>
        public static string LKR
        {
            get
            {
                return CurrentResourceLoader.GetString("LKR");
            }
        }

        /// <summary>
        ///   查找类似 利比里亚元 Liberian Dollar 的本地化字符串。
        /// </summary>
        public static string LRD
        {
            get
            {
                return CurrentResourceLoader.GetString("LRD");
            }
        }

        /// <summary>
        ///   查找类似 莱索托洛提 Lesotho Loti 的本地化字符串。
        /// </summary>
        public static string LSL
        {
            get
            {
                return CurrentResourceLoader.GetString("LSL");
            }
        }

        /// <summary>
        ///   查找类似 立陶宛里塔斯 Lithuanian Litas 的本地化字符串。
        /// </summary>
        public static string LTL
        {
            get
            {
                return CurrentResourceLoader.GetString("LTL");
            }
        }

        /// <summary>
        ///   查找类似 拉脱维亚拉图 Latvian Lats 的本地化字符串。
        /// </summary>
        public static string LVL
        {
            get
            {
                return CurrentResourceLoader.GetString("LVL");
            }
        }

        /// <summary>
        ///   查找类似 利比亚第纳尔 Libyan Dinar 的本地化字符串。
        /// </summary>
        public static string LYD
        {
            get
            {
                return CurrentResourceLoader.GetString("LYD");
            }
        }

        /// <summary>
        ///   查找类似 摩洛哥道拉姆 Moroccan Dirham 的本地化字符串。
        /// </summary>
        public static string MAD
        {
            get
            {
                return CurrentResourceLoader.GetString("MAD");
            }
        }

        /// <summary>
        ///   查找类似 请点击此处先添加一些货币。 的本地化字符串。
        /// </summary>
        public static string Main_AddCurrencyFirst
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_AddCurrencyFirst");
            }
        }

        /// <summary>
        ///   查找类似 数字格式错误或超出范围了。8-( 的本地化字符串。
        /// </summary>
        public static string Main_InputError
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_InputError");
            }
        }

        /// <summary>
        ///   查找类似 只能输入数字。 的本地化字符串。
        /// </summary>
        public static string Main_InputNote
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_InputNote");
            }
        }

        /// <summary>
        ///   查找类似 请输入数字。 的本地化字符串。
        /// </summary>
        public static string Main_InputTitle
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_InputTitle");
            }
        }

        /// <summary>
        ///   查找类似 最后更新时间： 的本地化字符串。
        /// </summary>
        public static string Main_LastUpdateTime
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_LastUpdateTime");
            }
        }

        /// <summary>
        ///   查找类似 未知 的本地化字符串。
        /// </summary>
        public static string Main_LastUpdateTimeUnknown
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_LastUpdateTimeUnknown");
            }
        }

        /// <summary>
        ///   查找类似 掌中汇率 的本地化字符串。
        /// </summary>
        public static string Main_PageName
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_PageName");
            }
        }

        /// <summary>
        ///   查找类似 固定到“开始”屏幕 的本地化字符串。
        /// </summary>
        public static string Main_PinToStart
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_PinToStart");
            }
        }

        /// <summary>
        ///   查找类似 删除 的本地化字符串。
        /// </summary>
        public static string Main_Remove
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_Remove");
            }
        }

        /// <summary>
        ///   查找类似 请点击评价按钮给个评论吧，谢谢啦！我需要您的支持和鼓励！8-) 的本地化字符串。
        /// </summary>
        public static string Main_ReviewMe
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_ReviewMe");
            }
        }

        /// <summary>
        ///   查找类似 下次吧 的本地化字符串。
        /// </summary>
        public static string Main_ReviewNextTime
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_ReviewNextTime");
            }
        }

        /// <summary>
        ///   查找类似 现在去评分 的本地化字符串。
        /// </summary>
        public static string Main_ReviewNow
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_ReviewNow");
            }
        }

        /// <summary>
        ///   查找类似 设为基准货币 的本地化字符串。
        /// </summary>
        public static string Main_SetAsBaseCurrency
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_SetAsBaseCurrency");
            }
        }

        /// <summary>
        ///   查找类似 分享 的本地化字符串。
        /// </summary>
        public static string Main_Share
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_Share");
            }
        }

        /// <summary>
        ///   查找类似 查看历史图表 的本地化字符串。
        /// </summary>
        public static string Main_ViewChart
        {
            get
            {
                return CurrentResourceLoader.GetString("Main_ViewChart");
            }
        }

        /// <summary>
        ///   查找类似 摩尔多瓦列伊 Moldovan Leu 的本地化字符串。
        /// </summary>
        public static string MDL
        {
            get
            {
                return CurrentResourceLoader.GetString("MDL");
            }
        }

        /// <summary>
        ///   查找类似 此应用的后台代理已被禁用。 的本地化字符串。
        /// </summary>
        public static string Message_BackgroundAgentsDisabled
        {
            get
            {
                return CurrentResourceLoader.GetString("Message_BackgroundAgentsDisabled");
            }
        }

        /// <summary>
        ///   查找类似 无法添加后台代理。如果同时启用的后台代理数量已超过限制，请在手机的设置中禁用某些代理。 的本地化字符串。
        /// </summary>
        public static string Message_BackgroundAgentsUnable
        {
            get
            {
                return CurrentResourceLoader.GetString("Message_BackgroundAgentsUnable");
            }
        }

        /// <summary>
        ///   查找类似 确认要清空汇率列表吗？ 的本地化字符串。
        /// </summary>
        public static string Message_ConfirmRemoveAll
        {
            get
            {
                return CurrentResourceLoader.GetString("Message_ConfirmRemoveAll");
            }
        }

        /// <summary>
        ///   查找类似 确认要删除所有Live Tile吗？ 的本地化字符串。
        /// </summary>
        public static string Message_ConfirmRemoveAllTiles
        {
            get
            {
                return CurrentResourceLoader.GetString("Message_ConfirmRemoveAllTiles");
            }
        }

        /// <summary>
        ///   查找类似 马其顿第纳尔 Macedonian Denar 的本地化字符串。
        /// </summary>
        public static string MKD
        {
            get
            {
                return CurrentResourceLoader.GetString("MKD");
            }
        }

        /// <summary>
        ///   查找类似 缅甸元 Myanmar Kyat 的本地化字符串。
        /// </summary>
        public static string MMK
        {
            get
            {
                return CurrentResourceLoader.GetString("MMK");
            }
        }

        /// <summary>
        ///   查找类似 蒙古图格里克 Mongolian Tugrik 的本地化字符串。
        /// </summary>
        public static string MNT
        {
            get
            {
                return CurrentResourceLoader.GetString("MNT");
            }
        }

        /// <summary>
        ///   查找类似 澳门元 Macau Pataca 的本地化字符串。
        /// </summary>
        public static string MOP
        {
            get
            {
                return CurrentResourceLoader.GetString("MOP");
            }
        }

        /// <summary>
        ///   查找类似 毛里塔尼亚乌吉亚 Mauritania Ougulya 的本地化字符串。
        /// </summary>
        public static string MRO
        {
            get
            {
                return CurrentResourceLoader.GetString("MRO");
            }
        }

        /// <summary>
        ///   查找类似 马尔他里拉 Maltese Lira 的本地化字符串。
        /// </summary>
        public static string MTL
        {
            get
            {
                return CurrentResourceLoader.GetString("MTL");
            }
        }

        /// <summary>
        ///   查找类似 毛里求斯卢比 Mauritius Rupee 的本地化字符串。
        /// </summary>
        public static string MUR
        {
            get
            {
                return CurrentResourceLoader.GetString("MUR");
            }
        }

        /// <summary>
        ///   查找类似 马尔代夫卢非亚 Maldives Rufiyaa 的本地化字符串。
        /// </summary>
        public static string MVR
        {
            get
            {
                return CurrentResourceLoader.GetString("MVR");
            }
        }

        /// <summary>
        ///   查找类似 马拉维克瓦查 Malawi Kwacha 的本地化字符串。
        /// </summary>
        public static string MWK
        {
            get
            {
                return CurrentResourceLoader.GetString("MWK");
            }
        }

        /// <summary>
        ///   查找类似 墨西哥比索 Mexican Peso 的本地化字符串。
        /// </summary>
        public static string MXN
        {
            get
            {
                return CurrentResourceLoader.GetString("MXN");
            }
        }

        /// <summary>
        ///   查找类似 马来西亚林吉特 Malaysian Ringgit 的本地化字符串。
        /// </summary>
        public static string MYR
        {
            get
            {
                return CurrentResourceLoader.GetString("MYR");
            }
        }

        /// <summary>
        ///   查找类似 纳米比亚元 Namibian Dollar 的本地化字符串。
        /// </summary>
        public static string NAD
        {
            get
            {
                return CurrentResourceLoader.GetString("NAD");
            }
        }

        /// <summary>
        ///   查找类似 尼日利亚奈拉 Nigerian Naira 的本地化字符串。
        /// </summary>
        public static string NGN
        {
            get
            {
                return CurrentResourceLoader.GetString("NGN");
            }
        }

        /// <summary>
        ///   查找类似 尼加拉瓜科多巴 Nicaragua Cordoba 的本地化字符串。
        /// </summary>
        public static string NIO
        {
            get
            {
                return CurrentResourceLoader.GetString("NIO");
            }
        }

        /// <summary>
        ///   查找类似 挪威克朗 Norwegian Kroner 的本地化字符串。
        /// </summary>
        public static string NOK
        {
            get
            {
                return CurrentResourceLoader.GetString("NOK");
            }
        }

        /// <summary>
        ///   查找类似 尼泊尔卢比 Nepalese Rupee 的本地化字符串。
        /// </summary>
        public static string NPR
        {
            get
            {
                return CurrentResourceLoader.GetString("NPR");
            }
        }

        /// <summary>
        ///   查找类似 新西兰元 New Zealand Dollar 的本地化字符串。
        /// </summary>
        public static string NZD
        {
            get
            {
                return CurrentResourceLoader.GetString("NZD");
            }
        }

        /// <summary>
        ///   查找类似 阿曼里亚尔 Omani Rial 的本地化字符串。
        /// </summary>
        public static string OMR
        {
            get
            {
                return CurrentResourceLoader.GetString("OMR");
            }
        }

        /// <summary>
        ///   查找类似 巴拿马巴尔博亚 Panama Balboa 的本地化字符串。
        /// </summary>
        public static string PAB
        {
            get
            {
                return CurrentResourceLoader.GetString("PAB");
            }
        }

        /// <summary>
        ///   查找类似 秘鲁索尔 Peruvian Nuevo Sol 的本地化字符串。
        /// </summary>
        public static string PEN
        {
            get
            {
                return CurrentResourceLoader.GetString("PEN");
            }
        }

        /// <summary>
        ///   查找类似 巴布亚新几内亚基那 Papua New Guinea Kina 的本地化字符串。
        /// </summary>
        public static string PGK
        {
            get
            {
                return CurrentResourceLoader.GetString("PGK");
            }
        }

        /// <summary>
        ///   查找类似 菲律宾比索 Philippine Peso 的本地化字符串。
        /// </summary>
        public static string PHP
        {
            get
            {
                return CurrentResourceLoader.GetString("PHP");
            }
        }

        /// <summary>
        ///   查找类似 巴基斯坦卢比 Pakistani Rupee 的本地化字符串。
        /// </summary>
        public static string PKR
        {
            get
            {
                return CurrentResourceLoader.GetString("PKR");
            }
        }

        /// <summary>
        ///   查找类似 波兰兹罗提 Polish Zloty 的本地化字符串。
        /// </summary>
        public static string PLN
        {
            get
            {
                return CurrentResourceLoader.GetString("PLN");
            }
        }

        /// <summary>
        ///   查找类似 巴拉圭瓜拉尼 Paraguayan Guarani 的本地化字符串。
        /// </summary>
        public static string PYG
        {
            get
            {
                return CurrentResourceLoader.GetString("PYG");
            }
        }

        /// <summary>
        ///   查找类似 卡塔尔利尔 Qatar Rial 的本地化字符串。
        /// </summary>
        public static string QAR
        {
            get
            {
                return CurrentResourceLoader.GetString("QAR");
            }
        }

        /// <summary>
        ///   查找类似 LeftToRight 的本地化字符串。
        /// </summary>
        public static string ResourceFlowDirection
        {
            get
            {
                return CurrentResourceLoader.GetString("ResourceFlowDirection");
            }
        }

        /// <summary>
        ///   查找类似 zh-cn 的本地化字符串。
        /// </summary>
        public static string ResourceLanguage
        {
            get
            {
                return CurrentResourceLoader.GetString("ResourceLanguage");
            }
        }

        /// <summary>
        ///   查找类似 罗马尼亚新列伊 Romanian New Leu 的本地化字符串。
        /// </summary>
        public static string RON
        {
            get
            {
                return CurrentResourceLoader.GetString("RON");
            }
        }

        /// <summary>
        ///   查找类似 俄罗斯卢布 Russian Rouble 的本地化字符串。
        /// </summary>
        public static string RUB
        {
            get
            {
                return CurrentResourceLoader.GetString("RUB");
            }
        }

        /// <summary>
        ///   查找类似 卢旺达法郎 Rwanda Franc 的本地化字符串。
        /// </summary>
        public static string RWF
        {
            get
            {
                return CurrentResourceLoader.GetString("RWF");
            }
        }

        /// <summary>
        ///   查找类似 沙特阿拉伯里亚尔 Saudi Arabian Riyal 的本地化字符串。
        /// </summary>
        public static string SAR
        {
            get
            {
                return CurrentResourceLoader.GetString("SAR");
            }
        }

        /// <summary>
        ///   查找类似 所罗门群岛元 Solomon Islands Dollar 的本地化字符串。
        /// </summary>
        public static string SBD
        {
            get
            {
                return CurrentResourceLoader.GetString("SBD");
            }
        }

        /// <summary>
        ///   查找类似 塞舌尔法郎 Seychelles Rupee 的本地化字符串。
        /// </summary>
        public static string SCR
        {
            get
            {
                return CurrentResourceLoader.GetString("SCR");
            }
        }

        /// <summary>
        ///   查找类似 苏丹镑 Sudanese Pound 的本地化字符串。
        /// </summary>
        public static string SDG
        {
            get
            {
                return CurrentResourceLoader.GetString("SDG");
            }
        }

        /// <summary>
        ///   查找类似 瑞典克朗 Swedish Krona 的本地化字符串。
        /// </summary>
        public static string SEK
        {
            get
            {
                return CurrentResourceLoader.GetString("SEK");
            }
        }

        /// <summary>
        ///   查找类似 精确度 的本地化字符串。
        /// </summary>
        public static string Settings_Accuracy
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_Accuracy");
            }
        }

        /// <summary>
        ///   查找类似 保留两位小数 的本地化字符串。
        /// </summary>
        public static string Settings_Accuracy_2
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_Accuracy_2");
            }
        }

        /// <summary>
        ///   查找类似 保留四位小数 的本地化字符串。
        /// </summary>
        public static string Settings_Accuracy_4
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_Accuracy_4");
            }
        }

        /// <summary>
        ///   查找类似 默认 的本地化字符串。
        /// </summary>
        public static string Settings_Accuracy_default
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_Accuracy_default");
            }
        }

        /// <summary>
        ///   查找类似 自动更新汇率 的本地化字符串。
        /// </summary>
        public static string Settings_AutoUpdateRate
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_AutoUpdateRate");
            }
        }

        /// <summary>
        ///   查找类似 后台代理自动更新Live Tile 的本地化字符串。
        /// </summary>
        public static string Settings_BackgroundAgents
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_BackgroundAgents");
            }
        }

        /// <summary>
        ///   查找类似 图表历史范围 的本地化字符串。
        /// </summary>
        public static string Settings_ChartType
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ChartType");
            }
        }

        /// <summary>
        ///   查找类似 1天 的本地化字符串。
        /// </summary>
        public static string Settings_ChartType_1day
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ChartType_1day");
            }
        }

        /// <summary>
        ///   查找类似 1年 的本地化字符串。
        /// </summary>
        public static string Settings_ChartType_1year
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ChartType_1year");
            }
        }

        /// <summary>
        ///   查找类似 2年 的本地化字符串。
        /// </summary>
        public static string Settings_ChartType_2years
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ChartType_2years");
            }
        }

        /// <summary>
        ///   查找类似 3个月 的本地化字符串。
        /// </summary>
        public static string Settings_ChartType_3months
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ChartType_3months");
            }
        }

        /// <summary>
        ///   查找类似 5天 的本地化字符串。
        /// </summary>
        public static string Settings_ChartType_5days
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ChartType_5days");
            }
        }

        /// <summary>
        ///   查找类似 语言 的本地化字符串。
        /// </summary>
        public static string Settings_Language
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_Language");
            }
        }

        /// <summary>
        ///   查找类似 设置 的本地化字符串。
        /// </summary>
        public static string Settings_PageName
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_PageName");
            }
        }

        /// <summary>
        ///   查找类似 删除所有Live Tile 的本地化字符串。
        /// </summary>
        public static string Settings_RemoveAllTiles
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_RemoveAllTiles");
            }
        }

        /// <summary>
        ///   查找类似 晃动手机 的本地化字符串。
        /// </summary>
        public static string Settings_ShakeDevice
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ShakeDevice");
            }
        }

        /// <summary>
        ///   查找类似 清空列表 的本地化字符串。
        /// </summary>
        public static string Settings_ShakeToClearList
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ShakeToClearList");
            }
        }

        /// <summary>
        ///   查找类似 禁用 的本地化字符串。
        /// </summary>
        public static string Settings_ShakeToDisable
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ShakeToDisable");
            }
        }

        /// <summary>
        ///   查找类似 设置基准货币数值为1 的本地化字符串。
        /// </summary>
        public static string Settings_ShakeToSetBaseCurrency
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ShakeToSetBaseCurrency");
            }
        }

        /// <summary>
        ///   查找类似 更新汇率 的本地化字符串。
        /// </summary>
        public static string Settings_ShakeToUpdate
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ShakeToUpdate");
            }
        }

        /// <summary>
        ///   查找类似 此定期代理用来更新Currency Exchanger的Live Tile。如果您没有设置Live Tile，无需启用。 的本地化字符串。
        /// </summary>
        public static string Settings_TaskDescription
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_TaskDescription");
            }
        }

        /// <summary>
        ///   查找类似 千分位分隔符，如启用则保留四位小数，精确度设置不起作用 的本地化字符串。
        /// </summary>
        public static string Settings_ThousandSeparator
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ThousandSeparator");
            }
        }

        /// <summary>
        ///   查找类似 关 的本地化字符串。
        /// </summary>
        public static string Settings_ToggleSwitchOff
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ToggleSwitchOff");
            }
        }

        /// <summary>
        ///   查找类似 开 的本地化字符串。
        /// </summary>
        public static string Settings_ToggleSwitchOn
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_ToggleSwitchOn");
            }
        }

        /// <summary>
        ///   查找类似 更新所有Live Tile 的本地化字符串。
        /// </summary>
        public static string Settings_UpdateAllTiles
        {
            get
            {
                return CurrentResourceLoader.GetString("Settings_UpdateAllTiles");
            }
        }

        /// <summary>
        ///   查找类似 新加坡元 Singapore Dollar 的本地化字符串。
        /// </summary>
        public static string SGD
        {
            get
            {
                return CurrentResourceLoader.GetString("SGD");
            }
        }

        /// <summary>
        ///   查找类似 今日汇率 的本地化字符串。
        /// </summary>
        public static string Share_Title
        {
            get
            {
                return CurrentResourceLoader.GetString("Share_Title");
            }
        }

        /// <summary>
        ///   查找类似 圣赫勒拿群岛磅 St Helena Pound 的本地化字符串。
        /// </summary>
        public static string SHP
        {
            get
            {
                return CurrentResourceLoader.GetString("SHP");
            }
        }

        /// <summary>
        ///   查找类似 斯洛文尼亚托拉捷夫 Slovenian Tolar 的本地化字符串。
        /// </summary>
        public static string SIT
        {
            get
            {
                return CurrentResourceLoader.GetString("SIT");
            }
        }

        /// <summary>
        ///   查找类似 斯洛伐克克朗 Slovak Koruna 的本地化字符串。
        /// </summary>
        public static string SKK
        {
            get
            {
                return CurrentResourceLoader.GetString("SKK");
            }
        }

        /// <summary>
        ///   查找类似 塞拉利昂利昂 Sierra Leone Leone 的本地化字符串。
        /// </summary>
        public static string SLL
        {
            get
            {
                return CurrentResourceLoader.GetString("SLL");
            }
        }

        /// <summary>
        ///   查找类似 索马里先令 Somali Shilling 的本地化字符串。
        /// </summary>
        public static string SOS
        {
            get
            {
                return CurrentResourceLoader.GetString("SOS");
            }
        }

        /// <summary>
        ///   查找类似 圣多美多布拉 Sao Tome Dobra 的本地化字符串。
        /// </summary>
        public static string STD
        {
            get
            {
                return CurrentResourceLoader.GetString("STD");
            }
        }

        /// <summary>
        ///   查找类似 萨尔瓦多科朗 El Salvador Colon 的本地化字符串。
        /// </summary>
        public static string SVC
        {
            get
            {
                return CurrentResourceLoader.GetString("SVC");
            }
        }

        /// <summary>
        ///   查找类似 叙利亚镑 Syrian Pound 的本地化字符串。
        /// </summary>
        public static string SYP
        {
            get
            {
                return CurrentResourceLoader.GetString("SYP");
            }
        }

        /// <summary>
        ///   查找类似 斯威士兰里兰吉尼 Swaziland Lilageni 的本地化字符串。
        /// </summary>
        public static string SZL
        {
            get
            {
                return CurrentResourceLoader.GetString("SZL");
            }
        }

        /// <summary>
        ///   查找类似 泰国铢 Thai Baht 的本地化字符串。
        /// </summary>
        public static string THB
        {
            get
            {
                return CurrentResourceLoader.GetString("THB");
            }
        }

        /// <summary>
        ///   查找类似 突尼斯第纳尔 Tunisian Dinar 的本地化字符串。
        /// </summary>
        public static string TND
        {
            get
            {
                return CurrentResourceLoader.GetString("TND");
            }
        }

        /// <summary>
        ///   查找类似 您的手机无法连接到网络，请检查网络设置。8-( 的本地化字符串。
        /// </summary>
        //public static string Toast_ErrorNet
        //{
        //    get
        //    {
        //        return CurrentResourceLoader.GetString("Toast_ErrorNet");
        //    }
        //}

        /// <summary>
        ///   查找类似 基准货币无需选择到Live Tile。 的本地化字符串。
        /// </summary>
        public static string Toast_NoBaseCurrency
        {
            get
            {
                return CurrentResourceLoader.GetString("Toast_NoBaseCurrency");
            }
        }

        /// <summary>
        ///   查找类似 所有Live Tile已删除。 的本地化字符串。
        /// </summary>
        public static string Toast_RemoveAllTilesDone
        {
            get
            {
                return CurrentResourceLoader.GetString("Toast_RemoveAllTilesDone");
            }
        }





        /// <summary>
        ///   查找类似 汤加潘加 Tonga Pa&apos;anga 的本地化字符串。
        /// </summary>
        public static string TOP
        {
            get
            {
                return CurrentResourceLoader.GetString("TOP");
            }
        }

        /// <summary>
        ///   查找类似 土耳其新里拉 New Turkish Lira 的本地化字符串。
        /// </summary>
        public static string TRY
        {
            get
            {
                return CurrentResourceLoader.GetString("TRY");
            }
        }

        /// <summary>
        ///   查找类似 特立尼达和多巴哥元 Trinidad&amp;Tobago Dollar 的本地化字符串。
        /// </summary>
        public static string TTD
        {
            get
            {
                return CurrentResourceLoader.GetString("TTD");
            }
        }

        /// <summary>
        ///   查找类似 台币 Taiwan Dollar 的本地化字符串。
        /// </summary>
        public static string TWD
        {
            get
            {
                return CurrentResourceLoader.GetString("TWD");
            }
        }

        /// <summary>
        ///   查找类似 坦桑尼亚先令 Tanzanian Shilling 的本地化字符串。
        /// </summary>
        public static string TZS
        {
            get
            {
                return CurrentResourceLoader.GetString("TZS");
            }
        }

        /// <summary>
        ///   查找类似 乌克兰赫夫米 Ukraine Hryvnia 的本地化字符串。
        /// </summary>
        public static string UAH
        {
            get
            {
                return CurrentResourceLoader.GetString("UAH");
            }
        }

        /// <summary>
        ///   查找类似 乌干达先令 Ugandan Shilling 的本地化字符串。
        /// </summary>
        public static string UGX
        {
            get
            {
                return CurrentResourceLoader.GetString("UGX");
            }
        }

        /// <summary>
        ///   查找类似 美元 US Dollar 的本地化字符串。
        /// </summary>
        public static string USD
        {
            get
            {
                return CurrentResourceLoader.GetString("USD");
            }
        }

        /// <summary>
        ///   查找类似 乌拉圭新比索 Uruguayan New Peso 的本地化字符串。
        /// </summary>
        public static string UYU
        {
            get
            {
                return CurrentResourceLoader.GetString("UYU");
            }
        }

        /// <summary>
        ///   查找类似 委内瑞拉博利瓦 Venezuelan Bolivar 的本地化字符串。
        /// </summary>
        public static string VEF
        {
            get
            {
                return CurrentResourceLoader.GetString("VEF");
            }
        }

        /// <summary>
        ///   查找类似 查看历史图表 的本地化字符串。
        /// </summary>
        public static string ViewChart_PageName
        {
            get
            {
                return CurrentResourceLoader.GetString("ViewChart_PageName");
            }
        }

        /// <summary>
        ///   查找类似 越南盾 Vietnam Dong 的本地化字符串。
        /// </summary>
        public static string VND
        {
            get
            {
                return CurrentResourceLoader.GetString("VND");
            }
        }

        /// <summary>
        ///   查找类似 瓦努阿图瓦图 Vanuatu Vatu 的本地化字符串。
        /// </summary>
        public static string VUV
        {
            get
            {
                return CurrentResourceLoader.GetString("VUV");
            }
        }

        /// <summary>
        ///   查找类似 萨摩亚塔拉 Samoa Tala 的本地化字符串。
        /// </summary>
        public static string WST
        {
            get
            {
                return CurrentResourceLoader.GetString("WST");
            }
        }

        /// <summary>
        ///   查找类似 刚果中非共同体法郎 CFA Franc BEAC 的本地化字符串。
        /// </summary>
        public static string XAF
        {
            get
            {
                return CurrentResourceLoader.GetString("XAF");
            }
        }

        /// <summary>
        ///   查找类似 银价盎司 Silver Ounces 的本地化字符串。
        /// </summary>
        public static string XAG
        {
            get
            {
                return CurrentResourceLoader.GetString("XAG");
            }
        }

        /// <summary>
        ///   查找类似 铝价盎司 Aluminium Ounces 的本地化字符串。
        /// </summary>
        public static string XAL
        {
            get
            {
                return CurrentResourceLoader.GetString("XAL");
            }
        }

        /// <summary>
        ///   查找类似 金价盎司 Gold Ounces 的本地化字符串。
        /// </summary>
        public static string XAU
        {
            get
            {
                return CurrentResourceLoader.GetString("XAU");
            }
        }

        /// <summary>
        ///   查找类似 格林纳达东加勒比元 East Caribbean Dollar 的本地化字符串。
        /// </summary>
        public static string XCD
        {
            get
            {
                return CurrentResourceLoader.GetString("XCD");
            }
        }

        /// <summary>
        ///   查找类似 铜价盎司 Copper Ounces 的本地化字符串。
        /// </summary>
        public static string XCP
        {
            get
            {
                return CurrentResourceLoader.GetString("XCP");
            }
        }

        /// <summary>
        ///   查找类似 多哥非洲共同体法郎 CFA Franc BCEAO 的本地化字符串。
        /// </summary>
        public static string XOF
        {
            get
            {
                return CurrentResourceLoader.GetString("XOF");
            }
        }

        /// <summary>
        ///   查找类似 钯价盎司 Palladium Ounces 的本地化字符串。
        /// </summary>
        public static string XPD
        {
            get
            {
                return CurrentResourceLoader.GetString("XPD");
            }
        }

        /// <summary>
        ///   查找类似 太平洋法郎 Pacific Franc 的本地化字符串。
        /// </summary>
        public static string XPF
        {
            get
            {
                return CurrentResourceLoader.GetString("XPF");
            }
        }

        /// <summary>
        ///   查找类似 铂价盎司 Platinum Ounces 的本地化字符串。
        /// </summary>
        public static string XPT
        {
            get
            {
                return CurrentResourceLoader.GetString("XPT");
            }
        }

        /// <summary>
        ///   查找类似 也门里亚尔 Yemen Riyal 的本地化字符串。
        /// </summary>
        public static string YER
        {
            get
            {
                return CurrentResourceLoader.GetString("YER");
            }
        }

        /// <summary>
        ///   查找类似 南非兰特 South African Rand 的本地化字符串。
        /// </summary>
        public static string ZAR
        {
            get
            {
                return CurrentResourceLoader.GetString("ZAR");
            }
        }

        /// <summary>
        ///   查找类似 赞比亚克瓦查 Zambian Kwacha 的本地化字符串。
        /// </summary>
        public static string ZMK
        {
            get
            {
                return CurrentResourceLoader.GetString("ZMK");
            }
        }

        /// <summary>
        ///   查找类似 津巴布韦元 Zimbabwe Dollar 的本地化字符串。
        /// </summary>
        public static string ZWD
        {
            get
            {
                return CurrentResourceLoader.GetString("ZWD");
            }
        }


        public static string NavBar_Currencies => CurrentResourceLoader.GetString("NavBar_Currencies");

        public static string NavBar_Charts => CurrentResourceLoader.GetString("NavBar_Charts");

        public static string NavBar_EditList => CurrentResourceLoader.GetString("NavBar_EditList");
        public static string NavBar_LiveTile => CurrentResourceLoader.GetString("NavBar_LiveTile");


        public static string NavBar_Settings => CurrentResourceLoader.GetString("NavBar_Settings");

        public static string NavBar_IAP => CurrentResourceLoader.GetString("NavBar_IAP");

        public static string NavBar_About => CurrentResourceLoader.GetString("NavBar_About");

        public static string App_DarkTheme => CurrentResourceLoader.GetString("App_DarkTheme");

        public static string App_LightTheme => CurrentResourceLoader.GetString("App_LightTheme");

        public static string Toast_NetworkError => CurrentResourceLoader.GetString("Toast_NetworkError");

        public static string Changelog_V3 => CurrentResourceLoader.GetString("Changelog_V3");

        public static string Changelog_V3_1 => CurrentResourceLoader.GetString("Changelog_V3_1");
        public static string Changelog_V3_2 => CurrentResourceLoader.GetString("Changelog_V3_2");


        public static string Message_ConfirmChangeLanguage => CurrentResourceLoader.GetString("Message_ConfirmChangeLanguage");

        public static string Toast_Thanks => CurrentResourceLoader.GetString("Toast_Thanks");
        public static string Toast_HavePurchased => CurrentResourceLoader.GetString("Toast_HavePurchased");
        public static string Toast_SelectCurrencies => CurrentResourceLoader.GetString("Toast_SelectCurrencies");
        public static string Toast_LiveTileMaxCount => CurrentResourceLoader.GetString("Toast_LiveTileMaxCount");
        public static string Toast_LiveTileExist => CurrentResourceLoader.GetString("Toast_LiveTileExist");
        public static string Toast_PinLiveTileSuccess => CurrentResourceLoader.GetString("Toast_PinLiveTileSuccess");
        public static string Toast_PinLiveTileFailed => CurrentResourceLoader.GetString("Toast_PinLiveTileFailed");
        public static string Message_ConfirmRemoveLiveTileLimit => CurrentResourceLoader.GetString("Message_ConfirmRemoveLiveTileLimit");



    }
}
