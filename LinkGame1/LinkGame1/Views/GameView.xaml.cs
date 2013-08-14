using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using LinkGame1.Entities;
using LinkGame1.Extensions;

namespace LinkGame1.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml.
    /// </summary>
    public partial class GameView : INotifyPropertyChanged
    {
        private Player player;

        public GameView(Player player)
        {
            InitializeComponent();

            this.Player = player;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Player Player
        {
            get
            {
                return this.player;
            }

            set
            {
                this.player = value;
                this.OnPropertyChanged("Player");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void PlaySelectedLevel(object sender, MouseButtonEventArgs e)
        {
            dynamic level = ((FrameworkElement)sender).DataContext;
            var mode = level.Mode;

            var mainRegion = this.FindAncestorElement<ContentControl>("MainRegion");
            mainRegion.Content = new PlayView(mode);
        }
    }
}
