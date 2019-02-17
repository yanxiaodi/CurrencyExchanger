using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YanSoft.CurrencyExchanger.Core.Models.Dto;
using YanSoft.CurrencyExchanger.Core.Utils;
using YanSoft.CurrencyExchanger.Core.ViewModels;

namespace YanSoft.CurrencyExchanger.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail)]
    public partial class ChartPage : MvxContentPage<ChartViewModel>
    {
        public ChartPage()
        {
            InitializeComponent();
        }


        private void HistoryChart_TrackballCreated(object sender, Syncfusion.SfChart.XForms.ChartTrackballCreatedEventArgs e)
        {
            if (BindingContext.DataContext is ChartViewModel vm)
            {
                if (e.ChartPointsInfo != null && e.ChartPointsInfo.Any() && e.ChartPointsInfo.First().DataPoint is CurrencyRateHistoryItem selectedItem)
                {
                    vm.SelectedItemClose = $"Close: {CurrencyHelper.FormatCurrencyAmount(selectedItem.Close, vm.TargetCurrency.CultureName)}";
                    vm.SelectedItemDateTime = selectedItem.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    vm.SelectedItemHigh = $"High: {CurrencyHelper.FormatCurrencyAmount(selectedItem.High, vm.TargetCurrency.CultureName)}";
                    vm.SelectedItemLow = $"Low: {CurrencyHelper.FormatCurrencyAmount(selectedItem.Low, vm.TargetCurrency.CultureName)}";
                    vm.SelectedItemOpen = $"Open: {CurrencyHelper.FormatCurrencyAmount(selectedItem.Open, vm.TargetCurrency.CultureName)}";
                }
                else
                {
                    vm.SelectedItemClose = string.Empty;
                    vm.SelectedItemDateTime = string.Empty;
                    vm.SelectedItemHigh = string.Empty;
                    vm.SelectedItemLow = string.Empty;
                    vm.SelectedItemOpen = string.Empty;
                }
            }
        }

        private void HistoryChart_SelectionChanged(object sender, Syncfusion.SfChart.XForms.ChartSelectionEventArgs e)
        {
            if (e.SelectedDataPointIndex != -1)
            {
                if (BindingContext.DataContext is ChartViewModel vm)
                {
                    var selectedItem = vm.CurrencyRateHistoryItemList[e.SelectedDataPointIndex];
                    if (selectedItem != null)
                    {
                        vm.SelectedItemClose = $"Close: {CurrencyHelper.FormatCurrencyAmount(selectedItem.Close, vm.TargetCurrency.CultureName)}";
                        vm.SelectedItemDateTime = selectedItem.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        vm.SelectedItemHigh = $"High: {CurrencyHelper.FormatCurrencyAmount(selectedItem.High, vm.TargetCurrency.CultureName)}";
                        vm.SelectedItemLow = $"Low: {CurrencyHelper.FormatCurrencyAmount(selectedItem.Low, vm.TargetCurrency.CultureName)}";
                        vm.SelectedItemOpen = $"Open: {CurrencyHelper.FormatCurrencyAmount(selectedItem.Open, vm.TargetCurrency.CultureName)}";
                    }
                    else
                    {
                        vm.SelectedItemClose = string.Empty;
                        vm.SelectedItemDateTime = string.Empty;
                        vm.SelectedItemHigh = string.Empty;
                        vm.SelectedItemLow = string.Empty;
                        vm.SelectedItemOpen = string.Empty;
                    }
                }
            }
        }

    }
}
