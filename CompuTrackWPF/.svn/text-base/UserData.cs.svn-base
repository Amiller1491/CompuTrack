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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace CompuTrackWPF
{

    public class UserData : ObservableCollection<UserItem>
    {
        public UserData() : base()
        {
            PopulateUserListView();
        }

        private void PopulateUserListView()
        {
            try
            {
                Shared.ramdbConnection.Open();
            }
            catch
            {

            }
            SqlCommand populateUserCmd = new SqlCommand("SELECT Username, Password, Permissions, UserID FROM Users ORDER BY Username ASC");
            populateUserCmd.Connection = Shared.ramdbConnection;
            SqlDataReader userReader = populateUserCmd.ExecuteReader();
            while (userReader.Read())
            {
                String username = userReader["Username"].ToString();
                String password = userReader["Password"].ToString();
                int permissions = Convert.ToInt32(userReader["Permissions"].ToString());
                int userID = Convert.ToInt32(userReader["UserID"].ToString());
                Add(new UserItem(username, password, permissions, userID));
            }

            Shared.ramdbConnection.Close();
        }

        public void refreshListView()
        {
            Clear();
            PopulateUserListView();
        }
    }


    public class UserItem : INotifyPropertyChanged
    {
        public string userName;
        public string password;
        public int permissions;
        public int userID;

        //auto update stuff
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        public UserItem(string userName, string password, int permissions, int userID)
        {
            this.userName = userName;
            this.password = password;
            this.permissions = permissions;
            this.userID = userID;
        }

        public string userNameString
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged("userNameString"); }
        }

        public string passwordString
        {
            get { return password; }
            set { password = value; OnPropertyChanged("passwordString"); }
        }

        public int permissionsInt
        {
            get { return permissions; }
            set { permissions = value; OnPropertyChanged("permissionsInt"); }
        }

        public int userIdInt
        {
            get { return userID; }
            set { userID = value; OnPropertyChanged("userIdInt"); }
        }

        public string permissionsString
        {
            get
            {
                if (permissions == 2) return "su";
                if (permissions == 1) return "admin";
                else return "user"; 
            }
        }
    }
}
