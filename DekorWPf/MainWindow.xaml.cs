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
using DekorWPf.Model;
using DekorWPf.Windows;
namespace DekorWPf
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

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = Connection.con.Users.Where(z => z.Login_User == TBLogin.Text && z.Password_User == TBPassword.Text).FirstOrDefault();
            if (user != null )
            {   
                if (user.id_Role == 3)
                {
                    AdminWindow admin = new AdminWindow();
                    MessageBox.Show($"Hello {user.Name_User}");
                    admin.ShowDialog();                  
                }
                else
                {
                    StandartWindow standartWindow = new StandartWindow();
                    MessageBox.Show($"Hello {user.Name_User}");
                    standartWindow.ShowDialog();
                  
                }
            }
            else
            {
                MessageBox.Show("Not corrected.");
                
            }
           
        }

        private void BLogin_Copy_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow();            
            guestWindow.ShowDialog();
        }
    }
}
