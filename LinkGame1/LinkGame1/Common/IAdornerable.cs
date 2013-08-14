namespace LinkGame1
{
    using System.Windows.Input;

    public interface IAdornerable
    {
        void OnMouseLeftButtonDownEventHandler(object sender, MouseButtonEventArgs mouseButtonEventArgs);

        void AddAdorner();

        void RemoveAdorner();
    }
}
