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
	/// Interaction logic for FrontDeskWindow.xaml
	/// </summary>
	public partial class FrontDeskWindow : Window
	{
		public FrontDeskWindow()
		{
			this.InitializeComponent();
            userLabel.Content = "Logged in as: " + Shared.currentUser._userName;
		}

        private void newCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow cw = new CustomerWindow();
            cw.Owner = this.Owner;
            cw.Show();
        }

        private void newTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            TicketWindow tw = new TicketWindow();
            tw.Owner = this.Owner;
            tw.Show();
        }

        bool passwordCanvasShown;
        private void fullViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (passwordCanvasShown == false)
            {
                passwordCanvas.Visibility = Visibility.Visible;
                passwordBox.Focus();
                passwordCanvasShown = true;
            }
            else
            {
                passwordCanvas.Visibility = Visibility.Hidden;
                passwordCanvasShown = false;
            }
        }

        private void submitPassword()
        {
            if (Shared.currentUser._password == passwordBox.Password)
            {
                this.Close();
                Owner.Show();
            }
            else
            {
                messageLabel.Content = "Incorrect password.";
            }
        }

        private void passwordSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            submitPassword();
        }

        private void OnEnterKey(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return && e.Key != Key.Enter)
                return;
            e.Handled = true;
            submitPassword();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Owner.Close();
            this.Close();
        }

        private void mouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
	}
}