﻿using System.Collections.Generic;
using System.Linq;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;

namespace XFListViewSamples.Views.ListViewPages
{
    public class CustomCellSampleViewModel : BaseViewModel
    {
        public List<UserModel> Items { get; set; } = new List<UserModel>();

        public CustomCellSampleViewModel()
        {
            var userData = new UserDataService();
            Items = userData.GetItemsAsync(1, 50).Result.ToList();
        }       
    }
}
