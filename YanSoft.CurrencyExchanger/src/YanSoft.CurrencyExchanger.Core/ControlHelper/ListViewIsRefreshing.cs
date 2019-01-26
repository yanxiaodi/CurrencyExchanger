using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace YanSoft.CurrencyExchanger.Core.ControlHelper
{
    public class ListViewIsRefreshing : BindableObject
    {
        public static readonly BindableProperty IsRefreshingProperty =
   BindableProperty.Create("IsRefreshing", typeof(bool), typeof(bool), true, BindingMode.OneWay, null, OnIsRefreshingChanged, null, null, null);

        public bool IsRefreshing
        {
            get => (bool)GetValue(IsRefreshingProperty);
            set => SetValue(IsRefreshingProperty, value);
        }

        static void OnIsRefreshingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Property changed implementation goes here
            if (bindable is ListView listView)
            {
                if(!(bool)newValue)
                {
                    listView.EndRefresh();
                }
            }
        }
    }
}
