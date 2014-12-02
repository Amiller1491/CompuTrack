using System;
using System.Collections.Generic;
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
	/// Interaction logic for EmailConfirmationWindow.xaml
	/// </summary>
	public partial class EmailConfirmationWindow : Window
	{

		public EmailConfirmationWindow(string message)
		{
			this.InitializeComponent();
			stringMessage.Text = message;
		}

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void emailConfirmationWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
	}
}