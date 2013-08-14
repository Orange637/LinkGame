namespace LinkGame1.Controls
{
    using System;
    using System.Runtime;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Threading;

    public class FadeAdorner : FrameworkElement
    {
        private readonly UIElement _adornedElement;

        private bool _isClipEnabled;

        protected FadeAdorner(UIElement adornedElement)
        {
            if (adornedElement == null)
            {
                throw new ArgumentNullException("adornedElement");
            }

            this._adornedElement = adornedElement;
            this._isClipEnabled = false;
            Dispatcher.CurrentDispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                (Delegate)new DispatcherOperationCallback(CreateFlowDirectionBinding),
                (object)this);
        }

        public UIElement AdornedElement
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this._adornedElement;
            }
        }

        private static object CreateFlowDirectionBinding(object o)
        {
            var adorner = (FadeAdorner)o;
            adorner.SetBinding(
                FrameworkElement.FlowDirectionProperty,
                new Binding("FlowDirection") { Mode = BindingMode.OneWay, Source = (object)adorner.AdornedElement });
            return (object)null;
        }
    }
}
