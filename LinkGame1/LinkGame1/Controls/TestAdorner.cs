using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkGame1.Controls
{
    using System.Runtime;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.Windows.Threading;

    public class TestAdorner : FrameworkElement
    {
        private readonly UIElement _adornedElement;
        private bool _isClipEnabled;

        internal Geometry AdornerClip
        {
            get
            {
                return this.Clip;
            }
            set
            {
                this.Clip = value;
            }
        }

        internal Transform AdornerTransform
        {
            get
            {
                return this.RenderTransform;
            }

            set
            {
                this.RenderTransform = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Windows.UIElement"/> that this adorner is bound to.
        /// </summary>
        /// 
        /// <returns>
        /// The element that this adorner is bound to. The default value is null.
        /// </returns>
        public UIElement AdornedElement
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this._adornedElement;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether clipping of the adorner is enabled.
        /// </summary>
        /// 
        /// <returns>
        /// A Boolean value indicating whether clipping of the adorner is enabled.If this property is false, the adorner is not clipped.If this property is true, the adorner is clipped using the same clipping geometry as the adorned element.The default value is false.
        /// </returns>
        public bool IsClipEnabled
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this._isClipEnabled;
            }
            set
            {
                this._isClipEnabled = value;
                this.InvalidateArrange();
                AdornerLayer.GetAdornerLayer((Visual)this._adornedElement).InvalidateArrange();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Documents.Adorner"/> class.
        /// </summary>
        /// <param name="adornedElement">The element to bind the adorner to.</param><exception cref="T:System.ArgumentNullException">adornedElement is null.</exception>
        protected TestAdorner(UIElement adornedElement)
        {
            if (adornedElement == null)
                throw new ArgumentNullException("adornedElement");
            this._adornedElement = adornedElement;
            this._isClipEnabled = false;
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate)new DispatcherOperationCallback(TestAdorner.CreateFlowDirectionBinding), (object)this);
        }

        /// <summary>
        /// Implements any custom measuring behavior for the adorner.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.Size"/> object representing the amount of layout space needed by the adorner.
        /// </returns>
        /// <param name="constraint">A size to constrain the adorner to.</param>
        protected override Size MeasureOverride(Size constraint)
        {
            Size availableSize = new Size(this.AdornedElement.RenderSize.Width, this.AdornedElement.RenderSize.Height);
            int visualChildrenCount = this.VisualChildrenCount;
            for (int index = 0; index < visualChildrenCount; ++index)
            {
                UIElement uiElement = this.GetVisualChild(index) as UIElement;
                if (uiElement != null)
                {
                    uiElement.Measure(availableSize);
                }
            }
            return availableSize;
        }

        /// <summary>
        /// For a description of this member, see <see cref="M:System.Windows.UIElement.GetLayoutClip(System.Windows.Size)"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The potential clipping geometry. See Remarks.
        /// </returns>
        /// <param name="layoutSlotSize">The available size provided by the element.</param>
        protected override Geometry GetLayoutClip(Size layoutSlotSize)
        {
            return (Geometry)null;
        }

        /// <summary>
        /// Returns a <see cref="T:System.Windows.Media.Transform"/> for the adorner, based on the transform that is currently applied to the adorned element.
        /// </summary>
        /// 
        /// <returns>
        /// A transform to apply to the adorner.
        /// </returns>
        /// <param name="transform">The transform that is currently applied to the adorned element.</param>
        public virtual GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            return transform;
        }

        internal virtual bool NeedsUpdate(Size oldSize)
        {
            return !AreClose(this.AdornedElement.RenderSize, oldSize);
        }

        public static bool AreClose(Size size1, Size size2)
        {
            if (AreClose(size1.Width, size2.Width))
                return AreClose(size1.Height, size2.Height);
            else
                return false;
        }

        public static bool AreClose(double value1, double value2)
        {
            if (value1 == value2)
                return true;
            double num1 = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * 2.22044604925031E-16;
            double num2 = value1 - value2;
            if (-num1 < num2)
                return num1 > num2;
            else
                return false;
        }

        private static object CreateFlowDirectionBinding(object o)
        {
            TestAdorner adorner = (TestAdorner)o;
            adorner.SetBinding(FrameworkElement.FlowDirectionProperty, (BindingBase)new Binding("FlowDirection")
            {
                Mode = BindingMode.OneWay,
                Source = (object)adorner.AdornedElement
            });
            return (object)null;
        }
    }
}

