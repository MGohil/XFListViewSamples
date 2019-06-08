using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFListViewSamples.Controls;

namespace XFListViewSamples.Views.ListViewPages.DynamicCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicCellTypesPage : ContentPage
    {
        public DynamicCellTypesPage()
        {
            InitializeComponent();
            this.AddActivityIndicatorControl();
        }

        private DynamicCellTypesViewModel ViewModel
        {
            get { return BindingContext as DynamicCellTypesViewModel; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.ScrollToBottomAction = () => {
                if (ViewModel.Messages.Count > 0)
                {
                    Device.BeginInvokeOnMainThread(() => {
                        chatListView.ScrollTo(ViewModel.Messages[ViewModel.Messages.Count - 1], ScrollToPosition.MakeVisible, true);
                    });
                }
            };
        }
    }
}