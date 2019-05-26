using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Xamarin.Forms.Platform.Android;

namespace XFListViewSamples.Droid
{
    public class DragItemShadowBuilder : View.DragShadowBuilder
    {
        private Drawable shadow;

        public DragItemShadowBuilder(View v, Xamarin.Forms.Color highlightColor) : base(v)
        {
            v.DrawingCacheEnabled = true;
            Bitmap bm = v.DrawingCache;
            shadow = new BitmapDrawable(bm);


            shadow.SetColorFilter(highlightColor.ToAndroid(), PorterDuff.Mode.Multiply);
        }

        public override void OnProvideShadowMetrics(Point size, Point touch)
        {
            int width = View.Width;
            int height = View.Height;
            shadow.SetBounds(0, 0, width, height);
            size.Set(width, height);
            touch.Set(width / 2, height / 2);
        }

        public override void OnDrawShadow(Canvas canvas)
        {
            base.OnDrawShadow(canvas);
            shadow.Draw(canvas);
        }
    }
}