using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LinkGame1.Common
{
    public class LinkLineHelper
    {
        public static Polyline CreatePolyline(params Point[] points)
        {
            var polyline = new Polyline
            {
                StrokeThickness = 4,
                Opacity = 0.5,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round
            };

            foreach (var point in points)
            {
                polyline.Points.Add(point);
            }

            return polyline;
        }

        public static void DrawingPolyline(Panel container, Polyline polyline)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (polyline == null)
            {
                throw new ArgumentNullException("polyline");
            }

            var animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 150)),
                FillBehavior = FillBehavior.HoldEnd
            };
            var strokeBrush = new LinearGradientBrush();
            var blueStop = new GradientStop(Colors.Blue, 0);
            var transparentStop = new GradientStop(Colors.Transparent, 0);
            strokeBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0));
            strokeBrush.GradientStops.Add(blueStop);
            strokeBrush.GradientStops.Add(transparentStop);

            Storyboard.SetTarget(animation, transparentStop);
            Storyboard.SetTarget(animation, blueStop);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Offset"));

            polyline.Stroke = strokeBrush;
            transparentStop.BeginAnimation(GradientStop.OffsetProperty, animation);
            blueStop.BeginAnimation(GradientStop.OffsetProperty, animation);
            container.Children.Add(polyline);
        }

        public static void RemovePolyline(Panel container, Polyline polyline)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (polyline == null)
            {
                throw new ArgumentNullException("polyline");
            }

            container.Children.Remove(polyline);
        }
    }
}
