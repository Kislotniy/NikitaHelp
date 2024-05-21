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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static Model.DekorDBEntities1 db = new Model.DekorDBEntities1();
        public List<Model.Orders> agents = new List<Model.Orders>();
        public AdminWindow()
        {
            InitializeComponent();
            RefreshComboBox();
            UpdateTovar();
           
        }
       
       
        private void CBNumberWrite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pageSize = Convert.ToInt32(CBNumberWrite.SelectedItem.ToString());
            RefreshPagination();
        }
        private void BLeft_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber == 0)
                return;
            pageNumber--;
            RefreshPagination();
        }

        private void BRight_Click(object sender, RoutedEventArgs e)
        {
            if (users.Count % pageSize == 0)
            {
                if (pageNumber == (users.Count / pageSize) - 1)
                    return;
            }
            else
            {

                if (pageNumber == (users.Count / pageSize))
                    return;
            }
            pageNumber++;
            RefreshPagination();
        }

        int pageSize;
        int pageNumber;
        List<Model.Orders> users = db.Orders.ToList();

        private void RefreshPagination()
        {
            KeyboardList.ItemsSource = null;
            KeyboardList.ItemsSource = users.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }

        private void RefreshComboBox()
        {
            CBNumberWrite.Items.Add("10");
            SortCB.Items.Add("По имени пользователя");
            SortCB.Items.Add("По коду");
            SortCB.Items.Add("По количеству");
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            pageNumber = Convert.ToInt32(button.Content) - 1;
            RefreshPagination();
        }
        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTovar();
        }
        private void UpdateTovar()
        {
            var currentKeyboard = Connection.con.Orders.ToList();

            currentKeyboard = currentKeyboard.Where(p => p.id_User.ToString().Contains(Poisk.Text.ToLower())).ToList();

            KeyboardList.ItemsSource = currentKeyboard.OrderBy(p => p.Quantity).ToList();

        }
        private void Mouse_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                
                KeyboardList.ItemsSource = Connection.con.Orders.ToList();
            }
        }
        private void Red_Click(object sender, RoutedEventArgs e)
        {
            OrderEditWindow page = new OrderEditWindow((sender as Button).DataContext as Orders);
            page.Show();
            this.Close();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCB.SelectedIndex == 0)
            {
                KeyboardList.ItemsSource = null;
                KeyboardList.ItemsSource = Connection.con.Orders.OrderBy(z => z.Users.Name_User).ToList();
            }
            if (SortCB.SelectedIndex == 1)
            {
                KeyboardList.ItemsSource = null;
                KeyboardList.ItemsSource = Connection.con.Orders.OrderBy(z => z.Kode).ToList();
            }
            if (SortCB.SelectedIndex == 2)
            {
                KeyboardList.ItemsSource = null;
                KeyboardList.ItemsSource = Connection.con.Orders.OrderBy(z => z.Quantity).ToList();
            }
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            string item = Convert.ToString(combobox.SelectedItem);
            if (item == "Фильтрация")
            {
                KeyboardList.ItemsSource = users;
                return;
            }
            agents = Connection.con.Orders.Where(z => z.Satus_Orders.Name_Satus == item).ToList();
            KeyboardList.ItemsSource = agents;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var listik = KeyboardList.SelectedItem as Model.Orders;

            var selected = Connection.con.Orders.Where(z => z.id_Orders == listik.id_Orders);
            //var selectedtwo = Connection.con.Agent.Where(z => z. == listik.ID);
            Connection.con.Orders.RemoveRange(selected);
            //Connection.con.Agent.RemoveRange(selectedtwo);
            Connection.con.SaveChanges();
            MessageBox.Show("Removed");
            KeyboardList.ItemsSource = Connection.con.Orders.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //AddAgent addAgent = new AddAgent(null);
            //this.Close();
            //addAgent.ShowDialog();
        }

        private void DeleteBtn_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            StandartWindow productwindow = new StandartWindow();
            this.Close();
            productwindow.ShowDialog();
        }
    }
}
