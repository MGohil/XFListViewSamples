using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Controls;

namespace XFListViewSamples.Views.ListViewPages.HeaderAndFooter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewHeaderPage : ContentPage
    {
        public ListViewHeaderPage()
        {
            InitializeComponent();
            this.AddActivityIndicatorControl();
        }
    }
}