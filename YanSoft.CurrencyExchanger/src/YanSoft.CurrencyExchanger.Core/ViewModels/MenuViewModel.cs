using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using YanSoft.CurrencyExchanger.Core.Messengers;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Resources;
using YanSoft.CurrencyExchanger.Core.Utils;
using YanSoft.CurrencyExchanger.Core.ViewModels.Home;

namespace YanSoft.CurrencyExchanger.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly MvxSubscriptionToken _token;
        public MenuViewModel(IMvxNavigationService navigationService, IMvxMessenger messenger)
        {
            _navigationService = navigationService;
            _token = messenger.Subscribe<UpdateLanguageMessage>(OnUpdateLanguageMessage);
            MenuItemList = new MvxObservableCollection<CommonMenuItem>()
            {
                new CommonMenuItem{Icon = "\uf015", Code = "Home", Name = AppResources.Menu_Home },
                new CommonMenuItem{Icon = "\uf201", Code = "Chart", Name = AppResources.Menu_Chart },
                //new CommonMenuItem{Icon = "\uf03a", Name = "Edit"},
                new CommonMenuItem{Icon = "\uf013", Code = "Settings", Name = AppResources.Menu_Settings },
                //new CommonMenuItem{Icon = "\uf1e0", Name = "Share" },
                //new CommonMenuItem{Icon = "\uf118", Name = "Like Me!" },
                //new CommonMenuItem{Icon = "\uf0e0", Name = "Feedback" },
                //new CommonMenuItem{Icon = "\uf4c4", Name = "Help" },
                new CommonMenuItem{Icon = "\uf129", Code = "About", Name = AppResources.Menu_About },
            };
        }

        private void OnUpdateLanguageMessage(UpdateLanguageMessage obj)
        {
            foreach (var item in MenuItemList)
            {
                switch (item.Code)
                {
                    case "Home":
                        item.Name = AppResources.Menu_Home;
                        break;
                    case "Chart":
                        item.Name = AppResources.Menu_Chart;
                        break;
                    case "Settings":
                        item.Name = AppResources.Menu_Settings;
                        break;
                    case "About":
                        item.Name = AppResources.Menu_About;
                        break;
                    default:
                        break;
                }
            }
        }


        #region Properties

        #region MenuItemList;
        private ObservableCollection<CommonMenuItem> _menuItemList;
        public ObservableCollection<CommonMenuItem> MenuItemList
        {
            get => _menuItemList;
            set => SetProperty(ref _menuItemList, value);
        }
        #endregion
        #endregion

        #region Commands


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
            switch (param.Code)
            {
                case "Home":
                    await _navigationService.Navigate<HomeViewModel>();
                    break;
                case "Chart":
                    await _navigationService.Navigate<ChartViewModel, CurrencyExchangeBindableItem>(new CurrencyExchangeBindableItem());
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

        #endregion


        #region Lifecycle

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
