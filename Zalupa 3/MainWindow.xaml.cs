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
using System.Windows.Media.Animation;

namespace Zalupa_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            
            DoubleAnimation bAnimation = new DoubleAnimation();
            bAnimation.From = 0;
            bAnimation.To = 450;
            bAnimation.Duration = TimeSpan.FromSeconds(3);
            regButton.BeginAnimation(Button.WidthProperty, bAnimation);
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

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
            if (pass_2 != pass)
            {
                passBox_2.ToolTip = "Сука повтори буквы!";
                passBox_2.Background = Brushes.LightBlue;
            }
            else
            {
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
            }
            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Боже чел какой нахуй 228 в почте?";
                textBoxEmail.Background = Brushes.LightBlue;
            }
            else
            {
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Всё ок, ты чёрт!");
                User user = new User(login, email, pass);
                
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Hide();
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }
    }
}
