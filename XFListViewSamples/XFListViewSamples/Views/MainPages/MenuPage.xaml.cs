using XFListViewSamples.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFListViewSamples.Views.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem { Id = MenuItemType.TextCellSample, Title = "Simple TextCell" },
                new HomeMenuItem { Id = MenuItemType.SwitchCellSample, Title = "Simple SwitchCell" },
                new HomeMenuItem { Id = MenuItemType.EntryCellSample, Title = "Simple EntryCell" },
                new HomeMenuItem { Id = MenuItemType.ImageCellSample, Title = "Simple ImageCell" },

            };

            ListViewMenu.ItemsSource = menuItems;

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