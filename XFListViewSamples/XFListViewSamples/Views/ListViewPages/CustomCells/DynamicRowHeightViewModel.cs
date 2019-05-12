using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;
using MvvmHelpers;

namespace XFListViewSamples.Views.ListViewPages.CustomCells
{
    public class DynamicRowHeightViewModel : BaseViewModel
    {
        public List<FruiteModel> items = new List<FruiteModel>();
        public List<FruiteModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public DynamicRowHeightViewModel()
        {
            Task.Run(async () =>
            {
                var fruitesData = new FruitesDataService();
                Items = (await fruitesData.GetItemsAsync(1, 50)).ToList();
            });
        }
    }
}
