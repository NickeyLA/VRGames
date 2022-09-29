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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        MainWindow MainWindow;

        public Registr()
        {
            InitializeComponent();
        }

        public Registr(MainWindow MainWindow)
        {
            this.MainWindow = MainWindow;
            InitializeComponent();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            if (LoginField.Text != null && LoginField.Text != "" && PasswordField.Text != null && PasswordField.Text != "")
            {
                 if (Adapter.Registration(LoginField.Text, PasswordField.Text, out string message))
                     this.Close();
            }
        }
    }
}
