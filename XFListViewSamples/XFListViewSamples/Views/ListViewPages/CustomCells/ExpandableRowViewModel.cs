using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFListViewSamples.Common;
using XFListViewSamples.Services;
using MvvmHelpers;

namespace XFListViewSamples.Views.ListViewPages.CustomCells
{
    public class ExpandableRowViewModel : BaseViewModel
    {
        public Command<ViewCell> ShowDescriptionCommand { get; }

        public List<Fruite> items = new List<Fruite>();
        public List<Fruite> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public ExpandableRowViewModel()
        {
            ShowDescriptionCommand = new Command<ViewCell>((viewCell) => { ShowDescriptionCommandExecute(viewCell); });
             
            Task.Run(async () =>
            {
                IsBusy = true;
                var fruitesData = new FruitesDataService();
                var fruites = (await fruitesData.GetItemsAsync(1, 50)).ToList();

                var items = new List<Fruite>();
                if (fruites != null)
                {
                    foreach (var f in fruites)
                    {
                        items.Add(new Fruite()
                        {
                            Name = f.Name,
                            Price = f.Price,
                            About = f.About,
                            ImageURL = f.ImageURL,
                        });
                    }

                    Items = items;
                }
                IsBusy = false;
            });
        }

        private void ShowDescriptionCommandExecute(ViewCell viewCell)
        {
            //fruiteModel.IsDescriptionVisible = !fruiteModel.IsDescriptionVisible;

            ViewCell cell = (viewCell as ViewCell);
            Fruite vm = cell.BindingContext as Fruite;
            vm.IsDescriptionVisible = !vm.IsDescriptionVisible;
            cell.ForceUpdateSize();
        }

        public class Fruite : ObservableObject
        {
            public string Name { get; set; }

            public string ImageURL { get; set; }

            public double Price { get; set; }

            public string About { get; set; }

            bool isDescriptionVisible = false;
            public bool IsDescriptionVisible
            {
                get { return isDescriptionVisible; }
                set { SetProperty(ref isDescriptionVisible, value); }
            }
        }
    }
}
