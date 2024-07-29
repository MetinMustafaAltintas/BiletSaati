using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    public static class MailService
    {
        public static void Send(string receiver, string password = "oktczfjzfohickzn", string body = "Test mesajıdır", string subject = "BiletSaati", string sender = "yzlm3170@gmail.com")
        {
            MailAddress senderEmail = new(sender);
            MailAddress receiverEmail = new(receiver);

            //Bizim Email işlemlerimiz SMTP'ye göre yapılır...

            SmtpClient smtp = new()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)

            };


            using (MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body,
            })
            {
                smtp.Send(message);
            }
        }
    }
}
