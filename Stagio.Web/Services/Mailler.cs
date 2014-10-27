using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;


namespace Stagio.Web.Services
{
    public sealed class Mailler : IMailler
    {
        private static Mailler instance = new Mailler();

        private SmtpClient client;

        const string SERVER = "jenkinssmtp.cegep-ste-foy.qc.ca";

        static Mailler()
        {

        }
        private Mailler()
        {
            client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = SERVER;
        }

        public static Mailler Instance
        {
            get
            {
                return instance;
            }
        }

        public bool SendEmail(string destination, string subject, string content)
        {
            try
            {
                MailMessage mail = new MailMessage("noreply@" + SERVER, destination);
                mail.Subject = subject;
                mail.Body = content;

                client.Send(mail);
            }
            catch(Exception e)
            {
                return false;
            }


            return true;
        }
    }
}