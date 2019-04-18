using System.Collections.Generic;
using System.Linq;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;

namespace XFListViewSamples.Views.ListViewPages
{
    public class CustomCellTwoViewModel : BaseViewModel
    {
        public List<UserModel> Items { get; set; } = new List<UserModel>();

        public CustomCellTwoViewModel()
        {
            Items.Add(new UserModel()
            {
                FirstName = "Milan",
                LastName = "Gohil",
                Email = "abc@gmail.com",
                Gender = "Male",
                ProfilePic = "https://robohash.org/aliaseosut.png?size=100x100&set=set1",
                Id = 1, 
            });

            var userData = new UserDataService();
            Items = userData.GetItemsAsync(1, 50).Result.ToList();
        }
    }
}
