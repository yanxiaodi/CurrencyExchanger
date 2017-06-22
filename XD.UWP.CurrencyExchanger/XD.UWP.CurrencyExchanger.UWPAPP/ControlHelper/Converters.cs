using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace XD.UWP.CurrencyExchanger.UWPAPP.ControlHelper
{
    public class FlagConverter : IValueConverter
    {


        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                //return new BitmapImage(new Uri("/Assets/Flag/" + value.ToString() + ".png", UriKind.Relative));
                return "/Assets/Flag/" + value.ToString() + ".png";
            }
            else
            {
                //return new BitmapImage(new Uri("/Assets/Images/Flag/flag_white.png", UriKind.Relative));
                return "/Assets/Flag/flag_white.png";
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
