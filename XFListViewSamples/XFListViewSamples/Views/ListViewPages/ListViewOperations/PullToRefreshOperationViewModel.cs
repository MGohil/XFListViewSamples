using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;
using MvvmHelpers;

namespace XFListViewSamples.Views.ListViewPages.ListViewOperations
{
    public class PullToRefreshOperationViewModel : BaseViewModel
    {
        UserDataService userDataService = new UserDataService();
        public Command RefreshUsersCommand { get; }


        public List<UserModel> items = new List<UserModel>();
        public List<UserModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public PullToRefreshOperationViewModel()
        {
            RefreshUsersCommand = new Command(() => { RefreshUsersCommandExecute(); });

            LoadItems();
        }

        private void RefreshUsersCommandExecute()
        {
            LoadItems();
        }

        private async Task LoadItems()
        {
            IsBusy = true;

            //Added some dummy waiting time
            await Task.Delay(3000);

            Items = (await userDataService.GetItemsAsync()).ToList();

            IsBusy = false;
        }
    }
}
