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

namespace suiviA
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        
        Login login = new Login("Admin", "Admin0", 0);

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string user = usernameTextBox.Text;
            string pass = passwordTextBox.Password;
            if (login.IsLoggedIn(user, pass))
            {
                MessageBox.Show("You are logged in successfully");
                MainWindow mainWindow = new MainWindow();

                mainWindow.Show();
                Close();
            }
            else
            {
                //show default login error message
                MessageBox.Show("Login Error!");
            }
        }
    }
}
