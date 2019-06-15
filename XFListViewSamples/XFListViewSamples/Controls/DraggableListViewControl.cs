using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace XFListViewSamples.Controls
{
    public class DraggableListViewControl : Xamarin.Forms.ListView
    {
        public DraggableListViewControl()
        {
            base.On<iOS>().SetSeparatorStyle(SeparatorStyle.FullWidth);
            Footer = "";
        }

        public static readonly BindableProperty DraggingColorProperty = BindableProperty.Create(nameof(DraggingColor), typeof(Color), typeof(DraggableViewCellControl), Color.Transparent, BindingMode.TwoWay);
        public Color DraggingColor
        {
            get { return (Color)GetValue(DraggingColorProperty); }
            set { SetValue(DraggingColorProperty, value); }
        }
    }
}
