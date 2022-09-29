using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VRgames
{
    /// <summary>
    /// Логика взаимодействия для Landing.xaml
    /// </summary>
    public partial class Landing : Window
    {
        

        public Landing()
        {
            InitializeComponent();
        }

        private void Last(object sender, RoutedEventArgs e)
        {
            Last last = new Last();
            last.ShowDialog();
        }
        private void VRClub(object sender, RoutedEventArgs e)
        {
            VRClubWindow club = new VRClubWindow();
            club.ShowDialog();
        }
        private void VRGames(object sender, RoutedEventArgs e)
        {
            VRGameWindow game = new VRGameWindow();
            game.ShowDialog();
        }
    }
}
