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
    /// Логика взаимодействия для ZapControlCli.xaml
    /// </summary>
    public partial class ZapControlCli : UserControl
    {
        BDclasses.LastDBCli lastdbCli;
        ClientsWindow client;
        public ZapControlCli()
        {
            InitializeComponent();
            AddElement();
        }

        public ZapControlCli(BDclasses.LastDBCli lastdbCli, ClientsWindow client)
        {
            InitializeComponent();

            this.lastdbCli = lastdbCli;
            this.client = client;

            User_Id.Text = Convert.ToString(lastdbCli.id);
            time.Content = lastdbCli.time;
            data.Content = lastdbCli.data;
            FIO.Content = lastdbCli.user_login;
        }

        public void AddElement()
        {
            Adapter.AddElLastCli(lastdbCli);
            client.FillBusketCli();
        }


        private void RemoveElement(object sender, RoutedEventArgs e)
        {
            Adapter.RemoveElementToLastCli(lastdbCli);
            client.FillBusketCli();
        }
    }
}
