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
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
            FillBusketCli();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            if (DataCli.Text != null && TimeCli.Text != "" && DataCli.Text != null && TimeCli.Text != "" && FIOCli.Text != null && FIOCli.Text != "")
            {
                Adapter.OutNewCli(DataCli.Text, TimeCli.Text, FIOCli.Text);
                DataCli.Text = null;
                TimeCli.Text = null;
                FIOCli.Text = null;
                FillBusketCli();
            }
        }

        public void FillBusketCli()
        {
            ZapElementsCli.Children.Clear();
            foreach (var item in Adapter.ZapElCli)
            {
                ZapControlCli zapcontrolCli = new ZapControlCli(item, this);
                ZapElementsCli.Children.Add(zapcontrolCli);
                
            }
        }
    }
}
