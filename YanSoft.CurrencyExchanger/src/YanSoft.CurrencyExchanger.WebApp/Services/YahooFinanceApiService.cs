using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using YanSoft.CurrencyExchanger.WebApp.Models;
using YanSoft.CurrencyExchanger.WebApp.Utils;

namespace YanSoft.CurrencyExchanger.WebApp.Services
{
    public class YahooFinanceApiService : IApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IMemoryCache cache;

        public YahooFinanceApiService(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            clientFactory = httpClientFactory;
            cache = memoryCache;
        }

        public List<Currency> GetCurrencies()
        {
            var result = new List<Currency>();
            var cacheEntry = new List<Currency>();
            if (cache.TryGetValue(CacheHelper.GetCurrenciesOfYahooFinanceCacheKeyName(), out cacheEntry))
            {
                return cacheEntry;
            }
            else
            {
                result = GetCurrencyList();
                cache.Set(CacheHelper.GetCurrenciesOfYahooFinanceCacheKeyName(), result, DateTime.Now.AddYears(1));
                return result;
            }
        }


        /// <summary>
        /// Gets the currency list.
        /// </summary>
        /// <returns></returns>
        private List<Currency> GetCurrencyList()
        {
            var result = new List<Currency>()
                {
                    new Currency { Code = "AED", Name = "United Arab Emirates Dirham"},
                    new Currency { Code = "AFN", Name = "Afghan Afghani"},
                    new Currency { Code = "ALL", Name = "Albanian Lek"},
                    new Currency { Code = "AMD", Name = "Armenian Dram"},
                    new Currency { Code = "ANG", Name = "Netherlands Antillean Guilder"},
                    new Currency { Code = "AOA", Name = "Angolan Kwanza"},
                    new Currency { Code = "ARS", Name = "Argentine Peso"},
                    new Currency { Code = "AUD", Name = "Australian Dollar"},
                    new Currency { Code = "AWG", Name = "Aruban Florin"},
                    new Currency { Code = "AZN", Name = "Azerbaijani Manat"},
                    new Currency { Code = "BAM", Name = "Bosnia and Herzegovina Convertible Mark"},
                    new Currency { Code = "BBD", Name = "Barbados Dollar"},
                    new Currency { Code = "BDT", Name = "Bangladeshi Taka"},
                    new Currency { Code = "BGN", Name = "Bulgarian Lev"},
                    new Currency { Code = "BHD", Name = "Bahraini Dinar"},
                    new Currency { Code = "BIF", Name = "Burundian Franc"},
                    new Currency { Code = "BMD", Name = "Bermudian Dollar"},
                    new Currency { Code = "BND", Name = "Brunei Dollar"},
                    new Currency { Code = "BOB", Name = "Boliviano"},
                    new Currency { Code = "BRL", Name = "Brazilian Real"},
                    new Currency { Code = "BSD", Name = "Bahamian Dollar"},
                    new Currency { Code = "BTN", Name = "Bhutanese Ngultrum"},
                    new Currency { Code = "BWP", Name = "Botswana Pula"},
                    new Currency { Code = "BYN", Name = "New Belarusian Ruble"},
                    new Currency { Code = "BYR", Name = "Belarusian Ruble"},
                    new Currency { Code = "BZD", Name = "Belize Dollar"},
                    new Currency { Code = "CAD", Name = "Canadian Dollar"},
                    new Currency { Code = "CDF", Name = "Congolese Franc"},
                    new Currency { Code = "CHF", Name = "Swiss Franc"},
                    new Currency { Code = "CLP", Name = "Chilean Peso"},
                    new Currency { Code = "CNY", Name = "Chinese Yuan"},
                    new Currency { Code = "COP", Name = "Colombian Peso"},
                    new Currency { Code = "CRC", Name = "Costa Rican Colon"},
                    new Currency { Code = "CUC", Name = "Cuban Convertible Peso"},
                    new Currency { Code = "CUP", Name = "Cuban Peso"},
                    new Currency { Code = "CVE", Name = "Cape Verde Escudo"},
                    new Currency { Code = "CZK", Name = "Czech Koruna"},
                    new Currency { Code = "DJF", Name = "Djiboutian Franc"},
                    new Currency { Code = "DKK", Name = "Danish Krone"},
                    new Currency { Code = "DOP", Name = "Dominican Peso"},
                    new Currency { Code = "DZD", Name = "Algerian Dinar"},
                    new Currency { Code = "EGP", Name = "Egyptian Pound"},
                    new Currency { Code = "ERN", Name = "Eritrean Nakfa"},
                    new Currency { Code = "ETB", Name = "Ethiopian Birr"},
                    new Currency { Code = "EUR", Name = "Euro"},
                    new Currency { Code = "FJD", Name = "Fiji Dollar"},
                    new Currency { Code = "FKP", Name = "Falkland Islands Pound"},
                    new Currency { Code = "GBP", Name = "Pound Sterling"},
                    new Currency { Code = "GEL", Name = "Georgian Lari"},
                    new Currency { Code = "GHS", Name = "Ghanaian Cedi"},
                    new Currency { Code = "GIP", Name = "Gibraltar Pound"},
                    new Currency { Code = "GMD", Name = "Gambian Dalasi"},
                    new Currency { Code = "GNF", Name = "Guinean Franc"},
                    new Currency { Code = "GTQ", Name = "Guatemalan Quetzal"},
                    new Currency { Code = "GYD", Name = "Guyanese Dollar"},
                    new Currency { Code = "HKD", Name = "Hong Kong Dollar"},
                    new Currency { Code = "HNL", Name = "Honduran Lempira"},
                    new Currency { Code = "HRK", Name = "Croatian Kuna"},
                    new Currency { Code = "HTG", Name = "Haitian Gourde"},
                    new Currency { Code = "HUF", Name = "Hungarian Forint"},
                    new Currency { Code = "IDR", Name = "Indonesian rRpiah"},
                    new Currency { Code = "ILS", Name = "Israeli New Shekel"},
                    new Currency { Code = "INR", Name = "Indian Rupee"},
                    new Currency { Code = "IQD", Name = "Iraqi Dinar"},
                    new Currency { Code = "IRR", Name = "Iranian Rial"},
                    new Currency { Code = "ISK", Name = "Icelandic Króna"},
                    new Currency { Code = "JMD", Name = "Jamaican Dollar"},
                    new Currency { Code = "JOD", Name = "Jordanian Dinar"},
                    new Currency { Code = "JPY", Name = "Japanese Yen"},
                    new Currency { Code = "KES", Name = "Kenyan Shilling"},
                    new Currency { Code = "KGS", Name = "Kyrgyzstani Som"},
                    new Currency { Code = "KHR", Name = "Cambodian Riel"},
                    new Currency { Code = "KMF", Name = "Comoro Franc"},
                    new Currency { Code = "KPW", Name = "North Korean Won"},
                    new Currency { Code = "KRW", Name = "South Korean Won"},
                    new Currency { Code = "KWD", Name = "Kuwaiti Dinar"},
                    new Currency { Code = "KYD", Name = "Cayman Islands Dollar"},
                    new Currency { Code = "KZT", Name = "Kazakhstani Tenge"},
                    new Currency { Code = "LAK", Name = "Lao Kip"},
                    new Currency { Code = "LBP", Name = "Lebanese Pound"},
                    new Currency { Code = "LKR", Name = "Sri Lankan Rupee"},
                    new Currency { Code = "LRD", Name = "Liberian Dollar"},
                    new Currency { Code = "LSL", Name = "Lesotho Loti"},
                    new Currency { Code = "LYD", Name = "Libyan Dinar"},
                    new Currency { Code = "MAD", Name = "Moroccan Dirham"},
                    new Currency { Code = "MDL", Name = "Moldovan Leu"},
                    new Currency { Code = "MGA", Name = "Malagasy Ariary"},
                    new Currency { Code = "MKD", Name = "Macedonian Denar"},
                    new Currency { Code = "MMK", Name = "Myanmar Kyat"},
                    new Currency { Code = "MNT", Name = "Mongolian Tögrög"},
                    new Currency { Code = "MOP", Name = "Macanese Pataca"},
                    new Currency { Code = "MRO", Name = "Mauritanian Ouguiya"},
                    new Currency { Code = "MUR", Name = "Mauritian Rupee"},
                    new Currency { Code = "MVR", Name = "Maldivian Rufiyaa"},
                    new Currency { Code = "MWK", Name = "Malawian Kwacha"},
                    new Currency { Code = "MXN", Name = "Mexican Peso"},
                    new Currency { Code = "MYR", Name = "Malaysian Ringgit"},
                    new Currency { Code = "MZN", Name = "Mozambican Metical"},
                    new Currency { Code = "NAD", Name = "Namibian Dollar"},
                    new Currency { Code = "NGN", Name = "Nigerian Naira"},
                    new Currency { Code = "NIO", Name = "Nicaraguan Córdoba"},
                    new Currency { Code = "NOK", Name = "Norwegian Krone"},
                    new Currency { Code = "NPR", Name = "Nepalese Rupee"},
                    new Currency { Code = "NZD", Name = "New Zealand Dollar"},
                    new Currency { Code = "OMR", Name = "Omani Rial"},
                    new Currency { Code = "PAB", Name = "Panamanian Balboa"},
                    new Currency { Code = "PEN", Name = "Peruvian Sol"},
                    new Currency { Code = "PGK", Name = "Papua New Guinean Kina"},
                    new Currency { Code = "PHP", Name = "Philippine Peso"},
                    new Currency { Code = "PKR", Name = "Pakistani Rupee"},
                    new Currency { Code = "PLN", Name = "Polish Złoty"},
                    new Currency { Code = "PYG", Name = "Paraguayan Guaraní"},
                    new Currency { Code = "QAR", Name = "Qatari Riyal"},
                    new Currency { Code = "RON", Name = "Romanian Leu"},
                    new Currency { Code = "RSD", Name = "Serbian Dinar"},
                    new Currency { Code = "RUB", Name = "Russian Ruble"},
                    new Currency { Code = "RWF", Name = "Rwandan Franc"},
                    new Currency { Code = "SAR", Name = "Saudi Riyal"},
                    new Currency { Code = "SBD", Name = "Solomon Islands Dollar"},
                    new Currency { Code = "SCR", Name = "Seychelles Rupee"},
                    new Currency { Code = "SDG", Name = "Sudanese Pound"},
                    new Currency { Code = "SEK", Name = "Swedish Krona/Kronor"},
                    new Currency { Code = "SGD", Name = "Singapore Dollar"},
                    new Currency { Code = "SHP", Name = "Saint Helena Pound"},
                    new Currency { Code = "SLL", Name = "Sierra Leonean Leone"},
                    new Currency { Code = "SOS", Name = "Somali Shilling"},
                    new Currency { Code = "SRD", Name = "Surinamese Dollar"},
                    new Currency { Code = "SSP", Name = "South Sudanese Pound"},
                    new Currency { Code = "STD", Name = "São Tomé and Príncipe Dobra"},
                    new Currency { Code = "SVC", Name = "Salvadoran Colón"},
                    new Currency { Code = "SYP", Name = "Syrian Pound"},
                    new Currency { Code = "SZL", Name = "Swazi Lilangeni"},
                    new Currency { Code = "THB", Name = "Thai Baht"},
                    new Currency { Code = "TJS", Name = "Tajikistani Somoni"},
                    new Currency { Code = "TMT", Name = "Turkmenistani Manat"},
                    new Currency { Code = "TND", Name = "Tunisian Dinar"},
                    new Currency { Code = "TOP", Name = "Tongan pPaʻanga"},
                    new Currency { Code = "TRY", Name = "Turkish Lira"},
                    new Currency { Code = "TTD", Name = "Trinidad and Tobago Dollar"},
                    new Currency { Code = "TWD", Name = "New Taiwan Dollar"},
                    new Currency { Code = "TZS", Name = "Tanzanian Shilling"},
                    new Currency { Code = "UAH", Name = "Ukrainian Hryvnia"},
                    new Currency { Code = "UGX", Name = "Ugandan Shilling"},
                    new Currency { Code = "USD", Name = "United States Dollar"},
                    new Currency { Code = "UYU", Name = "Uruguayan Peso"},
                    new Currency { Code = "UZS", Name = "Uzbekistan Som"},
                    new Currency { Code = "VEF", Name = "Venezuelan Bolívar"},
                    new Currency { Code = "VND", Name = "Vietnamese Dồng"},
                    new Currency { Code = "VUV", Name = "Vanuatu Vatu"},
                    new Currency { Code = "WST", Name = "Samoan Tala"},
                    new Currency { Code = "XAF", Name = "CFA Franc BEAC"},
                    new Currency { Code = "XCD", Name = "East Caribbean Dollar"},
                    new Currency { Code = "XDR", Name = "Special Drawing Rights"},
                    new Currency { Code = "XOF", Name = "CFA Franc BCEAO"},
                    new Currency { Code = "XSU", Name = "SUCRE"},
                    new Currency { Code = "YER", Name = "Yemeni Rial"},
                    new Currency { Code = "ZAR", Name = "South African Rand"},
                    new Currency { Code = "ZMW", Name = "Zambian Kwacha"}
                };
            return result;
        }


