using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Controls;

namespace XFListViewSamples.Views.ListViewPages.CustomCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpandableRowPage : ContentPage
    {
        public ExpandableRowPage()
        {
            InitializeComponent();
            this.AddActivityIndicatorControl();
        }
    }
}