using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;


//TODO Must be moved to Stagio.Utilities
namespace Stagio.Web.Controllers
{
    public sealed class Mailler
    {
        private static Mailler instance = new Mailler();
        private SmtpClient smtp;

        const string FROM = "thomarellau@hotmail.com";
        const string PASSWORD = "LesPommesRouge2";

        static Mailler()
        {

        }
        private Mailler()
        {
            smtp = new SmtpClient("smtp.live.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(FROM, PASSWORD);
            smtp.EnableSsl = true;
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
                MailMessage message = new MailMessage(FROM, destination);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = content;

                smtp.Send(message);
            }
            catch
            {
                return false;
            }


            return true;
        }
    }
}