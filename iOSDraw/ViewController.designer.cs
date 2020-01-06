// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOSDraw
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        iOSDraw.DrawingFigures DrawView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel messageshow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl SelectDrawFigure { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider SliderToControlItems { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DrawView != null) {
                DrawView.Dispose ();
                DrawView = null;
            }

            if (messageshow != null) {
                messageshow.Dispose ();
                messageshow = null;
            }

            if (SelectDrawFigure != null) {
                SelectDrawFigure.Dispose ();
                SelectDrawFigure = null;
            }

            if (SliderToControlItems != null) {
                SliderToControlItems.Dispose ();
                SliderToControlItems = null;
            }
        }
    }
}