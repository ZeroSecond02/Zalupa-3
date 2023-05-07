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

namespace Zalupa_3
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Подумай лучше псина!";
                textBoxLogin.Background = Brushes.LightBlue;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
            }
            if (pass.Length < 8)
            {
                passBox.ToolTip = "Kick me pls, I don't want check this!";
                passBox.Background = Brushes.LightBlue;
            }
            else
            {
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
            }
            User authUser = null;
            using(ApplicationContext db = new ApplicationContext())
            {
                authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
            }

            if(authUser != null)
                {
                MessageBox.Show("Всё ок, ты чёрт!");
                UserPageWindow userPageWindow = new UserPageWindow();
                userPageWindow.Show();
                Hide();
                }
            
            else
                MessageBox.Show("Tы чёрт!");

        }

        private void Button_Window_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
