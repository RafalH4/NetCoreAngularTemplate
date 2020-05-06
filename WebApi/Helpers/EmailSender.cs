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
        public void SendConfirmationEmain(string firstName, string secondName, string email, Guid id)
        {
            string to = email;
            string from = "testowymail341@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @$"Dzień dobry {firstName} {secondName}</p>
                            Dziękujemy za założenie konta. Kod aktywacyjny: {id}";
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new NetworkCredential("testowymail341@gmail.com", "TestMail123");
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
