using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows;
using System.Net;

namespace CompuTrackWPF
{
    class EmailCreator
    {
     

        public static void sendEmail(String subject, String body)
        {
            try
            {
                //This reads from the Settings.settings file to get the current business email..
                String company_email= Properties.Settings.Default.Company_Email;
                String owner_email = Properties.Settings.Default.Owner_Email;

                MailMessage mail = new MailMessage(company_email, owner_email, subject, body);
        
               // SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                SmtpClient smtp = new SmtpClient(Properties.Settings.Default.smtp, Properties.Settings.Default.port);

                //smtp.EnableSsl = true;
                if (Properties.Settings.Default.SSL_Value == true)
                {
                    smtp.EnableSsl = true;
                }
                else
                {
                    smtp.EnableSsl = false;
                }

                //smtp.Credentials = new NetworkCredential("computrackTest@gmail.com", "computrack";)
                //smtp.Credentials = new NetworkCredential(Properties.Settings.Default.Company_Email.ToString(), "computrack");
                smtp.Credentials = new NetworkCredential(Properties.Settings.Default.Company_Email.ToString(), Properties.Settings.Default.Password);

                smtp.Send(mail);
                EmailConfirmationWindow emailWindow = new EmailConfirmationWindow("Email was succesfully sent.");
                emailWindow.ShowDialog();
                //MessageBox.Show("Email Send Confirmed");
            }

            catch (Exception MyError)
            {
                EmailConfirmationWindow emailWindow = new EmailConfirmationWindow("Error: " + MyError.Message);
                emailWindow.ShowDialog();
                //MessageBox.Show("An error has occurred: " + MyError.Message);
            }
        }


    }
}