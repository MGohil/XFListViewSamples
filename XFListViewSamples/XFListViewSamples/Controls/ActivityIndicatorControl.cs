using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFListViewSamples.Controls
{
    public static class ActivityIndicatorControl
    {
        public static void AddActivityIndicatorControl(this ContentPage page)
        {
            var activity = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            activity.SetBinding(VisualElement.IsVisibleProperty, "IsBusy");
            activity.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

            var grid = new Grid();
            grid.Children.Add(page.Content);
            grid.Children.Add(activity);
            page.Content = grid;
        }
    }
}
