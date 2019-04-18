using XFListViewSamples.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Views.ListViewPages;

namespace XFListViewSamples.Views.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.TextCellSample, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id, string title)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.TextCellSample:
                        MenuPages.Add(id, new NavigationPage(new TextCellSamplePage() { Title = title }));
                        break;
                    case (int)MenuItemType.SwitchCellSample:
                        MenuPages.Add(id, new NavigationPage(new SwitchCellSamplePage() { Title = title }));
                        break;
                    case (int)MenuItemType.EntryCellSample:
                        MenuPages.Add(id, new NavigationPage(new EntryCellSamplePage() { Title = title }));
                        break;
                    case (int)MenuItemType.ImageCellSample:
                        MenuPages.Add(id, new NavigationPage(new ImageCellSamplePage() { Title = title }));
                        break;
                    case (int)MenuItemType.CustomCellOne:
                        MenuPages.Add(id, new NavigationPage(new CustomCellOnePage() { Title = title }));
                        break;
                    case (int)MenuItemType.CustomCellTwo:
                        MenuPages.Add(id, new NavigationPage(new CustomCellTwoPage() { Title = title }));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}