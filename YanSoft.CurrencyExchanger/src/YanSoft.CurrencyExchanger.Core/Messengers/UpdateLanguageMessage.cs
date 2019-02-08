using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Plugin.Messenger;

namespace YanSoft.CurrencyExchanger.Core.Messengers
{
    public class UpdateLanguageMessage : MvxMessage
    {
        public string LanguageCode { get; private set; }
        public UpdateLanguageMessage(object sender, string languageCode) : base(sender)
        {
            LanguageCode = languageCode;
        }
    }
}
