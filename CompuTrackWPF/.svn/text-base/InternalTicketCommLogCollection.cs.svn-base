using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CompuTrackWPF
{
    class InternalTicketCommLogCollection : ObservableCollection<TicketCommLogItem>
    {
        public InternalTicketCommLogCollection() : base()
        {
            //Add(new TicketNoteItem("Add new entry", "", ""));
        }
    }

    public class TicketCommLogItem
    {
        private string userName;
        private string dateCreated;
        private string commEntry;
        private int entryNo;

        public TicketCommLogItem(string userName, string dateCreated, string commEntry, int entryNo)
        {
            this.userName = userName;
            this.dateCreated = dateCreated;
            this.commEntry = commEntry;
            this.entryNo = entryNo;
        }

        public string userNameString
        {
            get { return userName; }
            set { userName = value; }
        }

        public string dateCreatedString
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public string commEntryString
        {
            get { return commEntry; }
            set { commEntry = value; }
        }

        public int entryNoInt
        {
            get { return entryNo; }
            set { entryNo = value; }
        }

        public string visibleString
        {
            get { return dateCreated + " - " + userName; }
        }
    }
}
