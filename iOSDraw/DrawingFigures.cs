using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace iOSDraw
{
    public partial class DrawingFigures : UIView
    {
        public float MaxSize;
        enum Figures : int
        {
            rectangle,
            manyRectangle,
            circle
        }

        private float _sliderPosition;
        public float SliderPosition { 
            set
            {
                _sliderPosition = value;
                SetNeedsDisplay();
            }
            get
            {
                return _sliderPosition;
            }
        }

        private int _drawableFigure;
        public int DrawableFigure
        {
            set
            {
                _drawableFigure = value;
                SetNeedsDisplay();
            }
            get
            {
                return _drawableFigure;
            }
        }

        public float W = 150;
        public float H = 300;
        public DrawingFigures (IntPtr handle) : base (handle)
        {
        }

        public override void Draw(CGRect rect)
        {
            W = (float)Bounds.Width / 2;
            H = (float)Bounds.Height * 0.70f;
            var context = UIGraphics.GetCurrentContext();

            var attributes = new UIStringAttributes
            {
                Font = UIFont.SystemFontOfSize(40),
                ForegroundColor = UIColor.White
            };
           
            var text = new NSAttributedString((SliderPosition/MaxSize).ToString("p1"), attributes);
            var size = text.Size;

            var bezierPath = new UIBezierPath();


            switch (DrawableFigure)
            {
                case (int)Figures.rectangle: //rectangle
                    {
                        text.DrawString(new CGPoint(Bounds.GetMidX() - size.Width / 2, Bounds.GetMidY() + H / 2 - (H / MaxSize * SliderPosition) - size.Height));
                        UIColor.Red.SetFill();
                        UIColor.Blue.SetStroke();
                        bezierPath.MoveTo(new CGPoint(Bounds.GetMidX() + W/2, Bounds.GetMidY() + H / 2));
                        bezierPath.AddLineTo(new CGPoint(Bounds.GetMidX() - W / 2, Bounds.GetMidY() + H / 2));
                        bezierPath.AddLineTo(new CGPoint(Bounds.GetMidX() - W / 2, Bounds.GetMidY() + H / 2 - (H / MaxSize * SliderPosition)));
                        bezierPath.AddLineTo(new CGPoint(Bounds.GetMidX() + W / 2, Bounds.GetMidY() + H / 2 - (H / MaxSize * SliderPosition)));
                        bezierPath.ClosePath();
                        bezierPath.Fill();
                        break;
                    }
                case (int)Figures.manyRectangle:  //many rectangles
                    {
                        var sizeOneRectangle = H / 5;
                        var sizeBorderRectangle = H / MaxSize * SliderPosition;
                        var countRectangle = sizeBorderRectangle / sizeOneRectangle;
                        var spaceBetweenRectangle = sizeOneRectangle / 5;
                        text.DrawString(new CGPoint(Bounds.GetMidX() - size.Width / 2, Bounds.GetMidY() + H / 2 -  sizeOneRectangle * Math.Ceiling(countRectangle) - size.Height));
                        
                        for (int i=0; i< countRectangle; i++)
                        {
                            UIColor.Red.SetFill();
                            UIColor.Blue.SetStroke();
                            var startPositionYRectangle = Bounds.GetMidY() + H / 2 - sizeOneRectangle * i;

                            bezierPath.MoveTo(new CGPoint(Bounds.GetMidX() + W / 2, startPositionYRectangle));
                            bezierPath.AddLineTo(new CGPoint(Bounds.GetMidX() - W / 2, startPositionYRectangle));
                            bezierPath.AddLineTo(new CGPoint(Bounds.GetMidX() - W / 2, startPositionYRectangle - sizeOneRectangle + spaceBetweenRectangle));
                            bezierPath.AddLineTo(new CGPoint(Bounds.GetMidX() + W / 2, startPositionYRectangle - sizeOneRectangle + spaceBetweenRectangle));
                            bezierPath.ClosePath();
                            bezierPath.Fill();
                        }
                        break;
                    }
                case (int)Figures.circle: //circle
                    {
                        text.DrawString(new CGPoint(Bounds.GetMidX() - size.Width / 2, Bounds.GetMidY() - size.Height / 2));
                        UIColor.Red.SetStroke();
                        var startDegree = Radiant(270);
                        var endDegree = Radiant(SliderPosition);

                        bezierPath.AddArc(new CGPoint(Bounds.GetMidX(), Bounds.GetMidY()), (nfloat)Math.Min(Bounds.Width, Bounds.Height) * 0.45f,
                                                     startDegree,
                                                     startDegree + endDegree, true);
                        break;
                    }
                default: break;
            }
           
            bezierPath.LineWidth = 5;
            bezierPath.Stroke();
        }

        float Radiant(float degree)
        {
            float result = degree * (float)Math.PI / 180f;
            return result;
        }

    }
}