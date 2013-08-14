namespace LinkGame1.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;

    using LinkGame1.Entities;

    public class LinkImage : Control
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(LinkItem), typeof(LinkImage), new PropertyMetadata(null));

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(LinkImage), new PropertyMetadata(false));

        public static readonly DependencyProperty IsDeadProperty =
            DependencyProperty.Register("IsDead", typeof(bool), typeof(LinkImage), new PropertyMetadata(false));

        public LinkImage()
        {
        }

        public LinkItem Value
        {
            get
            {
                return (LinkItem)this.GetValue(ValueProperty);
            }

            set
            {
                this.SetValue(ValueProperty, value);
            }
        }

        public bool IsSelected
        {
            get { return (bool)this.GetValue(IsSelectedProperty); }
            set { this.SetValue(IsSelectedProperty, value); }
        }

        public bool IsDead
        {
            get { return (bool)this.GetValue(IsDeadProperty); }
            set { this.SetValue(IsDeadProperty, value); }
        }
    }
}
