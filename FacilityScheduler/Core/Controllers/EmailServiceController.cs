using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FacilityScheduler.Core.Controllers
{
    public class EmailServiceController
    {
        /*static string smtpAddress = "smtp.live.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFrom = "fred.bralvalex@hotmail.com";
        static string emailPwd = ""Pit@ng01"";
        */
        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFrom = "schedulerfacilities@gmail.com";
        static string emailPwd = "f123s456";


        public static void SendEmail(String email, String code)
        {
            MailAddress to = new MailAddress(email);
            MailAddress from = new MailAddress(emailFrom);
            MailMessage message = new MailMessage(from, to);

            message.Subject = "Facility Scheduler Access code - " + code;

            //Look for the name of the user
            message.Body = CreateEmailBody(email, code);
            // host, port, and credentials.
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Host = smtpAddress,
                Port = portNumber,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = enableSSL,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(emailFrom, emailPwd)
            };

            Console.WriteLine("Sending an email message to {0} at {1} by using the SMTP host={2}.",
                to.User, to.Host, client.Host);
            client.Send(message);
        }

        private static String CreateEmailBody(string name, string code)
        {
            return "<html><head><title></title></head><body><p>Dear user the code for login is: <B>" +code +"</B> <br/>" +
                "<p/><p>Please use this code within the next 30 minutes.</p></body><html>";
        }

        public static void SendEmailAccessCode(String email, String code)
        {
            MailAddress to = new MailAddress(email);
            MailAddress from = new MailAddress(emailFrom);
            MailMessage message = new MailMessage(from, to);

            message.Subject = "Facility Scheduler Access code - " + code;

            //Look for the name of the user
            message.Body = CreateEmailBodyAccessCode(email, code);
            // host, port, and credentials.
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Host = smtpAddress,
                Port = portNumber,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = enableSSL,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(emailFrom, emailPwd)
            };

            Console.WriteLine("Sending an email message to {0} at {1} by using the SMTP host={2}.",
                to.User, to.Host, client.Host);
            client.Send(message);
        }

        private static String CreateEmailBodyAccessCode(string name, string code)
        {
            return "<html><head><title></title></head><body><p>Dear user the code for Access the facility is: <B>" +code +"</B> <br/>" +
                "<p/></body><html>";
        }
        
    }
}