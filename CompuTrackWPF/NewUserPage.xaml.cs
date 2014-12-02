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

namespace CompuTrackWPF
{
    /// <summary>
    /// Interaction logic for NewUserPage.xaml
    /// </summary>
    public partial class NewUserPage : Page
    {
        int permissionLevel;

        public NewUserPage()
        {
            InitializeComponent();
            userNameBox.Focus();
        }

        private void CloseNewUserBtn_Click(object sender, RoutedEventArgs e)
        {
            Uri LoginPageURI = new Uri("UserLoginPage.xaml", new UriKind());
            NavigationService.Navigate(LoginPageURI);
        }

        private void saveNewUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userNameBox.Text == "")
            {
                messageLabel.Content = "Username cannot be blank.";
            }
            else if (pwBox.Password == "")
            {
                messageLabel.Content = "Password cannot be blank.";
            }
            else if (pwBox.Password == pwConfirmBox.Password)
            {
                if (adminCheckBox.IsChecked == true) permissionLevel = 1;
                else permissionLevel = 0;
                User newUser = new User(userNameBox.Text, pwBox.Password, permissionLevel);
                newUser.createNewUserInDB();
                messageLabel.Content = newUser._message;
                if (newUser._message == newUser.successMsg) saveNewUserBtn.IsEnabled = false;
            }
            else messageLabel.Content = "Passwords do not match.";
        }
    }
}
