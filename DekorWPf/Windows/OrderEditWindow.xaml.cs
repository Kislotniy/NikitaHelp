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
using DekorWPf.Model;
using DekorWPf.Windows;
namespace DekorWPf.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderEditWindow.xaml
    /// </summary>
    public partial class OrderEditWindow : Window
    {
        Orders _orders;
        public OrderEditWindow(Orders orders)
        {
            InitializeComponent();
            _orders = orders;
            xDate.Text = orders.DateDelivery.ToString();
            xKolvo.Text = orders.Quantity.ToString();
            xStatus.Text = orders.Satus_Orders.Name_Satus;
        }
    }
}
