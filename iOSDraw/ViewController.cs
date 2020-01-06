using Foundation;
using System;
using UIKit;

namespace iOSDraw
{
    public partial class ViewController : UIViewController, IUIGestureRecognizerDelegate
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DrawView.SliderPosition = SliderToControlItems.Value;
            DrawView.MaxSize = SliderToControlItems.MaxValue;

            var tapGesture = new UITapGestureRecognizer(Tap);
            DrawView.AddGestureRecognizer(tapGesture);

            var panGesture = new UIPanGestureRecognizer(Pan);
            DrawView.AddGestureRecognizer(panGesture);

            SelectDrawFigure.ValueChanged += (sender, e) =>
            {
                DrawView.DrawableFigure = (int)SelectDrawFigure.SelectedSegment;
            };

            SliderToControlItems.ValueChanged += (sender, e) =>
            {
                DrawView.MaxSize = SliderToControlItems.MaxValue;
                DrawView.SliderPosition = SliderToControlItems.Value;
            };
        }

        private void Pan(UIPanGestureRecognizer gesture)
        {
            var view = gesture.View;
            var translation = gesture.LocationInView(view);
            var maxSize = DrawView.Frame.Height;
            var y = translation.Y;

            if (SelectDrawFigure.SelectedSegment != 2)
            {
                DrawView.MaxSize = (float)maxSize;
                DrawView.SliderPosition = (float)maxSize - (float)translation.Y;
            }
            else
            {
                DrawView.MaxSize = 360;
                DrawView.SliderPosition = degree((float)translation.Y, (float)translation.X);
            }
        }

    
        private void Tap(UITapGestureRecognizer gesture)
        {
            var view = gesture.View;
            var translation = gesture.LocationInView(view);

            var maxSize = DrawView.Frame.Height;
            var y = translation.Y;

           
            if(SelectDrawFigure.SelectedSegment != 2)
            {
                DrawView.MaxSize = (float)maxSize;
                DrawView.SliderPosition = (float)maxSize - (float)translation.Y;
            }
            else
            {
                DrawView.MaxSize = 360;
                DrawView.SliderPosition = degree((float)translation.Y, (float)translation.X);
            }
        }

        float degree(float By, float Bx)
        {
            var centerY = DrawView.Frame.Height / 2;
            var centerX = DrawView.Frame.Width / 2;

            var Ax = DrawView.Frame.Width / 2;
            var Ay = 0;

            var xa = centerX - Ax;
            var ya = centerY - Ay;

            var xb = centerX - Bx;
            var yb = centerY - By;

            var result = (xa * xb + ya * yb) / (Math.Sqrt(xa * xa + ya * ya) * Math.Sqrt(xb * xb + yb * yb));
            result = Math.Acos(result);
            result = result * 180 / Math.PI;

            if (Bx < centerX)
                result = 360 - result;
            
            return (float)result;
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}