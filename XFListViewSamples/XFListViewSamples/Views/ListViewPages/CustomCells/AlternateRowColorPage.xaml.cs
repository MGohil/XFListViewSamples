using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Controls;

namespace XFListViewSamples.Views.ListViewPages.CustomCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlternateRowColorPage : ContentPage
    {
        public AlternateRowColorPage()
        {
            InitializeComponent();
            this.AddActivityIndicatorControl();
        }
    }
}