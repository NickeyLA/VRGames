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
    /// Логика взаимодействия для Last.xaml
    /// </summary>
    public partial class Last : Window
    {

        public Last()
        {
            InitializeComponent();
        }

        private void LastNew(object sender, RoutedEventArgs e)
        {
            if (data.Text != null && time.Text != "" && data.Text != null && time.Text != "" && FIO.Text != null && FIO.Text != "")
            {
                if (Adapter.OutLast(data.Text, time.Text, FIO.Text, out string message))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
        }
    }
}
