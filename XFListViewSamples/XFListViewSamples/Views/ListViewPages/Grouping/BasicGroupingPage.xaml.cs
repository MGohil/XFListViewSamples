using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Controls;

namespace XFListViewSamples.Views.ListViewPages.Grouping
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicGroupingPage : ContentPage
    {
        public BasicGroupingPage()
        {
            InitializeComponent();
            this.AddActivityIndicatorControl();
        }
    }
}