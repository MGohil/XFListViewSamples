﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;
using MvvmHelpers;

namespace XFListViewSamples.Views.ListViewPages.CustomCells
{
    public class CustomCellOneViewModel : BaseViewModel
    {
        public List<UserModel> items = new List<UserModel>();
        public List<UserModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public CustomCellOneViewModel()
        {
            Task.Run(async() =>
            {
                IsBusy = true;
                var userData = new UserDataService();
                Items = (await userData.GetItemsAsync()).ToList();
                IsBusy = false;
            });
        }       
    }
}
