using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Hide();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = loginBox.Text;
            var pass = PasswordBox.Text;
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (login.Length == 0)
            { MessageBox.Show("Введите логин!");
                return;
            }
            if (pass.Length == 0)
            {
            MessageBox.Show("Введите пароль!");
                return;
            }

            if (user_exists is not null)
              {
                
                MessageBox.Show("Такой пользователь уже существует");
            
                return;
            }
          
            var user = new user { Login = login, Password = pass };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("добро пожаловать");
        }
        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
