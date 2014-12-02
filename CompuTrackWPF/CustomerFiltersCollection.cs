using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CompuTrackWPF
{
    class CustomerFiltersCollection : ObservableCollection<customerFilterItem>
    {
        public CustomerFiltersCollection(): base()
        {
            Add(new customerFilterItem("All Customers"));
            Add(new customerFilterItem("With Open Tickets"));
        }
    }

    public class customerFilterItem
    {
        private string filter;

        public customerFilterItem(string filter)
        {
            this.filter = filter;
        }

        public string filterString
        {
            get { return filter; }
            set { filter = value; }
        }
    }
}
