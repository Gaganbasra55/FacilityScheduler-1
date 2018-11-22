using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace FacilityScheduler.Pages.Account
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonForgotPassword_Click(object sender, EventArgs e)
        {
            string email = textboxForgotPassword.Text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential("schedulerfacilities@gmail.com", "f123s456");

            Random r = new Random(986532);
            MailMessage mail = new MailMessage("schedulerfacilities@gmail.com", email, "verification code", (r.NextDouble() * 999999).ToString());
            smtp.Send(mail);
        }
    }
}