using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace CompuTrackWPF
{
    /// <summary>
    /// Interaction logic for UserLoginPage.xaml
    /// </summary>
    public partial class UserLoginPage : Page
    {
        public UserLoginPage()
        {
            InitializeComponent();
            userNameBox.Focus();
        }

        private void newUserBtn_Click(object sender, RoutedEventArgs e)
        {
            Uri NewUserURI = new Uri("NewUserPage.xaml", new UriKind());
            NavigationService.Navigate(NewUserURI);
        }

        private void closelBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = Window.GetWindow(this);
            win.Close();
        }

        private void login()
        {
            try
            {
                Shared.ramdbConnection.Open();
            }
            catch
            {
                messageLabel.Content = "Cannot open SQL connection.";
            }
            SqlCommand loginCommand = new SqlCommand("SELECT * FROM Users WHERE Username = @name AND Password = @password");
            loginCommand.Connection = Shared.ramdbConnection;
            loginCommand.Parameters.AddWithValue("@name", userNameBox.Text);
            loginCommand.Parameters.AddWithValue("@password", pwBox.Password);
            SqlDataReader loginReader = loginCommand.ExecuteReader();
            while (loginReader.Read())
            {
                int permissions = Convert.ToInt32(loginReader["Permissions"].ToString());
                if ((loginReader["Username"].ToString() == userNameBox.Text)
                    && (loginReader["Password"].ToString() == pwBox.Password))
                {
                    Shared.currentUser = new User(userNameBox.Text, pwBox.Password, permissions);
                    loginBtn.IsEnabled = false;
                    if (permissions == 1)
                    {
                        loginBtn.Visibility = Visibility.Hidden;
                        newUserBtn.IsEnabled = true;
                        newUserBtn.Visibility = Visibility.Visible;
                    }
                    messageLabel.Content = "Logged in as " + Shared.currentUser._userName + ".";
                    var referenceToMainWindow = (MainWindow)Window.GetWindow(this).Owner;
                    if (Shared.currentUser._userName != null)
                    {
                        //referenceToMainWindow.displayCurrentUser();
                    }
                }
            }
            if (messageLabel.Content.ToString() == "") messageLabel.Content = "Invalid Username/Password combination.";
            Shared.ramdbConnection.Close();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void onEnterKey(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return && e.Key != Key.Enter)
                return;
            e.Handled = true;
            login();
        }
    }
}
