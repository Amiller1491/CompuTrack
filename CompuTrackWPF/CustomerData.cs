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


namespace CompuTrackWPF
{

    public class CustomerData : ObservableCollection<CustomerItem>
    {
        public CustomerData() : base()
        {
            PopulateCustomerListView();
        }

        private void PopulateCustomerListView()
        {

            try
            {
                Shared.ramdbConnection.Open();
                try
                {
                    SqlCommand populateCustomerCmd = new SqlCommand("SELECT C_id, LName, FName FROM Customers ORDER BY LName ASC");
                    populateCustomerCmd.Connection = Shared.ramdbConnection;
                    SqlDataReader customerReader = populateCustomerCmd.ExecuteReader();
                    while (customerReader.Read())
                    {
                        int C_id = Convert.ToInt32(customerReader["C_id"].ToString());
                        String LName = customerReader["LName"].ToString();
                        String FName = customerReader["FName"].ToString();
                        Add(new CustomerItem(C_id, LName, FName));
                    }

                    Shared.ramdbConnection.Close();
                }
                catch { }
            }
            catch
            {
                Add(new CustomerItem(0, "Connection", "No"));
            }
        }

        public void refreshListView()
        {
            Clear();
            PopulateCustomerListView();
        }
    }


    public class CustomerItem
    {
        public int C_id;
        public string LName;
        public string FName;

        public CustomerItem(int C_id, string LName, string FName)
        {
            this.C_id = C_id;
            this.LName = LName;
            this.FName = FName;
        }

        public int C_idInt
        {
            get { return C_id; }
            set { C_id = value; }
        }

        public string LNameString
        {
            get { return LName; }
            set { LName = value; }
        }

        public string FNameString
        {
            get { return FName; }
            set { FName = value; }
        }

        public string FullNameString
        {
            get { return LName + ", " + FName; }
        }
    }
}
