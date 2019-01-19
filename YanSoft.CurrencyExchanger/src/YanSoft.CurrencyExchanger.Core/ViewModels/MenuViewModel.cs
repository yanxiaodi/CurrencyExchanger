using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.ViewModels.Home;

namespace YanSoft.CurrencyExchanger.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItemList = new MvxObservableCollection<CommonMenuItem>()
            {
                new CommonMenuItem{Icon = "\uf015", Name = "Home" },
                new CommonMenuItem{Icon = "\uf201", Name = "Charts" },
                new CommonMenuItem{Icon = "\uf013", Name = "Settings" },
                //new CommonMenuItem{Icon = "\uf1e0", Name = "Share" },
                //new CommonMenuItem{Icon = "\uf118", Name = "Like Me!" },
                //new CommonMenuItem{Icon = "\uf0e0", Name = "Feedback" },
                //new CommonMenuItem{Icon = "\uf4c4", Name = "Help" },
                new CommonMenuItem{Icon = "\uf129", Name = "About" },


            };
        }

        #region MenuItemList;
        private ObservableCollection<CommonMenuItem> _menuItemList;
        public ObservableCollection<CommonMenuItem> MenuItemList
        {
            get => _menuItemList;
            set => SetProperty(ref _menuItemList, value);
        }
        #endregion


        #region ShowDetailPageAsyncCommand;
        private IMvxAsyncCommand<CommonMenuItem> _showDetailPageAsyncCommand;
        public IMvxAsyncCommand<CommonMenuItem> ShowDetailPageAsyncCommand
        {
            get
            {
                _showDetailPageAsyncCommand = _showDetailPageAsyncCommand ?? new MvxAsyncCommand<CommonMenuItem>(ShowDetailPageAsync);
                return _showDetailPageAsyncCommand;
            }
        }
        private async Task ShowDetailPageAsync(CommonMenuItem param)
        {
            // Implement your logic here.
            switch (param.Name)
            {
                case "Home":
                    await _navigationService.Navigate<HomeViewModel>();
                    break;
                case "Charts":
                    await _navigationService.Navigate<HomeViewModel>();
                    break;
                case "Settings":
                    await _navigationService.Navigate<SettingsViewModel>();
                    break;
                case "About":
                    await _navigationService.Navigate<AboutViewModel>();
                    break;
                default:
                    break;
            }
            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
            }
            else if (Application.Current.MainPage is NavigationPage navigationPage
                     && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
            {
                nestedMasterDetail.IsPresented = false;
            }
        }
        #endregion

        //#region ShowDetailPageAsyncCommand;
        //private IMvxAsyncCommand _showDetailPageAsyncCommand;
        //public IMvxAsyncCommand ShowDetailPageAsyncCommand
        //{
        //    get
        //    {
        //        _showDetailPageAsyncCommand = _showDetailPageAsyncCommand ?? new MvxAsyncCommand(ShowDetailPageAsync);
        //        return _showDetailPageAsyncCommand;
        //    }
        //}
        //private async Task ShowDetailPageAsync()
        //{
        //    // Implement your logic here.
        //    switch (SelectedMenuItem)
        //    {
        //        case "Home":
        //            await _navigationService.Navigate<HomeViewModel>();
        //            break;
        //        case "Charts":
        //            await _navigationService.Navigate<HomeViewModel>();
        //            break;
        //        case "Settings":
        //            await _navigationService.Navigate<SettingsViewModel>();
        //            break;
        //        default:
        //            break;
        //    }
        //    if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
        //    {
        //        masterDetailPage.IsPresented = false;
        //    }
        //    else if (Application.Current.MainPage is NavigationPage navigationPage
        //             && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
        //    {
        //        nestedMasterDetail.IsPresented = false;
        //    }
        //}
        //#endregion


        //#region SelectedMenuItem;
        //private string _selectedMenuItem;
        //public string SelectedMenuItem
        //{
        //    get => _selectedMenuItem;
        //    set => SetProperty(ref _selectedMenuItem, value);
        //}
        //#endregion

    }

}
