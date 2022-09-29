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
    public partial class LastView : Window
    {
        private Window mainWindow;
        public LastView()
        {
            InitializeComponent();
        }

        public LastView(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            FillBusket();
            
        }

        
        private void OpenClientsWindow(object sender, RoutedEventArgs e)
        {
            ClientsWindow client = new ClientsWindow();
            client.ShowDialog();
        }

        public void FillBusket()
        {
            ZapElements.Children.Clear();
            foreach (var item in Adapter.ZapEl)
            {
                ZapControl zapcontrol = new ZapControl(item, this);
                ZapElements.Children.Add(zapcontrol);
            }
        }
    }
}
