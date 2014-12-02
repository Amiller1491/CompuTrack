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

namespace CompuTrackWPF
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        string intention = "new";
        int c_idToEdit;

        public CustomerWindow()
        {
            InitializeComponent();
        }

        public CustomerWindow(int c_id)
        {
            InitializeComponent();
            this.c_idToEdit = c_id;
            this.intention = "edit";
            saveCustomerBtn.Content = "Update";
            titleLabel.Content = "Edit Customer";
        }

        private void saveOrEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (intention == "new") { newCustomer(); }
            else if (intention == "edit") { editCustomer(); }
        }

        public void newCustomer()
        {
            try
            {
                Shared.ramdbConnection.Open();
            }
            catch
            {
                messageLabel.Content = "Could not open SQL connection.";
            }
            SqlCommand saveCustomer = new SqlCommand("INSERT into Customers (LName, FName, Company, Add1, Add2, City, State, Zip, Phone1, Phone2, Email) " +
                "Values (@LName, @FName, @company, @address1, @address2, @city, @state, @zip, @phone1, @phone2, @email)" +
                "SELECT C_id FROM Customers WHERE C_id=SCOPE_IDENTITY()");
            saveCustomer.Connection = Shared.ramdbConnection;

            if (lnameBox.Text == "" || fnameBox.Text == "" || add1Box.Text == "" ||
                cityBox.Text == "" || stateComboBox.Text == "" || zipBox.Value.ToString() == "" ||
                phone1Box.Value.ToString() == "")
            {
                messageLabel.Content = "Please make sure all required fields are filled in.";
            }
            else if (phone1Box.Value.ToString().Length < 10 || (phone2Box.Value.ToString() != "" && phone2Box.Value.ToString().Length < 10))
            {
                messageLabel.Content = "Please enter a valid phone number.";
            }
            else if (zipBox.Value.ToString().Length < 5)
            {
                messageLabel.Content = "Please enter a valid five digit zip code.";
            }
            else
            {
                saveCustomer.Parameters.AddWithValue("@LName", lnameBox.Text.Trim());
                saveCustomer.Parameters.AddWithValue("@FName", fnameBox.Text.Trim());
                saveCustomer.Parameters.AddWithValue("@company", companyBox.Text.Trim());
                saveCustomer.Parameters.AddWithValue("@address1", add1Box.Text.Trim());
                saveCustomer.Parameters.AddWithValue("@address2", add2Box.Text.Trim());
                saveCustomer.Parameters.AddWithValue("@city", cityBox.Text.Trim());
                saveCustomer.Parameters.AddWithValue("@state", stateComboBox.Text.Trim());
                saveCustomer.Parameters.AddWithValue("@zip", zipBox.Value);
                saveCustomer.Parameters.AddWithValue("@phone1", phone1Box.Value);
                saveCustomer.Parameters.AddWithValue("@phone2", phone2Box.Value);
                saveCustomer.Parameters.AddWithValue("@email", emailBox.Text.Trim());

                try { var referenceToMainWindow = (MainWindow)Window.GetWindow(this).Owner; }
                catch { var referenceToMainWindow = (TicketWindow)Window.GetWindow(this).Owner; }

                try
                {
                    SqlDataReader saveCustomerReader = saveCustomer.ExecuteReader();
                    while (saveCustomerReader.Read())
                    {//for reselecting customer
                        c_idToEdit = Convert.ToInt32(saveCustomerReader["C_id"]);
                    }
                    Shared.ramdbConnection.Close();
                    //messageLabel.Content = "Customer successfully added to database.";
                    saveCustomerBtn.IsEnabled = false;
                    refreshListView();
                    reselectCustomer();
                    Close();
                }
                catch
                {
                    messageLabel.Content = "Error saving to database.";
                    Shared.ramdbConnection.Close();
                }
            }

        }

        public void editCustomer()
        {
            try
            {
                Shared.ramdbConnection.Open();
            }
            catch
            {
                messageLabel.Content = "Could not open SQL connection.";
            }
            SqlCommand editCustomer = new SqlCommand("UPDATE Customers SET LName = @LName, FName = @FName, Company = @company, Add1 = @address1, Add2 = @address2, City = @city, State = @state, Zip = @zip, Phone1 = @phone1, Phone2 = @phone2, Email = @email WHERE C_id = @c_id");
            editCustomer.Connection = Shared.ramdbConnection;

            if (lnameBox.Text == "" || fnameBox.Text == "" || add1Box.Text == "" ||
                cityBox.Text == "" || stateComboBox.Text == "" || zipBox.Value.ToString() == "" ||
                phone1Box.Value == "")
            {
                messageLabel.Content = "Please make sure all required fields are filled in.";
            }
            else if (phone1Box.Value.ToString().Length < 10 || (phone2Box.Value.ToString() != "" && phone2Box.Value.ToString().Length < 10))
            {
                messageLabel.Content = "Please enter a valid phone number.";
            }
            else if (zipBox.Value.ToString().Length < 5)
            {
                messageLabel.Content = "Please enter a valid five digit zip code.";
            }
            else
            {
                editCustomer.Parameters.AddWithValue("@c_id", c_idToEdit);
                editCustomer.Parameters.AddWithValue("@LName", lnameBox.Text.Trim());
                editCustomer.Parameters.AddWithValue("@FName", fnameBox.Text.Trim());
                editCustomer.Parameters.AddWithValue("@company", companyBox.Text.Trim());
                editCustomer.Parameters.AddWithValue("@address1", add1Box.Text.Trim());
                editCustomer.Parameters.AddWithValue("@address2", add2Box.Text.Trim());
                editCustomer.Parameters.AddWithValue("@city", cityBox.Text.Trim());
                editCustomer.Parameters.AddWithValue("@state", stateComboBox.Text.Trim());
                editCustomer.Parameters.AddWithValue("@zip", zipBox.Value);
                editCustomer.Parameters.AddWithValue("@phone1", phone1Box.Value);
                editCustomer.Parameters.AddWithValue("@phone2", phone2Box.Value);
                editCustomer.Parameters.AddWithValue("@email", emailBox.Text.Trim());

                var referenceToMainWindow = (MainWindow)Window.GetWindow(this).Owner;

                try
                {
                    editCustomer.ExecuteNonQuery();
                    Shared.ramdbConnection.Close();
                    //messageLabel.Content = "Customer information successfully updated.";
                    refreshListView();
                    reFilterListView();
                    reselectCustomer();
                    Close();
                }
                catch
                {
                    messageLabel.Content = "Error saving to database.";
                    Shared.ramdbConnection.Close();
                }
            }

        }

        private void closeCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //These 2 methods to only accept numbers and dashes in certain text boxes
        private static bool NumTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void OnlyNumInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumTextAllowed(e.Text);
        }

        //These 2 methods to only accept letters in certain text boxes
        private static bool LetterTextAllowed(string text)
        {
            Regex regex = new Regex("[^A-Za-z]+$"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void OnlyLetterInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !LetterTextAllowed(e.Text);
        }

        int indexOfSelectedCustomer;
        public void refreshListView()
        {
            try
            {
                var referenceToOwner = (MainWindow)this.Owner;
                var referenceToCustomerListView = (CustomerData)referenceToOwner.FindResource("CustomerList");
                indexOfSelectedCustomer = Convert.ToInt32(referenceToOwner.customerListView.SelectedIndex);
                referenceToCustomerListView.refreshListView();
            }
            catch
            {
                var referenceToOwner = (TicketWindow)this.Owner;
                var referenceToCustomerComboBox = (CustomerData)referenceToOwner.FindResource("CustomerList");
                indexOfSelectedCustomer = Convert.ToInt32(referenceToOwner.customerComboBox.SelectedIndex);
                referenceToCustomerComboBox.refreshListView();
                try
                {
                    var referenceToOwnerOwner = (MainWindow)this.Owner.Owner;
                    var referenceToCustomerListView = (CustomerData)referenceToOwnerOwner.FindResource("CustomerList");
                    indexOfSelectedCustomer = Convert.ToInt32(referenceToOwnerOwner.customerListView.SelectedIndex);
                    referenceToCustomerListView.refreshListView();
                }
                catch { }
            }
        }

        public void reFilterListView()
        {
            var referenceToOwner = (MainWindow)this.Owner;
            customerFilterItem selectedFilter = referenceToOwner.customerFilterComboBox.SelectedItem as customerFilterItem;
            if (selectedFilter.filterString == "With Open Tickets")
            {
                referenceToOwner.filterCustomers();
            }
                
        }

        public void reselectCustomer()
        {
            try
            {
                var referenceToOwner = (MainWindow)this.Owner;
                for (int i = 0; i < referenceToOwner.customerListView.Items.Count; i++)
                {
                    CustomerItem item = referenceToOwner.customerListView.Items.GetItemAt(i) as CustomerItem;
                    if (item.C_id == c_idToEdit)
                    {
                        referenceToOwner.customerListView.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch
            {
                var referenceToOwner = (TicketWindow)this.Owner;
                for (int i = 0; i < referenceToOwner.customerComboBox.Items.Count; i++)
                {
                    CustomerItem item = referenceToOwner.customerComboBox.Items.GetItemAt(i) as CustomerItem;
                    if (item.C_id == c_idToEdit)
                    {
                        referenceToOwner.customerComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}

