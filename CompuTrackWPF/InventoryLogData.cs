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
    public class InventoryLogData : ObservableCollection<InventoryLogItem>
    {
        public InventoryLogData() : base()
        {
            PopulateInventoryLog();
        }

        private void PopulateInventoryLog()
        {            
            bool connected;

            try
            {
                Shared.ramdbConnection.Open();
                connected = true;
            }
            catch
            {
                connected = false;
            }

            if (connected)
            {
                SqlCommand populateLogCmd = new SqlCommand("SELECT Date, Entry, Reason, MadeBy FROM InventoryLog ORDER BY Date DESC", Shared.ramdbConnection);
                SqlDataReader logReader = populateLogCmd.ExecuteReader();
                while (logReader.Read())
                {
                    string date = logReader["Date"].ToString();
                    string entry = logReader["Entry"].ToString();
                    string reason = logReader["Reason"].ToString();
                    string madeBy = logReader["MadeBy"].ToString();
                    Add(new InventoryLogItem(date, entry, reason, madeBy));
                }

                Shared.ramdbConnection.Close();
            }
        }
    }

    public class InventoryLogItem
    {
        private string _date;
        private string _entry;
        private string _reason;
        private string _madeBy;

        public InventoryLogItem(string date, string entry, string reason, string madeBy)
        {
            this._date = date;
            this._entry = entry;
            this._reason = reason;
            this._madeBy = madeBy;
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Entry
        {
            get { return _entry; }
            set { _entry = value; }
        }

        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        public string MadeBy
        {
            get { return _madeBy; }
            set { _madeBy = value; }
        }
    }
}
