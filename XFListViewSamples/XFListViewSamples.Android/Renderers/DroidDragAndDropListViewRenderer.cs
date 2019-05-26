using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFListViewSamples.Droid.Renderer;
using XFListViewSamples.Controls;
using XFListViewSamples.Droid;

[assembly: ExportRenderer(typeof(DraggableListViewControl), typeof(DroidDragAndDropListViewRenderer))]
namespace XFListViewSamples.Droid.Renderer
{
    public class DroidDragAndDropListViewRenderer : ListViewRenderer
    {
        Context _context;

        public DroidDragAndDropListViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            Color dragDropItemHighlightColor = Color.Transparent;

            if (e.NewElement != null && e.NewElement is DraggableListViewControl)
            {
                dragDropItemHighlightColor = (e.NewElement as DraggableListViewControl).DraggingColor;
            }

            Control.ItemLongClick += (s, args) =>
            {
                ClipData data = ClipData.NewPlainText("List", args.Position.ToString());
                DragItemShadowBuilder myShadownScreen = new DragItemShadowBuilder(args.View, dragDropItemHighlightColor);
                args.View.StartDrag(data, myShadownScreen, null, 0);
            };
        }
    }
}