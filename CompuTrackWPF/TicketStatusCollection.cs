using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CompuTrackWPF
{
    class TicketStatusCollection : ObservableCollection<StatusItem>
    {
        public TicketStatusCollection(): base()
        {            
            Add(new StatusItem("Not Started"));
            Add(new StatusItem("In Progress"));
            Add(new StatusItem("On Hold"));
            Add(new StatusItem("Complete"));
            Add(new StatusItem("Closed"));
        }
    }

    public class StatusItem
    {
        private string status;

        public StatusItem(string status)
        {
            this.status = status;
        }

        public string statusString
        {
            get { return status; }
            set { status = value; }
        }
    }
}

