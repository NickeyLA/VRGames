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
    public partial class ZapControl : UserControl
    {
        BDclasses.LastDB lastdb;
        LastView lastView;
       

        public ZapControl(BDclasses.LastDB lastdb, LastView lastView)
        {
            InitializeComponent();

            this.lastdb = lastdb;
            this.lastView = lastView;

            User_Id.Text = Convert.ToString(lastdb.id);
            time.Content = lastdb.time;
            data.Content = lastdb.data;
            FIO.Content = lastdb.user_login;
        }


        private void RemoveElement(object sender, RoutedEventArgs e)
        {
            Adapter.RemoveElementToLast(lastdb);
            lastView.FillBusket();
        }
    }
}
