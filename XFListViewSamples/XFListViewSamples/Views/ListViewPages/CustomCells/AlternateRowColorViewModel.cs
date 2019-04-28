using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;

namespace XFListViewSamples.Views.ListViewPages.CustomCells
{
    public class AlternateRowColorViewModel : BaseViewModel
    {
        public List<UserModel> items = new List<UserModel>();
        public List<UserModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public AlternateRowColorViewModel()
        {
            Task.Run(async () =>
            {
                var userData = new UserDataService();
                Items = (await userData.GetItemsAsync()).ToList();
            });
            
        }       
    }

    /// <summary>
    /// This class is the extended custom Listview class, created to handle the Odd / Even row color
    /// </summary>
    public class AlternateRowListView : ListView
    {
        protected override void SetupContent(Cell cell, int index)
        {
            base.SetupContent(cell, index);
            var currentViewCell = cell as ViewCell;

            if (currentViewCell != null)
            {
                currentViewCell.View.BackgroundColor = index % 2 == 0 ? Color.Transparent : Color.WhiteSmoke;
            }
        }

        public AlternateRowListView(ListViewCachingStrategy strategy) : base(strategy)
        {

        }

        public AlternateRowListView()
        {

        }
    }

}
