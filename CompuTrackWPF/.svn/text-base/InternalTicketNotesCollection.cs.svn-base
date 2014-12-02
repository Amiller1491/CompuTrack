using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CompuTrackWPF
{
    class InternalTicketNotesCollection : ObservableCollection<TicketNoteItem>
    {
        public InternalTicketNotesCollection(): base()
        {
            //Add(new TicketNoteItem("Add new note", "", ""));
        }
    }

    public class TicketNoteItem
    {
        private string userName;
        private string dateCreated;
        private string note;
        private int noteNo;

        public TicketNoteItem(string userName, string dateCreated, string note, int noteNo)
        {
            this.userName = userName;
            this.dateCreated = dateCreated;
            this.note = note;
            this.noteNo = noteNo;
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

        public string noteString
        {
            get { return note; }
            set { note = value; }
        }

        public int noteNoInt
        {
            get { return noteNo; }
            set { noteNo = value; }
        }

        public string visibleString
        {
            get { return dateCreated + " - " + userName; }
        }
    }
}
