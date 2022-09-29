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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VRgames
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenRegisrationWindow(object sender, MouseButtonEventArgs e)
        {
            Registr registration = new Registr(this);
            registration.ShowDialog();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (LoginField.Text != null && LoginField.Text != "" && PasswordField.Text != null && PasswordField.Text != "")
            {
                if (Adapter.Login(LoginField.Text, PasswordField.Text, out string message))
                {
                    Landing landing = new Landing();
                    landing.ShowDialog();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
        }

        private void OpenAdminWindow(object sender, RoutedEventArgs e)
        {
            if (LoginField.Text != null && LoginField.Text != "" && PasswordField.Text != null && PasswordField.Text != "")
            {
                if (Adapter.AdminLogin(LoginField.Text, PasswordField.Text, out string message))
                {
                    LastView last = new LastView(this);
                    last.ShowDialog();
                }
                 else
                 {
                    MessageBox.Show(message);
                 }
            }
        }

        /*protected override void OnClosed(EventArgs e)
        {
            if (!landing.IsActive)
                landing.Close();
            base.OnClosed(e);
        }*/
    }
}
