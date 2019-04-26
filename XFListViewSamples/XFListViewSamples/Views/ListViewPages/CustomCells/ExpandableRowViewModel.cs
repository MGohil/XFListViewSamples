using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFListViewSamples.Common;
using XFListViewSamples.Services;

namespace XFListViewSamples.Views.ListViewPages.CustomCells
{
    public class ExpandableRowViewModel : BaseViewModel
    {
        public Command<Fruite> ShowDescriptionCommand { get; }

        public List<Fruite> items = new List<Fruite>();
        public List<Fruite> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public ExpandableRowViewModel()
        {
            ShowDescriptionCommand = new Command<Fruite>((fruite) => { ShowDescriptionCommandExecute(fruite); });
             
            Task.Run(async () =>
            {
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
            });
        }

        private void ShowDescriptionCommandExecute(Fruite fruiteModel)
        {
            fruiteModel.IsDescriptionVisible = !fruiteModel.IsDescriptionVisible;
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
