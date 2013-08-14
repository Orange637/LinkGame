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
    /// Interaction logic for WelcomView.xaml.
    /// </summary>
    public partial class WelcomeView : INotifyPropertyChanged
    {
        private string nickname;

        public WelcomeView()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
                this.OnPropertyChanged("Nickname");
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

        private void StartPlayCommand(object sender, RoutedEventArgs e)
        {
            // Search database with the nickname
            // If new nickname, create new player
            // else get data from database
            var player = new Player { Name = this.nickname, Scores = 2002, GameInfo = new GameInfo() };

            var mainRegion = this.FindAncestorElement<ContentControl>("MainRegion");
            if (mainRegion != null)
            {
                mainRegion.Content = new GameView(player);
            }
        }
    }
}
