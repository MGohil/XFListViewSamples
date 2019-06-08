using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XFListViewSamples.Models;
using XFListViewSamples.Services;
using MvvmHelpers;

namespace XFListViewSamples.Views.ListViewPages.ListViewOperations
{
    public class ReOrderListViewItemsViewModel : BaseViewModel
    {
        readonly UserDataService userDataService = new UserDataService();

        public ReOrderListViewItemsViewModel()
        {
            LoadItems();
        }

        public ObservableCollection<UserModel> items = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        private async Task LoadItems()
        {
            IsBusy = true;
            var result = (await userDataService.GetItemsAsync(0, 20));
            if (result != null)
            {
                Items = new ObservableCollection<UserModel>(result.Items);
            }
            IsBusy = false;
        }
    }
}
