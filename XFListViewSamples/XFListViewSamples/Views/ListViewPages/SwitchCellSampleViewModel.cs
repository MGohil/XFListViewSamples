using System.Collections.Generic;
using XFListViewSamples.Common;

namespace XFListViewSamples.Views.ListViewPages
{
    public class SwitchCellSampleViewModel : BaseViewModel
    {
        public List<MyApp> Items { get; set; } = new List<MyApp>();

        public SwitchCellSampleViewModel()
        {
            Items.Add(new MyApp { AppName = "Instagram", IsEnabled = false });
            Items.Add(new MyApp { AppName = "Facebook", IsEnabled = true });
            Items.Add(new MyApp { AppName = "Snapchat", IsEnabled = false });
            Items.Add(new MyApp { AppName = "WhatsApp", IsEnabled = true });
            Items.Add(new MyApp { AppName = "Linkedin", IsEnabled = false });
            Items.Add(new MyApp { AppName = "Twitter", IsEnabled = true });
            Items.Add(new MyApp { AppName = "Gmail", IsEnabled = false });
            Items.Add(new MyApp { AppName = "Yahoo", IsEnabled = true });
            Items.Add(new MyApp { AppName = "HotMail", IsEnabled = false });
        }

        public class MyApp : ObservableObject
        {
            public string AppName { get; set; }

            bool isEnabled = false;
            public bool IsEnabled
            {
                get { return isEnabled; }
                set { SetProperty(ref isEnabled, value); }
            }
        }
    }
}
