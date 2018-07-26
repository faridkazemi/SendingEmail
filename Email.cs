
using System.Net.Mail;
using ClosedXML.Excel;
using Fiveways.WebApp.Helper.Intefrace;

namespace Fiveways.WebApp.Helper
{
    public class EmailHelper:IEmailHelper
    {
        public void Send(string from, string to, string subject = null, string body = null, string[] cc = null)
        {
            var email = new MailMessage(from, to, subject, body)
            {
                IsBodyHtml = true
            };
            if (cc != null)
               cc.ForEach(c => email.CC.Add(c));   
            SendEmail(email);
        }


    }

        public static void SendEmail(MailMessage mail)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 25;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Host = "smtp server host(eg. smtp.sendgrid.net)";
            smtpClient.Credentials = new NetworkCredential("userName", "password");

            smtpClient.Send(mail);
        }
}