using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;

namespace XFListViewSamples.Views.ListViewPages.CustomCells
{
    public class CustomCellTwoViewModel : BaseViewModel
    {
        public List<UserModel> items = new List<UserModel>();
        public List<UserModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public CustomCellTwoViewModel()
        {
            Task.Run(async () =>
            {
                var userData = new UserDataService();
                Items = (await userData.GetItemsAsync()).ToList();
            });
        }
    }
}
