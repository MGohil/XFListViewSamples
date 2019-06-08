using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Controls;

namespace XFListViewSamples.Views.ListViewPages.CustomCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomCellOnePage : ContentPage
    {
        public CustomCellOnePage()
        {
            InitializeComponent();
            this.AddActivityIndicatorControl();
        }
    }
}