using System.Collections.Generic;
using Xamarin.Forms;
using XFListViewSamples.Common;
using MvvmHelpers;

namespace XFListViewSamples.Views.ListViewPages.BuiltInCells
{
    public class ImageCellSampleViewModel : BaseViewModel
    {
        public List<MyImageCellModel> Items { get; set; } = new List<MyImageCellModel>();

        public ImageCellSampleViewModel()
        {
            Items.Add(new MyImageCellModel { Title = "Airoplane", Description = "This is an airoplane", MyImageURL = ImageSource.FromUri (new System.Uri ("https://homepages.cae.wisc.edu/~ece533/images/airplane.png")) });
            Items.Add(new MyImageCellModel { Title = "Baboon", Description = "This is a baboon", MyImageURL = ImageSource.FromUri(new System.Uri("https://homepages.cae.wisc.edu/~ece533/images/baboon.png")) });
            Items.Add(new MyImageCellModel { Title = "Boat", Description = "This is a boat", MyImageURL = ImageSource.FromUri(new System.Uri("https://homepages.cae.wisc.edu/~ece533/images/boat.png")) });
            Items.Add(new MyImageCellModel { Title = "Cat", Description = "This is a cat", MyImageURL = ImageSource.FromUri(new System.Uri("https://homepages.cae.wisc.edu/~ece533/images/cat.png")) });
            Items.Add(new MyImageCellModel { Title = "Fruits", Description = "These are fruites", MyImageURL = ImageSource.FromUri(new System.Uri("https://homepages.cae.wisc.edu/~ece533/images/fruits.png")) });
            Items.Add(new MyImageCellModel { Title = "Pool", Description = "This is a Pool", MyImageURL = ImageSource.FromUri(new System.Uri("https://homepages.cae.wisc.edu/~ece533/images/pool.png")) });
            Items.Add(new MyImageCellModel { Title = "Tulips", Description = "These are tulips", MyImageURL = ImageSource.FromUri(new System.Uri("https://homepages.cae.wisc.edu/~ece533/images/tulips.png")) });
            Items.Add(new MyImageCellModel { Title = "Mountain", Description = "This is a mountain", MyImageURL = ImageSource.FromUri(new System.Uri("https://homepages.cae.wisc.edu/~ece533/images/mountain.png")) });
        }

        public class MyImageCellModel : ObservableObject
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public ImageSource MyImageURL { get; set; }
        }
    }
}
