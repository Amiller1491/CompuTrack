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
    /// Interaction logic for InternalTicketWindow.xaml
    /// </summary>
    public partial class InternalTicketWindow : Window
    {
        int ticketNo;

        public InternalTicketWindow(int ticketNo)
        {
            InitializeComponent();
            this.ticketNo = ticketNo;
            populateNoteList(ticketNo);
            populateCommList(ticketNo);
            populateInternalTicket(ticketNo);
        }

        #region Populate Lists Bound to Comboboxes
        public void populateNoteList(int ticketNo)
        {
            var referenceToNoteList = (InternalTicketNotesCollection)FindResource("NotesList");
            referenceToNoteList.Add(new TicketNoteItem("Add new note", "", "", 0));
            try
            {
                Shared.ramdbConnection.Open();
                try
                {
                    SqlCommand getNotes = new SqlCommand("SELECT NoteNo, Note, Creator, Date FROM TicketNotes WHERE TicketNo = @ticketno");
                    getNotes.Connection = Shared.ramdbConnection;
                    getNotes.Parameters.AddWithValue("@ticketno", ticketNo);
                    SqlDataReader noteReader = getNotes.ExecuteReader();
                    while (noteReader.Read())
                    {
                        referenceToNoteList.Add(new TicketNoteItem(noteReader["Creator"].ToString(), noteReader["Date"].ToString(), noteReader["Note"].ToString(), Convert.ToInt32(noteReader["NoteNo"])));
                    }
                    Shared.ramdbConnection.Close();
                }
                catch { }
            }
            catch { }
        }

        public void populateCommList(int ticketNo)
        {
            var referenceToCommLog = (InternalTicketCommLogCollection)FindResource("CommLogList");
            referenceToCommLog.Add(new TicketCommLogItem("Add new entry", "", "", 0));
            try
            {
                Shared.ramdbConnection.Open();
                try
                {
                    SqlCommand getComm = new SqlCommand("SELECT EntryNo, ComEntry, Creator, Date FROM TicketComLog WHERE TicketNo = @ticketno");
                    getComm.Connection = Shared.ramdbConnection;
                    getComm.Parameters.AddWithValue("@ticketno", ticketNo);
                    SqlDataReader commReader = getComm.ExecuteReader();
                    while (commReader.Read())
                    {
                        referenceToCommLog.Add(new TicketCommLogItem(commReader["Creator"].ToString(), commReader["Date"].ToString(), commReader["ComEntry"].ToString(), Convert.ToInt32(commReader["EntryNo"])));
                    }
                    Shared.ramdbConnection.Close();
                }
                catch { }
            }
            catch { }
        }
        #endregion
        #region Selection Change for Comboboxes
        private void noteSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            TicketNoteItem selectedNote = NotesComboBox.SelectedItem as TicketNoteItem;
            if (selectedNote != null)
            {
                NoteTxBx.Text = selectedNote.noteString;
                if (selectedNote.userNameString == "Add new note")
                {
                    saveNoteBtn.Visibility = Visibility.Visible;
                }
                else saveNoteBtn.Visibility = Visibility.Hidden;
            }
        }

        private void commLogSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            TicketCommLogItem selectedEntry = LogComboBox.SelectedItem as TicketCommLogItem;
            if (selectedEntry != null)
            {
                CommLogTxBx.Text = selectedEntry.commEntryString;
                if (selectedEntry.userNameString == "Add new entry")
                {
                    saveLogBtn.Visibility = Visibility.Visible;
                }
                else saveLogBtn.Visibility = Visibility.Hidden;
            }
        }
        #endregion

        private void populateInternalTicket(int ticketNo)
        {
            try
            {
                Shared.ramdbConnection.Open();
            }
            catch
            {
                lblMessage.Content = "Could not open SQL connection.";
            }
            SqlCommand populateInternalTicket = new SqlCommand("SELECT HddDiag, MemoryDiag, OtherHardware, WorkSummary FROM TicketsInternal WHERE TicketNo = @ticketno", Shared.ramdbConnection);
            populateInternalTicket.Parameters.AddWithValue("@ticketno", ticketNo);
            SqlCommand populateStatus = new SqlCommand("SELECT Status FROM Tickets WHERE TicketNo = @ticketno", Shared.ramdbConnection);
            populateStatus.Parameters.AddWithValue("@ticketno", ticketNo);

            try
            {
                SqlDataReader statusReader = populateStatus.ExecuteReader();
                while (statusReader.Read())
                {
                    for (int i = 0; i < statusComboBox.Items.Count; i++)
                    {
                        StatusItem item = statusComboBox.Items.GetItemAt(i) as StatusItem;
                        if (item.statusString == statusReader["Status"].ToString())
                        {
                            statusComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                }
                Shared.ramdbConnection.Close();
            }

            catch
            {
                lblMessage.Content = "Unable to pull ticket status.";
            }
            try
            {
                Shared.ramdbConnection.Open();
                SqlDataReader internalticketReader = populateInternalTicket.ExecuteReader();
                while (internalticketReader.Read())
                {
                    if (internalticketReader["HddDiag"].ToString() == "Pass") { hddPassRadio.IsChecked = true; }
                    else if (internalticketReader["HddDiag"].ToString() == "Fail") { hddFailRadio.IsChecked = true; }
                    if (internalticketReader["MemoryDiag"].ToString() == "Pass") { memoryPassRadio.IsChecked = true; }
                    else if (internalticketReader["MemoryDiag"].ToString() == "Fail") { memoryFailRadio.IsChecked = true; }
                    workDoneTxBx.Text = internalticketReader["WorkSummary"].ToString();
                    badHardwareTextBox.Text = internalticketReader["OtherHardware"].ToString();
                    ticketNoLbl.Content = ticketNo;
                }
                Shared.ramdbConnection.Close();
            }
            catch
            {
                lblMessage.Content = "Error auto-filling fields.";
                Shared.ramdbConnection.Close();
            }
        }
        public void saveInternalTicket(int ticketNo)
        {
            try
            {
                Shared.ramdbConnection.Open();
                }
                catch
                {
                    lblMessage.Content = "Could not open SQL connection.";
                }
            SqlCommand saveInternalTicket = new SqlCommand("UPDATE TicketsInternal SET OtherHardware = @otherHardware, HddDiag = @hddDiag, MemoryDiag = @memoryDiag, WorkSummary = @workSummary WHERE TicketNo = @ticketno");
            saveInternalTicket.Connection = Shared.ramdbConnection;
            saveInternalTicket.Parameters.AddWithValue("@ticketno", ticketNo);
            if (hddPassRadio.IsChecked == true) saveInternalTicket.Parameters.AddWithValue("@hddDiag", "Pass");
            else if (hddFailRadio.IsChecked == true) saveInternalTicket.Parameters.AddWithValue("@hddDiag", "Fail");
            else saveInternalTicket.Parameters.AddWithValue("@hddDiag", "Untested");
            if (memoryPassRadio.IsChecked == true) saveInternalTicket.Parameters.AddWithValue("@memoryDiag", "Pass");
            else if (memoryFailRadio.IsChecked == true) saveInternalTicket.Parameters.AddWithValue("@memoryDiag", "Fail");
            else saveInternalTicket.Parameters.AddWithValue("@memoryDiag", "Untested");
            saveInternalTicket.Parameters.AddWithValue("@workSummary", workDoneTxBx.Text.Trim());
            saveInternalTicket.Parameters.AddWithValue("@otherHardware", badHardwareTextBox.Text.Trim());

            SqlCommand saveTicketStatus = new SqlCommand("UPDATE Tickets SET Status = @status WHERE TicketNo = @ticketno", Shared.ramdbConnection);
            saveTicketStatus.Parameters.AddWithValue("@ticketno", ticketNo);
            StatusItem statusItem = statusComboBox.SelectedItem as StatusItem;
            saveTicketStatus.Parameters.AddWithValue("@status", statusItem.statusString);

            try
            {
                saveInternalTicket.ExecuteNonQuery();
                Shared.ramdbConnection.Close();
                Shared.ramdbConnection.Open();
                saveTicketStatus.ExecuteNonQuery();
                Shared.ramdbConnection.Close();
                refreshListView();
                reselectCustomer();
                reselectTicket();
                Close();
            }
            catch
            {
                lblMessage.Content = "Error saving to database.";
                Shared.ramdbConnection.Close();
            }
        }

        #region Status Combobox Stuff
        private void statusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatusItem status = statusComboBox.SelectedItem as StatusItem;
            if (status.statusString == "Not Started")
            {
                disableAllItems();
            }
            else { enableAllItems(); }
        }

        private void enableAllItems()
        {
            hddPassRadio.IsEnabled = true;
            hddFailRadio.IsEnabled = true;
            memoryPassRadio.IsEnabled = true;
            memoryFailRadio.IsEnabled = true;
            badHardwareTextBox.IsEnabled = true;
            workDoneTxBx.IsEnabled = true;
            NotesComboBox.IsEnabled = true;
            LogComboBox.IsEnabled = true;
            NoteTxBx.IsEnabled = true;
            CommLogTxBx.IsEnabled = true;
            saveLogBtn.IsEnabled = true;
            saveNoteBtn.IsEnabled = true;
        }

        private void disableAllItems()
        {
            hddPassRadio.IsEnabled = false;
            hddFailRadio.IsEnabled = false;
            memoryPassRadio.IsEnabled = false;
            memoryFailRadio.IsEnabled = false;
            badHardwareTextBox.IsEnabled = false;
            workDoneTxBx.IsEnabled = false;
            NotesComboBox.IsEnabled = false;
            LogComboBox.IsEnabled = false;
            NoteTxBx.IsEnabled = false;
            CommLogTxBx.IsEnabled = false;
            saveLogBtn.IsEnabled = false;
            saveNoteBtn.IsEnabled = false;
        }
        #endregion

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            saveInternalTicket(ticketNo);
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region refresh ticketlistview
        int indexOfSelectedCustomer;
        CustomerItem selectedCustomer;
        public void refreshListView()
        {
            var referenceToOwner = (MainWindow)this.Owner;
            var referenceToCustomerListView = (CustomerData)referenceToOwner.FindResource("CustomerList");
            indexOfSelectedCustomer = Convert.ToInt32(referenceToOwner.customerListView.SelectedIndex);
            selectedCustomer = referenceToOwner.customerListView.SelectedItem as CustomerItem;
            referenceToCustomerListView.refreshListView();
        }

        public void reselectCustomer()
        {
            var referenceToOwner = (MainWindow)this.Owner;
            for (int i = 0; i < referenceToOwner.customerListView.Items.Count; i++)
            {
                CustomerItem item = referenceToOwner.customerListView.Items.GetItemAt(i) as CustomerItem;
                if (item.C_id == selectedCustomer.C_id)
                {
                    referenceToOwner.customerListView.SelectedIndex = i;
                    break;
                }
            }
        }

        public void reselectTicket()
        {
            var referenceToOwner = (MainWindow)this.Owner;
            for (int i = 0; i < referenceToOwner.ticketListView.Items.Count; i++)
            {
                TicketItem item = referenceToOwner.ticketListView.Items.GetItemAt(i) as TicketItem;
                if (item.ticketNoInt == ticketNo)
                {
                    referenceToOwner.ticketListView.SelectedIndex = i;
                    break;
                }
            }
        }
        #endregion

        #region Save Notes and Save Communication Log Entries
        #region Save Notes
        int newNoteNo;
        private void saveNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NoteTxBx.Text.Trim() == "") { lblMessage.Content = "Note may not be empty."; }
            else
            {
                saveNote();
                refreshNoteComboBox();
                selectNewNote();
            }
        }

        private void saveNote()
        {
            try
            {
                Shared.ramdbConnection.Open();
                try
                {
                    SqlCommand saveNoteCmd = new SqlCommand("INSERT into TicketNotes (Note, Creator, TicketNo) Values (@note, @creator, @ticketno)" +
                        "SELECT NoteNo FROM TicketNotes WHERE NoteNo = SCOPE_IDENTITY()", Shared.ramdbConnection);
                    saveNoteCmd.Parameters.AddWithValue("@note", NoteTxBx.Text.Trim());
                    saveNoteCmd.Parameters.AddWithValue("@creator", Shared.currentUser._userName);
                    saveNoteCmd.Parameters.AddWithValue("@ticketno", ticketNo);

                    SqlDataReader saveNoteReader = saveNoteCmd.ExecuteReader();
                    while (saveNoteReader.Read())
                    {
                        newNoteNo = Convert.ToInt32(saveNoteReader["NoteNo"]);
                    }
                    Shared.ramdbConnection.Close();
                }
                catch { lblMessage.Content = "Unable to save note into database."; Shared.ramdbConnection.Close(); }
            }
            catch { lblMessage.Content = "Unable to open SQL connection to save note."; Shared.ramdbConnection.Close(); }
        }

        private void refreshNoteComboBox()
        {
            var referenceToNoteList = (InternalTicketNotesCollection)FindResource("NotesList");
            referenceToNoteList.Clear();
            populateNoteList(ticketNo);
        }

        private void selectNewNote()
        {
            for (int i = 0; i < NotesComboBox.Items.Count; i++)
            {
                TicketNoteItem item = NotesComboBox.Items.GetItemAt(i) as TicketNoteItem;
                if (item.noteNoInt == newNoteNo)
                {
                    NotesComboBox.SelectedIndex = i;
                    break;
                }
            }
        }
        #endregion

        #region Save Communication Log
        int newEntryNo;
        private void saveLogBtn_Click(object sender, RoutedEventArgs e)
        {
            saveEntry();
            refreshComLogComboBox();
            selectNewEntry();
        }
        private void saveEntry()
        {
            try
            {
                Shared.ramdbConnection.Open();
                try
                {
                    SqlCommand saveNoteCmd = new SqlCommand("INSERT into TicketComLog (ComEntry, Creator, TicketNo) Values (@comEntry, @creator, @ticketno)" +
                        "SELECT EntryNo FROM TicketComLog WHERE EntryNo = SCOPE_IDENTITY()", Shared.ramdbConnection);
                    saveNoteCmd.Parameters.AddWithValue("@comEntry", CommLogTxBx.Text.Trim());
                    saveNoteCmd.Parameters.AddWithValue("@creator", Shared.currentUser._userName);
                    saveNoteCmd.Parameters.AddWithValue("@ticketno", ticketNo);

                    SqlDataReader saveNoteReader = saveNoteCmd.ExecuteReader();
                    while (saveNoteReader.Read())
                    {
                        newEntryNo = Convert.ToInt32(saveNoteReader["EntryNo"]);
                    }
                    Shared.ramdbConnection.Close();
                }
                catch { lblMessage.Content = "Unable to save entry into database."; Shared.ramdbConnection.Close(); }
            }
            catch { lblMessage.Content = "Unable to open SQL connection to save entry."; Shared.ramdbConnection.Close(); }
        }

        private void refreshComLogComboBox()
        {
            var referenceToCommLog = (InternalTicketCommLogCollection)FindResource("CommLogList");
            referenceToCommLog.Clear();
            populateCommList(ticketNo);
        }

        private void selectNewEntry()
        {
            for (int i = 0; i < NotesComboBox.Items.Count; i++)
            {
                TicketCommLogItem item = LogComboBox.Items.GetItemAt(i) as TicketCommLogItem;
                if (item.entryNoInt == newEntryNo)
                {
                    LogComboBox.SelectedIndex = i;
                    break;
                }
            }
        }
        #endregion
        #endregion
    }
}
