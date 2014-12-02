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
using System.Collections.ObjectModel;
using System.ComponentModel;
using CompuTrackWPF;

namespace CompuTrackWPF
{
    public class SortableListView : ListView
    {
        public SortableListView() : base()
        {            
        }

        GridViewColumnHeader lastClicked = null;
        ListSortDirection lastDirection = ListSortDirection.Ascending;        

        public ListSortDirection getSortDirection(GridViewColumnHeader clicked)
        {
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("SortArrowsDictionary.xaml", UriKind.Relative);
            ListSortDirection direction = ListSortDirection.Ascending;

            //remove previous directional arrow from header
            //string header = clicked.Column.Header.ToString();
            //if (header.Contains("⇓") || header.Contains("⇑"))
            //{
            //    string[] strings = header.Split(' ');
            //    header = strings[0];
            //    for (int i = 1; i < strings.Length - 1; i++) { header += " " + strings[i]; }
            //}

            //remove arrows from previous headers
            //if (lastClicked != null)
            //{
            //    string previousHeader = lastClicked.Column.Header.ToString();
            //    if (previousHeader.Contains("⇓") || previousHeader.Contains("⇑"))
            //    {
            //        string[] strings = previousHeader.Split(' ');
            //        previousHeader = strings[0];
            //        for (int i = 1; i < strings.Length - 1; i++) { previousHeader += " " + strings[i]; }
            //    }
            //    lastClicked.Column.Header = previousHeader;
            //}

            //figure out sort direction
            if (clicked != lastClicked)
            {
                if (lastClicked != null) direction = ListSortDirection.Ascending;
                else direction = ListSortDirection.Descending;
            }
            else if (clicked == lastClicked)
            {
                if (lastDirection == ListSortDirection.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
            }

            //assign arrow to go with direction to the header name
            if (direction == ListSortDirection.Ascending)
            {                
                clicked.Column.HeaderTemplate = rd["HeaderTemplateAscending"] as DataTemplate;
                //clicked.Column.Header = header + " ⇑";
            }
            else
            {
                clicked.Column.HeaderTemplate = rd["HeaderTemplateDescending"] as DataTemplate;
                //clicked.Column.Header = header + " ⇓";
            }

            if (lastClicked != null && lastClicked != clicked)
            {
                lastClicked.Column.HeaderTemplate = null;
            }

            lastClicked = clicked;
            lastDirection = direction;
            return direction;
        }

    }
}
