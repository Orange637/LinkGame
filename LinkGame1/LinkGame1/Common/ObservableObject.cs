namespace LinkGame1.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;

    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void NotifyPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var handler = this.PropertyChanged;
            if (handler != null && propertyExpression != null)
            {
                var propertyName = propertyExpression.Body as MemberExpression;
                
                if (propertyName != null)
                {
                    handler(this,new PropertyChangedEventArgs(propertyName.Member.Name));
                }
            }
        }

        protected virtual void SetProperty<T>(ref T field, T value, Expression<Func<T>> propertyExpression)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;

            this.NotifyPropertyChanged(propertyExpression);
        }
    }
}
