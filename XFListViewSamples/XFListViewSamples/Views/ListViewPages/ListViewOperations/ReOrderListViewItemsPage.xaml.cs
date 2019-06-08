using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Controls;

namespace XFListViewSamples.Views.ListViewPages.ListViewOperations
{
    //Ref : http://smartmobidevice.blogspot.com/2015/02/xamarinforms-listview-drag-and-drop-to.html
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReOrderListViewItemsPage : ContentPage
    {
        public ReOrderListViewItemsPage()
        {
            InitializeComponent();
            this.AddActivityIndicatorControl();
        }
    }
}