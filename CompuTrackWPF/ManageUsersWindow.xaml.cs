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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CompuTrackWPF
{
    /// <summary>
    /// Interaction logic for ManageUsersWindow.xaml
    /// </summary>
    public partial class ManageUsersWindow : Window
    {
        public ManageUsersWindow()
        {
            if (Shared.currentUser._permissions >= 1)
            {
                InitializeComponent();
            }
        }

        UserItem selectedUser;

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void userSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (this.userListView.SelectedItem != null)
            {
                selectedUser = (UserItem)this.userListView.SelectedItem;
                usernameBox.Text = selectedUser.userName;
                passwordBox.Password = selectedUser.password;
                if (selectedUser.permissions == 2) adminCheckBox.Visibility = Visibility.Collapsed;
                else if (selectedUser.permissions == 1)
                {
                    adminCheckBox.Visibility = Visibility.Visible;
                    adminCheckBox.IsChecked = true;
                }
                else if (selectedUser.permissions == 0)
                {
                    adminCheckBox.Visibility = Visibility.Visible;
                    adminCheckBox.IsChecked = false;
                }
                messageLabel.Content = "";
            }
            try
            {
                Shared.ramdbConnection.Open();
            }
            catch
            {
                messageLabel.Content = "Cannot open SQL connection.";
            }
            SqlCommand findUserIDCommand = new SqlCommand("SELECT UserID FROM Users WHERE Username = @name AND Password = @password");
            findUserIDCommand.Connection = Shared.ramdbConnection;
            findUserIDCommand.Parameters.AddWithValue("@name", usernameBox.Text);
            findUserIDCommand.Parameters.AddWithValue("@password", passwordBox.Password);
            SqlDataReader findUserIDReader = findUserIDCommand.ExecuteReader();
            while (findUserIDReader.Read()) Shared.currentUser._userID = Convert.ToInt32(findUserIDReader["UserID"]);
            Shared.ramdbConnection.Close();
        }

        private void createUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (newUsernameBox.Text == "")
            {
                messageLabel.Content = "Username cannot be blank.";
            }
            else if (newPasswordBox.Password == "")
            {
                messageLabel.Content = "Password cannot be blank.";
            }
            else if (newPasswordBox.Password == newPasswordConfirmBox.Password)
            {
                int permissionLevel;
                if (newAdminCheckBox.IsChecked == true) permissionLevel = 1;
                else permissionLevel = 0;
                User newUser = new User(newUsernameBox.Text.Trim(), newPasswordBox.Password.Trim(), permissionLevel);
                newUser.createNewUserInDB();
                messageLabel.Content = newUser._message;
                if (newUser._message == newUser.successMsg)
                {
                    refreshListView();
                    newUsernameBox.Clear();
                    newPasswordBox.Clear();
                    newPasswordConfirmBox.Clear();
                    newAdminCheckBox.IsChecked = false;
                    newUsernameBox.Focus();
                }
            }
            else if (newPasswordBox.Password != newPasswordConfirmBox.Password) messageLabel.Content = "Passwords do not match.";
            else messageLabel.Content = "Error. Username may already exist.";
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.userListView.SelectedItem != null)
            {
                if (selectedUser.permissions >= Shared.currentUser._permissions && selectedUser.userName != Shared.currentUser._userName) messageLabel.Content = "Insufficient privelages to edit user.";
                else
                {
                    try
                    {
                        Shared.ramdbConnection.Open();
                    }
                    catch
                    {
                        messageLabel.Content = "Cannot open SQL connection.";
                    }
                    SqlCommand updateCommand = new SqlCommand("UPDATE Users SET Username = @username, Password = @password, Permissions = @permissions WHERE UserID = @userID");
                    updateCommand.Connection = Shared.ramdbConnection;
                    updateCommand.Parameters.AddWithValue("@username", usernameBox.Text.Trim());                   
                    updateCommand.Parameters.AddWithValue("@password", passwordBox.Password.Trim());
                    if (selectedUser.permissions == 2) updateCommand.Parameters.AddWithValue("@permissions", 2);
                    else if (adminCheckBox.IsChecked == true) updateCommand.Parameters.AddWithValue("@permissions", 1);
                    else if (adminCheckBox.IsChecked == false) updateCommand.Parameters.AddWithValue("@permissions", 0);
                    updateCommand.Parameters.AddWithValue("@userID", Shared.currentUser._userID);
                    try
                    {
                    updateCommand.ExecuteNonQuery();
                    Shared.ramdbConnection.Close();
                    messageLabel.Content = "User edited sucessfully";
                    refreshListView();
                    }
                    catch
                    {
                        messageLabel.Content = "Error editing user. Username may already exist.";
                        Shared.ramdbConnection.Close();
                    }
                }
            }
            else messageLabel.Content = "Select a user first.";
        }

        private void deleteUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.userListView.SelectedItem != null)
            {
                if (selectedUser.permissions >= Shared.currentUser._permissions && selectedUser.userName != Shared.currentUser._userName) messageLabel.Content = "Insufficient privelages to delete user.";
                else if (selectedUser.userName == Shared.currentUser._userName) messageLabel.Content = "Cannot delete yourself.";
                else
                {
                    try
                    {
                        Shared.ramdbConnection.Open();
                    }
                    catch
                    {
                        messageLabel.Content = "Cannot open SQL connection.";
                    }
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM Users WHERE UserID = @userID");
                    deleteCommand.Connection = Shared.ramdbConnection;
                    deleteCommand.Parameters.AddWithValue("@userID", Shared.currentUser._userID);
                    try
                    {
                        deleteCommand.ExecuteNonQuery();
                        Shared.ramdbConnection.Close();
                        messageLabel.Content = "User deleted successfully.";
                        refreshListView();
                        userListView.SelectedIndex = -1;
                        usernameBox.Clear();
                        passwordBox.Clear();
                        adminCheckBox.IsChecked = false;
                    }
                    catch
                    {
                        messageLabel.Content = "Error deleting user.";
                        Shared.ramdbConnection.Close();
                    }
                }
            }
            else messageLabel.Content = "Select a user first.";
        }

        public void refreshListView()
        {
            var referenceToUserList = (UserData)FindResource("UserList");
            referenceToUserList.refreshListView();
        }
                
        private void userHeaderClicked(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader clicked = e.OriginalSource as GridViewColumnHeader;

            if (clicked != null && clicked.Role != GridViewColumnHeaderRole.Padding)
            {
                string header = clicked.Column.Header as string;
                Sort(header, userListView.getSortDirection(clicked)); 
            }
            
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(userListView.ItemsSource);
            dataView.SortDescriptions.Clear();
            if (sortBy.Equals("User")) sortBy = "userNameString";
            if (sortBy.Equals("Level")) sortBy = "permissionsString";
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }


       

    }

}
