﻿using XFListViewSamples.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Views.ListViewPages.DynamicCells;
using XFListViewSamples.Views.ListViewPages.BuiltInCells;
using XFListViewSamples.Views.ListViewPages.CustomCells;
using XFListViewSamples.Views.ListViewPages.HeaderAndFooter;
using XFListViewSamples.Views.ListViewPages.ListViewOperations;
using XFListViewSamples.Views.ListViewPages.Grouping;

namespace XFListViewSamples.Views.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
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
                    case (int)MenuItemType.AlternateRowColor:
                        MenuPages.Add(id, new NavigationPage(new AlternateRowColorPage() { Title = title }));
                        break;
                    case (int)MenuItemType.DynamicRowHeight:
                        MenuPages.Add(id, new NavigationPage(new DynamicRowHeightPage() { Title = title }));
                        break;
                    case (int)MenuItemType.ExpandableRow:
                        MenuPages.Add(id, new NavigationPage(new ExpandableRowPage() { Title = title }));
                        break;
                    case (int)MenuItemType.DynamicCells:
                        MenuPages.Add(id, new NavigationPage(new DynamicCellTypesPage() { Title = title }));
                        break;
                    case (int)MenuItemType.ListViewHeader:
                        MenuPages.Add(id, new NavigationPage(new ListViewHeaderPage() { Title = title }));
                        break;
                    case (int)MenuItemType.ListViewFooter:
                        MenuPages.Add(id, new NavigationPage(new ListViewFooterPage() { Title = title }));
                        break;
                    case (int)MenuItemType.PullToRefresh:
                        MenuPages.Add(id, new NavigationPage(new PullToRefreshOperationPage { Title = title }));
                        break;
                    case (int)MenuItemType.LoadMoreItems:
                        MenuPages.Add(id, new NavigationPage(new LoadMoreOperationPage { Title = title }));
                        break;
                    case (int)MenuItemType.BasicGrouping:
                        MenuPages.Add(id, new NavigationPage(new BasicGroupingPage { Title = title }));
                        break;
                    case (int)MenuItemType.ExpandableGroupList:
                        MenuPages.Add(id, new NavigationPage(new ExpandableGroupsListPage { Title = title }));
                        break;
                    case (int)MenuItemType.ReOrderListViewItems:
                        MenuPages.Add(id, new NavigationPage(new ReOrderListViewItemsPage { Title = title }));
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