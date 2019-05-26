using Xamarin.Forms;

namespace XFListViewSamples.Controls
{
    public class DraggableListViewControl : ListView
    {
        public static readonly BindableProperty DraggingColorProperty = BindableProperty.Create(nameof(DraggingColor), typeof(Color), typeof(DraggableViewCellControl), Color.Transparent, BindingMode.TwoWay);
        public Color DraggingColor
        {
            get { return (Color)GetValue(DraggingColorProperty); }
            set { SetValue(DraggingColorProperty, value); }
        }
    }
}
