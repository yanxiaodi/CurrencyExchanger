using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace XD.UWP.CurrencyExchanger.UWPAPP.Models
{
    public class CurrencyItem : BindableBase
    {

        string _Code = default(string);


        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get { return _Code; } set { Set(ref _Code, value); } }



        string _Description = default(string);

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get { return _Description; } set { Set(ref _Description, value); } }



        string _Image = default(string);
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get { return _Image; } set { Set(ref _Image, value); } }




        string _CultureName = default(string);
        /// <summary>
        /// Gets or sets the name of the culture.
        /// </summary>
        /// <value>
        /// The name of the culture.
        /// </value>
        public string CultureName { get { return _CultureName; } set { Set(ref _CultureName, value); } }
    }
}
