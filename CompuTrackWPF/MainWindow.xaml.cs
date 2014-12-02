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
using System.Data;
using CompuTrackWPF;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Configuration;

namespace CompuTrackWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            Shared.ramdbConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ramdbConnectionString"].ConnectionString;
            InitializeComponent();
            manageUsersOption.Visibility = Visibility.Collapsed;
            signOutOption.Visibility = Visibility.Collapsed;            
            DisableItems();
            PopulateStatusComboBox();
        }


        #region Customers ListView
        public void PopulateCustomersListView()
        {
            try
            {
                Shared.ramdbConnection.Open();
            }
            catch
            {
                customerListView.Items.Add("Cannot open SQL connection.");
            }
            SqlCommand populateCustomersCmd = new SqlCommand("SELECT C_id, LName, FName FROM Customers ORDER BY LName ASC");
            populateCustomersCmd.Connection = Shared.ramdbConnection;
            SqlDataReader customersReader = populateCustomersCmd.ExecuteReader();
            while (customersReader.Read())
            {
                customerListView.Items.Add(customersReader["LName"].ToString() + ", " + customersReader["FName"].ToString() + " - [" + customersReader["C_id"].ToString() + "]");
            }
            Shared.ramdbConnection.Close();
        }

        public void clearCustomersListView()
        {
            customerListView.Items.Clear();
        }
        #endregion

        #region Menu Items

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PDF_Output print = new PDF_Output();
            print.write_stream(sender, e);
        }

        private void MenuClick_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void inventoryPageCall_Click(object sender, RoutedEventArgs e)
        {
            openNewItemWindow();
        }

        public void openNewItemWindow()
        {
            InventoryMain inventoryMain = inventoryFrame.Content as InventoryMain;
            ItemWindow iw = new ItemWindow(inventoryMain);
            iw.Owner = this;
            iw.ShowDialog();
        }

        private void newCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow cw = new CustomerWindow();
            cw.Owner = this;
            cw.ShowDialog();
        }

        private void newTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            TicketWindow tw = new TicketWindow();
            tw.Owner = this;
            tw.ShowDialog();
        }
        #endregion

        #region Login System
        Boolean loginShown = false;
        private void selectAllText(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;            
            if (textBox != null)
                textBox.SelectAll();
        }

        private void selectPassword(object sender, RoutedEventArgs e)
        {
            var passwordBox = e.OriginalSource as PasswordBox;
            if (passwordBox != null)
                passwordBox.SelectAll();
        }

        private void LoginSplitClick(object sender, RoutedEventArgs e)
        {
            loginButton();
        }

        private void loginButton()
        {
            if (loginShown == false && Shared.currentUser == null)
            {
                Storyboard loginStoryboardShow = (Storyboard)FindResource("loginStoryboardShow");
                loginStoryboardShow.Begin(this);
                loginShown = true;
                userNameBox.Focus();
            }
            else if (loginShown == true)
            {
                try
                {
                    Shared.ramdbConnection.Open();
                }
                catch
                {
                    loginMessageLabel.Content = "Cannot open SQL connection.";
                }
                SqlCommand loginCommand = new SqlCommand("SELECT * FROM Users WHERE Username = @name AND Password = @password");
                loginCommand.Connection = Shared.ramdbConnection;
                loginCommand.Parameters.AddWithValue("@name", userNameBox.Text);
                loginCommand.Parameters.AddWithValue("@password", passwordBox.Password);
                SqlDataReader loginReader = loginCommand.ExecuteReader();
                while (loginReader.Read())
                {
                    if ((loginReader["Username"].ToString() == userNameBox.Text)
                        && (loginReader["Password"].ToString() == passwordBox.Password))
                    {
                        Shared.currentUser = new User(userNameBox.Text, passwordBox.Password, Convert.ToInt32(loginReader["Permissions"].ToString()));
                        loginSplitBtn.Content = Shared.currentUser._userName;
                        Storyboard loginStoryboardHide = (Storyboard)FindResource("loginStoryboardHide");
                        loginStoryboardHide.Begin(this);
                        loginShown = false;
                        signOutOption.Visibility = Visibility.Visible;
                        if (Shared.currentUser._permissions >= 1)
                        {
                            manageUsersOption.Visibility = Visibility.Visible;
                        }
                        EnableItems();                        
                    }
                }
                if (Shared.currentUser == null) loginMessageLabel.Content = "Invalid Username/Password combination.";
                Shared.ramdbConnection.Close();
            }
        }

        private void EnableItems()
        {
            customersTabGrid.IsEnabled = true;
            newTicketMenuItem.IsEnabled = true;
            newCustomerMenuItem.IsEnabled = true;
            newItemMenuItem.IsEnabled = true;
            newLogMenuItem.IsEnabled = true;
            inventoryFrame.IsEnabled = true;
            FrontDeskMenuItem.IsEnabled = true;
            tempLabel.Visibility = Visibility.Hidden; //temp

            InventoryMain im = inventoryFrame.Content as InventoryMain;
            im.naughtyBlock.Visibility = System.Windows.Visibility.Visible;
            im.getMainWindow(this); //ugly but it gets the job done
        }

        private void DisableItems()
        {
            customersTabGrid.IsEnabled = false;
            newTicketMenuItem.IsEnabled = false;
            customerCanvas.Visibility = Visibility.Hidden;
            newCustomerMenuItem.IsEnabled = false;
            newLogMenuItem.IsEnabled = false;
            newItemMenuItem.IsEnabled = false;
            inventoryFrame.IsEnabled = false;
            FrontDeskMenuItem.IsEnabled = false;

            InventoryMain im = inventoryFrame.Content as InventoryMain;
            try
            {
                im.naughtyBlock.Visibility = System.Windows.Visibility.Hidden; //this line throws something i don't know what it means
            }
            catch { }

            tempLabel.Visibility = Visibility.Visible; //temp
        }

        public static RoutedCommand signOutRoutedCommand = new RoutedCommand();
        public static RoutedCommand manageUsersRoutedCommand = new RoutedCommand();

        private void ExecuteSignOutCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Shared.currentUser = null;
            signOutOption.Visibility = Visibility.Collapsed;
            manageUsersOption.Visibility = Visibility.Collapsed;
            loginSplitBtn.Content = "Log in";
            userNameBox.Text = "Username";
            passwordBox.Password = "password";
            loginMessageLabel.Content = "";
            loginSplitBtn.IsOpen = false;
            DisableItems();
        }

        private void ExecuteManageUsersCommand(object sender, ExecutedRoutedEventArgs e)
        {
            ManageUsersWindow manageWindow = new ManageUsersWindow();
            manageWindow.Owner = this;
            manageWindow.Show();
            loginSplitBtn.IsOpen = false;
        }

        private void CanExecuteCustomCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void onEnterKey(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return && e.Key != Key.Enter)
                return;
            e.Handled = true;
            loginButton();
        }
        #endregion

        #region CustomerCanvas
        String Fname;
        String Lname;
        String Email;
        String Address1;
        String Address2;
        String City;
        String State;
        String Zip;
        String phone1;
        String phone2;
        int idNum;
        //int[] ticketNo = new int[100];
        TicketItem[] ticketItems = new TicketItem[100];

        private void editCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow editCustomer = new CustomerWindow(idNum);
            editCustomer.Owner = this;
            editCustomer.fnameBox.Text = Fname;
            editCustomer.lnameBox.Text = Lname;
            editCustomer.emailBox.Text = Email;
            editCustomer.add1Box.Text = Address1;
            editCustomer.add2Box.Text = Address2;
            editCustomer.cityBox.Text = City;
            editCustomer.stateComboBox.Text = State;
            editCustomer.zipBox.Value = Zip;
            editCustomer.phone1Box.Value = phone1;
            editCustomer.phone2Box.Value = phone2;
            editCustomer.ShowDialog();
        }

        private void clearCustomerStrings()
        {
            Fname = null;
            Lname = null;
            Email = null;
            Address1 = null;
            Address2 = null;
            City = null;
            State = null;
            Zip = null;
            phone1 = null;
            phone2 = null;
        }

        private void customerListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            clearCustomerStrings();
            editTicketDropDownBtn.IsEnabled = false;
            //editTicketBtn.IsEnabled = false;
            //intTicketBtn.IsEnabled = false;
            if (customerListView.SelectedItem != null)
            {
                SelectCustLabel.Visibility = Visibility.Hidden;
                CustomerItem custIt = (CustomerItem)this.customerListView.SelectedItem;
                idNum = custIt.C_id;
                String custName;
                String fullAddress;

                try
                {
                    Shared.ramdbConnection.Open();
                }
                catch
                {
                }
                SqlCommand findCustInfoCommand = new SqlCommand("SELECT FName, LName, Add1, Add2, City, State, Zip, Phone1, Phone2, Email FROM Customers WHERE C_id = @c_id ");
                SqlCommand getTickets = new SqlCommand("SELECT TicketNo, DateCreated, Type, Make, Model, Status FROM Tickets WHERE C_id = @c_id");
                getTickets.Connection = Shared.ramdbConnection;
                findCustInfoCommand.Connection = Shared.ramdbConnection;
                findCustInfoCommand.Parameters.AddWithValue("@c_id", idNum);
                getTickets.Parameters.AddWithValue("@c_id", idNum);
                SqlDataReader customerInfoReader = findCustInfoCommand.ExecuteReader();
                while (customerInfoReader.Read())
                {
                    Fname = customerInfoReader["FName"].ToString();
                    Lname = customerInfoReader["LName"].ToString();
                    custName = Lname + ", " + Fname;
                    Email = customerInfoReader["Email"].ToString();
                    Address1 = customerInfoReader["Add1"].ToString();
                    Address2 = customerInfoReader["Add2"].ToString();
                    City = customerInfoReader["City"].ToString();
                    State = customerInfoReader["State"].ToString();
                    Zip = customerInfoReader["Zip"].ToString();
                    phone1 = String.Format("{0:(###) ###-####}", Convert.ToInt64(customerInfoReader["Phone1"]));
                    if (!customerInfoReader["Phone2"].ToString().Equals("")) { phone2 = String.Format("{0:(###) ###-####}", Convert.ToInt64(customerInfoReader["Phone2"])); }
                    fullAddress = Address1 + "\n" + City + ", " +   State + " " + Zip;
                    customerName.Content = custName;
                    email.Content = Email;
                    address.Content = fullAddress;
                    if (phone2 == null) { phoneNumbersLabel.Content = phone1; }
                    else { phoneNumbersLabel.Content = phone1 + " / " + phone2; }
                }
                Shared.ramdbConnection.Close();
                try {Shared.ramdbConnection.Open(); }
                catch { MessageBox.Show("can't open connection"); }
                SqlDataReader ticketNoReader = getTickets.ExecuteReader();
                System.Array.Clear(ticketItems, 0, 99);
                for (int i = 0; ticketNoReader.Read(); i++)
                {
                    string dateCreatedParse = ticketNoReader["DateCreated"].ToString().Remove(9);
                    ticketItems[i] = new TicketItem(dateCreatedParse, Convert.ToInt32(ticketNoReader["TicketNo"]), ticketNoReader["Status"].ToString(), ticketNoReader["Type"].ToString(), ticketNoReader["Make"].ToString(), ticketNoReader["Model"].ToString());
                }

                PopulateTicketListView();

                Shared.ramdbConnection.Close();
                customerCanvas.Visibility = Visibility.Visible;
            }
        }

        public void PopulateStatusComboBox()
        {
            var referenceToStatusList = (TicketStatusCollection)FindResource("StatusList");
            referenceToStatusList.Insert(0, new StatusItem("All"));
            statusComboBox.SelectedIndex = 0;
        }

        public void PopulateTicketListView()
        {
            var referenceToTicketList = (TicketListCollection)FindResource("TicketList");
            referenceToTicketList.Clear();
            for (int i = 0; i < ticketItems.Length; i++)
            {
                if (ticketItems[i] != null)
                {
                    referenceToTicketList.Add(ticketItems[i]);
                }
            }
        }

        private void ticketListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ticketListView.SelectedItem != null)
            {
                editTicketDropDownBtn.IsEnabled = true;
                //editTicketBtn.IsEnabled = true;
                //intTicketBtn.IsEnabled = true;
            }
        }

        private void newTicketAutoSelectCustomer(object sender, RoutedEventArgs e)
        {
            TicketWindow tw = new TicketWindow();
            tw.Owner = this;
            CustomerItem selectedCustomer = customerListView.SelectedItem as CustomerItem;
            int reselectID = selectedCustomer.C_id;
            for (int i = 0; i < tw.customerComboBox.Items.Count; i++)
            {
                CustomerItem item = tw.customerComboBox.Items.GetItemAt(i) as CustomerItem;
                if (item.C_id == reselectID)
                {
                    tw.customerComboBox.SelectedIndex = i;
                    break;
                }

            }       
            tw.ShowDialog();
        }
        #endregion

        #region Filtering

        private void filterTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (customerListView != null)
            {
                ICollectionView customerDataView = CollectionViewSource.GetDefaultView(customerListView.ItemsSource);
                customerDataView.Filter = new Predicate<object>(CustomerFilter);
            }

        }

        public bool CustomerFilter(object ob)
        {
            CustomerItem customer = ob as CustomerItem;
            String filterString = (filterTxtBox.Text).ToLower();
            String customerName = (customer.FullNameString).ToLower();
            if (customerName.Contains(filterString)) 
            {
                return true;
            }
            else
            {
                return false;
            }            
            
        }

        private void statusSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ticketListView != null)
            {
                ICollectionView dataView = CollectionViewSource.GetDefaultView(ticketListView.ItemsSource);
                dataView.Filter = new Predicate<object>(ticketFilter);
            }
        }

        public bool ticketFilter(object ob)
        {
            TicketItem ticket = ob as TicketItem;
            int ticketFilterIndex = statusComboBox.SelectedIndex;
            StatusItem status = statusComboBox.Items.GetItemAt(ticketFilterIndex) as StatusItem;
            string ticketFilterString = "";
            if (status != null) ticketFilterString = status.statusString;
            if (ticketFilterString.Equals("All"))
            {
                return true;
            }
            else
            {
                return ticket.statusString == ticketFilterString;
            }
        }

        public void filterCustomers()
        {
            if (customerListView != null)
            {
                ICollectionView dataView = CollectionViewSource.GetDefaultView(customerListView.ItemsSource);
                dataView.Filter = new Predicate<object>(customerStatusFilter);
            }
        }

        private void customerFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterCustomers();
        }

        public bool customerStatusFilter(object ob)
        {
            bool ticketsFound = false;
            CustomerItem customer = ob as CustomerItem;
            int customerFilterIndex = customerFilterComboBox.SelectedIndex;
            customerFilterItem filterItem = customerFilterComboBox.Items.GetItemAt(customerFilterIndex) as customerFilterItem;
            string customerFilterString = "";
            if (filterItem != null) customerFilterString = filterItem.filterString;
            if (customerFilterString.Equals("All Customers"))
            {
                return true;
            }
            else
            {
                try
                {
                    Shared.ramdbConnection.Open();
                    try
                    {
                        int customerID = customer.C_id;
                        SqlCommand findCustomersWithOpenTickets = new SqlCommand("SELECT TicketNo FROM Tickets WHERE C_id = @customerid AND Status <> 'Closed'");
                        findCustomersWithOpenTickets.Connection = Shared.ramdbConnection;
                        findCustomersWithOpenTickets.Parameters.AddWithValue("@customerid", customerID);
                        SqlDataReader findCustomersReader = findCustomersWithOpenTickets.ExecuteReader();
                        while (findCustomersReader.Read() && ticketsFound == false)
                        {
                            ticketsFound = true;
                        }
                        Shared.ramdbConnection.Close();
                    }
                    catch { }
                }
                catch { }
                if (ticketsFound == true) return true;
                else return false;
            }
        }

        #endregion
        

        private void editTicket_Click(object sender, RoutedEventArgs e)
        {
            TicketItem selectedTicket = (TicketItem)ticketListView.SelectedItem;
            int selectedTicketNo = selectedTicket.ticketNoInt;
            TicketWindow editTicket = new TicketWindow(selectedTicketNo);
            editTicket.Owner = this;
            CustomerItem selectedCustomer = customerListView.SelectedItem as CustomerItem;
            int reselectID = selectedCustomer.C_id;
            for (int i = 0; i < editTicket.customerComboBox.Items.Count; i++)
            {
                CustomerItem item = editTicket.customerComboBox.Items.GetItemAt(i) as CustomerItem;
                if (item.C_id == reselectID)
                {
                    editTicket.customerComboBox.SelectedIndex = i;
                    break;
                }

            }       
            editTicket.Show();
        }

        private void window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                var referenceToCustomerList = (CustomerData)FindResource("CustomerList");
                referenceToCustomerList.refreshListView();
            }
        }

        private void Preferences_Click(object sender, RoutedEventArgs e)
        {
            PreferencesWindow pw = new PreferencesWindow(); 
            pw.set_text();
            pw.Owner = this;
            pw.ShowDialog();
        }

        private void FrontDeskMode_Click(object sender, RoutedEventArgs e)
        {
            FrontDeskWindow fw = new FrontDeskWindow();
            fw.Owner = this;
            this.Hide();
            fw.Show();
        }
        private void ticketDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ticketListView.SelectedItem != null)
            {
                TicketItem SelectedTicket = (TicketItem)this.ticketListView.SelectedItem;
                int selectedTicketNo = SelectedTicket.ticketNoInt;
                InternalTicketWindow internalTicket = new InternalTicketWindow(selectedTicketNo);
                internalTicket.Owner = this;
                internalTicket.ShowDialog();
            }
        }
        private void intTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            ticketDoubleClick(this, null);
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.ShowDialog();
        }

        private void inventoryLog_Click(object sender, RoutedEventArgs e)
        {
            InventoryLog log = new InventoryLog();
            log.Owner = this;
            log.ShowDialog();
        }

        private void ticketListView_HeaderClick(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader clicked = e.OriginalSource as GridViewColumnHeader;

            if (clicked != null && clicked.Role != GridViewColumnHeaderRole.Padding)
            {
                string header = clicked.Column.Header as string;
                SortTickets(header, ticketListView.getSortDirection(clicked));
            }
        }

        private void SortTickets(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(ticketListView.ItemsSource);
            dataView.SortDescriptions.Clear();
            if (sortBy.Equals("Date")) sortBy = "dateString";
            if (sortBy.Equals("Ticket No")) sortBy = "ticketNoInt";
            if (sortBy.Equals("Status")) sortBy = "statusString";
            if (sortBy.Equals("Type")) sortBy = "typeString";
            if (sortBy.Equals("Make")) sortBy = "makeString";
            if (sortBy.Equals("Model")) sortBy = "modelString";
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }
    }
}