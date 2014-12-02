using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows;

namespace CompuTrackWPF
{
    class User
    {
        public String _message;
        public String successMsg = "User successfully created.";
        public String errorMsg = "Error";
        public String sqlError = "Could not open SQL connection.";

        public String _userName;
        public String _password;
        public int _permissions;
        public int _userID;

        public User(String userName, String password, int permissions)
        {
            _userName = userName;
            _password = password;
            _permissions = permissions;
        }

        public void createNewUserInDB()
        {
            try
            {
                Shared.ramdbConnection.Open();
            }
            catch
            {
                _message = sqlError;
            }
            SqlCommand createUser = new SqlCommand("INSERT into Users (Username, Password, Permissions) VALUES (@username, @password, @permissions)");
            createUser.Parameters.AddWithValue("@username", _userName);
            createUser.Parameters.AddWithValue("@password", _password);
            createUser.Parameters.AddWithValue("@permissions", _permissions);
            createUser.Connection = Shared.ramdbConnection;
            try
            {
                createUser.ExecuteNonQuery();
                Shared.ramdbConnection.Close();
                _message = successMsg;
            }
            catch
            {
                _message = errorMsg;
                Shared.ramdbConnection.Close();
            }
        }
    }
}
