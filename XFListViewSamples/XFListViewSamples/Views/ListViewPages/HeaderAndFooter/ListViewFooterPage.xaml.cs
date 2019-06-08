using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Controls;

namespace XFListViewSamples.Views.ListViewPages.HeaderAndFooter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewFooterPage : ContentPage
    {
        public ListViewFooterPage()
        {
            InitializeComponent();
            this.AddActivityIndicatorControl();
        }
    }
}