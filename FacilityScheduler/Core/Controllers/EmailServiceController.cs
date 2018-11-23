using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FacilityScheduler.Core.Controllers
{
    public class EmailServiceController
    {
        static string smtpAddress = "smtp.live.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFrom = "fred.bralvalex@hotmail.com";


        public static void SendEmail(String email, String code)
        {
            MailAddress to = new MailAddress(email);
            MailAddress from = new MailAddress(emailFrom);
            MailMessage message = new MailMessage(from, to);

            message.Subject = "Facility Scheduler Access code";

            //Look for the name of the user
            message.Body = createEmailBody(email, code);
            // host, port, and credentials.
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Host = smtpAddress,
                Port = portNumber,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = enableSSL,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(emailFrom, "Pit@ng01")
            };

            Console.WriteLine("Sending an email message to {0} at {1} by using the SMTP host={2}.",
                to.User, to.Host, client.Host);
            client.Send(message);
        }

        private static String createEmailBody(string name, string code)
        {
            return "<html><head><title></title></head><body><p>Dear user the code for login is: <B>" +code +"</B> <br/>" +
                "<p/><p>Please use this code within the next 30 minutes.</p></body><html>";
        }
        
    }
}