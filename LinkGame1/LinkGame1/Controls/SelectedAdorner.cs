namespace LinkGame1
{
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;

    using LinkGame1.Controls;

    public class SelectedAdorner : Adorner
    {
        private readonly Brush background = new SolidColorBrush(new Color { A = 64, R = 255, G = 255, B = 255 });

        private readonly Pen border = new Pen(Brushes.Blue, 1);

        public SelectedAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            /*var adornerableElement = adornedElement as IAdornerable;
            if (adornerableElement != null)
            {
                this.MouseLeftButtonDown += adornerableElement.OnMouseLeftButtonDownEventHandler;
            }*/
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(this.background, this.border, new Rect(this.AdornedElement.DesiredSize));
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return constraint;
        }
    }
}
