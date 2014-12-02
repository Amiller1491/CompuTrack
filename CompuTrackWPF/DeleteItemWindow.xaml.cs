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
    /// Interaction logic for DeleteItemWindow.xaml
    /// </summary>
    public partial class DeleteItemWindow : Window
    {
        public bool deleteConfirmed;

        public DeleteItemWindow()
        {            
            InitializeComponent();
        }

        private void deleteItemWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                deleteConfirmed = false;
                Close();
            }
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                deleteConfirmed = true;
                Close();
            }
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            deleteConfirmed = true;
            Close();

        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            deleteConfirmed = false;
            Close();
        }
    }
}
