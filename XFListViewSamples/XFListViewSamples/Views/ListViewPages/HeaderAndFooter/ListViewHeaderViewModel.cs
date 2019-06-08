using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;
using MvvmHelpers;

namespace XFListViewSamples.Views.ListViewPages.HeaderAndFooter
{
    public class ListViewHeaderViewModel : BaseViewModel
    {
        public List<WeatherModel> weathers = new List<WeatherModel>();
        public List<WeatherModel> Weathers
        {
            get { return weathers; }
            set { SetProperty(ref weathers, value); }
        }

        public WeatherModel selectedWeather;
        public WeatherModel SelectedWeather
        {
            get { return selectedWeather; }
            set { SetProperty(ref selectedWeather, value); }
        }

        public ListViewHeaderViewModel()
        {
            Task.Run(async () =>
            {
                IsBusy = true;
                var weatherData = new WeatherDataService();
                Weathers = (await weatherData.GetItemsAsync(1, 50)).ToList();
                SelectedWeather = Weathers.FirstOrDefault();
                IsBusy = false;
            });
        }
    }
}
