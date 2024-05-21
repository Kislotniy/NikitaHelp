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
    /// Логика взаимодействия для GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        public GuestWindow()
        {
            InitializeComponent();
           ListProducts.ItemsSource = Connection.con.Products.ToList();
        }

        private void KeyboardList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
