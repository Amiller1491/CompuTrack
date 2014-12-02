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

namespace CompuTrackWPF
{
    /// <summary>
    /// Interaction logic for InventoryLog.xaml
    /// </summary>
    public partial class InventoryLog : Window
    {
        public InventoryLog()
        {
            InitializeComponent();
        }

        InventoryLogItem selectedLogItem = null;

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void inventoryLogListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedLogItem = inventoryLogListView.SelectedItem as InventoryLogItem;
            updateLogItem();
        }

        private void updateLogItem()
        {
            if (selectedLogItem == null)
            {
                entryBox.Text = "";
                userBox.Text = "";
                reasonBox.Text = "";
            }
            else
            {
                entryBox.Text = selectedLogItem.Entry;
                userBox.Text = selectedLogItem.MadeBy;
                reasonBox.Text = selectedLogItem.Reason;
            }
        }

    }
}
