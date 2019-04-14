using System.Collections.Generic;
using XFListViewSamples.Common;

namespace XFListViewSamples.Views.ListViewPages
{
    public class EntryCellSampleViewModel : BaseViewModel
    {
        public List<MyEntryCellModel> Items { get; set; } = new List<MyEntryCellModel>();

        public EntryCellSampleViewModel()
        {
            Items.Add(new MyEntryCellModel { Title = "First Name", Text = "James", PlaceHolderText = "First Name" });
            Items.Add(new MyEntryCellModel { Title = "Last Name", Text = "Bond", PlaceHolderText = "Last Name" });
            Items.Add(new MyEntryCellModel { Title = "Email", Text = "james.bond@abc.com", PlaceHolderText = "Email" });
            Items.Add(new MyEntryCellModel { Title = "Phone", Text = "1112223333", PlaceHolderText = "Phone" });
        }

        public class MyEntryCellModel : ObservableObject
        {
            public string Title { get; set; }
            public string Text { get; set; }
            public string PlaceHolderText { get; set; }
        }
    }
}
