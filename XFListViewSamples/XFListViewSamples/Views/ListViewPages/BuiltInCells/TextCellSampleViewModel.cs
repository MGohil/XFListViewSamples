using System.Collections.Generic;
using MvvmHelpers;
using System.Threading.Tasks;
using XFListViewSamples.Services;
using System.Linq;
using XFListViewSamples.Models;

namespace XFListViewSamples.Views.ListViewPages.BuiltInCells
{
    public class TextCellSampleViewModel : BaseViewModel
    {
        public List<UserModel> items = new List<UserModel>();
        public List<UserModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public TextCellSampleViewModel()
        {
            Task.Run(async () =>
            {
                IsBusy = true;
                var userData = new UserDataService();
                Items = (await userData.GetItemsAsync(0, 50)).Items;
                IsBusy = false;
            });
        }
    }
}
