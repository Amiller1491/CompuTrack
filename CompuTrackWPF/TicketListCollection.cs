using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CompuTrackWPF
{
    class TicketListCollection : ObservableCollection<TicketItem>
    {
        public TicketListCollection() : base()
        {            
            
        }
    }

    public class TicketItem
    {
        private string date;
        private int ticketNo;
        private string status;
        private string type;
        private string make;
        private string model;



        public TicketItem(string date, int ticketNo, string status, string type, string make, string model)
        {
            this.date = date;
            this.ticketNo = ticketNo;
            this.status = status;
            this.type = type;
            this.make = make;
            this.model = model;
        }

        public string dateString
        {
            get { return date; }
            set { date = value; }
        }

        public int ticketNoInt
        {
            get { return ticketNo; }
            set { ticketNo = value; }
        }

        public string statusString
        {
            get { return status; }
            set { status = value; }
        }

        public string typeString
        {
            get { return type; }
            set { type = value; }
        }

        public string makeString
        {
            get { return make; }
            set { make = value; }
        }

        public string modelString
        {
            get { return model; }
            set { model = value; }
        }

    }
}
