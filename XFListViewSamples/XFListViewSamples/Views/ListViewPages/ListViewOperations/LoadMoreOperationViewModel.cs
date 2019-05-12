using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;
using MvvmHelpers;

namespace XFListViewSamples.Views.ListViewPages.ListViewOperations
{
    public class LoadMoreOperationViewModel : BaseViewModel
    {
        private int _currentPage = 0;
        private readonly int _itemsPerPage = 20;
        readonly UserDataService userDataService = new UserDataService();

        public Command RefreshUsersCommand { get; }
        public Command LoadMoreUsersCommand { get; }

        public LoadMoreOperationViewModel()
        {
            RefreshUsersCommand = new Command(() => { RefreshUsersCommandExecute(); });
            LoadMoreUsersCommand = new Command(() => { LoadMoreUsersCommandExecute(); });

            LoadItems();
        }

        public ObservableCollection<UserModel> items = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        bool isLoadMoreVisible = false;
        public bool IsLoadMoreVisible
        {
            get { return isLoadMoreVisible; }
            set { SetProperty(ref isLoadMoreVisible, value); }
        }

        bool isLoadMoreBusy = false;
        public bool IsLoadMoreBusy
        {
            get { return isLoadMoreBusy; }
            set { SetProperty(ref isLoadMoreBusy, value); }
        }

        /// <summary>
        /// Executes when Load More is clicked
        /// </summary>
        private void LoadMoreUsersCommandExecute()
        {
            _currentPage += 1;
            IsLoadMoreBusy = true;
            LoadItems();
        }

        /// <summary>
        /// Executes when PullToRefresh is invoked
        /// </summary>
        private void RefreshUsersCommandExecute()
        {
            _currentPage = 1;
            LoadItems();
        }

        private async Task LoadItems()
        {
            //Pull to refresh only if current Page is = 1 
            if (_currentPage == 0)
            {
                IsBusy = true;
            }

            var result = (await userDataService.GetItemsAsync(_currentPage, _itemsPerPage));
            if (result != null)
            {
                _currentPage = result.CurrentPage;

                if (result.Items.Any())
                {
                    if (_currentPage == 0)
                    {
                        Items = new ObservableCollection<UserModel>(result.Items);
                    }
                    else
                    {
                        foreach (var user in result.Items)
                        {
                            Items.Add(user);
                        }
                    }
                }

                IsLoadMoreVisible = _currentPage < result.TotalPages;
            }
            IsLoadMoreBusy = false;
            IsBusy = false;
        }
    }
}
