using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;
using MvvmHelpers;

namespace XFListViewSamples.Views.ListViewPages.Grouping
{
    public class BasicGroupingViewModel : BaseViewModel
    {
        public List<ObservableGroupCollection<string, LifeOnPlanetModel>> groupedItems = new List<ObservableGroupCollection<string, LifeOnPlanetModel>>();
        public List<ObservableGroupCollection<string, LifeOnPlanetModel>> GroupedItems
        {
            get { return groupedItems; }
            set { SetProperty(ref groupedItems, value); }
        }

        public BasicGroupingViewModel()
        {
            Task.Run(async() =>
            {
                IsBusy = true;
                var livingItemsDataServicce = new LifeDataService();
                var livingItems = (await livingItemsDataServicce.GetItemsAsync()).ToList();

                GroupedItems = livingItems.GroupBy(x => x.Category).Select(x => new ObservableGroupCollection<string, LifeOnPlanetModel>(x)).ToList();
                IsBusy = false;
               
            });
        }       
    }

    public class ObservableGroupCollection<GroupKey, GroupItems> : ObservableCollection<GroupItems>
    {
        public ObservableGroupCollection(IGrouping<GroupKey, GroupItems> group) : base(group)
        {
            Key = group.Key;
        }
        public GroupKey Key { get; }
    }
}
