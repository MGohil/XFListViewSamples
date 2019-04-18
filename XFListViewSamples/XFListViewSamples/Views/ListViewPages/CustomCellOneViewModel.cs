using System.Collections.Generic;
using System.Linq;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;

namespace XFListViewSamples.Views.ListViewPages
{
    public class CustomCellOneViewModel : BaseViewModel
    {
        public List<UserModel> Items { get; set; } = new List<UserModel>();

        public CustomCellOneViewModel()
        {
            var userData = new UserDataService();
            Items = userData.GetItemsAsync(1, 50).Result.ToList();
        }       
    }
}
