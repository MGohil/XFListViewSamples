using XFListViewSamples.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;
using XFListViewSamples.Views.ListViewPages.Grouping;
using System.Linq;

namespace XFListViewSamples.Views.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => (Xamarin.Forms.Application.Current.MainPage as NavigationPage).CurrentPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem { Id = MenuItemType.TextCellSample, Category = MenuCategory.BuiltInCells, Title = "Text Cell" },
                new HomeMenuItem { Id = MenuItemType.SwitchCellSample, Category = MenuCategory.BuiltInCells, Title = "Switch Cell" },
                new HomeMenuItem { Id = MenuItemType.EntryCellSample, Category = MenuCategory.BuiltInCells, Title = "Entry Cell" },
                new HomeMenuItem { Id = MenuItemType.ImageCellSample, Category = MenuCategory.BuiltInCells, Title = "Image Cell" },

                new HomeMenuItem { Id = MenuItemType.CustomCellOne, Category = MenuCategory.CustomCells, Title = "Custom Cell 1" },
                new HomeMenuItem { Id = MenuItemType.CustomCellTwo, Category = MenuCategory.CustomCells, Title = "Custom Cell 2" },
                new HomeMenuItem { Id = MenuItemType.AlternateRowColor, Category = MenuCategory.CustomCells, Title = "Alternate Row Color" },
                new HomeMenuItem { Id = MenuItemType.DynamicRowHeight, Category = MenuCategory.CustomCells, Title = "Dynamic Cell Height" },
                new HomeMenuItem { Id = MenuItemType.ExpandableRow, Category = MenuCategory.CustomCells, Title = "Expandable Cell" },
                new HomeMenuItem { Id = MenuItemType.DynamicCells, Category = MenuCategory.DynamicCells, Title = "Dynamic Cell Templates" },

                new HomeMenuItem { Id = MenuItemType.ListViewHeader, Category = MenuCategory.HeaderFooter, Title = "ListView Header" },
                new HomeMenuItem { Id = MenuItemType.ListViewFooter, Category = MenuCategory.HeaderFooter, Title = "ListView Footer" },

                new HomeMenuItem { Id = MenuItemType.PullToRefresh, Category = MenuCategory.Operations, Title = "Pull To Refresh" },
                new HomeMenuItem { Id = MenuItemType.LoadMoreItems, Category = MenuCategory.Operations, Title = "Load More Items" },
                new HomeMenuItem { Id = MenuItemType.ReOrderListViewItems, Category = MenuCategory.Operations, Title = "Re-Order Items" },

                new HomeMenuItem { Id = MenuItemType.BasicGrouping, Category = MenuCategory.Grouping, Title = "Basic Grouping" },
                new HomeMenuItem { Id = MenuItemType.ExpandableGroupList, Category = MenuCategory.Grouping, Title = "Expandable Groups" },
            };

            ListViewMenu.ItemsSource = menuItems.GroupBy(x => x.Category).Select(x => new ObservableGroupCollection<string, HomeMenuItem>(x)).ToList();

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id, ((HomeMenuItem)e.SelectedItem).Title);
            };
        }
    }
}