        public Task<CurrencyRatesResponse> GetLatestRates(string baseCode, IEnumerable<string> targetCodes)
        {
            return null;
        }

        public async Task<CurrencyRatesHistoryResponse> GetHistoryRates(string baseCode, string targetCode, int timestampStart, int timestampEnd, string interval)
        {
            var result = new CurrencyRatesHistoryResponse
            {
                Base = baseCode,
                Target = targetCode,
                StartTimestamp = timestampStart,
                EndTimestamp = timestampEnd
            };
            HttpClient httpClient = clientFactory.CreateClient(Constants.YahooFinanceHttpClinetName);

            int datetimeStart = DateTimeHelper.ConvertDateTimeToTimestamp(DateTime.UtcNow);
            var url = $"https://query1.finance.yahoo.com/v8/finance/chart/{baseCode}{targetCode}=X?symbol={baseCode}{targetCode}=X&interval={interval}&includePrePost=false&events=div|split|earn&lang=en-US&region=US&crumb=HcsmAxZIEFw&corsDomain=finance.yahoo.com&period1={timestampStart}&period2={timestampEnd}";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseObject = JObject.Parse(await response.Content.ReadAsStringAsync());

                    var responseResult = responseObject["chart"]["result"][0];
                    if(responseResult != null)
                    {
                        var timestamps = responseResult["timestamp"];
                        var quotes = responseResult["indicators"]["quote"][0];
                        var close = quotes["close"];
                        var open = quotes["open"];
                        var low = quotes["low"];
                        var high = quotes["high"];

                        for (int i = 0; i < timestamps.Count(); i++)
                        {
                            var item = new CurrencyRateHistoryItem();
                            if(int.TryParse(timestamps[i].ToString(), out var timestamp))
                            {
                                item.Timestamp = timestamp;
                            }
                            if(decimal.TryParse(open[i].ToString(), out var openValue))
                            {
                                item.Open = openValue;
                            }
                            if (decimal.TryParse(close[i].ToString(), out var closeValue))
                            {
                                item.Close = closeValue;
                            }
                            if (decimal.TryParse(high[i].ToString(), out var highValue))
                            {
                                item.High = highValue;
                            }
                            if (decimal.TryParse(low[i].ToString(), out var lowValue))
                            {
                                item.Low = lowValue;
                            }
                            result.Items.Add(item);

                        }
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch
            {
                return result;
            }
        }
    }
}
