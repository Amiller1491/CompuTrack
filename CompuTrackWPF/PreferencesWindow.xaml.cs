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
using System.Configuration;

namespace CompuTrackWPF
{
	/// <summary>
	/// Interaction logic for Preferences.xaml
	/// </summary>
	public partial class PreferencesWindow : Window
	{
		public PreferencesWindow()
		{
			this.InitializeComponent();
            if (Shared.currentUser == null) { emailGroupBox.IsEnabled = false; }
			
			// Insert code required on object creation below this point.
		}

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            String newCon;
            //http://support.microsoft.com/kb/310083
            MSDASC.DataLinks mydlg = new MSDASC.DataLinks();
            ADODB._Connection ADOcon;

            //Cast the generic object that PromptNew returns to an ADODB._Connection.
            ADOcon = (ADODB._Connection)mydlg.PromptNew();
            try
            {
                ADOcon.Open("", "", "", 0);

                if (ADOcon.State == 1)
                {
                    //MessageBox.Show("Connection Opened");
                    newCon = ADOcon.ConnectionString;
                    //MessageBox.Show("old con string: " + ConfigurationManager.ConnectionStrings["ramdbConnectionString"].ConnectionString.ToString());
                    //MessageBox.Show("newcon: " + newCon);
                    ADOcon.Close();
                    Configuration oConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    oConfig.ConnectionStrings.ConnectionStrings["ramdbConnectionString"].ConnectionString = newCon;
                    oConfig.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    //MessageBox.Show("after save:" + ConfigurationManager.ConnectionStrings["ramdbConnectionString"].ConnectionString.ToString());
                    //MessageBox.Show("saved.");
                }
                else
                {
                    MessageBox.Show("Connection Failed");
                }
            }
            catch { }
        }
        
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>



        private void test_email_button_Click(object sender, RoutedEventArgs e)
        {
            EmailCreator.sendEmail("test", "test");
        }

        private void Save_All_button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Owner_Email = emailAddressTextBox.Text;
            Properties.Settings.Default.Company_Email = Company_Email.Text;
            Properties.Settings.Default.Password = PasswordBox.Password;
            Properties.Settings.Default.smtp = SMTP_textBox.Text;
            String port_number = Port_Textbox.Text;
            Properties.Settings.Default.port = int.Parse(port_number);
            Properties.Settings.Default.SSL_Value = ssl_checkbox.IsChecked.Value;
            Properties.Settings.Default.Save();
            
        }

        public void set_text()
        {
            emailAddressTextBox.Text = Properties.Settings.Default.Owner_Email;
            Company_Email.Text = Properties.Settings.Default.Company_Email;
            PasswordBox.Password = Properties.Settings.Default.Password;
            SMTP_textBox.Text = Properties.Settings.Default.smtp;
            Port_Textbox.Text = Properties.Settings.Default.port.ToString();
            ssl_checkbox.IsChecked.Value.Equals(Properties.Settings.Default.SSL_Value); 


        }


    }
}