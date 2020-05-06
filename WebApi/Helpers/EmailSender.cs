using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public class EmailSender : IEmailSender
    {
        public void SendConfirmationEmain()
        {
            string to = "r.huk@outlook.com";
            string from = "testowymail341@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @"Using this new feature, you can send an email message from an application very easily.";
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new NetworkCredential("testowymail341@gmail.com", "TestMail123");
            client.EnableSsl = true;
            //client.Send(message);
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }
    }
}
